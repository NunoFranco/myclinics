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
using ClearCanvas.Material.Application.Services.Warehouses;
using AuthorityTokens = ClearCanvas.Material.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Material.Application.Common.Warehouses;
namespace ClearCanvas.Material.Application.Services.Warehouses
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IWarehouseService))]
    public partial class WarehouseService : ApplicationServiceBase, IWarehouseService
    {
        #region IWarehouseService Members

        [ReadOperation]
        public TextQueryResponse<WarehouseSummary> TextQuery(TextQueryRequest request)
        {
            IWarehouseBroker broker = PersistenceContext.GetBroker<IWarehouseBroker>();
            WarehouseAssembler assembler = new WarehouseAssembler();

            TextQueryHelper<Warehouse, WarehouseSearchCriteria, WarehouseSummary> helper
                = new TextQueryHelper<Warehouse, WarehouseSearchCriteria, WarehouseSummary>(
                    delegate
                    {
                        string rawQuery = request.TextQuery;

                        IList<string> terms = TextQueryHelper.ParseTerms(rawQuery);
                        List<WarehouseSearchCriteria> criteria = new List<WarehouseSearchCriteria>();

                        // allow matching on name (assume entire query is a name which may contain spaces)
                        WarehouseSearchCriteria nameCriteria = new WarehouseSearchCriteria();
                        nameCriteria.Name.StartsWith(rawQuery);
                        criteria.Add(nameCriteria);
                        

                        // allow matching of any term against ID
                        WarehouseSearchCriteria CodeCriteria = new WarehouseSearchCriteria();
                        CodeCriteria.Code.StartsWith(rawQuery);
                        criteria.Add(CodeCriteria);

                        return criteria.ToArray();
                    },
                    delegate(Warehouse pt)
                    {
                        return assembler.CreateSummary(pt);
                    },
                    delegate(WarehouseSearchCriteria[] criteria, int threshold)
                    {
                        return broker.Count(criteria) <= threshold;
                    },
                    delegate(WarehouseSearchCriteria[] criteria, SearchResultPage page)
                    {
                        return broker.Find(criteria, page);
                    });

            return helper.Query(request);
        }
		
        [ReadOperation]
        public ListWarehousesResponse ListWarehouses(ListWarehousesRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            WarehouseSearchCriteria where = new WarehouseSearchCriteria();
            where.Code.SortAsc(0);
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            IWarehouseBroker broker = PersistenceContext.GetBroker<IWarehouseBroker>();
            IList<Warehouse> items = broker.Find(where, request.Page);

            WarehouseAssembler assembler = new WarehouseAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListWarehousesResponse(
                CollectionUtils.Map<Warehouse, WarehouseSummary>(items,
                    delegate(Warehouse item)
                    {
                        return assembler.CreateSummary(item);
                    })
                );
         
        }

        [ReadOperation]
        public LoadWarehouseForEditResponse LoadWarehouseForEdit(LoadWarehouseForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            Warehouse item = PersistenceContext.Load<Warehouse>(request.objRef);

            WarehouseAssembler assembler = new WarehouseAssembler();
            return new LoadWarehouseForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        /*[ReadOperation]
        public LoadWarehouseEditorFormDataResponse LoadWarehouseEditorFormData(LoadWarehouseEditorFormDataRequest request)
        {
            WarehouseSearchCriteria where = new WarehouseSearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<Warehouse> items = PersistenceContext.GetBroker<IWarehouseBroker>().Find(where);
            
            WarehouseAssembler assembler = new WarehouseAssembler();
            List<WarehouseSummary> baseChoices = CollectionUtils.Map<Warehouse, WarehouseSummary>(items,
                   delegate(Warehouse pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new LoadWarehouseEditorFormDataResponse(baseTypeChoices);
        }*/

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Warehouse)]
        public AddWarehouseResponse AddWarehouse(AddWarehouseRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            Warehouse item = new Warehouse();

            WarehouseAssembler assembler = new WarehouseAssembler();
            assembler.UpdateWarehouse(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddWarehouseResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Warehouse)]
        public UpdateWarehouseResponse UpdateWarehouse(UpdateWarehouseRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.WarehouseRef, "request.objDetail.WarehouseRef");


            Warehouse item = PersistenceContext.Load<Warehouse>(request.objDetail.WarehouseRef);

            WarehouseAssembler assembler = new WarehouseAssembler();
            assembler.UpdateWarehouse(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateWarehouseResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Warehouse)]
        public DeleteWarehouseResponse DeleteWarehouse(DeleteWarehouseRequest request)
        {
            try
            {
                IWarehouseBroker broker = PersistenceContext.GetBroker<IWarehouseBroker>();
                Warehouse item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteWarehouseResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(Warehouse))));
            }
        }

        #endregion
    }
}
