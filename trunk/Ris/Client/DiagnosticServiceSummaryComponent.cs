﻿#region License

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
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Enterprise.Desktop;
using ClearCanvas.Ris.Client;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.DiagnosticServiceAdmin;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;

namespace ClearCanvas.Ris.Client
{
    [MenuAction("launch", "global-menus/Admin/Imaging Services", "Launch")]
    [ActionPermission("launch", ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DiagnosticService)]
    [ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class DiagnosticServiceAdminTool : Tool<IDesktopToolContext>
    {
        private IWorkspace _workspace;

        public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    DiagnosticServiceSummaryComponent component = new DiagnosticServiceSummaryComponent();

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        "Imaging Services");
                    _workspace.Closed += delegate { _workspace = null; };

                }
                catch (Exception e)
                {
                    // failed to launch component
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
    /// Extension point for views onto <see cref="DiagnosticServiceSummaryComponent"/>
    /// </summary>
    [ExtensionPoint]
    public class DiagnosticServiceSummaryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    public class DiagnosticServiceSummaryTable : Table<DiagnosticServiceSummary>
    {
        private readonly int columnSortIndex = 0;

        public static string PrimaryCurrencyCode = "";
        public static string PrimaryLocale = "";
        public static string Customeformat = "";
        void InitTableViewFormat()
        {
            ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail detail = null;
            Common.Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
            {
                ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
                request.IsListDetail = true;
                request.IsPrimaryCurrency = true;
                List<ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail> lst = service.ListAllCurrency(request).Details;
                if (lst != null && lst.Count > 0)
                    detail = lst[0];
            });
            if (detail != null)
            {
                PrimaryLocale = detail.DisplayLocale;
                Customeformat = detail.CustomDisplayFormat;
                PrimaryCurrencyCode = detail.CurrencyCode;
            }
        }
        public DiagnosticServiceSummaryTable()
        {
            InitTableViewFormat();
            this.Columns.Add(new TableColumn<DiagnosticServiceSummary, string>("ID",
                                                                               delegate(DiagnosticServiceSummary rpt) { return rpt.Id; },
                                                                               0.2f));

            this.Columns.Add(new TableColumn<DiagnosticServiceSummary, string>("Name",
                                                                               delegate(DiagnosticServiceSummary rpt) { return rpt.Name; },
                                                                               1.0f));

            this.Columns.Add(new TableColumn<DiagnosticServiceSummary, bool>(SR.IsPackageProcedure,
              delegate(DiagnosticServiceSummary summary) { return summary.IsPackageProcedure; },
              0.5f));
            this.Columns.Add(new TableColumn<DiagnosticServiceSummary, string>(string.Format(SR.ColumnPackageprice, PrimaryCurrencyCode),
              delegate(DiagnosticServiceSummary summary) { return NumberUtils.GetCurrencyDisplayFormat(PrimaryLocale, Customeformat, summary.PackagePrice); },
              0.5f));

            this.Columns.Add(new TableColumn<DiagnosticServiceSummary, bool?>(SR.ColumnIsAutoUpdate,
              delegate(DiagnosticServiceSummary summary) { return summary.IsAutoUpdatePrice; },
              0.5f));

            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }

    /// <summary>
    /// DiagnosticServiceSummaryComponent class.
    /// </summary>
    [AssociateView(typeof(DiagnosticServiceSummaryComponentViewExtensionPoint))]
    public class DiagnosticServiceSummaryComponent : SummaryComponentBase<DiagnosticServiceSummary, DiagnosticServiceSummaryTable, ListDiagnosticServicesRequest>
    {
        private string _id;
        private string _name;

        public DiagnosticServiceSummaryComponent()
        {

        }

        public DiagnosticServiceSummaryComponent(bool dialogMode)
            : base(dialogMode)
        {

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

        #endregion


        /// <summary>
        /// Override this method to perform custom initialization of the action model,
        /// such as adding permissions or adding custom actions.
        /// </summary>
        /// <param name="model"></param>
        protected override void InitializeActionModel(AdminActionModel model)
        {
            base.InitializeActionModel(model);

            model.Add.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DiagnosticService);
            model.Edit.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DiagnosticService);
            model.Delete.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DiagnosticService);
            model.ToggleActivation.SetPermissibility(ClearCanvas.Ris.Application.Common.AuthorityTokens.Admin.Data.DiagnosticService);
        }

        protected override bool SupportsDelete
        {
            get { return true; }
        }

        public static bool UpdatePackagePrice()
        {
            try
            {
                ListDiagnosticServicesRequest request = new ListDiagnosticServicesRequest();
                ListDiagnosticServicesResponse listResponse = null;
                Platform.GetService<IDiagnosticServiceAdminService>(
                    delegate(IDiagnosticServiceAdminService service)
                    {
                        listResponse = service.ListDiagnosticServices(request);
                    });
                foreach (var item in listResponse.DiagnosticServices)
                {
                    if (item.IsPackageProcedure && item.IsAutoUpdatePrice == true)
                    {
                        UpdateDiagnosticTotalPrice(item);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Platform.ShowMessageBox(ex.Message);
                Platform.Log(LogLevel.Error, ex);
            }
            return false;
        }
        public static void UpdateDiagnosticTotalPrice(DiagnosticServiceSummary summary)
        {

            Platform.GetService<IDiagnosticServiceAdminService>(
                            delegate(IDiagnosticServiceAdminService service)
                            {
                                DiagnosticServiceDetail detail = service.LoadDiagnosticServiceForEdit(
                                    new LoadDiagnosticServiceForEditRequest(summary.DiagnosticServiceRef)).DiagnosticService;
                                decimal totalPrice = 0;
                                foreach (var item in detail.ProcedureTypes)
                                {
                                    totalPrice += item.BasePrice + (item.Tax / 100 * item.BasePrice);// -item.AfterDiscountPrice - item.AfterInsurancePrice;
                                }
                                detail.PackagePrice = totalPrice;
                                service.UpdateDiagnosticService(new UpdateDiagnosticServiceRequest(detail));
                            });
        }
        /// <summary>
        /// Gets the list of items to show in the table, according to the specifed first and max items.
        /// </summary>
        /// <returns></returns>
        protected override IList<DiagnosticServiceSummary> ListItems(ListDiagnosticServicesRequest request)
        {
            ListDiagnosticServicesResponse listResponse = null;
            Platform.GetService<IDiagnosticServiceAdminService>(
                delegate(IDiagnosticServiceAdminService service)
                {
                    request.Id = _id;
                    request.Name = _name;
                    listResponse = service.ListDiagnosticServices(request);
                });
            return listResponse.DiagnosticServices;
        }


        /// <summary>
        /// Called to handle the "add" action.
        /// </summary>
        /// <param name="addedItems"></param>
        /// <returns>True if items were added, false otherwise.</returns>
        protected override bool AddItems(out IList<DiagnosticServiceSummary> addedItems)
        {
            addedItems = new List<DiagnosticServiceSummary>();
            DiagnosticServiceEditorComponent editor = new DiagnosticServiceEditorComponent();
            ApplicationComponentExitCode exitCode = ApplicationComponent.LaunchAsDialog(
                this.Host.DesktopWindow, editor, SR.TitleAddDiagnosticService);
            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                addedItems.Add(editor.DiagnosticServiceSummary);
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
        protected override bool EditItems(IList<DiagnosticServiceSummary> items, out IList<DiagnosticServiceSummary> editedItems)
        {
            editedItems = new List<DiagnosticServiceSummary>();
            DiagnosticServiceSummary item = CollectionUtils.FirstElement(items);

            DiagnosticServiceEditorComponent editor = new DiagnosticServiceEditorComponent(item.DiagnosticServiceRef);
            ApplicationComponentExitCode exitCode = LaunchAsDialog(
                this.Host.DesktopWindow, editor, SR.TitleUpdateDiagnosticService + " - " + "(" + item.Id + ") " + item.Name);
            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                editedItems.Add(editor.DiagnosticServiceSummary);
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
        protected override bool DeleteItems(IList<DiagnosticServiceSummary> items, out IList<DiagnosticServiceSummary> deletedItems, out string failureMessage)
        {
            failureMessage = null;
            deletedItems = new List<DiagnosticServiceSummary>();

            foreach (DiagnosticServiceSummary item in items)
            {
                try
                {
                    Platform.GetService<IDiagnosticServiceAdminService>(
                        delegate(IDiagnosticServiceAdminService service)
                        {
                            service.DeleteDiagnosticService(new DeleteDiagnosticServiceRequest(item.DiagnosticServiceRef));
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
        protected override bool UpdateItemsActivation(IList<DiagnosticServiceSummary> items, out IList<DiagnosticServiceSummary> editedItems)
        {
            List<DiagnosticServiceSummary> results = new List<DiagnosticServiceSummary>();
            foreach (DiagnosticServiceSummary item in items)
            {
                Platform.GetService<IDiagnosticServiceAdminService>(
                    delegate(IDiagnosticServiceAdminService service)
                    {
                        DiagnosticServiceDetail detail = service.LoadDiagnosticServiceForEdit(
                            new LoadDiagnosticServiceForEditRequest(item.DiagnosticServiceRef)).DiagnosticService;
                        detail.Deactivated = !detail.Deactivated;
                        DiagnosticServiceSummary summary = service.UpdateDiagnosticService(
                            new UpdateDiagnosticServiceRequest(detail)).DiagnosticService;

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
        protected override bool IsSameItem(DiagnosticServiceSummary x, DiagnosticServiceSummary y)
        {
            if (x != null && y != null)
            {
                return x.DiagnosticServiceRef.Equals(y.DiagnosticServiceRef, true);
            }
            return false;
        }
    }
}