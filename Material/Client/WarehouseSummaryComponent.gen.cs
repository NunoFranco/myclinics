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
using ClearCanvas.Material.Application.Common.Warehouses;
using ClearCanvas.Desktop.Tables;
namespace ClearCanvas.Material.Client
{
    [MenuAction("launch", "global-menus/Admin/Warehouse", "Launch")]
	[ActionPermission("launch", ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Warehouse)]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class WarehouseTool : Tool<IDesktopToolContext>
	{
		private IWorkspace _workspace;

		public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    WarehouseSummaryComponent component = new WarehouseSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        SR.TitleWarehouseSummary);
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
	/// Extension point for views onto <see cref="WarehouseSummaryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class WarehouseSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

    public class WarehouseSummaryTable : Table<WarehouseSummary>
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
        public WarehouseSummaryTable()
        {
            //InitTableViewFormat();
			 this.Columns.Add(new TableColumn<WarehouseSummary, string>(SR.TitleWarehouseCodeColumn ,
                delegate(WarehouseSummary obj) { return obj.Code; },
                0.5f));
 this.Columns.Add(new TableColumn<WarehouseSummary, string>(SR.TitleWarehouseNameColumn ,
                delegate(WarehouseSummary obj) { return obj.Name; },
                0.5f));
 this.Columns.Add(new TableColumn<WarehouseSummary, string>(SR.TitleWarehouseContactDetailInformationColumn ,
                delegate(WarehouseSummary obj) { return obj.ContactDetailInformation; },
                0.5f));
 
          
            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }


	/// <summary>
	/// WarehouseSummaryComponent class.
	/// </summary>
	[AssociateView(typeof(WarehouseSummaryComponentViewExtensionPoint))]
	public partial class WarehouseSummaryComponent : SummaryComponentBase<WarehouseSummary, WarehouseSummaryTable, ListWarehousesRequest>
	{
        private Shelf _shelf;

        WarehouseEditorComponent editor = new WarehouseEditorComponent();
        void InitialEditor()
        {
            editor = new WarehouseEditorComponent();
            editor.ItemAdded += delegate { AddedItems(editor.summary); };
            editor.ItemUpdated += delegate { 
                UpdatedItem(editor.summary);
                if (_shelf != null)
                {
                    _shelf.Title = SR.TitleAddWarehouse;
                }
            };

            editor.IsCloseWhenSaved = false;
        }

        public override void Stop()
        {
            if (_shelf != null)
                _shelf.Close();
            base.Stop();
        }
		public WarehouseSummaryComponent()
		{
           InitialEditor();
		}

        public WarehouseSummaryComponent(bool dialogMode)
			: base(dialogMode)
		{
            InitialEditor();
		}

		/// <summary>
		/// Override this method to perform custom initialization of the action model,
		/// such as adding permissions or adding custom actions.
		/// </summary>
		/// <param name="model"></param>
		protected override void InitializeActionModel(AdminActionModel model)
		{
			base.InitializeActionModel(model);

			model.Add.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Warehouse );
            model.Edit.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Warehouse);
            model.Delete.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Warehouse);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.Warehouse);
		}

		protected override bool SupportsDelete
		{
			get
			{
				return true;
			}
		}
		#region Presentation Model
      
     
		#endregion
		
		/// <summary>
		/// Gets the list of items to show in the table, according to the specifed first and max items.
		/// </summary>
		/// <returns></returns>
		protected override IList<WarehouseSummary> ListItems(ListWarehousesRequest request)
		{
			ListWarehousesResponse _response = null;
			Platform.GetService<IWarehouseService>(
				delegate(IWarehouseService service)
				{
					_response = service.ListWarehouses(request);
				});
			return _response.objSummarys;
		}
        void ShowEditor(bool isNew,string editingName)
        {
            if (_shelf == null)
            {
                InitialEditor();
                _shelf = ApplicationComponent.LaunchAsShelf(
                    this.Host.DesktopWindow, editor, "", ShelfDisplayHint.DockLeft);
                _shelf.Closed += delegate { _shelf = null; };
            }
            //editor = (_shelf.Component as DoctorPrescriptionEditorComponent);

            _shelf.Title  = isNew ? SR.TitleAddWarehouse : string.Format(SR.TitleUpdateWarehouse, editingName);
            editor.IsNew = isNew;
            
            _shelf.Activate();
        }
		/// <summary>
		/// Called to handle the "add" action.
		/// </summary>
		/// <param name="addedItems"></param>
		/// <returns>True if items were added, false otherwise.</returns>
		protected override bool AddItems(out IList<WarehouseSummary> addedItems)
		{
            addedItems = new List<WarehouseSummary>();
            if (DialogMode)
            {
                addedItems = new List<WarehouseSummary>();
                var editor = new WarehouseEditorComponent();
                var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleAddWarehouse);
                if (exitCode == ApplicationComponentExitCode.Accepted)
                {
                    addedItems.Add(editor.summary);
                    return true;
                }
                return false;
            }
            else
            {
               
                ShowEditor(true, "");
                return true;
            }
		}

		/// <summary>
		/// Called to handle the "edit" action.
		/// </summary>
		/// <param name="items">A list of items to edit.</param>
		/// <param name="editedItems">The list of items that were edited.</param>
		/// <returns>True if items were edited, false otherwise.</returns>
		protected override bool EditItems(IList<WarehouseSummary> items, out IList<WarehouseSummary> editedItems)
		{
            WarehouseSummary item = CollectionUtils.FirstElement(items);
            editedItems = new List<WarehouseSummary>();
            if (DialogMode)
            {
                var editor = new WarehouseEditorComponent(item.objRef );
                var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleUpdateWarehouse);
                if (exitCode == ApplicationComponentExitCode.Accepted)
                {
                    editedItems.Add(editor.summary );
                    return true;
                }
                return false;
            }
            else
            {
                ShowEditor(false, item.Code );
                (_shelf.Component as WarehouseEditorComponent).WarehouseRef = item.objRef;

                return true;
            }
		}

		/// <summary>
		/// Called to handle the "delete" action, if supported.
		/// </summary>
		/// <param name="items"></param>
		/// <param name="deletedItems">The list of items that were deleted.</param>
		/// <param name="failureMessage">The message if there any errors that occurs during deletion.</param>
		/// <returns>True if items were deleted, false otherwise.</returns>
		protected override bool DeleteItems(IList<WarehouseSummary> items, out IList<WarehouseSummary> deletedItems, out string failureMessage)
		{
			failureMessage = null;
			deletedItems = new List<WarehouseSummary>();

			foreach (WarehouseSummary item in items)
			{
				try
				{
					Platform.GetService<IWarehouseService>(
						delegate(IWarehouseService service)
						{
							service.DeleteWarehouse(new DeleteWarehouseRequest(item.objRef));
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
		protected override bool UpdateItemsActivation(IList<WarehouseSummary> items, out IList<WarehouseSummary> editedItems)
		{
			List<WarehouseSummary> results = new List<WarehouseSummary>();
			foreach (WarehouseSummary item in items)
			{
				Platform.GetService<IWarehouseService>(
					delegate(IWarehouseService service)
					{
						WarehouseDetail detail = service.LoadWarehouseForEdit(
							new LoadWarehouseForEditRequest(item.objRef)).objDetail;
						detail.Deactivated  = !detail.Deactivated;
						WarehouseSummary summary = service.UpdateWarehouse(
							new UpdateWarehouseRequest(detail)).objSummary;

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
		protected override bool IsSameItem(WarehouseSummary x, WarehouseSummary y)
		{
			if (x != null && y != null)
			{
				return x.objRef.Equals(y.objRef, true);
			}
			return false;
		}
	}
}
