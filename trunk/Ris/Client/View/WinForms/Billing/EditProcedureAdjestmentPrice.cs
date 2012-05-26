using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    public partial class EditProcedureAdjestmentPrice : Form
    {
        public EditProcedureAdjestmentPrice(BillingInfoUserControl Caller)
        {
            InitializeComponent();
            _caller = Caller;
            UserConfigCurrency = Caller.UserconfigureCurrency;

        }

        BillingInfoUserControl _caller;
        //get
        //    {
        //        try
        //        {
        //            bool isGetPrimaryCurrency = false;
        //            ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail result = new ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail();
        //            if (EditingOrder != null && EditingOrder.Invoices != null && EditingOrder.Invoices.Count > 0)
        //            {
        //                var pros = ClearCanvas.Common.Utilities.ObjectSerialization.DeSerialze<List<BindingGridColumns>>(EditingOrder.Invoices[0].ListProcedures);
        //                var pro = pros.FirstOrDefault();
        //                if (pro == null)
        //                {
        //                    isGetPrimaryCurrency = true;
        //                }
        //                else
        //                {
        //                    Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
        //                   {
        //                       ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
        //                       request.IsListDetail = true;
        //                       request.Code = pro.UserCofigureCurrency;
        //                       result = service.ListAllCurrency(request).Details[0];
        //                   });
        //                }
        //            }
        //            if (isGetPrimaryCurrency)
        //            {
        //                Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
        //                {
        //                    ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
        //                    request.IsListDetail = true;
        //                    request.IsPrimaryCurrency = true;
        //                    result = service.ListAllCurrency(request).Details[0];
        //                });
        //            }
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            Platform.Log(LogLevel.Error, ex);
        //            Platform.Log(LogLevel.Error, "Primary Currency Not found");
        //        }
        //        return new ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail();
        //    }
       public  ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail UserConfigCurrency
        {
            get;
            set;
        }
        public OrderDetail EditingOrder { get; set; }
        public bool IsEditable { get; set; }
        public bool IsConfirmable { get; set; }
        public bool IsPackageProcedure { get; set; }
        public List<BindingGridColumns> Historyprocedures = new List<BindingGridColumns>();
        public event EventHandler OnConfirmed;
        public void BindData(OrderDetail order, string procedurecode, string procedurename, string baseprice, string afterdiscountprice, string adjestmentprice, string waitingInsuranceamount)
        {
            this.txtBasePrice.Text = NumberUtils.GetCurrencyDisplayFormat(UserConfigCurrency.DisplayLocale, UserConfigCurrency.CustomDisplayFormat, baseprice);
            this.txtPriceAfterDiscount.Text = NumberUtils.GetCurrencyDisplayFormat(UserConfigCurrency.DisplayLocale, UserConfigCurrency.CustomDisplayFormat, afterdiscountprice);
            this.txtProcedureCode.Text = procedurecode;
            this.txtProcedureName.Text = procedurename;
            this.txtAdjestment.Text = NumberUtils.GetCurrencyDisplayFormat(UserConfigCurrency.DisplayLocale, UserConfigCurrency.CustomDisplayFormat, adjestmentprice);
            this.txtPendingInsuranceAmount.Text = waitingInsuranceamount;
            EditingOrder = order;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)//save
        {
            //ModifyOrderRequest request = new ModifyOrderRequest(EditingOrder.OrderRef, req);
            Enterprise.Common.EntityRef ProcedureRef = null;
            foreach (var item in EditingOrder.Procedures)
            {
                if (item.Type.Id == this.txtProcedureCode.Text)
                {
                    ProcedureRef = item.ProcedureRef;
                    break;
                }
            }
            if (ProcedureRef == null)
            {
                Platform.Log(LogLevel.Fatal, "Procedure not in procedures of order detail");
                return;
            }
            decimal collectamount = 0;
            decimal pendingInsuranceamount = 0;

            if (NumberUtils.ParseNumber(this.txtAdjestment.Text, UserConfigCurrency.DisplayLocale, out collectamount) == false)
            {
                MessageBox.Show(SR.WrongFormat);
                return;
            }
            if (NumberUtils.ParseNumber(this.txtPendingInsuranceAmount.Text, UserConfigCurrency.DisplayLocale, out pendingInsuranceamount) == false)
            {
                MessageBox.Show(SR.WrongFormat);
                return;
            }
            //if (Historyprocedures == null)
            //{
            //    Platform.Log(LogLevel.Error, "List History Procedures XML is not set, cannot be empty");
            //    Platform.ShowMessageBox(SR.UpdateFailed);
            //    return;
            //}
            //BindingGridColumns tmp = Historyprocedures.FirstOrDefault<BindingGridColumns>(b => b.Code == this.txtProcedureCode.Text);
            //tmp.PendingInsuranceStatus = ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM.ToString();
            
            UpdateProcedureAdjestmentPriceRequest request =
                new UpdateProcedureAdjestmentPriceRequest(
                    ProcedureRef,
                    _caller.ConvertToPrimaryCurrency(collectamount),
                    _caller.ConvertToPrimaryCurrency(pendingInsuranceamount)
                    );
            Platform.GetService<IOrderInvoicesService>(delegate(IOrderInvoicesService service)
            {
                service.UpdateProcedureAdjestmentPrice(request);
            }
                );

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//confirm insurance
        {
            //ModifyOrderRequest request = new ModifyOrderRequest(EditingOrder.OrderRef, req);
            Enterprise.Common.EntityRef ProcedureRef = null;
            foreach (var item in EditingOrder.Procedures)
            {
                if (item.Type.Id == this.txtProcedureCode.Text
                    && item.Type.Name == this.txtProcedureName.Text)
                {
                    ProcedureRef = item.ProcedureRef;
                    break;
                }

            }
            if (ProcedureRef == null)
            {
                Platform.Log(LogLevel.Info, "Procedure is not pending insurance");
                Platform.ShowMessageBox(SR.NotPendingInsurance);
                return;
            }
            decimal collectamount = 0;
            if (NumberUtils.ParseNumber(this.txtAdjestment.Text, UserConfigCurrency.DisplayLocale, out collectamount) == false)
            {
                MessageBox.Show(SR.WrongFormat);
                return;
            }
            if (Historyprocedures == null)
            {
                Platform.Log(LogLevel.Error, "List History Procedures XML is not set, cannot be empty");
                Platform.ShowMessageBox(SR.UpdateFailed);
                return;
            }
            BindingGridColumns tmp = Historyprocedures.FirstOrDefault<BindingGridColumns>(b => b.Code == this.txtProcedureCode.Text);
            tmp.PendingInsuranceStatus = ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.CONFIRMED.ToString();

            ConfirmInsuranceRequest request = new ConfirmInsuranceRequest(
                ProcedureRef,
                tmp.PendingInsuranceStatus,
                ClearCanvas.Common.Utilities.ObjectSerialization.Serialize<List<BindingGridColumns>>(Historyprocedures));
            Platform.GetService<IOrderInvoicesService>(delegate(IOrderInvoicesService service)
            {
                service.ConfirmInsurance(request);
            });
            MessageBox.Show(SR.CollectScreenConfirmInsurance);
            this.Close();
            if (OnConfirmed != null)
                OnConfirmed(this, new System.EventArgs());
        }

        private void EditProcedureAdjestmentPrice_Load(object sender, EventArgs e)
        {
            this.txtAdjestment.ReadOnly = !IsEditable;
            this.btnOk.Enabled = IsEditable;
            this.btnConfirmInsurance.Visible = IsConfirmable && !IsPackageProcedure;
            this.btnRejectInsurance.Visible = this.btnConfirmInsurance.Visible;
            if (IsPackageProcedure)
            {
                this.btnOk.Enabled = false;
            }
        }

        private void btnRejectInsurance_Click(object sender, EventArgs e)
        {
            Enterprise.Common.EntityRef ProcedureRef = null;
            foreach (var item in EditingOrder.Procedures)
            {
                if (item.Type.Id == this.txtProcedureCode.Text
                    && item.Type.Name == this.txtProcedureName.Text)
                {
                    ProcedureRef = item.ProcedureRef;
                    break;
                }

            }
            if (ProcedureRef == null)
            {
                Platform.Log(LogLevel.Info, "Procedure is not pending insurance");
                Platform.ShowMessageBox(SR.NotPendingInsurance);
                return;
            }
            decimal collectamount = 0;
            if (NumberUtils.ParseNumber(this.txtAdjestment.Text, UserConfigCurrency.DisplayLocale, out collectamount) == false)
            {
                MessageBox.Show(SR.WrongFormat);
                return;
            }
            if (Historyprocedures == null)
            {
                Platform.Log(LogLevel.Error, "List History Procedures XML is not set, cannot be empty");
                Platform.ShowMessageBox(SR.UpdateFailed);
                return;
            }
            BindingGridColumns tmp = Historyprocedures.FirstOrDefault<BindingGridColumns>(b => b.Code == this.txtProcedureCode.Text);
            tmp.PendingInsuranceStatus = ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.REJECTED.ToString();
            RejectInsuranceRequest request = new RejectInsuranceRequest(
                ProcedureRef,
                tmp.PendingInsuranceStatus,
                ClearCanvas.Common.Utilities.ObjectSerialization.Serialize<List<BindingGridColumns>>(Historyprocedures));
            Platform.GetService<IOrderInvoicesService>(delegate(IOrderInvoicesService service)
            {
                service.RejectInsurance(request);
            });
            MessageBox.Show(SR.CollectScreenRejectedInsurance);
            this.Close();
            if (OnConfirmed != null)
                OnConfirmed(this, new System.EventArgs());
        }
    }
}
