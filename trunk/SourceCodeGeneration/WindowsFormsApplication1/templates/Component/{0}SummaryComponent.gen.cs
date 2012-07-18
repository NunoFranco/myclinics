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
using {$CommonNS};
using {$CommonNS}{$Suffix};
using {$CommonNS}.Billing.ServiecInterfaces;
using ClearCanvas.Desktop.Tables;
namespace {$componentNS}
{
	[MenuAction("launch", "global-menus/Admin/Doctor Prescription Template", "Launch")]
	[ActionPermission("launch", {$CommonNS}.AuthorityTokens.Admin.Data.{0})]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class {0}Tool : Tool<IDesktopToolContext>
	{
		private IWorkspace _workspace;

		public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    {0}SummaryComponent component = new {0}SummaryComponent();

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
	/// Extension point for views onto <see cref="{0}SummaryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class {0}SummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

    public class {0}SummaryTable : Table<{0}Summary>
    {
        private readonly int columnSortIndex = 0;
        public static string PrimaryCurrencyCode = "";
        public static string PrimaryLocale = "";
        public static string Customeformat = "";
        void InitTableViewFormat()
        {
            //{$CommonNS}.Billing.CurrencyDetail detail = null;
            //Common.Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
            //{
            //    {$CommonNS}.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new {$CommonNS}.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
            //    request.IsListDetail = true;
            //    request.IsPrimaryCurrency = true;
            //    List<{$CommonNS}.Billing.CurrencyDetail> lst = service.ListAllCurrency(request).Details;
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
        public {0}SummaryTable()
        {
            //InitTableViewFormat();
			{1}
          
            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }


	/// <summary>
	/// {0}SummaryComponent class.
	/// </summary>
	[AssociateView(typeof({0}SummaryComponentViewExtensionPoint))]
	public partial class {0}SummaryComponent : SummaryComponentBase<{0}Summary, {0}SummaryTable, List{0}sRequest>
	{
        private Shelf _shelf;

        {0}EditorComponent editor = new {0}EditorComponent();
        void InitialEditor()
        {
            editor = new {0}EditorComponent();
            editor.ItemAdded += delegate { AddedItems(editor.summary); };
            editor.ItemUpdated += delegate { 
                UpdatedItem(editor.summary);
                if (_shelf != null)
                {
                    _shelf.Title = SR.TitleAdd{0};
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
		public {0}SummaryComponent()
		{
           InitialEditor();
		}

        public {0}SummaryComponent(bool dialogMode)
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

			model.Add.SetPermissibility({$CommonNS}.AuthorityTokens.Admin.Data.{0} );
            model.Edit.SetPermissibility({$CommonNS}.AuthorityTokens.Admin.Data.{0});
            model.Delete.SetPermissibility({$CommonNS}.AuthorityTokens.Admin.Data.{0});
            model.ToggleActivation.SetPermissibility({$CommonNS}.AuthorityTokens.Admin.Data.{0});
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
		protected override IList<{0}Summary> ListItems(List{0}sRequest request)
		{
			List{0}sResponse _response = null;
			Platform.GetService<I{0}Service>(
				delegate(I{0}Service service)
				{
					_response = service.List{0}s(request);
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

            _shelf.Title  = isNew ? SR.TitleAdd{0} : string.Format(SR.TitleUpdate{0}, editingName);
            editor.IsNew = isNew;
            
            _shelf.Activate();
        }
		/// <summary>
		/// Called to handle the "add" action.
		/// </summary>
		/// <param name="addedItems"></param>
		/// <returns>True if items were added, false otherwise.</returns>
		protected override bool AddItems(out IList<{0}Summary> addedItems)
		{
            ShowEditor(true,"" );
            return true;
		}

		/// <summary>
		/// Called to handle the "edit" action.
		/// </summary>
		/// <param name="items">A list of items to edit.</param>
		/// <param name="editedItems">The list of items that were edited.</param>
		/// <returns>True if items were edited, false otherwise.</returns>
		protected override bool EditItems(IList<{0}Summary> items, out IList<{0}Summary> editedItems)
		{
            {0}Summary item = CollectionUtils.FirstElement(items);
            ShowEditor(false,item.Name );
            (_shelf.Component as {0}EditorComponent).{0}Ref = item.objRef;

            return true;
		}

		/// <summary>
		/// Called to handle the "delete" action, if supported.
		/// </summary>
		/// <param name="items"></param>
		/// <param name="deletedItems">The list of items that were deleted.</param>
		/// <param name="failureMessage">The message if there any errors that occurs during deletion.</param>
		/// <returns>True if items were deleted, false otherwise.</returns>
		protected override bool DeleteItems(IList<{0}Summary> items, out IList<{0}Summary> deletedItems, out string failureMessage)
		{
			failureMessage = null;
			deletedItems = new List<{0}Summary>();

			foreach ({0}Summary item in items)
			{
				try
				{
					Platform.GetService<I{0}Service>(
						delegate(I{0}Service service)
						{
							service.Delete{0}(new Delete{0}Request(item.{0}Ref));
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
		protected override bool UpdateItemsActivation(IList<{0}Summary> items, out IList<{0}Summary> editedItems)
		{
			List<{0}Summary> results = new List<{0}Summary>();
			foreach ({0}Summary item in items)
			{
				Platform.GetService<I{0}Service>(
					delegate(I{0}Service service)
					{
						{0}Detail detail = service.Load{0}ForEdit(
							new Load{0}ForEditRequest(item.{0}Ref)).objDetail;
						detail.Deactivated  = !detail.Deactivated;
						{0}Summary summary = service.Update{0}(
							new Update{0}Request(detail)).objSummary;

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
		protected override bool IsSameItem({0}Summary x, {0}Summary y)
		{
			if (x != null && y != null)
			{
				return x.{0}Ref.Equals(y.{0}Ref, true);
			}
			return false;
		}
	}
}
