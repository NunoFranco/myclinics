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

using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Enterprise.Desktop;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Client.Billing.TableView;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
namespace ClearCanvas.Ris.Client.Billing
{
    /// <summary>
    /// Extension point for views onto <see cref="BillingCurrencyManagerComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingCurrencyManagerComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingCurrencyManagerComponent class.
    /// </summary>
    [AssociateView(typeof(BillingCurrencyManagerComponentViewExtensionPoint))]
    public class BillingCurrencyManagerComponent : SummaryComponentBase<CurrencySummary, CurrencySummaryTable, ListCurrencyRequest>
    {

        public string CurrencyCode
        {
            get;
            set;
        }

        public string CurrencyName
        {
            get;
            set;
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingCurrencyManagerComponent()
        {
        }

        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            // TODO prepare the component for its live phase
            base.Start();
        }

        /// <summary>
        /// Called by the host when the application component is being terminated.
        /// </summary>
        public override void Stop()
        {
            // TODO prepare the component to exit the live phase
            // This is a good place to do any clean up
            base.Stop();
        }
        /// <summary>
        /// Override this method to perform custom initialization of the action model,
        /// such as adding permissions or adding custom actions.
        /// </summary>
        /// <param name="model"></param>
        protected override void InitializeActionModel(AdminActionModel model)
        {
            base.InitializeActionModel(model);

            model.Add.SetPermissibility(ClearCanvas.Ris.Application.Common.Billing.AuthorityTokens.Billing.Admin.BillingManageCurrency);
            model.Edit.SetPermissibility(ClearCanvas.Ris.Application.Common.Billing.AuthorityTokens.Billing.Admin.BillingManageCurrency);
            model.Delete.SetPermissibility(ClearCanvas.Ris.Application.Common.Billing.AuthorityTokens.Billing.Admin.BillingManageCurrency);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Ris.Application.Common.Billing.AuthorityTokens.Billing.Admin.BillingManageCurrency);
        }
        protected override bool SupportsDelete
        {
            get { return true; }
        }


        /// <summary>
        /// Gets the list of items to show in the table, according to the specifed first and max items.
        /// </summary>
        /// <returns></returns>
        protected override IList<CurrencySummary> ListItems(ListCurrencyRequest request)
        {
            ListCurrencyResponse listResponse = null;
            Platform.GetService<ICurrencyService>(
                delegate(ICurrencyService service)
                {
                    request.Code = CurrencyCode;
                    request.Name = CurrencyName;
                    listResponse = service.ListAllCurrency(request);
                });
            return listResponse.Currency;
        }


        /// <summary>
        /// Called to handle the "add" action.
        /// </summary>
        /// <param name="addedItems"></param>
        /// <returns>True if items were added, false otherwise.</returns>
        protected override bool AddItems(out IList<CurrencySummary> addedItems)
        {
            addedItems = new List<CurrencySummary>();
            BillingCurrencyEditComponent editor = new BillingCurrencyEditComponent();
            ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
                this.Host.DesktopWindow, editor, SR.TitleAddCurrency);
            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                addedItems.Add(editor.objectSummary);
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
        protected override bool EditItems(IList<CurrencySummary> items, out IList<CurrencySummary> editedItems)
        {
            editedItems = new List<CurrencySummary>();
            CurrencySummary item = CollectionUtils.FirstElement(items);

            BillingCurrencyEditComponent editor = new BillingCurrencyEditComponent(item.CurrencyRef);
            ApplicationComponentExitCode exitCode = LaunchAsDialog(
                this.Host.DesktopWindow, editor, SR.TitleUpdateCurrency + " - " + "(" + item.CurrencyCode + ") " + item.CurrencyName);
            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                editedItems.Add(editor.objectSummary);
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
        protected override bool DeleteItems(IList<CurrencySummary> items, out IList<CurrencySummary> deletedItems, out string failureMessage)
        {
            failureMessage = null;
            deletedItems = new List<CurrencySummary>();
            

            foreach (CurrencySummary item in items)
            {
                if (item.IsPrimaryCurrency || item.IsPrimaryExRateCurrency)
                {
                    Platform.ShowMessageBox(SR.CurrencyDeleteError);
                    return false;
                }
                try
                {
                    Platform.GetService<ICurrencyService>(
                        delegate(ICurrencyService service)
                        {
                            service.DeleteCurrencyDetail(new DeleteCurrencyRequest(item.CurrencyRef));
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
        protected override bool UpdateItemsActivation(IList<CurrencySummary> items, out IList<CurrencySummary> editedItems)
        {
            List<CurrencySummary> results = new List<CurrencySummary>();
            foreach (CurrencySummary item in items)
            {
                Platform.GetService<ICurrencyService>(
                    delegate(ICurrencyService service)
                    {
                        CurrencyDetail detail = service.LoadCurrencyForedit(new LoadCurrencyEditRequest(item.CurrencyRef)).CurrencyDetail;
                        detail.Deactivated = !detail.Deactivated;
                        CurrencySummary summary = service.UpdateCurrency(
                            new UpdateCurrencyRequest(detail)).ObjectSummary;

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
        protected override bool IsSameItem(CurrencySummary x, CurrencySummary y)
        {
            if (x != null && y != null)
            {
                return x.CurrencyRef.Equals(y.CurrencyRef, true);
            }
            return false;
        }
    }
}
