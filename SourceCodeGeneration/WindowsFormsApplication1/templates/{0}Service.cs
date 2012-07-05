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
using ClearCanvas.Ris.Application.Common{-1};
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services{-1}
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(I{0}Service))]
    public class {0}Service : ApplicationServiceBase, I{0}Service
    {
        #region I{0}Service Members

		[ReadOperation]
        public TextQueryResponse<{0}Summary> TextQuery(TextQueryRequest request)
        {
            I{0}Broker broker = PersistenceContext.GetBroker<I{0}Broker>();
            {0}Assembler assembler = new {0}Assembler();

            TextQueryHelper<{0}, {0}SearchCriteria, {0}Summary> helper
                = new TextQueryHelper<{0}, {0}SearchCriteria, {0}Summary>(
                    delegate
                    {
                        string rawQuery = request.TextQuery;

                        IList<string> terms = TextQueryHelper.ParseTerms(rawQuery);
                        List<{0}SearchCriteria> criteria = new List<{0}SearchCriteria>();

                        // allow matching on name (assume entire query is a name which may contain spaces)
                        {0}SearchCriteria nameCriteria = new {0}SearchCriteria();
                        nameCriteria.Name.StartsWith(rawQuery);
                        criteria.Add(nameCriteria);

                        // allow matching of any term against ID
                        /*criteria.AddRange(CollectionUtils.Map<string, {0}SearchCriteria>(terms,
                                     delegate(string term)
                                     {
                                         {0}SearchCriteria c = new {0}SearchCriteria();
                                         c.Id.StartsWith(term);
                                         return c;
                                     }));*/

                        return criteria.ToArray();
                    },
                    delegate({0} pt)
                    {
                        return assembler.CreateSummary(pt, this.PersistenceContext);
                    },
                    delegate({0}SearchCriteria[] criteria, int threshold)
                    {
                        return broker.Count(criteria) <= threshold;
                    },
                    delegate({0}SearchCriteria[] criteria, SearchResultPage page)
                    {
                        return broker.Find(criteria, page);
                    });

            return helper.Query(request);
        }
		
        [ReadOperation]
        public List{0}sResponse List{0}s(List{0}sRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            {0}SearchCriteria where = new {0}SearchCriteria();
            where.Id.SortAsc(0);
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            I{0}Broker broker = PersistenceContext.GetBroker<I{0}Broker>();
            IList<{0}> items = broker.Find(where, request.Page);

            {0}Assembler assembler = new {0}Assembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new List{0}sResponse(
                CollectionUtils.Map<{0}, {0}Summary>(items,
                    delegate({0} item)
                    {
                        return assembler.CreateSummary(item, this.PersistenceContext);
                    })
                );
         
        }

        [ReadOperation]
        public Load{0}ForEditResponse Load{0}ForEdit(Load{0}ForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            {0} item = PersistenceContext.Load<{0}>(request.objRef);

            {0}Assembler assembler = new {0}Assembler();
            return new Load{0}ForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        /*[ReadOperation]
        public Load{0}EditorFormDataResponse Load{0}EditorFormData(Load{0}EditorFormDataRequest request)
        {
            {0}SearchCriteria where = new {0}SearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<{0}> items = PersistenceContext.GetBroker<I{0}Broker>().Find(where);
            
            {0}Assembler assembler = new {0}Assembler();
            List<{0}Summary> baseChoices = CollectionUtils.Map<{0}, {0}Summary>(items,
                   delegate({0} pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new Load{0}EditorFormDataResponse(baseTypeChoices);
        }*/

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.{0})]
        public Add{0}Response Add{0}(Add{0}Request request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            {0} item = new {0}();

            {0}Assembler assembler = new {0}Assembler();
            assembler.Update{0}(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new Add{0}Response(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.{0})]
        public Update{0}Response Update{0}(Update{0}Request request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.{0}Ref, "request.objDetail.{0}Ref");


            {0} item = PersistenceContext.Load<{0}>(request.objDetail.{0}Ref);

            {0}Assembler assembler = new {0}Assembler();
            assembler.Update{0}(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new Update{0}Response(assembler.CreateSummary(item, this.PersistenceContext));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.{0})]
        public Delete{0}Response Delete{0}(Delete{0}Request request)
        {
            try
            {
                I{0}Broker broker = PersistenceContext.GetBroker<I{0}Broker>();
                {0} item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new Delete{0}Response();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof({0}))));
            }
        }

        #endregion
    }
}
