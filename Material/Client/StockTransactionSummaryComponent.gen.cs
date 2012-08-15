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
using ClearCanvas.Material.Application.Common.StockTransactions;
using ClearCanvas.Desktop.Tables;
namespace ClearCanvas.Material.Client
{
	[MenuAction("launch", "global-menus/Admin/StockTransaction", "Launch")]
	[ActionPermission("launch", ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineTransaction )]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class StockTransactionTool : Tool<IDesktopToolContext>
	{
		private IWorkspace _workspace;

		public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    StockTransactionSummaryComponent component = new StockTransactionSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        SR.TitleStockTransactionSummary);
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
	/// Extension point for views onto <see cref="StockTransactionSummaryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class StockTransactionSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

    public class StockTransactionSummaryTable : Table<StockTransactionSummary>
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
        public StockTransactionSummaryTable()
        {
            //InitTableViewFormat();
			 this.Columns.Add(new TableColumn<StockTransactionSummary, string>(SR.TitleStockTransactionCodeColumn ,
                delegate(StockTransactionSummary obj) { return obj.Code; },
                0.5f));
 this.Columns.Add(new TableColumn<StockTransactionSummary, string>(SR.TitleStockTransactionDescriptionColumn ,
                delegate(StockTransactionSummary obj) { return obj.Description; },
                0.5f));
 this.Columns.Add(new TableColumn<StockTransactionSummary, string>(SR.TitleStockTransactionTypeColumn,
    delegate(StockTransactionSummary obj) { return obj.TransactionType.Value  ; },
    0.5f));

 this.Columns.Add(new TableColumn<StockTransactionSummary, DateTime?>(SR.TitleStockTransactionTransactionDateColumn ,
                delegate(StockTransactionSummary obj) { return obj.TransactionDate; },
                0.5f));

          
            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }


	/// <summary>
	/// StockTransactionSummaryComponent class.
	/// </summary>
	[AssociateView(typeof(StockTransactionSummaryComponentViewExtensionPoint))]
	public partial class StockTransactionSummaryComponent : SummaryComponentBase<StockTransactionSummary, StockTransactionSummaryTable, ListStockTransactionsRequest>
	{
        private Shelf _shelf;

        //StockTransactionEditorComponent editor = new StockTransactionEditorComponent();
        void InitialEditor()
        {
            //editor = new StockTransactionEditorComponent();
            //editor.ItemAdded += delegate { AddedItems(editor.summary); };
            //editor.ItemUpdated += delegate
            //{
            //    UpdatedItem(editor.summary);
            //    if (_shelf != null)
            //    {
            //        _shelf.Title = SR.TitleAddStockTransaction;
            //    }
            //};

            //editor.IsCloseWhenSaved = false;
        }

        public override void Stop()
        {
            if (_shelf != null)
                _shelf.Close();
            base.Stop();
        }
		public StockTransactionSummaryComponent()
		{
           InitialEditor();
		}

        public StockTransactionSummaryComponent(bool dialogMode)
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

			model.Add.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineTransaction  );
            model.Edit.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineTransaction);
            model.Delete.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineTransaction);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MedicineTransaction);
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
		protected override IList<StockTransactionSummary> ListItems(ListStockTransactionsRequest request)
		{
			ListStockTransactionsResponse _response = null;
			Platform.GetService<IStockTransactionService>(
				delegate(IStockTransactionService service)
				{
					_response = service.ListStockTransactions(request);
				});
			return _response.objSummarys;
		}
        void ShowEditor(bool isNew,string editingName)
        {
            //if (_shelf == null)
            //{
            //    InitialEditor();
            //    _shelf = ApplicationComponent.LaunchAsShelf(
            //        this.Host.DesktopWindow, editor, "", ShelfDisplayHint.DockLeft);
            //    _shelf.Closed += delegate { _shelf = null; };
            //}
            ////editor = (_shelf.Component as DoctorPrescriptionEditorComponent);

            //_shelf.Title  = isNew ? SR.TitleAddStockTransaction : string.Format(SR.TitleUpdateStockTransaction, editingName);
            //editor.IsNew = isNew;
            
            //_shelf.Activate();
        }
		/// <summary>
		/// Called to handle the "add" action.
		/// </summary>
		/// <param name="addedItems"></param>
		/// <returns>True if items were added, false otherwise.</returns>
		protected override bool AddItems(out IList<StockTransactionSummary> addedItems)
		{
            addedItems = new List<StockTransactionSummary>();
            if (DialogMode)
            {
                addedItems = new List<StockTransactionSummary>();
                //var editor = new StockTransactionEditorComponent();
                //var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleAddStockTransaction);
                //if (exitCode == ApplicationComponentExitCode.Accepted)
                //{
                //    addedItems.Add(editor.summary);
                //    return true;
                //}
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
		protected override bool EditItems(IList<StockTransactionSummary> items, out IList<StockTransactionSummary> editedItems)
		{
            StockTransactionSummary item = CollectionUtils.FirstElement(items);
            editedItems = new List<StockTransactionSummary>();
            if (DialogMode)
            {
                var editor = new StockTransactionEditorComponent(item.objRef );
                //var exitCode = LaunchAsDialog(this.Host.DesktopWindow, editor, SR.TitleUpdateStockTransaction);
                //if (exitCode == ApplicationComponentExitCode.Accepted)
                //{
                //    editedItems.Add(editor.summary );
                //    return true;
                //}
                return false;
            }
            else
            {
                //ShowEditor(false, item.Id);
                (_shelf.Component as StockTransactionEditorComponent).StockTransactionRef = item.objRef;

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
		protected override bool DeleteItems(IList<StockTransactionSummary> items, out IList<StockTransactionSummary> deletedItems, out string failureMessage)
		{
			failureMessage = null;
			deletedItems = new List<StockTransactionSummary>();

			foreach (StockTransactionSummary item in items)
			{
				try
				{
					Platform.GetService<IStockTransactionService>(
						delegate(IStockTransactionService service)
						{
							service.DeleteStockTransaction(new DeleteStockTransactionRequest(item.objRef));
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
		protected override bool UpdateItemsActivation(IList<StockTransactionSummary> items, out IList<StockTransactionSummary> editedItems)
		{
			List<StockTransactionSummary> results = new List<StockTransactionSummary>();
			foreach (StockTransactionSummary item in items)
			{
				Platform.GetService<IStockTransactionService>(
					delegate(IStockTransactionService service)
					{
						StockTransactionDetail detail = service.LoadStockTransactionForEdit(
							new LoadStockTransactionForEditRequest(item.objRef)).objDetail;
						detail.Deactivated  = !detail.Deactivated;
						StockTransactionSummary summary = service.UpdateStockTransaction(
							new UpdateStockTransactionRequest(detail)).objSummary;

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
		protected override bool IsSameItem(StockTransactionSummary x, StockTransactionSummary y)
		{
			if (x != null && y != null)
			{
				return x.objRef.Equals(y.objRef, true);
			}
			return false;
		}
	}
}
