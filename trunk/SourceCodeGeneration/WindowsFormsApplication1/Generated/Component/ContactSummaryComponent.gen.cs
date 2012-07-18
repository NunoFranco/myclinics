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
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Enterprise.Desktop;
using ClearCanvas.Material.Application.Common;
using ClearCanvas.Material.Application.Common.Contactss;
using ClearCanvas.Material.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Desktop.Tables;
namespace ClearCanvas.Material.Client
{
	[MenuAction("launch", "global-menus/Admin/Doctor Prescription Template", "Launch")]
	[ActionPermission("launch", ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Contact)]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class ContactTool : Tool<IDesktopToolContext>
	{
		private IWorkspace _workspace;

		public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    ContactSummaryComponent component = new ContactSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        SR.TitleDoctorPrescritpionSummary);
                    _workspace.Closed += delegate { _workspace = null; };

                }
                catch (Exception e)
                {
                    // could not launch editor
                    ExceptionHandler.Report(e, this.Context.DesktopWindow);
                }
            }
			else
			{
				_workspace.Activate();
			}
		}
	}

	/// <summary>
	/// Extension point for views onto <see cref="ContactSummaryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class ContactSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

    public class ContactSummaryTable : Table<ContactSummary>
    {
        private readonly int columnSortIndex = 0;
        public static string PrimaryCurrencyCode = "";
        public static string PrimaryLocale = "";
        public static string Customeformat = "";
        void InitTableViewFormat()
        {
            //ClearCanvas.Material.Application.Common.Billing.CurrencyDetail detail = null;
            //Common.Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
            //{
            //    ClearCanvas.Material.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new ClearCanvas.Material.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
            //    request.IsListDetail = true;
            //    request.IsPrimaryCurrency = true;
            //    List<ClearCanvas.Material.Application.Common.Billing.CurrencyDetail> lst = service.ListAllCurrency(request).Details;
            //    if (lst != null && lst.Count > 0)
            //        detail = lst[0];
            //});
            //if (detail != null)
            //{
            //    PrimaryLocale = detail.DisplayLocale;
            //    Customeformat = detail.CustomDisplayFormat;
            //    PrimaryCurrencyCode = detail.CurrencyCode;
            //}
        }
        public ContactSummaryTable()
        {
            //InitTableViewFormat();
			 this.Columns.Add(new TableColumn<ContactSummary, string>(SR.TitleContactCodeColumn ,
                delegate(ContactSummary obj) { return obj.Code; },
                0.5f));
 this.Columns.Add(new TableColumn<ContactSummary, string>(SR.TitleContactNameColumn ,
                delegate(ContactSummary obj) { return obj.Name; },
                0.5f));
 this.Columns.Add(new TableColumn<ContactSummary, string>(SR.TitleContactAddressColumn ,
                delegate(ContactSummary obj) { return obj.Address; },
                0.5f));
 this.Columns.Add(new TableColumn<ContactSummary, string>(SR.TitleContactContactDetailInformationColumn ,
                delegate(ContactSummary obj) { return obj.ContactDetailInformation; },
                0.5f));
 this.Columns.Add(new TableColumn<ContactSummary, bool>(SR.TitleContactDeactivatedColumn ,
                delegate(ContactSummary obj) { return obj.Deactivated; },
                0.5f));
 this.Columns.Add(new TableColumn<ContactSummary, FacilitySummary>(SR.TitleContactClinicColumn ,
                delegate(ContactSummary obj) { return obj.Clinic; },
                0.5f));

          
            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }


	/// <summary>
	/// ContactSummaryComponent class.
	/// </summary>
	[AssociateView(typeof(ContactSummaryComponentViewExtensionPoint))]
	public partial class ContactSummaryComponent : SummaryComponentBase<ContactSummary, ContactSummaryTable, ListContactsRequest>
	{
		public ContactSummaryComponent()
		{
           
		}

        public ContactSummaryComponent(bool dialogMode)
			: base(dialogMode)
		{
            
		}

		/// <summary>
		/// Override this method to perform custom initialization of the action model,
		/// such as adding permissions or adding custom actions.
		/// </summary>
		/// <param name="model"></param>
		protected override void InitializeActionModel(AdminActionModel model)
		{
			base.InitializeActionModel(model);

			model.Add.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Contact );
            model.Edit.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Contact);
            model.Delete.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Contact);
            //model.ToggleActivation.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Contact);
		}

		protected override bool SupportsDelete
		{
			get
			{
				return true;
			}
		}
		#region Presentation Model

        //public string Id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
		#endregion
		
		/// <summary>
		/// Gets the list of items to show in the table, according to the specifed first and max items.
		/// </summary>
		/// <returns></returns>
		protected override IList<ContactSummary> ListItems(ListContactsRequest request)
		{
			ListContactsResponse _response = null;
			Platform.GetService<IContactService>(
				delegate(IContactService service)
				{
					_response = service.ListContacts(request);
				});
			return _response.objSummarys;
		}

		/// <summary>
		/// Called to handle the "add" action.
		/// </summary>
		/// <param name="addedItems"></param>
		/// <returns>True if items were added, false otherwise.</returns>
		protected override bool AddItems(out IList<ContactSummary> addedItems)
		{
			addedItems = new List<ContactSummary>();
			ContactEditorComponent editor = new ContactEditorComponent();
			ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
				this.Host.DesktopWindow, editor, SR.TitleAddContact);
			if (exitCode == ApplicationComponentExitCode.Accepted)
			{
				addedItems.Add(editor.summary );
				return true;
			}
			return false;
		}

		/// <summary>
		/// Called to handle the "edit" action.
		/// </summary>
		/// <param name="items">A list of items to edit.</param>
		/// <param name="editedItems">The list of items that were edited.</param>
		/// <returns>True if items were edited, false otherwise.</returns>
		protected override bool EditItems(IList<ContactSummary> items, out IList<ContactSummary> editedItems)
		{
			editedItems = new List<ContactSummary>();
			ContactSummary item = CollectionUtils.FirstElement(items);

			ContactEditorComponent editor = new ContactEditorComponent(item.objRef);
			ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
				this.Host.DesktopWindow, editor, SR.TitleUpdateContact + " - " + "("+item.Name +") ");
			if (exitCode == ApplicationComponentExitCode.Accepted)
			{
				editedItems.Add(editor.summary);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Called to handle the "delete" action, if supported.
		/// </summary>
		/// <param name="items"></param>
		/// <param name="deletedItems">The list of items that were deleted.</param>
		/// <param name="failureMessage">The message if there any errors that occurs during deletion.</param>
		/// <returns>True if items were deleted, false otherwise.</returns>
		protected override bool DeleteItems(IList<ContactSummary> items, out IList<ContactSummary> deletedItems, out string failureMessage)
		{
			failureMessage = null;
			deletedItems = new List<ContactSummary>();

			foreach (ContactSummary item in items)
			{
				try
				{
					Platform.GetService<IContactService>(
						delegate(IContactService service)
						{
							service.DeleteContact(new DeleteContactRequest(item.ContactRef));
						});

					deletedItems.Add(item);
				}
				catch (Exception e)
				{
					failureMessage = e.Message;
				}
			}

			return deletedItems.Count > 0;
		}

		/// <summary>
		/// Called to handle the "toggle activation" action, if supported
		/// </summary>
		/// <param name="items">A list of items to edit.</param>
		/// <param name="editedItems">The list of items that were edited.</param>
		/// <returns>True if items were edited, false otherwise.</returns>
		protected override bool UpdateItemsActivation(IList<ContactSummary> items, out IList<ContactSummary> editedItems)
		{
			List<ContactSummary> results = new List<ContactSummary>();
			foreach (ContactSummary item in items)
			{
				Platform.GetService<IContactService>(
					delegate(IContactService service)
					{
						ContactDetail detail = service.LoadContactForEdit(
							new LoadContactForEditRequest(item.ContactRef)).Contact;
						detail.Deactivated  = !detail.Deactivated;
						ContactSummary summary = service.UpdateContact(
							new UpdateContactRequest(detail)).Contact;

						results.Add(summary);
					});
			}

			editedItems = results;
			return true;
		}

		/// <summary>
		/// Compares two items to see if they represent the same item.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		protected override bool IsSameItem(ContactSummary x, ContactSummary y)
		{
			if (x != null && y != null)
			{
				return x.ContactRef.Equals(y.ContactRef, true);
			}
			return false;
		}
	}
}
