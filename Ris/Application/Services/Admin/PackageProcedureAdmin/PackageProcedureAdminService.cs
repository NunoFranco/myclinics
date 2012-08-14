#region License

// Copyright (c) 2009, ClearCanvas Inc.
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
using System.Security.Permissions;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.PackageProcedureAdmin;
using AuthorityTokens=ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services.Admin.PackageProcedureAdmin
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IPackageProcedureAdminService))]
    public class PackageProcedureAdminService : ApplicationServiceBase, IPackageProcedureAdminService
    {
        #region IPackageProcedureAdminService Members

        [ReadOperation]
        public GetPackageProcedureEditFormDataResponse GetPackageProcedureEditFormData(
            GetPackageProcedureEditFormDataRequest request)
        {
            GetPackageProcedureEditFormDataResponse response = new GetPackageProcedureEditFormDataResponse();
            PackageProcedureAssembler ptgAssembler = new PackageProcedureAssembler();
           
            // ProcedureType choices
            ProcedureTypeAssembler assembler = new ProcedureTypeAssembler();
            response.ProcedureTypes = CollectionUtils.Map<ProcedureType, ProcedureTypeSummary>(
				PersistenceContext.GetBroker<IProcedureTypeBroker>().FindAll(false),
                delegate(ProcedureType rpt)
                {
                    return assembler.CreateSummary(rpt);
                });

            return response;
        }

        //[ReadOperation]
        //public GetPackageProcedureSummaryFormDataResponse GetPackageProcedureSummaryFormData(GetPackageProcedureSummaryFormDataRequest request)
        //{
        //    PackageProcedureAssembler ptgAssembler = new PackageProcedureAssembler();
			

        //    // Category choices
        //    return new GetPackageProcedureSummaryFormDataResponse(
        //        CollectionUtils.Map<Type, EnumValueInfo>(subClasses,
        //            delegate(Type t)
        //            {
        //                return ptgAssembler.GetCategoryEnumValueInfo(t);
        //            }));
        //}

        [ReadOperation]
        public ListPackageProceduresResponse ListPackageProcedures(
            ListPackageProceduresRequest request)
        {
            ListPackageProceduresResponse response = new ListPackageProceduresResponse();
            PackageProcedureAssembler assembler = new PackageProcedureAssembler();

			PackageProcedureSearchCriteria criteria = new PackageProcedureSearchCriteria();
			criteria.Code .SortAsc(0);
            IList<PackageProcedure> result = PersistenceContext.GetBroker<IPackageProcedureBroker>().Find(criteria, request.Page);

			response.Items = CollectionUtils.Map<PackageProcedure, PackageProcedureSummary, List<PackageProcedureSummary>>(result,
                delegate(PackageProcedure rptGroup)
                {
                    return assembler.GetPackageProcedureSummary(rptGroup, this.PersistenceContext);
                });

            return response;
        }

        [ReadOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.PackageProcedure)]
        public LoadPackageProcedureForEditResponse LoadPackageProcedureForEdit(
            LoadPackageProcedureForEditRequest request)
        {
            PackageProcedure rptGroup = PersistenceContext.GetBroker<IPackageProcedureBroker>().Load(request.EntityRef);
            PackageProcedureAssembler assembler = new PackageProcedureAssembler();
            PackageProcedureDetail detail = assembler.GetPackageProcedureDetail(rptGroup, this.PersistenceContext);
            return new LoadPackageProcedureForEditResponse(rptGroup.GetRef(), detail);
        }

        [UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.PackageProcedure)]
		public AddPackageProcedureResponse AddPackageProcedure(
            AddPackageProcedureRequest request)
        {
            if (string.IsNullOrEmpty(request.Detail.Name))
            {
                throw new RequestValidationException(SR.ExceptionPackageProcedureNameRequired);
            }

            // create appropriate class of group
            PackageProcedure group = new PackageProcedure();
            PackageProcedureAssembler assembler = new PackageProcedureAssembler();
            assembler.UpdatePackageProcedure(group, request.Detail, this.PersistenceContext);

            PersistenceContext.Lock(group, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddPackageProcedureResponse(
                assembler.GetPackageProcedureSummary(group, this.PersistenceContext));
        }

        [UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.PackageProcedure)]
		public UpdatePackageProcedureResponse UpdatePackageProcedure(
            UpdatePackageProcedureRequest request)
        {
            PackageProcedure group = PersistenceContext.Load<PackageProcedure>(request.EntityRef, EntityLoadFlags.CheckVersion);
            PackageProcedureAssembler assembler = new PackageProcedureAssembler();
            assembler.UpdatePackageProcedure(group, request.Detail, this.PersistenceContext);

            return new UpdatePackageProcedureResponse(
                assembler.GetPackageProcedureSummary(group, this.PersistenceContext));
        }

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.PackageProcedure)]
		public DeletePackageProcedureResponse DeletePackageProcedure(DeletePackageProcedureRequest request)
		{
			try
			{
				IPackageProcedureBroker broker = PersistenceContext.GetBroker<IPackageProcedureBroker>();
				PackageProcedure item = broker.Load(request.PackageProcedureRef, EntityLoadFlags.Proxy);
				broker.Delete(item);
				PersistenceContext.SynchState();
				return new DeletePackageProcedureResponse();
			}
			catch (PersistenceException)
			{
				throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(PackageProcedure))));
			}
		}

		#endregion
    }
}
