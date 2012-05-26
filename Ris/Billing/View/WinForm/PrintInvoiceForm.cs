using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Common;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.Billing;
using ClearCanvas.Ris.Billing.View.WinForms.reports;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using ClearCanvas.Common.Utilities;
using System.Globalization;
using System.Threading;
namespace ClearCanvas.Ris.Billing.View.WinForms
{
    public partial class PrintInvoiceForm : Form
    {

        //IList<OrderDetail> listOrdersInvoiceDetail = new List<OrderDetail>();
        public PatientProfileDetail SelectedPatient;
        public OrderInvoicesDetail currentSelectedOrderInvoice;
        public OrderSummary currentSelectedOrder;
        public OrderDetail currentSelectedOrderDetail;
        public CurrencyDetail ConfigCurrency { get; set; }
        public string invoiceNumber;

        public PrintInvoiceForm()
        {
            InitializeComponent();
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

                case ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM:
                    return SR.Pending;

                case ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.CONFIRMED:
                    return SR.Confirmed;

                case ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.REJECTED:
                    return SR.Rejected;

            }
            return "";
        }

        List<BindingGridColumns> reportSource = new List<BindingGridColumns>();

        private void PrintInvoiceForm_Load(object sender, EventArgs e)
        {
            //CultureInfo current = Thread.CurrentThread.CurrentCulture;
            //try
            //{
            //    Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigCurrency.DisplayLocale);
            //}
            //catch (Exception ex)
            //{
            //    Platform.Log(LogLevel.Error, ex);
                
            //}
            PrintInvoice f = new PrintInvoice();

            List<PrintInvoiceMember> list = new List<PrintInvoiceMember>();
            if (currentSelectedOrderDetail != null && currentSelectedOrderDetail.Invoices != null && currentSelectedOrderDetail.Invoices.Count > 0)
            {
                reportSource = ClearCanvas.Common.Utilities.ObjectSerialization.DeSerialze<List<BindingGridColumns>>(currentSelectedOrderDetail.Invoices[0].ListProcedures);
                foreach (var item in reportSource)
                {
                    PrintInvoiceMember invoicedetail = new PrintInvoiceMember
                    {
                        PatientName = this.SelectedPatient.Name.FamilyName + " " + this.SelectedPatient.Name.MiddleName + " " + this.SelectedPatient.Name.GivenName,
                        Street = "",
                        Address = "",
                        ReferenceNumber = currentSelectedOrderDetail.Invoices[0].InvoiceNumber,
                        TotalBalanceDue = currentSelectedOrderDetail.Invoices[0].TotalCollect,

                        ProceduceName = item.Name,
                        TotalCharge = item.TotalPrice,
                        DiscountPayment = item.DiscountAmount,
                        InsurancePayment = item.InsuranceAmount,
                        Adjustments = (decimal)item.AdjestmentPrice,
                        PaymentByYou = item.TotalPrice,
                        DueFromYou = item.TotalPrice,
                        BasePrice = item.BasePrice,
                        AfterDiscount = item.AfterDiscount,
                        AfterInsurance = item.AfterInsurance,
                        WaitingInsuranceAmount =item.WaitingInsuranceAmount,
                        AdjestmentPrice = (decimal)item.AdjestmentPrice,
                        IsPackageProcedure = item.IsPackageProcedure,
                        PackagePrice = item.PackagePrice,
                    };
                   
                    invoicedetail.DueFromYou = invoicedetail.DueFromYou < 0 ? 0 : invoicedetail.DueFromYou;
                    if (invoicedetail.IsPackageProcedure)
                    {
                        invoicedetail.DueFromYou = 0;
                        invoicedetail.PackageProcedureText = SR.PackgeProcedure;
                    }
                    invoicedetail.PaymentByYou = invoicedetail.DueFromYou;
                    string primarycurrency = "";
                    Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
                    { ListCurrencyRequest request=new ListCurrencyRequest();
                        request.IsListDetail=true;
                        request.IsPrimaryCurrency=true;

                        List<ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail> lst = service.ListAllCurrency(request).Details;
                        ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail detail = null;
                        if (lst != null && lst.Count > 0)
                            detail = lst[0];
                        if (detail != null)
                            primarycurrency = detail.CurrencyCode;
                        else
                            Platform.Log(LogLevel.Error, "Primary Currency not found");
                    });
                    invoicedetail.Currency = string.IsNullOrEmpty(item.UserCofigureCurrency)?primarycurrency:item.UserCofigureCurrency;
                    list.Add(invoicedetail);

                }
            }
            #region Old Source
            //this.currentSelectedOrderInvoice = this.getInvoiceDetailFromInvoiceNumber(this.invoiceNumber);

            //PrintInvoiceMember pim;
            //if (currentSelectedOrderDetail.Invoices.Count == 0)
            //{
            //    foreach (var item in this.currentSelectedOrderDetail.Procedures)
            //    {
            //        pim = new PrintInvoiceMember
            //        {
            //            AfterDiscount = item.Type.AfterDiscountPrice == null ? 0 : item.Type.AfterDiscountPrice,
            //            AfterInsurance = item.Type.AfterDiscountPrice == null ? 0 : item.Type.AfterInsurancePrice,
            //            ProceduceName = item.Type.Name,
            //            BasePrice = item.Type.BasePrice == null ? 0 : item.Type.BasePrice,
            //            AdjestmentPrice = (decimal)item.CollectedAmount == null ? 0 : (decimal)item.CollectedAmount,
            //            IsPackageProcedure = item.IsPackageProcedure,
            //            PackagePrice = item.PackageProcedure == null ? 0 : (decimal)item.PackageProcedure.PackagePrice,
            //            WaitingInsuranceAmount = item.WaitingInsuranceAmount,
            //            //IsPendingInsuranceStatus = item.IsPendingProcedure,
            //            //PendingInsuranceStatus = item.IsPendingProcedure == true ? SR.Pending : SR.Confirmed
            //        };
            //        pim.Street = "";
            //        if (this.SelectedPatient.Addresses.Count > 0)
            //        {
            //            pim.Street = this.SelectedPatient.Addresses[0].Street == null ? "" : this.SelectedPatient.Addresses[0].Street;
            //            pim.Address = this.SelectedPatient.Addresses[0].Province + " " + this.SelectedPatient.Addresses[0].City + " " + this.SelectedPatient.Addresses[0].Country + " OR " + this.SelectedPatient.Addresses[0].PostalCode;
            //        }

            //        if (this.SelectedPatient.Name != null)
            //        {
            //            pim.PatientName = this.SelectedPatient.Name.FamilyName + " " + this.SelectedPatient.Name.MiddleName + " " + this.SelectedPatient.Name.GivenName;
            //        }
            //        pim.ReferenceNumber = this.invoiceNumber;
            //        pim.ProceduceName = item.Type.Name;
            //        pim.TotalCharge = item.Type.BasePrice;

            //        pim.AfterDiscount = pim.BasePrice;
            //        pim.AfterInsurance = pim.BasePrice;
            //        if (pim.WaitingInsuranceAmount == 0)
            //        {
            //            pim.PendingInsuranceStatus = SR.NotPending;
            //        }
            //        if (SelectedPatient.DiscountType != null)
            //        {
            //            List<DiscountRuleSummary> discounts = new List<DiscountRuleSummary>();
            //            Platform.GetService<IDiscountRuleService>(
            //            delegate(IDiscountRuleService service)
            //            {
            //                discounts = service.ListAllDiscount(
            //                new ListDiscountRuleRequest(item.Type.ProcedureTypeRef,
            //                    SelectedPatient.DiscountType.Code,
            //                SelectedPatient.DiscountType.Value,
            //                SelectedPatient.DiscountType.Description))._Discounts;
            //            }
            //            );

            //            if (discounts.Count > 0)
            //            {
            //                DiscountRuleSummary discount = discounts[0];
            //                switch (discount.AmountType)
            //                {
            //                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
            //                        pim.AfterDiscount = discount.Amount;
            //                        break;
            //                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
            //                        pim.AfterDiscount = pim.BasePrice - discount.Amount;
            //                        break;
            //                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
            //                        pim.AfterDiscount = pim.BasePrice * (1 - (discount.Amount / 100));
            //                        break;
            //                }
            //            }
            //        }
            //        if (SelectedPatient.InsuranceType != null)
            //        {
            //            List<InsuranceRuleSummary> Insurances = new List<InsuranceRuleSummary>();
            //            Platform.GetService<IInsuranceRuleService>(
            //            delegate(IInsuranceRuleService service)
            //            {
            //                Insurances = service.ListAllInsurance(
            //             new ListInsuranceRuleRequest(item.Type.ProcedureTypeRef,
            //                 SelectedPatient.InsuranceType.Code,
            //             SelectedPatient.InsuranceType.Value,
            //             SelectedPatient.InsuranceType.Description))._Insurances;
            //            }
            //            );

            //            if (Insurances.Count > 0)
            //            {
            //                InsuranceRuleSummary Insurance = Insurances[0];
            //                switch (Insurance.AmountType)
            //                {
            //                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
            //                        pim.AfterInsurance = Insurance.Amount;
            //                        break;
            //                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
            //                        pim.AfterInsurance = pim.BasePrice - Insurance.Amount;
            //                        break;
            //                    case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
            //                        pim.AfterInsurance = pim.BasePrice * (1 - (Insurance.Amount / 100));
            //                        break;
            //                }
            //            }
            //        }
            //        if (pim.AdjestmentPrice == null || pim.AdjestmentPrice == 0)
            //            pim.AdjestmentPrice = 0;
            //        pim.InsurancePayment = pim.BasePrice - pim.AfterInsurance;
            //        //if (SelectedPatient.DiscountType != null)
            //        //{
            //        //    List<DiscountRuleSummary> Discounts = Platform.GetService<IDiscountRuleService>()
            //        //        .ListAllDiscount(
            //        //        new ListDiscountRuleRequest(item.Type.ProcedureTypeRef,
            //        //            SelectedPatient.InsuranceType.Code,
            //        //        SelectedPatient.InsuranceType.Value,
            //        //        SelectedPatient.InsuranceType.Description))._Discounts;
            //        //    if (Discounts.Count > 0)
            //        //    {
            //        //        DiscountRuleSummary Discount = Discounts[0];
            //        //        switch (Discount.AmountType)
            //        //        {
            //        //            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
            //        //                pim.AfterDiscount = Discount.Amount;
            //        //                break;
            //        //            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
            //        //                pim.AfterDiscount = pim.BasePrice - Discount.Amount;
            //        //                break;
            //        //            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
            //        //                pim.AfterInsurance = pim.BasePrice * (1 - (Discount.Amount / 100));
            //        //                break;
            //        //        }
            //        //    }
            //        //}
            //        pim.DiscountPayment = pim.BasePrice - pim.AfterDiscount;
            //        pim.DueFromYou = pim.BasePrice - (pim.InsurancePayment + pim.AdjestmentPrice + pim.PaymentByYou + pim.WaitingInsuranceAmount + pim.DiscountPayment);
            //        pim.DueFromYou = pim.DueFromYou < 0 ? 0 : pim.DueFromYou;
            //        list.Add(pim);
            //    }
            //}
            //else
            //{
            //    OrderInvoicesDetail d = (OrderInvoicesDetail)currentSelectedOrderDetail.Invoices[0];
            //    //ListOrderInvoiceHistoryProcedure = d.ListProcedures;
            //}
            //foreach (var item in list)
            //{
            //    if (item.IsPackageProcedure)
            //    {
            //        item.AfterDiscount = 0;
            //        item.AfterInsurance = 0;
            //        item.InsurancePayment = 0;
            //        item.DiscountPayment = 0;
            //        item.DueFromYou = 0;
            //        item.AdjestmentPrice = 0;
            //        item.Adjustments = 0;
            //        item.PaymentByYou = 0;
            //        item.WaitingInsuranceAmount = 0;
            //        item.TotalCharge = 0;
            //        item.TotalBalanceDue = 0;
            //    }
            //}
            #endregion

            f.Subreports["HospitalInfoHeader.rpt"].SetDataSource(reports.LoadHospitalInfo.GetHospitalInfoDataSource());

            f.SetDataSource(list);
            //f.SetDataSource(listOrdersInvoiceDetail);
            this.crystalReportViewer1.ReportSource = f;
        }
    }
    public class PrintInvoiceMember
    {
        public string PatientName;
        public string Street;
        public string Address;
        public string ReferenceNumber;
        public decimal TotalBalanceDue;

        public string ProceduceName;
        public decimal TotalCharge;
        public decimal DiscountPayment;
        public decimal InsurancePayment;
        public decimal Adjustments;
        public decimal PaymentByYou;
        public decimal DueFromYou;
        public decimal BasePrice;
        public decimal AfterDiscount;
        public decimal AfterInsurance;
        public decimal WaitingInsuranceAmount;
        public decimal AdjestmentPrice;
        public string PendingInsuranceStatus;
        public bool IsPackageProcedure;
        public decimal PackagePrice;
        public bool IsPendingInsuranceStatus;
        public string PackageProcedureText;
        public string Currency;
    }

}
