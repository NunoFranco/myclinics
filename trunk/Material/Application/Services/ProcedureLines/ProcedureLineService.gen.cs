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
using ClearCanvas.Material.Healthcare;
using ClearCanvas.Material.Healthcare.Brokers;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Material.Application.Common;
using ClearCanvas.Material.Application.Common.ProcedureLines;
using AuthorityTokens = ClearCanvas.Material.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;
namespace ClearCanvas.Material.Application.Services.ProcedureLines
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IProcedureLineService))]
    public partial class ProcedureLineService : ApplicationServiceBase, IProcedureLineService
    {
        #region IProcedureLineService Members

		
		
        [ReadOperation]
        public ListProcedureLinesResponse ListProcedureLines(ListProcedureLinesRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            ProcedureLineSearchCriteria where = new ProcedureLineSearchCriteria();
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            IProcedureLineBroker broker = PersistenceContext.GetBroker<IProcedureLineBroker>();
            IList<ProcedureLine> items = broker.Find(where, request.Page);

            ProcedureLineAssembler assembler = new ProcedureLineAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListProcedureLinesResponse(
                CollectionUtils.Map<ProcedureLine, ProcedureLineSummary>(items,
                    delegate(ProcedureLine item)
                    {
                        return assembler.CreateSummary(item,PersistenceContext );
                    })
                );
         
        }

        [ReadOperation]
        public LoadProcedureLineForEditResponse LoadProcedureLineForEdit(LoadProcedureLineForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            ProcedureLine item = PersistenceContext.Load<ProcedureLine>(request.objRef);

            ProcedureLineAssembler assembler = new ProcedureLineAssembler();
            return new LoadProcedureLineForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        /*[ReadOperation]
        public LoadProcedureLineEditorFormDataResponse LoadProcedureLineEditorFormData(LoadProcedureLineEditorFormDataRequest request)
        {
            ProcedureLineSearchCriteria where = new ProcedureLineSearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<ProcedureLine> items = PersistenceContext.GetBroker<IProcedureLineBroker>().Find(where);
            
            ProcedureLineAssembler assembler = new ProcedureLineAssembler();
            List<ProcedureLineSummary> baseChoices = CollectionUtils.Map<ProcedureLine, ProcedureLineSummary>(items,
                   delegate(ProcedureLine pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new LoadProcedureLineEditorFormDataResponse(baseTypeChoices);
        }*/

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.ProcedureLine)]
        public AddProcedureLineResponse AddProcedureLine(AddProcedureLineRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            ProcedureLine item = new ProcedureLine();

            ProcedureLineAssembler assembler = new ProcedureLineAssembler();
            assembler.UpdateProcedureLine(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddProcedureLineResponse(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.ProcedureLine)]
        public UpdateProcedureLineResponse UpdateProcedureLine(UpdateProcedureLineRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.ProcedureLineRef, "request.objDetail.ProcedureLineRef");


            ProcedureLine item = PersistenceContext.Load<ProcedureLine>(request.objDetail.ProcedureLineRef);

            ProcedureLineAssembler assembler = new ProcedureLineAssembler();
            assembler.UpdateProcedureLine(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateProcedureLineResponse(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.ProcedureLine)]
        public DeleteProcedureLineResponse DeleteProcedureLine(DeleteProcedureLineRequest request)
        {
            try
            {
                IProcedureLineBroker broker = PersistenceContext.GetBroker<IProcedureLineBroker>();
                ProcedureLine item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteProcedureLineResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(ProcedureLine))));
            }
        }

        #endregion
    }
}
