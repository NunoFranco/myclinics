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
using ClearCanvas.Material.Application.Common.MaterialLots;
using ClearCanvas.Desktop.Tables;
namespace ClearCanvas.Material.Client
{
    
    [MenuAction("launch", "global-menus/Admin/MaterialLot", "Launch")]
	[ActionPermission("launch", ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MaterialLot)]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class MaterialLotTool : Tool<IDesktopToolContext>
	{
		private IWorkspace _workspace;

		public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    MaterialLotSummaryComponent component = new MaterialLotSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        SR.TitleMaterialLotSummary);
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
	/// Extension point for views onto <see cref="MaterialLotSummaryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class MaterialLotSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

    public class MaterialLotSummaryTable : Table<MaterialLotSummary>
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
        public MaterialLotSummaryTable()
        {
            //InitTableViewFormat();
			 this.Columns.Add(new TableColumn<MaterialLotSummary, string>(SR.TitleMaterialLotIdColumn ,
                delegate(MaterialLotSummary obj) { return obj.Id; },
                0.5f));
 this.Columns.Add(new TableColumn<MaterialLotSummary, string>(SR.TitleMaterialLotDescriptionColumn ,
                delegate(MaterialLotSummary obj) { return obj.Description; },
                0.5f));
 this.Columns.Add(new TableColumn<MaterialLotSummary, DateTime>(SR.TitleMaterialLotInputDateColumn ,
                delegate(MaterialLotSummary obj) { return obj.InputDate; },
                0.5f));
 
          
            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }


	/// <summary>
	/// MaterialLotSummaryComponent class.
	/// </summary>
	[AssociateView(typeof(MaterialLotSummaryComponentViewExtensionPoint))]
	public partial class MaterialLotSummaryComponent : SummaryComponentBase<MaterialLotSummary, MaterialLotSummaryTable, ListMaterialLotsRequest>
	{
        private Shelf _shelf;

        MaterialLotEditorComponent editor = new MaterialLotEditorComponent();
        void InitialEditor()
        {
            editor = new MaterialLotEditorComponent();
            editor.ItemAdded += delegate { AddedItems(editor.summary); };
            editor.ItemUpdated += delegate { 
                UpdatedItem(editor.summary);
                if (_shelf != null)
                {
                    _shelf.Title = SR.TitleAddMaterialLot;
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
		public MaterialLotSummaryComponent()
		{
           InitialEditor();
		}

        public MaterialLotSummaryComponent(bool dialogMode)
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

			model.Add.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MaterialLot );
            model.Edit.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MaterialLot);
            model.Delete.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MaterialLot);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MaterialLot);
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
		protected override IList<MaterialLotSummary> ListItems(ListMaterialLotsRequest request)
		{
			ListMaterialLotsResponse _response = null;
			Platform.GetService<IMaterialLotService>(
				delegate(IMaterialLotService service)
				{
					_response = service.ListMaterialLots(request);
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

            _shelf.Title  = isNew ? SR.TitleAddMaterialLot : string.Format(SR.TitleUpdateMaterialLot, editingName);
            editor.IsNew = isNew;
            
            _shelf.Activate();
        }
		/// <summary>
		/// Called to handle the "add" action.
		/// </summary>
		/// <param name="addedItems"></param>
		/// <returns>True if items were added, false otherwise.</returns>
		protected override bool AddItems(out IList<MaterialLotSummary> addedItems)
		{
            addedItems = new List<MaterialLotSummary>();
            if (DialogMode)
            {
                addedItems = new List<MaterialLotSummary>();
                var editor = new MaterialLotEditorComponent();
                var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleAddMaterialLot);
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
		protected override bool EditItems(IList<MaterialLotSummary> items, out IList<MaterialLotSummary> editedItems)
		{
            MaterialLotSummary item = CollectionUtils.FirstElement(items);
            editedItems = new List<MaterialLotSummary>();
            if (DialogMode)
            {
                var editor = new MaterialLotEditorComponent(item.objRef );
                var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleUpdateMaterialLot);
                if (exitCode == ApplicationComponentExitCode.Accepted)
                {
                    editedItems.Add(editor.summary );
                    return true;
                }
                return false;
            }
            else
            {
                ShowEditor(false, item.Id);
                (_shelf.Component as MaterialLotEditorComponent).MaterialLotRef = item.objRef;

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
		protected override bool DeleteItems(IList<MaterialLotSummary> items, out IList<MaterialLotSummary> deletedItems, out string failureMessage)
		{
			failureMessage = null;
			deletedItems = new List<MaterialLotSummary>();

			foreach (MaterialLotSummary item in items)
			{
				try
				{
					Platform.GetService<IMaterialLotService>(
						delegate(IMaterialLotService service)
						{
							service.DeleteMaterialLot(new DeleteMaterialLotRequest(item.objRef));
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
		protected override bool UpdateItemsActivation(IList<MaterialLotSummary> items, out IList<MaterialLotSummary> editedItems)
		{
			List<MaterialLotSummary> results = new List<MaterialLotSummary>();
			foreach (MaterialLotSummary item in items)
			{
				Platform.GetService<IMaterialLotService>(
					delegate(IMaterialLotService service)
					{
						MaterialLotDetail detail = service.LoadMaterialLotForEdit(
							new LoadMaterialLotForEditRequest(item.objRef)).objDetail;
						detail.Deactivated  = !detail.Deactivated;
						MaterialLotSummary summary = service.UpdateMaterialLot(
							new UpdateMaterialLotRequest(detail)).objSummary;

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
		protected override bool IsSameItem(MaterialLotSummary x, MaterialLotSummary y)
		{
			if (x != null && y != null)
			{
				return x.objRef.Equals(y.objRef, true);
			}
			return false;
		}
	}
}
