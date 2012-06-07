#region License

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

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.DoctorPrescription;
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services.DoctorPrescription
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IDoctorPrescriptionService))]
    public class DoctorPrescriptionService : ApplicationServiceBase, IDoctorPrescriptionService
    {
        #region IDoctorPrescriptionService Members

        [ReadOperation]
        public TextQueryResponse<DoctorPrescriptionSummary> TextQuery(TextQueryRequest request)
        {
            IDoctorPrescriptionBroker broker = PersistenceContext.GetBroker<IDoctorPrescriptionBroker>();
            DoctorPrescriptionAssembler assembler = new DoctorPrescriptionAssembler();

            TextQueryHelper<Healthcare.DoctorPrescription, DoctorPrescriptionSearchCriteria, DoctorPrescriptionSummary> helper
                = new TextQueryHelper<Healthcare.DoctorPrescription, DoctorPrescriptionSearchCriteria, DoctorPrescriptionSummary>(
                    delegate
                    {
                        string rawQuery = request.TextQuery;

                        IList<string> terms = TextQueryHelper.ParseTerms(rawQuery);
                        List<DoctorPrescriptionSearchCriteria> criteria = new List<DoctorPrescriptionSearchCriteria>();

                        // allow matching on name (assume entire query is a name which may contain spaces)
                        DoctorPrescriptionSearchCriteria nameCriteria = new DoctorPrescriptionSearchCriteria();
                        nameCriteria.Name.StartsWith(rawQuery);
                        criteria.Add(nameCriteria);

                        // allow matching of any term against ID
                        criteria.AddRange(CollectionUtils.Map<string, DoctorPrescriptionSearchCriteria>(terms,
                                     delegate(string term)
                                     {
                                         DoctorPrescriptionSearchCriteria c = new DoctorPrescriptionSearchCriteria();
                                         c.Name.StartsWith(term);
                                         return c;
                                     }));

                        return criteria.ToArray();
                    },
                    delegate(Healthcare.DoctorPrescription pt)
                    {
                        return assembler.CreateSummary(pt);
                    },
                    delegate(DoctorPrescriptionSearchCriteria[] criteria, int threshold)
                    {
                        return broker.Count(criteria) <= threshold;
                    },
                    delegate(DoctorPrescriptionSearchCriteria[] criteria, SearchResultPage page)
                    {
                        return broker.Find(criteria, page);
                    });

            return helper.Query(request);
        }

        [ReadOperation]
        public ListDoctorPrescriptionsResponse ListDoctorPrescriptions(ListDoctorPrescriptionsRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            DoctorPrescriptionSearchCriteria where = new DoctorPrescriptionSearchCriteria();
            where.Name.SortAsc(0);
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));

            var items = PersistenceContext.GetBroker<IDoctorPrescriptionBroker>().Find(where);

            DoctorPrescriptionAssembler assembler = new DoctorPrescriptionAssembler();
            //if request to get detail the return detail ortherwise return summary

            return new ListDoctorPrescriptionsResponse(
                CollectionUtils.Map<Healthcare.DoctorPrescription, DoctorPrescriptionSummary>(items,
                    delegate(Healthcare.DoctorPrescription item)
                    {
                        return assembler.CreateSummary(item);
                    })
                );

        }

        [ReadOperation]
        public LoadDoctorPrescriptionForEditResponse LoadDoctorPrescriptionForEdit(LoadDoctorPrescriptionForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.DoctorPrescriptionRef, "request.DoctorPrescriptionRef");

            Healthcare.DoctorPrescription item = PersistenceContext.Load<Healthcare.DoctorPrescription>(request.DoctorPrescriptionRef);

            DoctorPrescriptionAssembler assembler = new DoctorPrescriptionAssembler();
            return new LoadDoctorPrescriptionForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        [ReadOperation]
        public LoadDoctorPrescriptionEditorFormDataResponse LoadDoctorPrescriptionEditorFormData(LoadDoctorPrescriptionEditorFormDataRequest request)
        {
            DoctorPrescriptionSearchCriteria where = new DoctorPrescriptionSearchCriteria();
            where.Name.SortAsc(0);
            where.Deactivated.EqualTo(false);

            ProcedureTypeSearchCriteria criteria =new ProcedureTypeSearchCriteria();
            criteria.Category.EqualTo(EnumUtils.GetEnumValue<ProcedureTypeCategoryEnum>(Healthcare.ProcedureTypeCategory.ME,PersistenceContext ));
            criteria.Deactivated.EqualTo(false);
            IList<ProcedureType> procTypes = PersistenceContext.GetBroker<IProcedureTypeBroker>().Find(criteria);
          ProcedureTypeAssembler assembler = new ProcedureTypeAssembler();
            return new LoadDoctorPrescriptionEditorFormDataResponse(CollectionUtils.Map<ProcedureType,ProcedureTypeSummary>(procTypes,p=>assembler.CreateSummary(p,null )));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.DoctorPrescription)]
        public AddDoctorPrescriptionResponse AddDoctorPrescription(AddDoctorPrescriptionRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.DoctorPrescription, "request.DoctorPrescription");



            Healthcare.DoctorPrescription item = new Healthcare.DoctorPrescription();

            DoctorPrescriptionAssembler assembler = new DoctorPrescriptionAssembler();
            assembler.UpdateDoctorPrescription(item, request.DoctorPrescription, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddDoctorPrescriptionResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.DoctorPrescription)]
        public UpdateDoctorPrescriptionResponse UpdateDoctorPrescription(UpdateDoctorPrescriptionRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.DoctorPrescription, "request.DoctorPrescription");
            Platform.CheckMemberIsSet(request.DoctorPrescription.DoctorPrescriptionRef, "request.DoctorPrescription.DoctorPrescriptionRef");


            Healthcare.DoctorPrescription item = PersistenceContext.Load<Healthcare.DoctorPrescription>(request.DoctorPrescription.DoctorPrescriptionRef);

            DoctorPrescriptionAssembler assembler = new DoctorPrescriptionAssembler();
            assembler.UpdateDoctorPrescription(item, request.DoctorPrescription, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateDoctorPrescriptionResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.DoctorPrescription)]
        public DeleteDoctorPrescriptionResponse DeleteDoctorPrescription(DeleteDoctorPrescriptionRequest request)
        {
            try
            {
                IDoctorPrescriptionBroker broker = PersistenceContext.GetBroker<IDoctorPrescriptionBroker>();
                Healthcare.DoctorPrescription item = broker.Load(request.DoctorPrescriptionRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteDoctorPrescriptionResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(Healthcare.DoctorPrescription))));
            }
        }

        #endregion
    }
}
