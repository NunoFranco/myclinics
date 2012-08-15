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
using ClearCanvas.Material.Application.Common.MedicineCounters;
using ClearCanvas.Desktop.Tables;
namespace ClearCanvas.Material.Client
{
	[MenuAction("launch", "global-menus/Admin/MedicineCounter", "Launch")]
	[ActionPermission("launch", ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineCounter)]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class MedicineCounterTool : Tool<IDesktopToolContext>
	{
		private IWorkspace _workspace;

		public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    MedicineCounterSummaryComponent component = new MedicineCounterSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        SR.TitleMedicineCounterSummary);
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
	/// Extension point for views onto <see cref="MedicineCounterSummaryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class MedicineCounterSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

    public class MedicineCounterSummaryTable : Table<MedicineCounterSummary>
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
        public MedicineCounterSummaryTable()
        {
            //InitTableViewFormat();
			 this.Columns.Add(new TableColumn<MedicineCounterSummary, string>(SR.TitleMedicineCounterCodeColumn ,
                delegate(MedicineCounterSummary obj) { return obj.Code; },
                0.5f));
 this.Columns.Add(new TableColumn<MedicineCounterSummary, string>(SR.TitleMedicineCounterNameColumn ,
                delegate(MedicineCounterSummary obj) { return obj.Name; },
                0.5f));

          
            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }


	/// <summary>
	/// MedicineCounterSummaryComponent class.
	/// </summary>
	[AssociateView(typeof(MedicineCounterSummaryComponentViewExtensionPoint))]
	public partial class MedicineCounterSummaryComponent : SummaryComponentBase<MedicineCounterSummary, MedicineCounterSummaryTable, ListMedicineCountersRequest>
	{
        private Shelf _shelf;

        MedicineCounterEditorComponent editor = new MedicineCounterEditorComponent();
        void InitialEditor()
        {
            editor = new MedicineCounterEditorComponent();
            editor.ItemAdded += delegate { AddedItems(editor.summary); };
            editor.ItemUpdated += delegate { 
                UpdatedItem(editor.summary);
                if (_shelf != null)
                {
                    _shelf.Title = SR.TitleAddMedicineCounter;
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
		public MedicineCounterSummaryComponent()
		{
           InitialEditor();
		}

        public MedicineCounterSummaryComponent(bool dialogMode)
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

			model.Add.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineCounter );
            model.Edit.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineCounter);
            model.Delete.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineCounter);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineCounter);
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
		protected override IList<MedicineCounterSummary> ListItems(ListMedicineCountersRequest request)
		{
			ListMedicineCountersResponse _response = null;
			Platform.GetService<IMedicineCounterService>(
				delegate(IMedicineCounterService service)
				{
					_response = service.ListMedicineCounters(request);
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

            _shelf.Title  = isNew ? SR.TitleAddMedicineCounter : string.Format(SR.TitleUpdateMedicineCounter, editingName);
            editor.IsNew = isNew;
            
            _shelf.Activate();
        }
		/// <summary>
		/// Called to handle the "add" action.
		/// </summary>
		/// <param name="addedItems"></param>
		/// <returns>True if items were added, false otherwise.</returns>
		protected override bool AddItems(out IList<MedicineCounterSummary> addedItems)
		{
            addedItems = new List<MedicineCounterSummary>();
            if (DialogMode)
            {
                addedItems = new List<MedicineCounterSummary>();
                var editor = new MedicineCounterEditorComponent();
                var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleAddMedicineCounter);
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
		protected override bool EditItems(IList<MedicineCounterSummary> items, out IList<MedicineCounterSummary> editedItems)
		{
            MedicineCounterSummary item = CollectionUtils.FirstElement(items);
            editedItems = new List<MedicineCounterSummary>();
            if (DialogMode)
            {
                var editor = new MedicineCounterEditorComponent(item.objRef );
                var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleUpdateMedicineCounter);
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
                (_shelf.Component as MedicineCounterEditorComponent).MedicineCounterRef = item.objRef;

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
		protected override bool DeleteItems(IList<MedicineCounterSummary> items, out IList<MedicineCounterSummary> deletedItems, out string failureMessage)
		{
			failureMessage = null;
			deletedItems = new List<MedicineCounterSummary>();

			foreach (MedicineCounterSummary item in items)
			{
				try
				{
					Platform.GetService<IMedicineCounterService>(
						delegate(IMedicineCounterService service)
						{
							service.DeleteMedicineCounter(new DeleteMedicineCounterRequest(item.objRef));
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
		protected override bool UpdateItemsActivation(IList<MedicineCounterSummary> items, out IList<MedicineCounterSummary> editedItems)
		{
			List<MedicineCounterSummary> results = new List<MedicineCounterSummary>();
			foreach (MedicineCounterSummary item in items)
			{
				Platform.GetService<IMedicineCounterService>(
					delegate(IMedicineCounterService service)
					{
						MedicineCounterDetail detail = service.LoadMedicineCounterForEdit(
							new LoadMedicineCounterForEditRequest(item.objRef)).objDetail;
						detail.Deactivated  = !detail.Deactivated;
						MedicineCounterSummary summary = service.UpdateMedicineCounter(
							new UpdateMedicineCounterRequest(detail)).objSummary;

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
		protected override bool IsSameItem(MedicineCounterSummary x, MedicineCounterSummary y)
		{
			if (x != null && y != null)
			{
				return x.objRef.Equals(y.objRef, true);
			}
			return false;
		}
	}
}
