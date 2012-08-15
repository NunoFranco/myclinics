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
using ClearCanvas.Material.Application.Common.Contacts;
using AuthorityTokens = ClearCanvas.Material.Application.Common.AuthorityTokens;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;

namespace ClearCanvas.Material.Application.Services.Contacts
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IContactService))]
    public partial class ContactService : ApplicationServiceBase, IContactService
    {
        #region IContactService Members

        [ReadOperation]
        public TextQueryResponse<ContactSummary> TextQuery(TextQueryRequest request)
        {
            IContactBroker broker = PersistenceContext.GetBroker<IContactBroker>();
            ContactAssembler assembler = new ContactAssembler();

            TextQueryHelper<Contact, ContactSearchCriteria, ContactSummary> helper
                = new TextQueryHelper<Contact, ContactSearchCriteria, ContactSummary>(
                    delegate
                    {
                        string rawQuery = request.TextQuery;

                        IList<string> terms = TextQueryHelper.ParseTerms(rawQuery);
                        List<ContactSearchCriteria> criteria = new List<ContactSearchCriteria>();

                        // allow matching on name (assume entire query is a name which may contain spaces)
                        ContactSearchCriteria nameCriteria = new ContactSearchCriteria();
                        nameCriteria.Name.StartsWith(rawQuery);
                        criteria.Add(nameCriteria);

                        // allow matching of any term against ID
                        /*criteria.AddRange(CollectionUtils.Map<string, ContactSearchCriteria>(terms,
                                     delegate(string term)
                                     {
                                         ContactSearchCriteria c = new ContactSearchCriteria();
                                         c.Id.StartsWith(term);
                                         return c;
                                     }));*/

                        return criteria.ToArray();
                    },
                    delegate(Contact pt)
                    {
                        return assembler.CreateSummary (pt);
                    },
                    delegate(ContactSearchCriteria[] criteria, int threshold)
                    {
                        return broker.Count(criteria) <= threshold;
                    },
                    delegate(ContactSearchCriteria[] criteria, SearchResultPage page)
                    {
                        return broker.Find(criteria, page);
                    });

            return helper.Query(request);
        }
		
        [ReadOperation]
        public ListContactsResponse ListContacts(ListContactsRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            ContactSearchCriteria where = new ContactSearchCriteria();
            where.Code.SortAsc(0);
            where.Clinic.EqualTo(PersistenceContext.GetBroker<IFacilityBroker>().Load(request.ClinicRef));
            
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);
           
            IContactBroker broker = PersistenceContext.GetBroker<IContactBroker>();
            IList<Contact> items = broker.Find(where, request.Page);

            ContactAssembler assembler = new ContactAssembler();
            //if request to get detail the return detail ortherwise return summary
           
            return new ListContactsResponse(
                CollectionUtils.Map<Contact, ContactSummary>(items,
                    delegate(Contact item)
                    {
                        return assembler.CreateSummary(item);
                    })
                );
         
        }

        [ReadOperation]
        public LoadContactForEditResponse LoadContactForEdit(LoadContactForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objRef, "request.objRef");

            Contact item = PersistenceContext.Load<Contact>(request.objRef);

            ContactAssembler assembler = new ContactAssembler();
            return new LoadContactForEditResponse(assembler.CreateDetail(item, this.PersistenceContext));
        }

        /*[ReadOperation]
        public LoadContactEditorFormDataResponse LoadContactEditorFormData(LoadContactEditorFormDataRequest request)
        {
            ContactSearchCriteria where = new ContactSearchCriteria();
            //where.Id.SortAsc(0);
            where.Deactivated.EqualTo(false);
            IList<Contact> items = PersistenceContext.GetBroker<IContactBroker>().Find(where);
            
            ContactAssembler assembler = new ContactAssembler();
            List<ContactSummary> baseChoices = CollectionUtils.Map<Contact, ContactSummary>(items,
                   delegate(Contact pt) { return assembler.CreateSummary(pt, this.PersistenceContext); });

          
            return new LoadContactEditorFormDataResponse(baseTypeChoices);
        }*/

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Contact)]
        public AddContactResponse AddContact(AddContactRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

          

            Contact item = new Contact();

            ContactAssembler assembler = new ContactAssembler();
            assembler.UpdateContact(item, request.Detail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddContactResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Contact)]
        public UpdateContactResponse UpdateContact(UpdateContactRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.objDetail, "request.objDetail");
            Platform.CheckMemberIsSet(request.objDetail.ContactRef, "request.objDetail.ContactRef");


            Contact item = PersistenceContext.Load<Contact>(request.objDetail.ContactRef);

            ContactAssembler assembler = new ContactAssembler();
            assembler.UpdateContact(item, request.objDetail, PersistenceContext);


            PersistenceContext.SynchState();

            return new UpdateContactResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        //[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Contact)]
        public DeleteContactResponse DeleteContact(DeleteContactRequest request)
        {
            try
            {
                IContactBroker broker = PersistenceContext.GetBroker<IContactBroker>();
                Contact item = broker.Load(request.objRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteContactResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(typeof(Contact))));
            }
        }

        #endregion
    }
}
