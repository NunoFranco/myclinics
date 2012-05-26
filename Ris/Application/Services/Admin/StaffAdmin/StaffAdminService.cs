﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.StaffAdmin;
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services.Admin.StaffAdmin
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IStaffAdminService))]
    public class StaffAdminService : ApplicationServiceBase, IStaffAdminService
    {
        #region IStaffAdminService Members

        [ReadOperation]
        // note: this operation is not protected with ClearCanvas.Ris.Application.Common.AuthorityTokens.StaffAdmin
        // because it is used in non-admin situations - perhaps we need to create a separate operation???
        public ListStaffResponse ListStaff(ListStaffRequest request)
        {

            var assembler = new StaffAssembler();
            Facility CurrentClinic = PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef);
            FacilityAssembler FAssembler = new FacilityAssembler();
            var criteria = new StaffSearchCriteria();
            criteria.Name.FamilyName.SortAsc(0);

            if (!string.IsNullOrEmpty(request.StaffID))
                ApplyCondition(criteria.Id, request.StaffID, request.ExactMatch);

            if (!string.IsNullOrEmpty(request.GivenName))
                ApplyCondition(criteria.Name.GivenName, request.GivenName, request.ExactMatch);

            if (!string.IsNullOrEmpty(request.FamilyName))
                ApplyCondition(criteria.Name.FamilyName, request.FamilyName, request.ExactMatch);

            if (!string.IsNullOrEmpty(request.UserName))
                criteria.UserName.EqualTo(request.UserName);

            if (!request.IncludeDeactivated)
                criteria.Deactivated.EqualTo(false);

            ApplyStaffTypesFilter(request.StaffTypesFilter, new[] { criteria }, FAssembler.CreateFacilitySummary(CurrentClinic));

            return new ListStaffResponse(
                CollectionUtils.Map<Staff, StaffSummary, List<StaffSummary>>(
                    PersistenceContext.GetBroker<IStaffBroker>().Find(criteria, request.Page),
                    s => assembler.CreateStaffSummary(s)));
        }

        private static void ApplyCondition(ISearchCondition<string> condition, string value, bool exactMatch)
        {
            if (exactMatch)
                condition.EqualTo(value);
            else
                condition.StartsWith(value);
        }

        [ReadOperation]
        public LoadStaffForEditResponse LoadStaffForEdit(LoadStaffForEditRequest request)
        {
            var s = PersistenceContext.Load<Staff>(request.StaffRef);

            // ensure user has access to edit this staff
            CheckReadAccess(s);

            var assembler = new StaffAssembler();
            return new LoadStaffForEditResponse(assembler.CreateStaffDetail(s, null, this.PersistenceContext));
        }

        [ReadOperation]
        public LoadStaffEditorFormDataResponse LoadStaffEditorFormData(LoadStaffEditorFormDataRequest request)
        {
            var groupAssember = new StaffGroupAssembler();
            var fAssember = new FacilityAssembler();
            return new LoadStaffEditorFormDataResponse(
                EnumUtils.GetEnumValueList<StaffTypeEnum>(this.PersistenceContext),
                EnumUtils.GetEnumValueList<SexEnum>(this.PersistenceContext),
                (new SimplifiedPhoneTypeAssembler()).GetPatientPhoneTypeChoices(),
                EnumUtils.GetEnumValueList<AddressTypeEnum>(PersistenceContext),
                CollectionUtils.Map(PersistenceContext.GetBroker<IStaffGroupBroker>().FindAll(false),
                                    (StaffGroup group) => groupAssember.CreateSummary(group)),
                CollectionUtils.Map(PersistenceContext.GetBroker<IFacilityBroker>().FindAll(false),
                                    (Facility f) => fAssember.CreateFacilitySummary(f))
                );
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Staff)]
        public AddStaffResponse AddStaff(AddStaffRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.StaffDetail, "StaffDetail");

            // if trying to associate with a user account, check the account is free
            if (!string.IsNullOrEmpty(request.StaffDetail.UserName))
            {
                ValidateUserNameFree(request.StaffDetail.UserName);
            }

            // create new staff
            var staff = new Staff();

            // set properties from request
            var assembler = new StaffAssembler();

            var groupsEditable = Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Admin.Data.StaffGroup);
            assembler.UpdateStaff(request.StaffDetail,
                staff,
                groupsEditable,
                groupsEditable,
                PersistenceContext);

            PersistenceContext.Lock(staff, DirtyState.New);

            // ensure the new staff is assigned an OID before using it in the return value
            PersistenceContext.SynchState();

            return new AddStaffResponse(assembler.CreateStaffSummary(staff));
        }

        [UpdateOperation]
        public UpdateStaffResponse UpdateStaff(UpdateStaffRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.StaffDetail, "StaffDetail");

            var staff = PersistenceContext.Load<Staff>(request.StaffDetail.StaffRef);

            // ensure user has access to edit this staff
            CheckWriteAccess(staff);

            // if trying to associate with a new user account, check the account is free
            if (!string.IsNullOrEmpty(request.StaffDetail.UserName) && request.StaffDetail.UserName != staff.UserName)
            {
                ValidateUserNameFree(request.StaffDetail.UserName);
            }

            var assembler = new StaffAssembler();
            assembler.UpdateStaff(request.StaffDetail,
                staff,
                request.UpdateElectiveGroups && (Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Admin.Data.StaffGroup) || staff.UserName == this.CurrentUser),
                request.UpdateNonElectiveGroups && Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Admin.Data.StaffGroup),
                PersistenceContext);

            return new UpdateStaffResponse(assembler.CreateStaffSummary(staff));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Staff)]
        public DeleteStaffResponse DeleteStaff(DeleteStaffRequest request)
        {
            try
            {
                var broker = PersistenceContext.GetBroker<IStaffBroker>();
                var item = broker.Load(request.StaffRef, EntityLoadFlags.Proxy);

                //bug #3324: because StaffGroup owns the collection, need to iterate over each group
                //and manually remove this staff
                var groups = new List<StaffGroup>(item.Groups);
                foreach (var group in groups)
                {
                    group.RemoveMember(item);
                }

                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteStaffResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(Staff))));
            }
        }

        [ReadOperation]
        public TextQueryResponse<StaffSummary> TextQuery(StaffTextQueryRequest request)
        {
            var broker = PersistenceContext.GetBroker<IStaffBroker>();
            var assembler = new StaffAssembler();
            Facility CurrentClinic = PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef);
            FacilityAssembler FAssembler = new FacilityAssembler();
            var helper = new TextQueryHelper<Staff, StaffSearchCriteria, StaffSummary>(
                    delegate
                    {
                        var rawQuery = request.TextQuery;

                        // this will hold all criteria
                        var criteria = new List<StaffSearchCriteria>();

                        // build criteria against names
                        var names = TextQueryHelper.ParsePersonNames(rawQuery);
                        criteria.AddRange(CollectionUtils.Map(names,
                            (PersonName n) =>
                            {
                                var sc = new StaffSearchCriteria();
                                sc.Name.FamilyName.StartsWith(n.FamilyName);
                                if (n.GivenName != null)
                                    sc.Name.GivenName.StartsWith(n.GivenName);
                                return sc;
                            }));

                        // build criteria against identifiers
                        var ids = TextQueryHelper.ParseIdentifiers(rawQuery);
                        criteria.AddRange(CollectionUtils.Map(ids,
                                     (string word) =>
                                     {
                                         var c = new StaffSearchCriteria();
                                         c.Id.StartsWith(word);
                                         return c;
                                     }));


                        ApplyStaffTypesFilter(request.StaffTypesFilter, criteria, FAssembler.CreateFacilitySummary(CurrentClinic));

                        return criteria.ToArray();
                    },
                    staff => assembler.CreateStaffSummary(staff),
                    (criteria, threshold) => broker.Count(criteria) <= threshold,
                    broker.Find);

            return helper.Query(request);
        }

        #endregion

        /// <summary>
        /// Throws an exception if the current user does not have access to edit specified staff.
        /// </summary>
        /// <param name="staff"></param>
        private void CheckReadAccess(Staff staff)
        {
            // users with Admin.Data.Staff token can access any staff
            if (Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Admin.Data.Staff))
                return;

            // users can access their own staff profile
            if (staff.UserName == this.CurrentUser)
                return;

            throw new System.Security.SecurityException(SR.ExceptionUserNotAuthorized);
        }

        /// <summary>
        /// Throws an exception if the current user does not have access to edit specified staff.
        /// </summary>
        /// <param name="staff"></param>
        private void CheckWriteAccess(Staff staff)
        {
            // users with Admin.Data.Staff token can access any staff
            if (Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Admin.Data.Staff))
                return;

            // users can update their own staff profile with the Update token
            if (staff.UserName == this.CurrentUser && Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Workflow.StaffProfile.Update))
                return;

            throw new System.Security.SecurityException(SR.ExceptionUserNotAuthorized);
        }

        /// <summary>
        /// Applies the specified staff types filter to the specified set of criteria objects.
        /// </summary>
        /// <param name="staffTypesFilter"></param>
        /// <param name="criteria"></param>
        private void ApplyStaffTypesFilter(IEnumerable<string> staffTypesFilter, IEnumerable<StaffSearchCriteria> criteria, FacilitySummary clinic)
        {
            var broker = PersistenceContext.GetBroker<IEnumBroker>();
            if (staffTypesFilter != null)
            {
                // parse strings into StaffType 
                var typeFilters = CollectionUtils.Map(staffTypesFilter, (string t) => broker.Find<StaffTypeEnum>(t, clinic.OID));

                if (typeFilters.Count > 0)
                {
                    // apply type filter to each criteria object
                    foreach (var criterion in criteria)
                    {
                        criterion.Type.In(typeFilters);
                    }
                }
            }
        }

        private void ValidateUserNameFree(string userName)
        {
            var staffBroker = PersistenceContext.GetBroker<IStaffBroker>();
            try
            {
                var where = new StaffSearchCriteria();
                where.UserName.EqualTo(userName);
                var existing = staffBroker.FindOne(where);
                if (existing != null)
                    throw new RequestValidationException(
                        string.Format("Staff cannot be associated with user {0} because this user is already associated to staff {1}",
                            userName, existing.Name));
            }
            catch (EntityNotFoundException)
            {
                // no previously associated staff
            }
        }
    }
}
