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
using ClearCanvas.Material.Application.Common.MaterialLots;
using AuthorityTokens = ClearCanvas.Material.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;
namespace ClearCanvas.Material.Application.Services.MaterialLots
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IMaterialLotService))]
    public partial class MaterialLotService : ApplicationServiceBase, IMaterialLotService
    {
        #region IMaterialLotService Members

		[ReadOperation]
        public TextQueryResponse<MaterialLotSummary> TextQuery(TextQueryRequest request)
        {
            IMaterialLotBroker broker = PersistenceContext.GetBroker<IMaterialLotBroker>();
            MaterialLotAssembler assembler = new MaterialLotAssembler();

            TextQueryHelper<MaterialLot, MaterialLotSearchCriteria, MaterialLotSummary> helper
                = new TextQueryHelper<MaterialLot, MaterialLotSearchCriteria, MaterialLotSummary>(
                    delegate
                    {
                        string rawQuery = request.TextQuery;

                        IList<string> terms = TextQueryHelper.ParseTerms(rawQuery);
                        List<MaterialLotSearchCriteria> criteria = new List<MaterialLotSearchCriteria>();

                        // allow matching on name (assume entire query is a name which may contain spaces)
                        MaterialLotSearchCriteria nameCriteria = new MaterialLotSearchCriteria();
                        nameCriteria.Id.StartsWith(rawQuery);
                        criteria.Add(nameCriteria);

                        // allow matching of any term against ID
                        /*criteria.AddRange(CollectionUtils.Map<string, MaterialLotSearchCriteria>(terms,
                                     delegate(string term)
                                     {
                                         MaterialLotSearchCriteria c = new MaterialLotSearchCriteria();
                                         c.Id.StartsWith(term);
                                         return c;
                                     }));*/

                        return criteria.ToArray();
                    },
                    delegate(MaterialLot pt)
                    {
                        return assembler.CreateSummary(pt);
                    },
                    delegate(MaterialLotSearchCriteria[] criteria, int threshold)
                    {
                        return broker.Count(criteria) <= threshold;
                    },
                    delegate(MaterialLotSearchCriteria[] criteria, SearchResultPage page)
                    {
                        return broker.Find(criteria, page);
                    });

            return helper.Query(request);
        }
		
        [ReadOperation]
        public ListMaterialLotsResponse ListMaterialLots(ListMaterialLotsRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            MaterialLotSearchCriteria where = new MaterialLotSearchCriteria();
            where.Id.SortAsc(0);
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            IMaterialLotBroker broker = PersistenceContext.GetBroker<IMaterialLotBroker>();
            IList<MaterialLot> items = broker.Find(where, request.Page);

            MaterialLotAssembler assembler = new MaterialLotAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListMaterialLotsResponse(
                CollectionUtils.Map<MaterialLot, MaterialLotSummary>(items,
                    delegate(MaterialLot item)
                    {
                        return assembler.CreateSummary(item);
                    })
                );
         
        }

        [ReadOperation]
        public LoadMaterialLotForEditResponse LoadMaterialLotForEdit(LoadMaterialLotForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            MaterialLot item = PersistenceContext.Load<MaterialLot>(request.objRef);

            MaterialLotAssembler assembler = new MaterialLotAssembler();
            return new LoadMaterialLotForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        /*[ReadOperation]
        public LoadMaterialLotEditorFormDataResponse LoadMaterialLotEditorFormData(LoadMaterialLotEditorFormDataRequest request)
        {
            MaterialLotSearchCriteria where = new MaterialLotSearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<MaterialLot> items = PersistenceContext.GetBroker<IMaterialLotBroker>().Find(where);
            
            MaterialLotAssembler assembler = new MaterialLotAssembler();
            List<MaterialLotSummary> baseChoices = CollectionUtils.Map<MaterialLot, MaterialLotSummary>(items,
                   delegate(MaterialLot pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new LoadMaterialLotEditorFormDataResponse(baseTypeChoices);
        }*/

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.MaterialLot)]
        public AddMaterialLotResponse AddMaterialLot(AddMaterialLotRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            MaterialLot item = new MaterialLot();

            MaterialLotAssembler assembler = new MaterialLotAssembler();
            assembler.UpdateMaterialLot(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddMaterialLotResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.MaterialLot)]
        public UpdateMaterialLotResponse UpdateMaterialLot(UpdateMaterialLotRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.MaterialLotRef, "request.objDetail.MaterialLotRef");


            MaterialLot item = PersistenceContext.Load<MaterialLot>(request.objDetail.MaterialLotRef);

            MaterialLotAssembler assembler = new MaterialLotAssembler();
            assembler.UpdateMaterialLot(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateMaterialLotResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.MaterialLot)]
        public DeleteMaterialLotResponse DeleteMaterialLot(DeleteMaterialLotRequest request)
        {
            try
            {
                IMaterialLotBroker broker = PersistenceContext.GetBroker<IMaterialLotBroker>();
                MaterialLot item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteMaterialLotResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(MaterialLot))));
            }
        }

        #endregion
    }
}
