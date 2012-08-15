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
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Ris.Client;
using ClearCanvas.Material.Application.Common.StockTransactions;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Material.Application.Common.Contacts;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Material.Application.Common.MaterialLots;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Material.Application.Common.StockTransactionLines;
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Material.Application.Common.Warehouses;
using ClearCanvas.Healthcare;

namespace ClearCanvas.Material.Client
{

    [MenuAction("launch", "global-menus/Materials/In-stocking Medicines", "Launch")]
    [ActionPermission("launch", ClearCanvas.Material.Application.Common.AuthorityTokens.Admin.Data.MaterialLot)]
    [ExtensionOf(typeof(DesktopToolExtensionPoint))]
    public class InputStockMaterialTool : Tool<IDesktopToolContext>
    {
        private IWorkspace _workspace;

        public void Launch()
        {
            if (_workspace == null)
            {
                try
                {
                    EnumValueInfo type = new EnumValueInfo();
                    type.Code = ClearCanvas.Material.Healthcare.StockTransactionType.INS.ToString();
                    type.ClinicOID = LoginSession.Current.WorkingFacility.OID;
                    StockTransactionEditorComponent component = new StockTransactionEditorComponent(type);

                    _workspace = ApplicationComponent.LaunchAsWorkspace(
                        this.Context.DesktopWindow,
                        component,
                        SR.ToolInstockingMedicine);
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
    public class TransactionLineSummaryTable : Table<StockTransactionLineSummary>
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
        public TransactionLineSummaryTable(List<ProcedureTypeSummary> materialDataSource)
        {
            //InitTableViewFormat();

            ITableColumn IdColumn = new TableColumn<StockTransactionLineDetail, ProcedureTypeSummary>(SR.TitleTransactionLineCodeColumn,
               delegate(StockTransactionLineDetail obj)
               {
                   return obj.Material;
               },
               delegate(StockTransactionLineDetail obj, ProcedureTypeSummary value)
               {
                   obj.Material = value;
               },
               0.5f);
            IdColumn.LookupItemsDataSource = materialDataSource;
            this.Columns.Add(IdColumn);


            this.Columns.Add(new TableColumn<StockTransactionLineSummary, string>(SR.TitleTransactionLineNameColumn,
                           delegate(StockTransactionLineSummary obj)
                           {
                               if (obj.Material == null)
                                   return "";
                               return obj.Material.Name;
                           },
                           0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineSummary, string>(SR.TitleTransactionLineUOMColumn,
                           delegate(StockTransactionLineSummary obj)
                           {
                               if (obj.UOM == null)
                                   return "";
                               return obj.UOM.Code;
                           },
                           0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineSummary, double?>(SR.TitleTransactionLineAmountColumn,
                           delegate(StockTransactionLineSummary obj)
                           {
                               if (obj.Amount == null || Convert.IsDBNull(obj.Amount))
                                   return 0;
                               return obj.Amount;
                           },
                           delegate(StockTransactionLineSummary summary, double? value)
                           {
                               if (value.HasValue)
                                   summary.Amount = value.Value;
                           }
                           ,
                           0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineSummary, double?>(SR.TitleTransactionLineInputPriceColumn,
                                       delegate(StockTransactionLineSummary obj)
                                       {
                                           if (obj.InputPrice == null || Convert.IsDBNull(obj.InputPrice))
                                               return 0;
                                           return obj.InputPrice;
                                       },
                                       delegate(StockTransactionLineSummary summary, double? value)
                                       {
                                           if (value.HasValue)
                                               summary.InputPrice = value.Value;
                                       }
                                       ,
                                       0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineSummary, double?>(SR.TitleTransactionLineTaxColumn,
                                      delegate(StockTransactionLineSummary obj)
                                      {
                                          if (obj.Tax == null || Convert.IsDBNull(obj.Tax))
                                              return 0;
                                          return obj.Tax;
                                      },
                                       delegate(StockTransactionLineSummary summary, double? value)
                                       {
                                           if (value.HasValue)
                                               summary.Tax = value.Value;
                                       },
                                      0.5f));
            this.Columns.Add(new DateTimeTableColumn<StockTransactionLineSummary>(SR.TitleTransactionLineExpireDateColumn,
                                       delegate(StockTransactionLineSummary obj) { return obj.ExpireDate; },
                                       0.5f));

            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }

    public class TransactionLineDetailTable : Table<StockTransactionLineDetail>
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
        public TransactionLineDetailTable()
        {
            //InitTableViewFormat();

            ITableColumn IdColumn = new TableColumn<StockTransactionLineDetail, ProcedureTypeSummary>(SR.TitleTransactionLineCodeColumn,
               delegate(StockTransactionLineDetail obj)
               {
                   return obj.Material;
               },
               delegate(StockTransactionLineDetail obj, ProcedureTypeSummary value)
               {
                   obj.Material = value;
               },
               0.5f);
            this.Columns.Add(IdColumn);
            this.Columns.Add(new TableColumn<StockTransactionLineDetail, string>(SR.TitleTransactionLineNameColumn,
                           delegate(StockTransactionLineDetail obj)
                           {
                               if (obj.Material == null)
                                   return "";
                               return obj.Material.Name;
                           },
                           0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineDetail, string>(SR.TitleTransactionLineUOMColumn,
                           delegate(StockTransactionLineDetail obj)
                           {
                               if (obj.UOM == null)
                                   return "";
                               return obj.UOM.Code;
                           },
                           0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineDetail, double?>(SR.TitleTransactionLineAmountColumn,
                           delegate(StockTransactionLineDetail obj)
                           {
                               if (obj.Amount == null || Convert.IsDBNull(obj.Amount))
                                   return 0;
                               return obj.Amount;
                           },
                           delegate(StockTransactionLineDetail summary, double? value)
                           {
                               if (value.HasValue)
                                   summary.Amount = value.Value;
                           }
                           ,
                           0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineDetail, double?>(SR.TitleTransactionLineInputPriceColumn,
                                       delegate(StockTransactionLineDetail obj)
                                       {
                                           if (obj.InputPrice == null || Convert.IsDBNull(obj.InputPrice))
                                               return 0;
                                           return obj.InputPrice;
                                       },
                                       delegate(StockTransactionLineDetail summary, double? value)
                                       {
                                           if (value.HasValue)
                                               summary.InputPrice = value.Value;
                                       }
                                       ,
                                       0.5f));
            this.Columns.Add(new TableColumn<StockTransactionLineDetail, double?>(SR.TitleTransactionLineTaxColumn,
                                      delegate(StockTransactionLineDetail obj)
                                      {
                                          if (obj.Tax == null || Convert.IsDBNull(obj.Tax))
                                              return 0;
                                          return obj.Tax;
                                      },
                                       delegate(StockTransactionLineDetail summary, double? value)
                                       {
                                           if (value.HasValue)
                                               summary.Tax = value.Value;
                                       },
                                      0.5f));
            this.Columns.Add(new DateTimeTableColumn<StockTransactionLineDetail>(SR.TitleTransactionLineExpireDateColumn,
                                       delegate(StockTransactionLineDetail obj) { return obj.ExpireDate; },
                                       0.5f));

            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }
    }
    /// <summary>
    /// Extension point for views onto <see cref="Instock_Medicine"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class Instock_MedicineViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// Instock_Medicine class.
    /// </summary>
    [AssociateView(typeof(Instock_MedicineViewExtensionPoint))]
    public class StockTransactionEditorComponent : ApplicationComponent
    {
        public ILookupHandler supplierlookup;
        public ILookupHandler materilLotLookup;
        public ILookupHandler medicineLookup;
        public ILookupHandler inWareHouseLookup;
        public ILookupHandler outWareHouseLookup;

        public event EventHandler ItemAdded;
        public event EventHandler ItemUpdated;
        public bool IsCloseWhenSaved { get; set; }
        private EntityRef _ref;
        private StockTransactionDetail _detail;
        private bool _isNew;
        private TransactionLineSummaryTable _lines;
        private StockTransactionSummary _summary;
        private List<StockTransactionSummary> _baseTypeChoices;
        private EnumValueInfo _type;
        private CrudActionModel _LineitemModel;
        public StockTransactionEditorComponent(EnumValueInfo transactionType)
        {
            _isNew = true;
            _type = transactionType;
        }
        public StockTransactionEditorComponent(EntityRef objRef)
        {
            _ref = objRef;
            _isNew = false;

        }

        public CrudActionModel LineItemAction { get { return _LineitemModel; } }
        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                _isNew = value;
                ResetNew();
            }
        }
        void ResetNew()
        {
            _detail = new StockTransactionDetail();
            ReBindData();
        }
        public EntityRef StockTransactionRef
        {
            get { return _ref; }
            set
            {
                _ref = value;
                _isNew = false;
                Platform.GetService<IStockTransactionService>(
                                 delegate(IStockTransactionService service)
                                 {
                                     LoadStockTransactionForEditResponse response = service.LoadStockTransactionForEdit(
                                         new LoadStockTransactionForEditRequest(_ref));
                                     _detail = response.objDetail;
                                     //ItemsTable.Items.Clear();
                                     //ItemsTable.Items.AddRange(_detail.Medicines);
                                 });
                ReBindData();
            }
        }
        public void ReBindData()
        {

            _lines.Items.Clear();
            _currentAdding = new StockTransactionLineSummary();

            NotifyPropertyChanged("Code");
            NotifyPropertyChanged("Description");
            NotifyPropertyChanged("TransactionDate");
            NotifyPropertyChanged("Deactivated");
            NotifyPropertyChanged("SelectMedicine");
            NotifyPropertyChanged("SelectedMedicineLot");
            NotifyPropertyChanged("SelectedLine");
            NotifyPropertyChanged("InputPrice");
            NotifyPropertyChanged("Amount");
            NotifyPropertyChanged("ExpireDate");
            NotifyPropertyChanged("Tax");
            NotifyPropertyChanged("InWareHouse");
            NotifyPropertyChanged("OutWareHouse");

            _isNew = true;
            this.Modified = false;
            NotifyAllPropertiesChanged();
        }
        ///// <summary>
        ///// Constructor.
        ///// </summary>
        //public StockTransactionEditorComponent()
        //{
        //    _isNew = true;

        //}

        //public StockTransactionEditorComponent(EntityRef _objRef)
        //{
        //    _isNew = false;
        //    _ref = _objRef;

        //}

        /// <summary>
        /// After editing is complete, gets the summary of the created/edited procedure type.
        /// </summary>
        public StockTransactionSummary summary
        {
            get { return _summary; }
        }


        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {

            Platform.GetService<IStockTransactionService>(
                delegate(IStockTransactionService service)
                {
                    LoadStockTransactionEditFormDataRequest request = new LoadStockTransactionEditFormDataRequest();
                    request.MaterialCategories.Add(new EnumValueInfo(ProcedureTypeCategory.ME.ToString(), "", LoginSession.Current.WorkingFacility.OID));

                    LoadStockTransactionEditFormDataResponse Loaddataresponse = service.LoadStockTransactionEditorFormData(request);
                    _lines = new TransactionLineSummaryTable(Loaddataresponse.Materials);
                    if (_isNew)
                    {
                        _detail = new StockTransactionDetail();
                        _detail.TransactionType = _type;
                    }
                    else
                    {
                        LoadStockTransactionForEditResponse response = service.LoadStockTransactionForEdit(new LoadStockTransactionForEditRequest(_ref));
                        _detail = response.objDetail;
                        _type = _detail.TransactionType;
                        _lines.Items.Clear();
                        _lines.Items.AddRange(_detail.Details);
                    }
                });
            _LineitemModel = new CrudActionModel(true, false, true);

            _LineitemModel.Add.SetClickHandler(AddLineItem);
            //_LineitemModel.Edit.SetClickHandler(EditLineItem);
            _LineitemModel.Delete.SetClickHandler(DeleteLineItem);
            UpdateActionMenu();
            supplierlookup = new ContactLookupHandler(this.Host.DesktopWindow);
            materilLotLookup = new MaterialLotLookupHandler(this.Host.DesktopWindow);
            inWareHouseLookup = new WareHouseLookupHandler(this.Host.DesktopWindow);
            outWareHouseLookup = new WareHouseLookupHandler(this.Host.DesktopWindow);
            List<ClearCanvas.Healthcare.ProcedureTypeCategory> types = new List<ClearCanvas.Healthcare.ProcedureTypeCategory>();
            types.Add(ClearCanvas.Healthcare.ProcedureTypeCategory.ME);
            //types.Add(ClearCanvas.Healthcare.ProcedureTypeCategory.EQ);
            medicineLookup = new ProcedureTypeLookupHandler(this.Host.DesktopWindow, types);

            base.Start();
        }
        public void UpdateActionMenu()
        {
            //_LineitemModel.Edit.Enabled = _selectedLine != null;
            _LineitemModel.Delete.Enabled = _selectedLine != null;

        }
        public void AddLineItem()
        {
            //_isNew = true;
            //_currentAdding = new StockTransactionLineSummary();
            StockTransactionLineSummary item = new StockTransactionLineSummary();
            _lines.Items.Add(item);
            NotifyAllPropertiesChanged();
        }
        public void EditLineItem()
        {
            //_isNew = false;
            //_currentAdding = _selectedLine;
            //NotifyCurrentLineItemChanged();
        }
        public void DeleteLineItem()
        {
            _lines.Items.Remove(_selectedLine);
            NotifyAllPropertiesChanged();
        }
        /// <summary>
        /// Called by the host when the application component is being terminated.
        /// </summary>
        public override void Stop()
        {


            base.Stop();
        }

        #region Presentation Model
        ContactSummary _selectedsupplier;
        //[ValidateNotNull]
        //public ContactSummary SelectedSupplier
        //{
        //    get
        //    {
        //        return _selectedsupplier;
        //    }
        //    set
        //    {
        //        _selectedsupplier = value;
        //        this.Modified = true;
        //        NotifyPropertyChanged("SelectedSupplier");
        //    }
        //}

        private ProcedureTypeSummary _selectedMedicine;

        [ValidateNotNull]
        public ProcedureTypeSummary SelectMedicine
        {
            get
            {
                return _selectedMedicine;
            }
            set
            {
                _selectedMedicine = value;
                this.Modified = true;
                NotifyPropertyChanged("SelectMedicine");
            }
        }
        MaterialLotSummary _lots;
        [ValidateNotNull]
        public MaterialLotSummary SelectedMedicineLot
        {
            get
            {
                return _detail.EquipmentLot;
            }
            set
            {
                _detail.EquipmentLot = value;
                this.Modified = true;
                NotifyPropertyChanged("SelectedMedicineLot");
            }
        }

        StockTransactionLineSummary _selectedLine;
        public ISelection SelectedLine
        {
            get { return new Selection(_selectedLine); }
            set
            {
                //if (value.Item != _selectedLine && value.Item != null )
                //{
                _selectedLine = (StockTransactionLineSummary)value.Item;
                this.Modified = true;
                UpdateActionMenu();
                NotifyPropertyChanged("SelectedLine");
                //}
            }
        }
        private StockTransactionLineSummary _currentEditing = new StockTransactionLineSummary();
        public StockTransactionLineSummary CurrentEditingItem
        {
            get { return _currentEditing; }
            set { _currentEditing = value; }
        }
        private StockTransactionLineSummary _currentAdding = new StockTransactionLineSummary();
        public StockTransactionLineSummary CurrentAddingItem
        {
            get { return _currentAdding; }
            set { _currentAdding = value; }
        }

        public double InputPrice
        {
            get
            {
                return _currentAdding.InputPrice;
            }
            set
            {
                _currentAdding.InputPrice = value;
                this.Modified = true;
                NotifyPropertyChanged("InputPrice");
            }
        }
        public double Amount
        {
            get
            {
                return _currentAdding.Amount;
            }
            set
            {
                _currentAdding.Amount = value;
                this.Modified = true;
                NotifyPropertyChanged("Amount");
            }
        }
        public DateTime? ExpireDate
        {
            get
            {
                return _currentAdding.ExpireDate;
            }
            set
            {
                _currentAdding.ExpireDate = value;
                this.Modified = true;
                NotifyPropertyChanged("ExpireDate");
            }
        }
        public double Tax
        {
            get
            {
                return _currentAdding.Tax;
            }
            set
            {
                _currentAdding.Tax = value;
                this.Modified = true;
                NotifyPropertyChanged("Tax");
            }
        }

        public TransactionLineSummaryTable Lines
        {
            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
            }
        }
        public string Code
        {
            get
            {
                return _detail.Code;
            }
            set
            {
                if (_detail.Code == value)
                    return;
                this.Modified = true;
                _detail.Code = value;
                NotifyPropertyChanged("Code");
            }
        }
        public WarehouseSummary InWareHouse
        {
            get
            {
                return _detail.InWarehouse;
            }
            set
            {
                if (_detail.InWarehouse == value)
                    return;

                _detail.InWarehouse = value;
                this.Modified = true;
                NotifyPropertyChanged("InWareHouse");
            }
        }
        public WarehouseSummary OutWareHouse
        {
            get
            {
                return _detail.OutWarehouse;
            }
            set
            {
                if (_detail.OutWarehouse == value)
                    return;

                _detail.OutWarehouse = value;
                this.Modified = true;
                NotifyPropertyChanged("OutWareHouse");
            }
        }
        public double CurrentQuantity
        {
            get
            {
                if (SelectMedicine == null)
                    return 0;
                return SelectMedicine.CurrentQuantity;
            }
        }
        public string UOM
        {
            get
            {
                if (SelectMedicine == null)
                    return "";
                return SelectMedicine.UOM.Value;
            }
        }
        public string MedicineDose
        {
            get
            {
                if (SelectMedicine == null)
                    return "";
                return SelectMedicine.MedicinesDose;
            }
        }

        public string Description
        {
            get
            {
                return _detail.Description;
            }
            set
            {
                if (_detail.Description == value)
                    return;
                this.Modified = true;
                _detail.Description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public DateTime? TransactionDate
        {
            get
            {
                return _detail.TransactionDate;
            }
            set
            {
                if (_detail.TransactionDate == value)
                    return;
                this.Modified = true;
                _detail.TransactionDate = value;
                NotifyPropertyChanged("TransactionDate");
            }
        }

        public bool Deactivated
        {
            get
            {
                return _detail.Deactivated;
            }
            set
            {
                if (_detail.Deactivated == value)
                    return;
                this.Modified = true;
                _detail.Deactivated = value;
                NotifyPropertyChanged("Deactivated");
            }
        }



        public bool AcceptEnabled
        {
            get { return this.Modified; }
        }

        public event EventHandler AcceptEnabledChanged
        {
            add { this.ModifiedChanged += value; }
            remove { this.ModifiedChanged -= value; }
        }

        public void Accept()
        {

            if (this.HasValidationErrors)
            {
                this.ShowValidation(true);
                return;
            }
            else
            {
                try
                {
                    SaveChanges();
                    if (IsCloseWhenSaved)
                        this.Exit(ApplicationComponentExitCode.Accepted);
                }
                catch (Exception e)
                {
                    ExceptionHandler.Report(e, SR.ExceptionSave, this.Host.DesktopWindow,
                        delegate
                        {
                            this.Exit(ApplicationComponentExitCode.Error);
                        });
                }
            }
        }



        public void Cancel()
        {
            this.Exit(ApplicationComponentExitCode.None);
        }


        #endregion
        public bool IsShowWareHouse2
        {
            get
            {
                return _type.Code == ClearCanvas.Material.Healthcare.StockTransactionType.ST.ToString();
            }
        }
        public bool IsEnableCancel
        {
            get
            {
                return !IsNew;
            }
        }
        private void SaveChanges()
        {
            _detail.Clinic = LoginSession.Current.WorkingFacility;
            _detail.Details.Clear();
            if (_lines.Items.Count > 0)
                _detail.Details.AddRange(_lines.Items);
            Platform.GetService<IStockTransactionService>(
                delegate(IStockTransactionService service)
                {
                    if (_isNew)
                    {
                        AddStockTransactionResponse response = service.AddStockTransaction(new AddStockTransactionRequest(_detail));
                        _summary = response.Summarys;
                        if (ItemAdded != null)
                        {
                            ItemAdded(this, System.EventArgs.Empty);
                        }
                        if (Platform.ShowMessageBox(SR.MessageConfirmPrintInvoice, MessageBoxActions.OkCancel) == DialogBoxAction.Ok)
                        {
                            //PrintInvoice();
                        }
                    }
                    else
                    {
                        UpdateStockTransactionResponse response = service.UpdateStockTransaction(new UpdateStockTransactionRequest(_detail));
                        _summary = response.objSummary;
                        if (ItemUpdated != null)
                            ItemUpdated(this, System.EventArgs.Empty);
                    }
                });

            ResetNew();
        }
        public bool AllowAddLineItems
        {
            get
            {
                return SelectMedicine != null && SelectedMedicineLot != null && InputPrice > 0 && Amount > 0;
            }
        }
        public void AddLineItems()
        {
            if (_isNew)
            {
                _lines.Items.Remove(_currentAdding);
            }
            _currentAdding.Material = SelectMedicine;

            _currentAdding.UOM = SelectMedicine.UOM;
            _currentAdding.Clinic = LoginSession.Current.WorkingFacility;
            this._lines.Items.Add(_currentAdding);
            //_selectedLine = _currentAdding;
            _currentAdding = new StockTransactionLineSummary();

            NotifyAllPropertiesChanged();
        }

        public void LineItemsSelectChanged()
        {
            //if (_selectedLine == null)
            //    return;
            //_currentAdding = _selectedLine;
            //SelectMedicine = _selectedLine.Material;
            //NotifyCurrentLineItemChanged();
        }
        public void CancelEditLineItem()
        {
            //_currentAdding = new StockTransactionLineSummary();
            //_selectedLine = null;
            //NotifyCurrentLineItemChanged();

        }
        public void NotifyCurrentLineItemChanged()
        {
            NotifyPropertyChanged("Tax");
            NotifyPropertyChanged("ExpireDate");
            NotifyPropertyChanged("Amount");
            NotifyPropertyChanged("InputPrice");
            UpdateActionMenu();
        }
    }

}
