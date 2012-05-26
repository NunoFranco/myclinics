using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Threading;
using System.Globalization;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{

    public partial class BillingInfoUserControl : UserControl
    {
        List<OrderSummary> orders = new List<OrderSummary>();
        public OrderSummary CurrentSelectedOrder { get; set; }
        List<BindingGridColumns> dataSource = new List<BindingGridColumns>();
        List<BindingGridColumns> displayDataSource = new List<BindingGridColumns>();

        List<CurrencyDetail> _listCurrency = null;
        CurrencyDetail primaryCurrency
        {
            get
            {
                if (_listCurrency == null)
                {
                    _listCurrency = LoadCurrency();
                }

                return _listCurrency.FirstOrDefault<CurrencyDetail>(x => x.IsPrimaryCurrency == true);
            }
        }
        CurrencyDetail primaryExrateCurrency
        {
            get
            {
                if (_listCurrency == null)
                {
                    _listCurrency = LoadCurrency();
                }

                return _listCurrency.FirstOrDefault<CurrencyDetail>(x => x.IsPrimaryExRateCurrency == true);
            }
        }
        bool _ishistoryorder;
        public bool IsHistoryOrder
        {
            get
            {
                return _ishistoryorder;
            }
            set
            {
                //if (!value)
                //{
                //    if (_listCurrency == null)
                //    {
                //        _listCurrency = LoadCurrency();
                //    }
                //    ClearCanvas.Enterprise.Common.Billing.BillingOptions opt = new ClearCanvas.Enterprise.Common.Billing.BillingOptions();
                //    CurrencyDetail tmp = _listCurrency.FirstOrDefault<CurrencyDetail>(x => x.CurrencyCode == opt.PrimaryCurrency.Trim());
                //    UserconfigureCurrency = tmp == null ? _listCurrency.First() : tmp;
                //}
                //else
                //{
                //    if (dataSource != null && dataSource.Count > 0)
                //    {
                //        CurrencyDetail tmp = _listCurrency.FirstOrDefault<CurrencyDetail>(x => x.CurrencyCode == dataSource[0].UserCofigureCurrency.Trim());
                //        UserconfigureCurrency = tmp == null ? _listCurrency.First() : tmp;
                //    }
                //}
                _ishistoryorder = value;
            }
        }
        CurrencyDetail _userconfigurecurrency;
        public CurrencyDetail UserconfigureCurrency
        {
            get
            {
                if (_listCurrency == null)
                {
                    _listCurrency = LoadCurrency();
                }
                if (!IsHistoryOrder)
                {

                    ClearCanvas.Enterprise.Common.Billing.BillingOptions opt = new ClearCanvas.Enterprise.Common.Billing.BillingOptions();
                    CurrencyDetail tmp = _listCurrency.FirstOrDefault<CurrencyDetail>(x => x.CurrencyCode == opt.PrimaryCurrency.Trim());
                    _userconfigurecurrency = tmp == null ? primaryCurrency : tmp;
                }
                else
                {
                    if (dataSource != null && dataSource.Count > 0)
                    {
                        var obj = dataSource.FirstOrDefault(x => x.UserCofigureCurrency != null);
                        CurrencyDetail tmp = null;
                        if (obj != null)
                        {
                            tmp = _listCurrency.FirstOrDefault<CurrencyDetail>(x => x.CurrencyCode == obj.UserCofigureCurrency);
                        }
                        _userconfigurecurrency = tmp == null ? primaryCurrency : tmp;
                    }
                }
                //if (string.IsNullOrEmpty(_userconfigurecurrency.DisplayLocale))
                //{
                //    ClearCanvas.Common.Utilities.NumberUtils.numberFormat = _userconfigurecurrency.CustomDisplayFormat;
                //}
                //else
                //    Thread.CurrentThread.CurrentCulture = new CultureInfo(_userconfigurecurrency.DisplayLocale);

                return _userconfigurecurrency;
            }
            set
            {
                _listCurrency = null;
            }

        }

        bool _isnewinvoice;
        public bool IsNewInvoice
        {
            get
            {
                return _isnewinvoice;
            }
            set
            {
                _isnewinvoice = value;
                setEnablePrintInvoice(!value);

            }
        }
        public string ListOrderInvoiceHistoryProcedure
        {
            get
            {
                if (dataSource == null)
                    dataSource = new List<BindingGridColumns>();
                return ClearCanvas.Common.Utilities.ObjectSerialization.Serialize<List<BindingGridColumns>>(dataSource);
            }
            set
            {
                //XmlSerializer serial = new XmlSerializer(typeof(List<BindingGridColumns>));
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(ASCIIEncoding.ASCII.GetBytes(value));
                //TextReader reader = new StringReader(value);
                //dataSource = (List<BindingGridColumns>)serial.Deserialize(reader);
                dataSource = ClearCanvas.Common.Utilities.ObjectSerialization.DeSerialze<List<BindingGridColumns>>(value);
            }
        }
        void setEnablePrintInvoice(bool value)
        {
            this.btnPrintInvoice.Enabled = value;
        }
        //public bool IsPrintableInvoice { get; set; }

        [Browsable(true)]
        public PatientProfileDetail SelectedPatient { get; set; }
        public bool AllowPrintInvoice
        {
            set
            {
                this.btnPrintInvoice.Visible = value;
            }
        }
        [Browsable(false)]
        public string OrderNumber { get; set; }
        public bool IsEditable { get; set; }
        public bool IsConfirmable { get; set; }

        public decimal TotalInsurance { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalCollect { get; set; }
        public decimal TotalAdjestment { get; set; }
        public decimal TotalChanges { get; set; }
        public decimal TotalReceived { get; set; }
        public decimal TotalWaitingInsurance { get; set; }
        string _invoicenumber = "";
        public string InvoiceNumber
        {
            get
            {
                //if (IsNewInvoice && CurrentOrderDetail!=null)
                //{
                //    _invoicenumber = CurrentOrderDetail.AccessionNumber;
                //}
                return _invoicenumber;
            }

            set
            {
                _invoicenumber = value;
            }

        }
        OrderDetail _orderdetail = null;
        public OrderDetail CurrentOrderDetail
        {
            get
            {
                if (_orderdetail == null)
                {
                    RefreshOrderDetail(OrderNumber);
                }
                return _orderdetail;
            }
            set
            {
                _orderdetail = value;
            }

        }
        public bool IsFormLoaded = false;
        [Browsable(true)]
        public bool IsSelectableOrder { get; set; }
        [Browsable(true)]
        public bool IsEditableInvoice { get; set; }
        public event EventHandler OnBindingDataChanged;
        public event EventHandler OnConfirmedOrder;

        public BillingInfoUserControl()
        {
            InitializeComponent();
        }
        void LoadOrders()
        {


            Platform.GetService<IOrderEntryService>(
                delegate(IOrderEntryService service)
                {
                    orders = service.ListActiveOrdersForPatient
                    (new ListOrdersForPatientRequest(SelectedPatient.PatientProfileRef, false)).Orders;
                });
        }
        public void BindData()
        {
            Reset();

            if (SelectedPatient == null)
                return;
            LoadOrders();
            try
            {
                this.txtFirstName.Text = SelectedPatient.Name.GivenName;
                this.txtLastName.Text = SelectedPatient.Name.FamilyName;
                if (SelectedPatient.DiscountType != null)
                    this.txtDiscountType.Text = SelectedPatient.DiscountType.Value;
                else
                    this.txtDiscountType.Text = "";
                if (SelectedPatient.InsuranceType != null)
                    this.txtInsuranceType.Text = SelectedPatient.InsuranceType.Value;
                else
                    this.txtInsuranceType.Text = "";
                this.txtMRN.Text = SelectedPatient.Mrn.Id;
                this.txtInvoiceNumber.Text = InvoiceNumber;
                if (orders.Count == 0)
                    return;

                orders.OrderByDescending(o => o.EnteredTime);
                if (orders[0].EnteredTime != null)
                    this.txtLastOrderDate.Text = orders[0].EnteredTime.ToString();
                List<EnumValueInfo> lst = new List<EnumValueInfo>();
                foreach (var item in orders)
                {
                    EnumValueInfo i = new EnumValueInfo(item.OrderNumber, item.OrderNumber, item.Clinic.OID );
                    lst.Add(i);
                }
                this.cmbOrderNumbers.Properties.Items.AddRange(lst);


            }
            catch (Exception ex)
            {
                Platform.ShowMessageBox(ex.Message);
                Platform.Log(LogLevel.Error, ex);
            }

            //this.txtInvoiceNumber.Enabled = IsEditableInvoice;
            this.cmbOrderNumbers.Enabled = IsSelectableOrder;

            if (!string.IsNullOrEmpty(OrderNumber))
            {
                this.cmbOrderNumbers.Enabled = IsSelectableOrder;
                this.cmbOrderNumbers.EditValue = OrderNumber;
            }
            //cmbOrderNumbers_SelectedIndexChanged(null, System.EventArgs.Empty);
            if (this.cmbOrderNumbers.EditValue == null)
                return;

            var order = orders.Where(x => x.OrderNumber == this.cmbOrderNumbers.EditValue.ToString()).FirstOrDefault();
            if (order == null)
                return;
            BindProcedureType(order);
            this.grpBillingInfo.Text = string.Format(SR.BillingInfoText, SR.OrderPaid);
            IsNewInvoice = false;
            bool canCancelOrder = true;
            bool canReconfirmOrder = false;

            if (order == null || order.Invoices.Count == 0)
            {
                this.grpBillingInfo.Text = string.Format(SR.BillingInfoText, SR.OrderUnPaid);
                IsNewInvoice = true;
            }
            else
            {
                canCancelOrder = false;
                this.txtInvoiceNumber.Text = order.Invoices[0].InvoiceNumber;
            }
            if (order.OrderStatus.Code == order.CancelStatus.Code)
            {
                this.grpBillingInfo.Text = string.Format(SR.BillingInfoText, SR.OrderCancel);
                canCancelOrder = false;
                canReconfirmOrder = true;
                IsNewInvoice = true;
            }

            //this.txtInvoiceNumber.Properties.ReadOnly = !string.IsNullOrEmpty(this.txtInvoiceNumber.Text);

            CurrentSelectedOrder = order;
            UpdateOrderCancel(canCancelOrder, canReconfirmOrder);
            if (OnBindingDataChanged != null)
                OnBindingDataChanged(this, new System.EventArgs());
        }
        private void BillingInfoUserControl_Load(object sender, EventArgs e)
        {
            //this.btnPrintInvoice.DataBindings.Add("Enabled", this, "IsPrintableInvoice", true, DataSourceUpdateMode.OnPropertyChanged);
            AllowPrintInvoice = true;
            BindData();
            IsFormLoaded = true;
        }
        public void Reset()
        {
            this.grpBillingInfo.Text = string.Format(SR.BillingInfoText, SR.OrderEmpty);
            CurrentSelectedOrder = null;
            ClearBindProcedureType();
            this.txtInvoiceNumber.Text = "";
            cmbOrderNumbers.Properties.Items.Clear();
            cmbOrderNumbers.EditValue = "";
            this.grdInvoiceDetails.DataSource = null;
            btnCancelOrder.Enabled = false;
            this.btnReConfirmOrder.Enabled = false;

        }
        private void cmbOrderNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reset();
            if (cmbOrderNumbers.EditValue != null)
            {
                OrderNumber = cmbOrderNumbers.EditValue.ToString();
            }
            RefreshOrderDetail(OrderNumber);
            BindData();
        }
        void UpdateOrderCancel(bool canCancelOrder, bool canReConfirm)
        {
            this.btnReConfirmOrder.Enabled = canReConfirm;
            this.btnCancelOrder.Enabled = canCancelOrder;
        }
        void ClearBindProcedureType()
        {
            if (dataSource == null)
                dataSource = new List<BindingGridColumns>();
            dataSource.Clear();
        }
        string GetPendingProcedureStatusText(string statusEnum)
        {
            object value = Enterprise.Common.CommonEnumUtil.GetEnumValue<Enterprise.Common.WaitingInsuranceStatus>(statusEnum);
            if (value == null)
            {
                return SR.NotPending;
            }
            switch ((Enterprise.Common.WaitingInsuranceStatus)value)
            {
                case ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.NOWAITING:
                    return SR.NotPending;
                    break;
                case ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM:
                    return SR.Pending;
                    break;
                case ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.CONFIRMED:
                    return SR.Confirmed;
                    break;
                case ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.REJECTED:
                    return SR.Rejected;
                    break;
            }
            return "";
        }
        void BindProcedureType(OrderSummary summary)
        {
            if (CurrentOrderDetail.Invoices.Count == 0)
            {
                foreach (var item in CurrentOrderDetail.Procedures)
                {

                    BindingGridColumns obj = new BindingGridColumns
                    {
                        AfterDiscount = item.Type.AfterDiscountPrice == null ? 0 : item.Type.AfterDiscountPrice,
                        AfterInsurance = item.Type.AfterDiscountPrice == null ? 0 : item.Type.AfterInsurancePrice,
                        Code = item.Type.Id,
                        Name = item.Type.Name,
                        BasePrice = item.Type.BasePrice == null ? 0 : item.Type.BasePrice,
                        Tax = item.Type.Tax,

                        AdjestmentPrice = item.CollectedAmount == null ? 0 : item.CollectedAmount,
                        IsPackageProcedure = item.IsPackageProcedure,
                        WaitingInsuranceAmount = item.WaitingInsuranceAmount,
                        PendingInsuranceStatus = item.PendingProcedureStatus,
                        PackagePrice = item.PackageProcedure == null ? 0 : (decimal)item.PackageProcedure.PackagePrice
                    };
                    obj.TotalPrice = obj.BasePrice + (obj.Tax / 100 * obj.BasePrice);
                    obj.AfterDiscount = obj.TotalPrice;
                    obj.AfterInsurance = obj.TotalPrice;
                    if (obj.WaitingInsuranceAmount == 0)
                    {
                        obj.PendingInsuranceStatusText = SR.NotPending;
                    }
                    if (!item.IsPackageProcedure)
                    {
                        if (SelectedPatient.DiscountType != null)
                        {
                            List<DiscountRuleSummary> discounts = new List<DiscountRuleSummary>();
                            Platform.GetService<IDiscountRuleService>
                    (delegate(IDiscountRuleService service)
                    {
                        discounts = service.ListAllDiscount(
                             new ListDiscountRuleRequest(item.Type.ProcedureTypeRef,
                                 SelectedPatient.DiscountType.Code,
                             SelectedPatient.DiscountType.Value,
                             SelectedPatient.DiscountType.Description))._Discounts;
                    });
                            if (discounts.Count > 0)
                            {
                                DiscountRuleSummary discount = discounts[0];
                                switch (discount.AmountType)
                                {
                                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
                                        obj.AfterDiscount = discount.Amount;
                                        break;
                                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
                                        obj.AfterDiscount = obj.TotalPrice - discount.Amount;
                                        break;
                                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
                                        obj.AfterDiscount = obj.TotalPrice * (1 - (discount.Amount / 100));
                                        break;
                                }
                            }
                        }
                        if (SelectedPatient.InsuranceType != null)
                        {
                            List<InsuranceRuleSummary> Insurances = new List<InsuranceRuleSummary>();
                            Platform.GetService<IInsuranceRuleService>
                        (delegate(IInsuranceRuleService service)
                        {
                            Insurances = service.ListAllInsurance(
                             new ListInsuranceRuleRequest(item.Type.ProcedureTypeRef,
                                 SelectedPatient.InsuranceType.Code,
                             SelectedPatient.InsuranceType.Value,
                             SelectedPatient.InsuranceType.Description))._Insurances;
                        }
                        );
                            if (Insurances.Count > 0)
                            {
                                InsuranceRuleSummary Insurance = Insurances[0];
                                switch (Insurance.AmountType)
                                {
                                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
                                        obj.AfterInsurance = Insurance.Amount;
                                        break;
                                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
                                        obj.AfterInsurance = obj.TotalPrice - Insurance.Amount;
                                        break;
                                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
                                        obj.AfterInsurance = obj.TotalPrice * (1 - (Insurance.Amount / 100));
                                        break;
                                }
                            }
                        }
                    }
                    if (obj.AdjestmentPrice == null || obj.AdjestmentPrice == 0)
                        obj.AdjestmentPrice = 0;
                    obj.AfterDiscount = obj.AfterDiscount < 0 ? 0 : obj.AfterDiscount;
                    obj.AfterInsurance = obj.AfterInsurance < 0 ? 0 : obj.AfterInsurance;
                    obj.DiscountAmount = obj.TotalPrice - obj.AfterDiscount;
                    obj.InsuranceAmount = obj.TotalPrice - obj.AfterInsurance;

                    obj.TotalPrice = obj.TotalPrice - obj.DiscountAmount - obj.InsuranceAmount - (decimal)obj.AdjestmentPrice - obj.WaitingInsuranceAmount;
                    obj.TotalPrice = obj.TotalPrice > 0 ? obj.TotalPrice : 0;
                    dataSource.Add(obj);

                }
                ConvertObjectCurrency(dataSource);
                IsHistoryOrder = false;
            }
            else
            {
                IsHistoryOrder = true;
                OrderInvoicesDetail d = (OrderInvoicesDetail)CurrentOrderDetail.Invoices[0];
                ListOrderInvoiceHistoryProcedure = d.ListProcedures;
            }

            foreach (var item in dataSource)//Get Localize text for Procedure status no matter hisroty or waiting
            {
                item.PendingInsuranceStatusText = GetPendingProcedureStatusText(item.PendingInsuranceStatus);
            }
            this.grdInvoiceDetails.DataSource = dataSource;
        }
        List<CurrencyDetail> LoadCurrency()
        {
            List<CurrencyDetail> listCurrency = new List<CurrencyDetail>();

            Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
            {
                ListCurrencyRequest request = new ListCurrencyRequest();
                request.IsListDetail = true;
                listCurrency = service.ListAllCurrency(request).Details;
            });
            return listCurrency;
        }
        decimal ConvertCurrency(decimal amount)
        {

            return ClearCanvas.Ris.Application.Common.Billing.CurrencyManager.ConvertCurrency(
                                amount,
                                primaryCurrency,
                                UserconfigureCurrency,
                                primaryExrateCurrency);


        }
        public decimal ConvertToPrimaryCurrency(decimal amount)
        {
            return ClearCanvas.Ris.Application.Common.Billing.CurrencyManager.ConvertCurrency(
                amount,
                UserconfigureCurrency,
                primaryCurrency,
                primaryExrateCurrency);
        }
        void ConvertObjectCurrency(List<BindingGridColumns> obj)
        {


            foreach (var item in obj)
            {
                item.BasePrice = ConvertCurrency(item.BasePrice);
                item.AfterInsurance = ConvertCurrency(item.AfterInsurance);
                item.AfterDiscount = ConvertCurrency(item.AfterDiscount);
                item.AdjestmentPrice = ConvertCurrency((decimal)item.AdjestmentPrice);
                item.DiscountAmount = ConvertCurrency((decimal)item.DiscountAmount);
                item.InsuranceAmount = ConvertCurrency((decimal)item.InsuranceAmount);
                item.PackagePrice = ConvertCurrency((decimal)item.PackagePrice);
                item.TotalPrice = ConvertCurrency((decimal)item.TotalPrice);
                item.WaitingInsuranceAmount = ConvertCurrency((decimal)item.WaitingInsuranceAmount);
                //save currency to History
                item.UserCofigureCurrency = UserconfigureCurrency.CurrencyCode;
                item.PrimaryCurrency = primaryCurrency.CurrencyCode;
            }
        }
        void RefreshData()
        {
            LoadOrders();
            cmbOrderNumbers_SelectedIndexChanged(null, new System.EventArgs());

        }
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            string message = "";
            if (CurrentSelectedOrder == null)
            {
                Platform.ShowMessageBox(SR.OrderEmpty);
                return;
            }
            try
            {

                Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
                {
                    service.CancelOrder(
                    new CancelOrderRequest(CurrentSelectedOrder.OrderRef, CurrentSelectedOrder.CancelReason));
                }
                    );

                message = SR.CancelOrderFinished;
                RefreshData();
            }
            catch (Exception ex)
            {
                message = SR.UpdateFailed + "\n" + ex.Message;
                Platform.Log(LogLevel.Error, ex);
            }
            Platform.ShowMessageBox(message);
        }

        private void btnReConfirmOrder_Click(object sender, EventArgs e)
        {
            string message = "";
            if (CurrentSelectedOrder == null)
            {
                Platform.ShowMessageBox(SR.OrderEmpty);
                return;
            }
            try
            {
                OrderRequisition orderReq = new OrderRequisition();
                Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
                {
                    GetOrderRequisitionForEditResponse response = service.GetOrderRequisitionForEdit(new GetOrderRequisitionForEditRequest(CurrentSelectedOrder.OrderRef));
                    service.ReconfirmOrder(new ReConfirmOrderRequest(CurrentSelectedOrder.OrderRef));
                    //service.recon(new ReplaceOrderRequest(response.OrderRef, CurrentSelectedOrder.CancelReason, response.Requisition));

                }
                    );
                message = SR.ReConfirmOrderFinished;
                RefreshData();
            }
            catch (Exception ex)
            {
                message = SR.UpdateFailed + "\n" + ex.Message;
                Platform.Log(LogLevel.Error, ex);
            }
            Platform.ShowMessageBox(message);

        }

        private void txtInvoiceNumber_TextChanged(object sender, EventArgs e)
        {
            InvoiceNumber = txtInvoiceNumber.Text;
        }

        private void grdInvoiceDetails_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.GridControl control = (DevExpress.XtraGrid.GridControl)sender;
            Point pt = control.PointToClient(Control.MousePosition);
            DoRowDoubleClick(control, pt);
        }
        private void DoRowDoubleClick(DevExpress.XtraGrid.GridControl grdControl, Point pt)
        {
            if (CurrentSelectedOrder == null)
                return;
            GridHitInfo info = (GridHitInfo)grdControl.MainView.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();

                EditProcedureAdjestmentPrice editor = new EditProcedureAdjestmentPrice(this);
                BindingGridColumns doubleClickRow = (BindingGridColumns)grdControl.MainView.GetRow(info.RowHandle);
                OrderDetail detail = CurrentOrderDetail;
                doubleClickRow.AdjestmentPrice = doubleClickRow.AdjestmentPrice == null ? 0 : doubleClickRow.AdjestmentPrice;
                doubleClickRow.TotalPrice = doubleClickRow.TotalPrice == null ? 0 : doubleClickRow.TotalPrice;
                doubleClickRow.AfterDiscount = doubleClickRow.AfterDiscount == null ? 0 : doubleClickRow.AfterDiscount;
                if (doubleClickRow.IsPackageProcedure)
                {
                    Platform.ShowMessageBox(SR.PackageProcedureEditError);
                    return;
                }
                if (detail == null)
                    return;
                editor.BindData(detail, doubleClickRow.Code, doubleClickRow.Name, doubleClickRow.BasePrice.ToString(), doubleClickRow.AfterDiscount.ToString(), doubleClickRow.AdjestmentPrice.ToString(), doubleClickRow.WaitingInsuranceAmount.ToString());
                editor.IsEditable = IsEditable;
                editor.IsConfirmable = IsConfirmable && doubleClickRow.PendingInsuranceStatus == ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM.ToString();
                editor.IsPackageProcedure = doubleClickRow.IsPackageProcedure;
                editor.OnConfirmed += new EventHandler(editor_OnConfirmed);
                editor.Historyprocedures = dataSource;

                //editor.UpdatedInvoiceListProcedures = ((OrderInvoicesDetail)detail.Invoices[0]).ListProcedures;
                editor.ShowDialog();
                RefreshOrderDetail();
                this.RefreshData();
            }
        }

        void editor_OnConfirmed(object sender, EventArgs e)
        {
            OnConfirmedOrder(sender, e);
        }
        void RefreshOrderDetail()
        {
            if (CurrentOrderDetail == null)
                return;
            RefreshOrderDetail(CurrentOrderDetail.OrderNumber);
        }
        void RefreshOrderDetail(string ordernumber)
        {
            if (string.IsNullOrEmpty(ordernumber))
                return;
            IList<OrderDetail> details = new List<OrderDetail>();
            Platform.GetService<IOrderEntryService>(
            delegate(IOrderEntryService service)
            {
                details = service.LoadOrder(new LoadOrderRequest(ordernumber)).orderDetailList;
            }
            );
            if (details.Count == 0)
                return;
            CurrentOrderDetail = details[0];
        }
        public void CalcToTal()
        {
            TotalCollect = 0;
            TotalDiscount = 0;
            TotalInsurance = 0;
            TotalWaitingInsurance = 0;
            TotalAdjestment = 0;
            bool isPackage = false;
            foreach (var item in dataSource)
            {
                if (item.IsPackageProcedure)
                {
                    TotalCollect = item.PackagePrice;
                    isPackage = true;
                    break;
                }
                decimal discountamount = 0;
                decimal insuranceamount = 0;

                //discountamount = item.TotalPrice - item.AfterDiscount;
                TotalDiscount += item.DiscountAmount;//discountamount < 0 ? 0 : discountamount;

                //insuranceamount = item.TotalPrice - item.AfterInsurance;
                TotalInsurance += item.InsuranceAmount;

                TotalWaitingInsurance += item.WaitingInsuranceAmount;
                if (item.AdjestmentPrice != null)
                    TotalAdjestment += (decimal)item.AdjestmentPrice;
                decimal tmp = (item.BasePrice + item.Tax/100 * item.BasePrice)
                    - discountamount
                    - insuranceamount
                    - (decimal)item.AdjestmentPrice
                    - item.WaitingInsuranceAmount;
                TotalCollect += tmp < 0 ? 0 : tmp;
            }
            if (isPackage)
            {
                TotalDiscount = 0;
                TotalInsurance = 0;
                TotalAdjestment = 0;
            }
            else
            {
                TotalDiscount = TotalDiscount < 0 ? 0 : TotalDiscount;
                TotalInsurance = TotalInsurance < 0 ? 0 : TotalInsurance;
                TotalAdjestment = TotalAdjestment < 0 ? 0 : TotalAdjestment;
                TotalWaitingInsurance = TotalWaitingInsurance < 0 ? 0 : TotalWaitingInsurance;
                TotalCollect = TotalCollect < 0 ? 0 : TotalCollect;
            }
            if (CurrentOrderDetail != null && CurrentOrderDetail.Invoices.Count > 0)
            {
                TotalChanges = CurrentOrderDetail.Invoices[0].TotalChanges;
                TotalReceived = CurrentOrderDetail.Invoices[0].TotalReceived;
            }
            else
            {
                TotalChanges = 0;
                TotalReceived = 0;
            }
            //TotalCollect = ConvertCurrency(TotalCollect);
            //TotalDiscount = ConvertCurrency(TotalDiscount);
            //TotalInsurance = ConvertCurrency(TotalInsurance);
            //TotalWaitingInsurance = ConvertCurrency(TotalWaitingInsurance);
            //TotalAdjestment = ConvertCurrency(TotalAdjestment);
            //this.txtTotalCollectAmount.Text = NumberUtils.GetCurrencyDisplayFormat(this.billingInfoUserControl1.TotalCollect);
            //this.txtTotalDiscountAmount.Text = NumberUtils.GetCurrencyDisplayFormat(this.billingInfoUserControl1.TotalDiscount.ToString());
            //this.txtTotalInsuranceAmount.Text = NumberUtils.GetCurrencyDisplayFormat(this.billingInfoUserControl1.TotalInsurance.ToString());
            //this.txtTotalAdjestment.Text = NumberUtils.GetCurrencyDisplayFormat(this.billingInfoUserControl1.TotalAdjestment.ToString());
            //this.txtReceiveCash.Text = NumberUtils.GetCurrencyDisplayFormat(this.billingInfoUserControl1.TotalReceived.ToString());
            //this.txtChanges.Text = NumberUtils.GetCurrencyDisplayFormat(this.billingInfoUserControl1.TotalChanges.ToString());
            //this.txtTotalWaitingInsurance.Text = NumberUtils.GetCurrencyDisplayFormat(this.billingInfoUserControl1.TotalWaitingInsurance.ToString());

        }
        public bool IsCanCollect()
        {
            foreach (var item in dataSource)
            {
                if (item.WaitingInsuranceAmount > 0)
                    return true;
            }
            return false;
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }

        public void PrintInvoice()
        {
            RefreshData();
            if (string.IsNullOrEmpty(InvoiceNumber))
            {
                return;
            }

            PrintInvoiceForm invoiceForm = new PrintInvoiceForm();
            invoiceForm.SelectedPatient = SelectedPatient;
            invoiceForm.currentSelectedOrder = CurrentSelectedOrder;
            invoiceForm.currentSelectedOrderDetail = CurrentOrderDetail;
            invoiceForm.invoiceNumber = InvoiceNumber;
            invoiceForm.ConfigCurrency = UserconfigureCurrency;
            invoiceForm.ShowDialog();
        }

        private void grdInvoiceDetails_Click(object sender, EventArgs e)
        {

        }
    }

    [Serializable]
    public class BindingGridColumns
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal AfterDiscount { get; set; }
        public decimal AfterInsurance { get; set; }
        public decimal InsuranceAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal WaitingInsuranceAmount { get; set; }
        public decimal? AdjestmentPrice { get; set; }
        public bool IsPackageProcedure { get; set; }
        public string PendingInsuranceStatus { get; set; }
        public string PendingInsuranceStatusText { get; set; }//Display Localize text
        public bool IsPendingInsuranceStatus { get; set; }
        public decimal PackagePrice { get; set; }
        public string PrimaryCurrency { get; set; }
        public string UserCofigureCurrency { get; set; }
        //if change later will use this custome field without Update Esisting data
        //this object will serialize to store to db when invoice in save to store the History
        //when a field is added then the struct will be broke. if we use the custom field every thing is ok
        //don't care about the struct.
        public object Custom1 { get; set; }
        public object Custom2 { get; set; }
        public object Custom3 { get; set; }
        public object Custom4 { get; set; }
        public object Custom5 { get; set; }
        public object Custom6 { get; set; }
        public object Custom7 { get; set; }
        public object Custom8 { get; set; }
        public object Custom9 { get; set; }
        public object Custom10 { get; set; }

    }
}
