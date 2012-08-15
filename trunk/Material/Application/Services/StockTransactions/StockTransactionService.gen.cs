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
using ClearCanvas.Material.Application.Common.StockTransactions;
using AuthorityTokens = ClearCanvas.Material.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Healthcare;
using System.ServiceModel;
namespace ClearCanvas.Material.Application.Services.StockTransactions
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IStockTransactionService))]
    [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)] 
    public partial class StockTransactionService : ApplicationServiceBase, IStockTransactionService
    {
        #region IStockTransactionService Members

		
		
        [ReadOperation]
        public ListStockTransactionsResponse ListStockTransactions(ListStockTransactionsRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            StockTransactionSearchCriteria where = new StockTransactionSearchCriteria();
           
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            IStockTransactionBroker broker = PersistenceContext.GetBroker<IStockTransactionBroker>();
            IList<StockTransaction> items = broker.Find(where, request.Page);

            StockTransactionAssembler assembler = new StockTransactionAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListStockTransactionsResponse(
                CollectionUtils.Map<StockTransaction, StockTransactionSummary>(items,
                    delegate(StockTransaction item)
                    {
                        return assembler.CreateSummary(item,PersistenceContext );
                    })
                );
         
        }

        [ReadOperation]
        public LoadStockTransactionForEditResponse LoadStockTransactionForEdit(LoadStockTransactionForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            StockTransaction item = PersistenceContext.Load<StockTransaction>(request.objRef);

            StockTransactionAssembler assembler = new StockTransactionAssembler();
            return new LoadStockTransactionForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        [ReadOperation]
        public LoadStockTransactionEditFormDataResponse LoadStockTransactionEditorFormData(LoadStockTransactionEditFormDataRequest request)
        {
            ProcedureTypeSearchCriteria where = new ProcedureTypeSearchCriteria();
            where.Category.In(
                    CollectionUtils.Map<EnumValueInfo , ProcedureTypeCategoryEnum >(request.MaterialCategories,
                    delegate(EnumValueInfo cate)
                    {
                        return EnumUtils.GetEnumValue <ProcedureTypeCategoryEnum>(cate,PersistenceContext);
                    })
                );
            where.Deactivated.EqualTo(false);
            IList<ProcedureType> items = PersistenceContext.GetBroker<IProcedureTypeBroker>().Find(where);

            ProcedureTypeAssembler assembler = new ProcedureTypeAssembler();
            List<ProcedureTypeSummary> baseChoices = CollectionUtils.Map<ProcedureType, ProcedureTypeSummary>(items,
                   delegate(ProcedureType pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });


            return new LoadStockTransactionEditFormDataResponse(baseChoices);
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.StockTransaction)]
        public AddStockTransactionResponse AddStockTransaction(AddStockTransactionRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            StockTransaction item = new StockTransaction();

            StockTransactionAssembler assembler = new StockTransactionAssembler();
            assembler.UpdateStockTransaction(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddStockTransactionResponse(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.StockTransaction)]
        public UpdateStockTransactionResponse UpdateStockTransaction(UpdateStockTransactionRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.StockTransactionRef, "request.objDetail.StockTransactionRef");


            StockTransaction item = PersistenceContext.Load<StockTransaction>(request.objDetail.StockTransactionRef);

            StockTransactionAssembler assembler = new StockTransactionAssembler();
            assembler.UpdateStockTransaction(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateStockTransactionResponse(assembler.CreateSummary(item,PersistenceContext ));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.StockTransaction)]
        public DeleteStockTransactionResponse DeleteStockTransaction(DeleteStockTransactionRequest request)
        {
            try
            {
                IStockTransactionBroker broker = PersistenceContext.GetBroker<IStockTransactionBroker>();
                StockTransaction item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteStockTransactionResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(StockTransaction))));
            }
        }

        #endregion
    }
}