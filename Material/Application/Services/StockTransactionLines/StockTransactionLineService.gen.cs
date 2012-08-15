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
using ClearCanvas.Material.Application.Common.StockTransactionLines;
using AuthorityTokens = ClearCanvas.Material.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;

namespace ClearCanvas.Material.Application.Services.StockTransactionLines
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IStockTransactionLineService))]
    public partial class StockTransactionLineService : ApplicationServiceBase, IStockTransactionLineService
    {
        #region IStockTransactionLineService Members

		
		
        [ReadOperation]
        public ListStockTransactionLinesResponse ListStockTransactionLines(ListStockTransactionLinesRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            StockTransactionLineSearchCriteria where = new StockTransactionLineSearchCriteria();
            //where.Id.SortAsc(0);
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            IStockTransactionLineBroker broker = PersistenceContext.GetBroker<IStockTransactionLineBroker>();
            IList<StockTransactionLine> items = broker.Find(where, request.Page);

            StockTransactionLineAssembler assembler = new StockTransactionLineAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListStockTransactionLinesResponse(
                CollectionUtils.Map<StockTransactionLine, StockTransactionLineSummary>(items,
                    delegate(StockTransactionLine item)
                    {
                        return assembler.CreateSummary(item, this.PersistenceContext);
                    })
                );
         
        }

        [ReadOperation]
        public LoadStockTransactionLineForEditResponse LoadStockTransactionLineForEdit(LoadStockTransactionLineForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            StockTransactionLine item = PersistenceContext.Load<StockTransactionLine>(request.objRef);

            StockTransactionLineAssembler assembler = new StockTransactionLineAssembler();
            return new LoadStockTransactionLineForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        /*[ReadOperation]
        public LoadStockTransactionLineEditorFormDataResponse LoadStockTransactionLineEditorFormData(LoadStockTransactionLineEditorFormDataRequest request)
        {
            StockTransactionLineSearchCriteria where = new StockTransactionLineSearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<StockTransactionLine> items = PersistenceContext.GetBroker<IStockTransactionLineBroker>().Find(where);
            
            StockTransactionLineAssembler assembler = new StockTransactionLineAssembler();
            List<StockTransactionLineSummary> baseChoices = CollectionUtils.Map<StockTransactionLine, StockTransactionLineSummary>(items,
                   delegate(StockTransactionLine pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new LoadStockTransactionLineEditorFormDataResponse(baseTypeChoices);
        }*/

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.StockTransactionLine)]
        public AddStockTransactionLineResponse AddStockTransactionLine(AddStockTransactionLineRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            StockTransactionLine item = new StockTransactionLine();

            StockTransactionLineAssembler assembler = new StockTransactionLineAssembler();
            assembler.UpdateStockTransactionLine(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddStockTransactionLineResponse(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.StockTransactionLine)]
        public UpdateStockTransactionLineResponse UpdateStockTransactionLine(UpdateStockTransactionLineRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.StockTransactionLineRef, "request.objDetail.StockTransactionLineRef");


            StockTransactionLine item = PersistenceContext.Load<StockTransactionLine>(request.objDetail.StockTransactionLineRef);

            StockTransactionLineAssembler assembler = new StockTransactionLineAssembler();
            assembler.UpdateStockTransactionLine(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateStockTransactionLineResponse(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.StockTransactionLine)]
        public DeleteStockTransactionLineResponse DeleteStockTransactionLine(DeleteStockTransactionLineRequest request)
        {
            try
            {
                IStockTransactionLineBroker broker = PersistenceContext.GetBroker<IStockTransactionLineBroker>();
                StockTransactionLine item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteStockTransactionLineResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(StockTransactionLine))));
            }
        }

        #endregion
    }
}
