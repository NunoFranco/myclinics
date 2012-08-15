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
using ClearCanvas.Material.Application.Common.MedicineCounters;
using AuthorityTokens = ClearCanvas.Material.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;
namespace ClearCanvas.Material.Application.Services.MedicineCounters
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IMedicineCounterService))]
    public partial class MedicineCounterService : ApplicationServiceBase, IMedicineCounterService
    {
        #region IMedicineCounterService Members

		[ReadOperation]
        public TextQueryResponse<MedicineCounterSummary> TextQuery(TextQueryRequest request)
        {
            IMedicineCounterBroker broker = PersistenceContext.GetBroker<IMedicineCounterBroker>();
            MedicineCounterAssembler assembler = new MedicineCounterAssembler();

            TextQueryHelper<MedicineCounter, MedicineCounterSearchCriteria, MedicineCounterSummary> helper
                = new TextQueryHelper<MedicineCounter, MedicineCounterSearchCriteria, MedicineCounterSummary>(
                    delegate
                    {
                        string rawQuery = request.TextQuery;

                        IList<string> terms = TextQueryHelper.ParseTerms(rawQuery);
                        List<MedicineCounterSearchCriteria> criteria = new List<MedicineCounterSearchCriteria>();

                        // allow matching on name (assume entire query is a name which may contain spaces)
                        MedicineCounterSearchCriteria nameCriteria = new MedicineCounterSearchCriteria();
                        nameCriteria.Name.StartsWith(rawQuery);
                        criteria.Add(nameCriteria);

                        // allow matching of any term against ID
                        /*criteria.AddRange(CollectionUtils.Map<string, MedicineCounterSearchCriteria>(terms,
                                     delegate(string term)
                                     {
                                         MedicineCounterSearchCriteria c = new MedicineCounterSearchCriteria();
                                         c.Id.StartsWith(term);
                                         return c;
                                     }));*/

                        return criteria.ToArray();
                    },
                    delegate(MedicineCounter pt)
                    {
                        return assembler.CreateSummary(pt);
                    },
                    delegate(MedicineCounterSearchCriteria[] criteria, int threshold)
                    {
                        return broker.Count(criteria) <= threshold;
                    },
                    delegate(MedicineCounterSearchCriteria[] criteria, SearchResultPage page)
                    {
                        return broker.Find(criteria, page);
                    });

            return helper.Query(request);
        }
		
        [ReadOperation]
        public ListMedicineCountersResponse ListMedicineCounters(ListMedicineCountersRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            MedicineCounterSearchCriteria where = new MedicineCounterSearchCriteria();
            
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
           
            IMedicineCounterBroker broker = PersistenceContext.GetBroker<IMedicineCounterBroker>();
            IList<MedicineCounter> items = broker.Find(where, request.Page);

            MedicineCounterAssembler assembler = new MedicineCounterAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListMedicineCountersResponse(
                CollectionUtils.Map<MedicineCounter, MedicineCounterSummary>(items,
                    delegate(MedicineCounter item)
                    {
                        return assembler.CreateSummary (item);
                    })
                );
         
        }

        [ReadOperation]
        public LoadMedicineCounterForEditResponse LoadMedicineCounterForEdit(LoadMedicineCounterForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            MedicineCounter item = PersistenceContext.Load<MedicineCounter>(request.objRef);

            MedicineCounterAssembler assembler = new MedicineCounterAssembler();
            return new LoadMedicineCounterForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        /*[ReadOperation]
        public LoadMedicineCounterEditorFormDataResponse LoadMedicineCounterEditorFormData(LoadMedicineCounterEditorFormDataRequest request)
        {
            MedicineCounterSearchCriteria where = new MedicineCounterSearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<MedicineCounter> items = PersistenceContext.GetBroker<IMedicineCounterBroker>().Find(where);
            
            MedicineCounterAssembler assembler = new MedicineCounterAssembler();
            List<MedicineCounterSummary> baseChoices = CollectionUtils.Map<MedicineCounter, MedicineCounterSummary>(items,
                   delegate(MedicineCounter pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new LoadMedicineCounterEditorFormDataResponse(baseTypeChoices);
        }*/

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.MedicineCounter)]
        public AddMedicineCounterResponse AddMedicineCounter(AddMedicineCounterRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            MedicineCounter item = new MedicineCounter();

            MedicineCounterAssembler assembler = new MedicineCounterAssembler();
            assembler.UpdateMedicineCounter(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddMedicineCounterResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.MedicineCounter)]
        public UpdateMedicineCounterResponse UpdateMedicineCounter(UpdateMedicineCounterRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.MedicineCounterRef, "request.objDetail.MedicineCounterRef");


            MedicineCounter item = PersistenceContext.Load<MedicineCounter>(request.objDetail.MedicineCounterRef);

            MedicineCounterAssembler assembler = new MedicineCounterAssembler();
            assembler.UpdateMedicineCounter(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateMedicineCounterResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.MedicineCounter)]
        public DeleteMedicineCounterResponse DeleteMedicineCounter(DeleteMedicineCounterRequest request)
        {
            try
            {
                IMedicineCounterBroker broker = PersistenceContext.GetBroker<IMedicineCounterBroker>();
                MedicineCounter item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteMedicineCounterResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format("Failed to delete {0}", TerminologyTranslator.Translate(typeof(MedicineCounter))));
            }
        }

        #endregion
    }
}
