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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using ClearCanvas.Common;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Desktop.View.WinForms;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Ris.Client.Billing;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="BillingCollectCashComponent"/>.
    /// </summary>
    public partial class BillingCollectCashComponentControl : ApplicationComponentUserControl
    {
        private BillingCollectCashComponent _component;
        OrderDetail CurrentOrderdetail = null;
        internal enum ActiveTabs
        {
            WAITING,
            PENDING,
            FINISHED
        }
        ActiveTabs CurrentActiveTab = ActiveTabs.WAITING;
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingCollectCashComponentControl(BillingCollectCashComponent component)
            : base(component)
        {
            _component = component;
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _component;
            //this.listPatientPending.PatientBillingStatus = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.PENDING;
            //this.listPatientPending.BindData();
            //this.listPatientFinished.PatientBillingStatus = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED;
            //this.listPatientFinished.BindData();
            //this.listPatientWaiting.PatientBillingStatus = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.WAITING;
            this.listPatientWaiting.BindData();

            this.listPatientWaiting.OrderSelectionChanged += new EventHandler(listPatientControl_OrderSelectionChanged);
            this.listPatientPending.OrderSelectionChanged += new EventHandler(listPatientControl_OrderSelectionChanged);
            this.listPatientFinished.OrderSelectionChanged += new EventHandler(listPatientControl_OrderSelectionChanged);
            this.billingInfoUserControl1.DataBindings.Add("OrderNumber", _component, "OrderNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtTotalCollectAmount.DataBindings.Add("Text", _component, "Totalcollect", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtTotalInsuranceAmount.DataBindings.Add("Text", _component, "TotalInsurance", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.txtTotalDiscountAmount.DataBindings.Add("Text", _component, "TotalDiscount", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.billingInfoUserControl1.DataBindings.Add("InvoiceNumber", _component, "InvoiceNumber", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.tabPage1.Select();
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1_SelectedIndexChanged(null, System.EventArgs.Empty);
            //listPatientControl_OrderSelectionChanged(listPatientWaiting.CurrentSelectedOrder, System.EventArgs.Empty);

        }

        void listPatientControl_OrderSelectionChanged(object sender, EventArgs phe)
        {
            billingInfoUserControl1.Reset();
            resetScreen();
            if (sender == null)
                return;
            CurrentOrderdetail = (sender as OrderDetail);
            if (CurrentOrderdetail.PatinentProfiles.Count == 0)
                return;

            _component.OrderNumber = CurrentOrderdetail.OrderNumber;
            string invoiceNumber = "";
            if (!billingInfoUserControl1.IsNewInvoice && CurrentOrderdetail.Invoices.Count > 0)
            {
                _component.Details = (OrderInvoicesDetail)CurrentOrderdetail.Invoices[0];
                invoiceNumber = _component.Details.InvoiceNumber;
            }
            //else
            //{
            //    invoiceNumber = CurrentOrderdetail.AccessionNumber;
            //}
            this.billingInfoUserControl1.IsSelectableOrder = false;
            this.billingInfoUserControl1.SelectedPatient = CurrentOrderdetail.PatinentProfiles[0];
            this.billingInfoUserControl1.OrderNumber = CurrentOrderdetail.OrderNumber;
            this.billingInfoUserControl1.CurrentOrderDetail = CurrentOrderdetail;
            this.billingInfoUserControl1.InvoiceNumber = invoiceNumber;
            if (this.billingInfoUserControl1.IsFormLoaded)
                this.billingInfoUserControl1.BindData();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool isAllNumberValid()
        {
            decimal result;
            return (NumberUtils.ParseNumber(this.txtTotalCollectAmount.Text,billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, out result)
                && NumberUtils.ParseNumber(this.txtTotalDiscountAmount.Text, billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, out result)
                && NumberUtils.ParseNumber(this.txtTotalInsuranceAmount.Text, billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, out result)
                && NumberUtils.ParseNumber(this.txtReceiveCash.Text, billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, out result)
                );

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CurrentOrderdetail == null)
                return;
            _component.InvoiceNumber = CurrentOrderdetail.AccessionNumber;//this.billingInfoUserControl1.InvoiceNumber;
            if (!isAllNumberValid())
            {
                Platform.ShowMessageBox(SR.NumberFormatInvalid);
                return;
            }
            if (string.IsNullOrEmpty(_component.InvoiceNumber))
            {
                Platform.ShowMessageBox(SR.InvoiceNumberInvalid);
                return;
            }
            _component.Totalcollect = billingInfoUserControl1.TotalCollect;
            _component.TotalDiscount = billingInfoUserControl1.TotalDiscount;
            _component.TotalInsurance = billingInfoUserControl1.TotalInsurance;
            _component.TotalWaitingAmount = billingInfoUserControl1.TotalWaitingInsurance;
            decimal receive = 0;
            NumberUtils.ParseNumber(this.txtReceiveCash.Text, billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, out receive);
            _component.TotalReceived = receive;

            _component.TotalChanges = _component.TotalReceived - _component.Totalcollect;
            _component.ListOrderInvoiceProcedure = this.billingInfoUserControl1.ListOrderInvoiceHistoryProcedure;
            if (_component.TotalChanges < 0)
            {
                Platform.ShowMessageBox(SR.Totalreceivednotenough);
                return;
            }
            if (!_component.SaveChanges(billingInfoUserControl1.IsNewInvoice))
            {
                Platform.ShowMessageBox(SR.SaveInvoiceFailed);
                return;
            }
            Platform.ShowMessageBox(SR.SaveInvoiceSuccessful);
            //this.listPatientPending.BindData();
            this.listPatientWaiting.BindData();

            this.billingInfoUserControl1.InvoiceNumber = _component.InvoiceNumber;
            this.billingInfoUserControl1.PrintInvoice();
            tabControl1_SelectedIndexChanged(null, System.EventArgs.Empty);
            //this.listPatientFinished.BindData();
        }
        void resetScreen()
        {
            this.btnCollected.Enabled = false;
            this.txtTotalCollectAmount.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, 0);
            this.txtTotalDiscountAmount.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, 0);
            this.txtTotalInsuranceAmount.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, 0);
            this.txtReceiveCash.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, 0);
            this.txtChanges.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, 0);
            this.txtTotalWaitingInsurance.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, 0);

            CurrentOrderdetail = null;
        }
        private void btnCollect_Click(object sender, EventArgs e)//Collected Insurance
        {
            if (CurrentOrderdetail == null)
                return;
            ClearCanvas.Enterprise.Common.OrderBillingStatusEnum status = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED;
            foreach (var item in CurrentOrderdetail.Procedures)
            {
                Enterprise.Common.WaitingInsuranceStatus t = (Enterprise.Common.WaitingInsuranceStatus)
                    Enterprise.Common.CommonEnumUtil.GetEnumValue<Enterprise.Common.WaitingInsuranceStatus>
                    (item.PendingProcedureStatus);
                if (t == Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM)
                {
                    status = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.COLLECTEDINSURANCE;
                    break;
                }
            }
            if (CurrentOrderdetail.Invoices.Count > 0)
                CurrentOrderdetail.Invoices[0].IsFinished = true;
            UpdateOrderStatusRequest request = new UpdateOrderStatusRequest(CurrentOrderdetail.OrderRef, status.ToString());
            Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            {
                service.UpdateOrderStatus(request);
            });
            Platform.ShowMessageBox(SR.CollectedInsurance);
            this.listPatientPending.BindData();
            resetScreen();
            //this.listPatientFinished.BindData();
        }

        private void btnFinish_Click(object sender, EventArgs e)//Finished Order
        {
            if (CurrentOrderdetail == null)
                return;
            UpdateOrderStatusRequest request = new UpdateOrderStatusRequest(CurrentOrderdetail.OrderRef, ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED.ToString());
            Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            {
                service.UpdateOrderStatus(request);
            }
                );
            Platform.ShowMessageBox(SR.InvoiceClosed);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            billingInfoUserControl1.AllowPrintInvoice = true;
            btnCollected.Visible = true;
            switch (this.tabControl1.SelectedIndex)
            {
                case 0://Waiting
                    CurrentActiveTab = ActiveTabs.WAITING;
                    //this.billingInfoUserControl1.InvoiceNumber = this.listPatientWaiting.CurrentSelectedOrder.AccessionNumber;
                    this.btnCollected.Enabled = false;
                    this.btnFinshed.Enabled = false;
                    this.btnSave.Visible = true;
                    this.billingInfoUserControl1.IsEditable = true;
                    this.billingInfoUserControl1.IsConfirmable = false;
                    this.txtReceiveCash.Properties.ReadOnly = false;
                    this.btnSave.Visible = !(this.listPatientWaiting.CurrentSelectedOrder == null);
                    billingInfoUserControl1.AllowPrintInvoice = false;
                    btnCollected.Visible = false;
                    listPatientControl_OrderSelectionChanged(this.listPatientWaiting.CurrentSelectedOrder, System.EventArgs.Empty);
                    break;
                case 1://pending
                    CurrentActiveTab = ActiveTabs.PENDING;
                    listPatientControl_OrderSelectionChanged(this.listPatientPending.CurrentSelectedOrder, System.EventArgs.Empty);
                    //Update Collect button enable at BinddataChanged Event
                    this.btnFinshed.Enabled = false;
                    this.billingInfoUserControl1.IsEditable = false;
                    this.billingInfoUserControl1.IsConfirmable = true;
                    this.txtReceiveCash.Properties.ReadOnly = true;
                    this.btnSave.Visible = false;
                    break;
                case 2://finished
                    CurrentActiveTab = ActiveTabs.FINISHED;
                    this.btnCollected.Enabled = false;
                    this.btnFinshed.Enabled = false;
                    this.btnSave.Visible = false;
                    this.billingInfoUserControl1.IsEditable = false;
                    this.billingInfoUserControl1.IsConfirmable = false;
                    this.txtReceiveCash.Properties.ReadOnly = true;
                    listPatientControl_OrderSelectionChanged(this.listPatientFinished.CurrentSelectedOrder, System.EventArgs.Empty);
                    break;
            }
        }

        private void textEdit12_EditValueChanged(object sender, EventArgs e)
        {
            decimal totalcollect = 0;
            decimal totalreceive = 0;
            decimal totalChanges = 0;
            if (NumberUtils.ParseNumber(this.txtReceiveCash.EditValue.ToString(),billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, out totalreceive)
                && NumberUtils.ParseNumber(this.txtTotalCollectAmount.EditValue.ToString(), billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, out totalcollect)
                )
            {
                totalChanges = totalreceive - totalcollect;
                this.txtChanges.EditValue = totalChanges < 0 ? 0 : totalChanges;
            }
            else
            {
                Platform.ShowMessageBox(SR.WrongFormat);
                this.txtReceiveCash.Focus();
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BillingCollectCashComponentControl_Load(object sender, EventArgs e)
        {
            this.billingInfoUserControl1.IsEditable = true;
            this.billingInfoUserControl1.AllowPrintInvoice = false;
            this.billingInfoUserControl1.OnConfirmedOrder += new EventHandler(billingInfoUserControl1_OnConfirmedOrder);
        }

        void billingInfoUserControl1_OnConfirmedOrder(object sender, EventArgs e)
        {
            this.listPatientPending.BindData();
            //this.listPatientFinished.BindData();
        }

        private void billingInfoUserControl1_OnBindingDataChanged(object sender, EventArgs e)
        {
            if (CurrentOrderdetail == null)
                return;
            this.billingInfoUserControl1.CalcToTal();
            this.lblCurrency.Text = billingInfoUserControl1.UserconfigureCurrency.CurrencyCode;

            this.txtTotalCollectAmount.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, this.billingInfoUserControl1.TotalCollect);
            this.txtTotalDiscountAmount.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, this.billingInfoUserControl1.TotalDiscount);
            this.txtTotalInsuranceAmount.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, this.billingInfoUserControl1.TotalInsurance);
            this.txtTotalAdjestment.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, this.billingInfoUserControl1.TotalAdjestment);
            this.txtReceiveCash.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, this.billingInfoUserControl1.TotalReceived);
            this.txtChanges.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, this.billingInfoUserControl1.TotalChanges);
            this.txtTotalWaitingInsurance.Text = NumberUtils.GetCurrencyDisplayFormat(billingInfoUserControl1.UserconfigureCurrency.DisplayLocale, billingInfoUserControl1.UserconfigureCurrency.CustomDisplayFormat, this.billingInfoUserControl1.TotalWaitingInsurance);



            if (CurrentActiveTab == ActiveTabs.PENDING)
            {
                this.btnCollected.Enabled = this.billingInfoUserControl1.TotalInsurance > 0 && CurrentOrderdetail.BillingStatus != ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.COLLECTEDINSURANCE.ToString();
                this.billingInfoUserControl1.IsConfirmable = this.billingInfoUserControl1.TotalWaitingInsurance > 0;
            }
            else
                this.btnCollected.Enabled = false;
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            if (CurrentActiveTab == ActiveTabs.PENDING)
            {
                this.listPatientPending.BindData();
            }
            else if (CurrentActiveTab == ActiveTabs.FINISHED)
            {
                this.listPatientFinished.BindData();
            }
            else if (CurrentActiveTab == ActiveTabs.WAITING)
            {
                this.listPatientWaiting.BindData();
            }
            tabControl1_SelectedIndexChanged(null, System.EventArgs.Empty);
        }

    }
}

