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
using ClearCanvas.Ris.Application.Common.DiagnosticResult;
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services.DiagnosticResult
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IDiagnosticResultService))]
    public class DiagnosticResultService : ApplicationServiceBase, IDiagnosticResultService
    {
        #region IDiagnosticResultService Members

        [ReadOperation]
        public ListDiagnosticResultsResponse ListDiagnosticResults(ListDiagnosticResultsRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            DiagnosticResultSearchCriteria where = new DiagnosticResultSearchCriteria();
            where.Id.SortAsc(0);
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            IDiagnosticResultBroker broker = PersistenceContext.GetBroker<IDiagnosticResultBroker>();
            IList<DiagnosticResult> items = broker.Find(where, request.Page);

            DiagnosticResultAssembler assembler = new DiagnosticResultAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListDiagnosticResultsResponse(
                CollectionUtils.Map<DiagnosticResult, DiagnosticResultSummary>(items,
                    delegate(DiagnosticResult item)
                    {
                        return assembler.CreateSummary(item, this.PersistenceContext);
                    })
                );
         
        }

        [ReadOperation]
        public LoadDiagnosticResultForEditResponse LoadDiagnosticResultForEdit(LoadDiagnosticResultForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            DiagnosticResult item = PersistenceContext.Load<DiagnosticResult>(request.objRef);

            DiagnosticResultAssembler assembler = new DiagnosticResultAssembler();
            return new LoadDiagnosticResultForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        [ReadOperation]
        public LoadDiagnosticResultEditorFormDataResponse LoadDiagnosticResultEditorFormData(LoadDiagnosticResultEditorFormDataRequest request)
        {
            DiagnosticResultSearchCriteria where = new DiagnosticResultSearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<DiagnosticResult> items = PersistenceContext.GetBroker<IDiagnosticResultBroker>().Find(where);
            
            DiagnosticResultAssembler assembler = new DiagnosticResultAssembler();
            List<DiagnosticResultSummary> baseChoices = CollectionUtils.Map<DiagnosticResult, DiagnosticResultSummary>(items,
                   delegate(DiagnosticResult pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new LoadDiagnosticResultEditorFormDataResponse(baseTypeChoices);
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.DiagnosticResult)]
        public AddDiagnosticResultResponse AddDiagnosticResult(AddDiagnosticResultRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            DiagnosticResult item = new DiagnosticResult();

            DiagnosticResultAssembler assembler = new DiagnosticResultAssembler();
            assembler.UpdateDiagnosticResult(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddDiagnosticResultResponse(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.DiagnosticResult)]
        public UpdateDiagnosticResultResponse UpdateDiagnosticResult(UpdateDiagnosticResultRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.DiagnosticResultRef, "request.objDetail.DiagnosticResultRef");


            DiagnosticResult item = PersistenceContext.Load<DiagnosticResult>(request.objDetail.DiagnosticResultRef);

            DiagnosticResultAssembler assembler = new DiagnosticResultAssembler();
            assembler.UpdateDiagnosticResult(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateDiagnosticResultResponse(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.DiagnosticResult)]
        public DeleteDiagnosticResultResponse DeleteDiagnosticResult(DeleteDiagnosticResultRequest request)
        {
            try
            {
                IDiagnosticResultBroker broker = PersistenceContext.GetBroker<IDiagnosticResultBroker>();
                DiagnosticResult item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteDiagnosticResultResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(DiagnosticResult))));
            }
        }

        #endregion
    }
}
