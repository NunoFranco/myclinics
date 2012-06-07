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
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.DoctorPrescription;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Desktop.Tables;
namespace ClearCanvas.Ris.Client
{
	[MenuAction("launch", "global-menus/Admin/Procedure Types", "Launch")]
	[ActionPermission("launch", ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DoctorPrescription)]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class DoctorPrescriptionTool : Tool<IDesktopToolContext>
	{
		private IWorkspace _workspace;

		public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    DoctorPrescriptionSummaryComponent component = new DoctorPrescriptionSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        "Procedure Types");
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
	/// Extension point for views onto <see cref="DoctorPrescriptionSummaryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class DoctorPrescriptionSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

    public class DoctorPrescriptionSummaryTable : Table<DoctorPrescriptionSummary>
    {
        private readonly int columnSortIndex = 0;
        public static string PrimaryCurrencyCode = "";
        public static string PrimaryLocale = "";
        public static string Customeformat = "";
        void InitTableViewFormat()
        {
            //ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail detail = null;
            //Common.Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
            //{
            //    ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
            //    request.IsListDetail = true;
            //    request.IsPrimaryCurrency = true;
            //    List<ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail> lst = service.ListAllCurrency(request).Details;
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
        public DoctorPrescriptionSummaryTable()
        {
            //InitTableViewFormat();
          
            this.Columns.Add(new TableColumn<DoctorPrescriptionSummary, string>(SR.TitleDoctorPrescritpionNameColumn ,
                delegate(DoctorPrescriptionSummary rpt) { return rpt.Name; },
                0.5f));
            this.Columns.Add(new TableColumn<DoctorPrescriptionSummary, string>(SR.TitleDoctorPrescriptionDescriptionColumn,
                            delegate(DoctorPrescriptionSummary rpt) { return rpt.Description ; },
                            0.5f));
            //this.Columns.Add(new TableColumn<DoctorPrescriptionSummary, string>(SR.DoctorPrescriptionColumnTax,
            //    delegate(DoctorPrescriptionSummary rpt) { return rpt.Tax.ToString(); },
            //    0.5f));
            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }


	/// <summary>
	/// DoctorPrescriptionSummaryComponent class.
	/// </summary>
	[AssociateView(typeof(DoctorPrescriptionSummaryComponentViewExtensionPoint))]
	public class DoctorPrescriptionSummaryComponent : SummaryComponentBase<DoctorPrescriptionSummary, DoctorPrescriptionSummaryTable, ListDoctorPrescriptionsRequest>
	{
		private string _id;
		private string _name;
        
		public DoctorPrescriptionSummaryComponent()
		{
           
		}

		public DoctorPrescriptionSummaryComponent(bool dialogMode)
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

			model.Add.SetPermissibility(ClearCanvas.Ris.Application.Common .AuthorityTokens.Admin.Data.DoctorPrescription );
            model.Edit.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DoctorPrescription);
            model.Delete.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DoctorPrescription);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DoctorPrescription);
		}

		protected override bool SupportsDelete
		{
			get
			{
				return true;
			}
		}

		#region Presentation Model

		public string Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
		#endregion
		
		/// <summary>
		/// Gets the list of items to show in the table, according to the specifed first and max items.
		/// </summary>
		/// <returns></returns>
		protected override IList<DoctorPrescriptionSummary> ListItems(ListDoctorPrescriptionsRequest request)
		{
			ListDoctorPrescriptionsResponse _response = null;
			Platform.GetService<IDoctorPrescriptionService>(
				delegate(IDoctorPrescriptionService service)
				{
					_response = service.ListDoctorPrescriptions(request);
				});
			return _response.DoctorPrescriptions;
		}

		/// <summary>
		/// Called to handle the "add" action.
		/// </summary>
		/// <param name="addedItems"></param>
		/// <returns>True if items were added, false otherwise.</returns>
		protected override bool AddItems(out IList<DoctorPrescriptionSummary> addedItems)
		{
			addedItems = new List<DoctorPrescriptionSummary>();
			DoctorPrescriptionEditorComponent editor = new DoctorPrescriptionEditorComponent();
			ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
				this.Host.DesktopWindow, editor, SR.TitleAddDoctorPrescription);
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
		protected override bool EditItems(IList<DoctorPrescriptionSummary> items, out IList<DoctorPrescriptionSummary> editedItems)
		{
			editedItems = new List<DoctorPrescriptionSummary>();
			DoctorPrescriptionSummary item = CollectionUtils.FirstElement(items);

			DoctorPrescriptionEditorComponent editor = new DoctorPrescriptionEditorComponent(item.DoctorPrescriptionRef , new List<ProcedureSummary> ());
			ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
				this.Host.DesktopWindow, editor, SR.TitleUpdateDoctorPrescription + " - " + "("+item.Name +") ");
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
		protected override bool DeleteItems(IList<DoctorPrescriptionSummary> items, out IList<DoctorPrescriptionSummary> deletedItems, out string failureMessage)
		{
			failureMessage = null;
			deletedItems = new List<DoctorPrescriptionSummary>();

			foreach (DoctorPrescriptionSummary item in items)
			{
				try
				{
					Platform.GetService<IDoctorPrescriptionService>(
						delegate(IDoctorPrescriptionService service)
						{
							service.DeleteDoctorPrescription(new DeleteDoctorPrescriptionRequest(item.DoctorPrescriptionRef));
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
		protected override bool UpdateItemsActivation(IList<DoctorPrescriptionSummary> items, out IList<DoctorPrescriptionSummary> editedItems)
		{
			List<DoctorPrescriptionSummary> results = new List<DoctorPrescriptionSummary>();
			foreach (DoctorPrescriptionSummary item in items)
			{
				Platform.GetService<IDoctorPrescriptionService>(
					delegate(IDoctorPrescriptionService service)
					{
						DoctorPrescriptionDetail detail = service.LoadDoctorPrescriptionForEdit(
							new LoadDoctorPrescriptionForEditRequest(item.DoctorPrescriptionRef)).DoctorPrescription;
						detail.Deactivated  = !detail.Deactivated;
						DoctorPrescriptionSummary summary = service.UpdateDoctorPrescription(
							new UpdateDoctorPrescriptionRequest(detail)).DoctorPrescription;

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
		protected override bool IsSameItem(DoctorPrescriptionSummary x, DoctorPrescriptionSummary y)
		{
			if (x != null && y != null)
			{
				return x.DoctorPrescriptionRef.Equals(y.DoctorPrescriptionRef, true);
			}
			return false;
		}
	}
}
