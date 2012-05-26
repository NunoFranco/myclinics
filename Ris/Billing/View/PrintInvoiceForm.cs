using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Common;
using ClearCanvas.Ris.Billing.Common;
using ClearCanvas.Ris.Extend.Common;
using ClearCanvas.Ris.Extend.Common.Billing;
using ClearCanvas.Ris.Billing.View.WinForms.reports;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;

namespace ClearCanvas.Ris.Billing.View.WinForms
{
    public partial class PrintInvoiceForm : Form
    {

        //IList<OrderDetail> listOrdersInvoiceDetail = new List<OrderDetail>();
        public PatientProfileDetail SelectedPatient;
        public OrderInvoicesDetail currentSelectedOrderInvoice;
        public OrderSummary currentSelectedOrder;
        public OrderDetail currentSelectedOrderDetail;
        public string invoiceNumber;


        public PrintInvoiceForm()
        {
            InitializeComponent();
        }

        private void PrintInvoiceForm_Load(object sender, EventArgs e)
        {
            PrintInvoice f = new PrintInvoice();
            //Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            //{
            //    listOrdersInvoiceDetail = service.LoadOrder(new LoadOrderRequest(null)).orderDetailList;

            //}
            //);
            List<PrintInvoiceMember> list = new List<PrintInvoiceMember>();

            //this.currentSelectedOrderInvoice = this.getInvoiceDetailFromInvoiceNumber(this.invoiceNumber);

            PrintInvoiceMember pim;
            foreach (var item in this.currentSelectedOrderDetail.Procedures)
            {
                pim = new PrintInvoiceMember
                {
                    AfterDiscount = item.Type.AfterDiscountPrice == null ? 0 : item.Type.AfterDiscountPrice,
                    AfterInsurance = item.Type.AfterDiscountPrice == null ? 0 : item.Type.AfterInsurancePrice,
                    ProceduceName = item.Type.Name,
                    BasePrice = item.Type.BasePrice == null ? 0 : item.Type.BasePrice,
                    AdjestmentPrice = (decimal)item.CollectedAmount == null ? 0 : (decimal)item.CollectedAmount,
                    IsPackageProcedure = item.IsPackageProcedure,
                    PackagePrice = item.PackageProcedure == null ? 0 : (decimal)item.PackageProcedure.PackagePrice,
                    WaitingInsuranceAmount = item.WaitingInsuranceAmount,
                    IsPendingInsuranceStatus = item.IsPendingProcedure,
                    PendingInsuranceStatus = item.IsPendingProcedure == true ? SR.Pending : SR.Confirmed
                };
                pim.Street = "";
                if (this.SelectedPatient.Addresses.Count > 0)
                {
                    pim.Street = this.SelectedPatient.Addresses[0].Street == null ? "" : this.SelectedPatient.Addresses[0].Street;
                    pim.Address = this.SelectedPatient.Addresses[0].Province + " " + this.SelectedPatient.Addresses[0].City + " " + this.SelectedPatient.Addresses[0].Country + " OR " + this.SelectedPatient.Addresses[0].PostalCode;
                }

                if (this.SelectedPatient.Name != null)
                {
                    pim.PatientName = this.SelectedPatient.Name.FamilyName + " " + this.SelectedPatient.Name.MiddleName + " " + this.SelectedPatient.Name.GivenName;
                }
                pim.ReferenceNumber = this.invoiceNumber;
                pim.ProceduceName = item.Type.Name;
                pim.TotalCharge = item.Type.BasePrice;

                pim.AfterDiscount = pim.BasePrice;
                pim.AfterInsurance = pim.BasePrice;
                if (pim.WaitingInsuranceAmount == 0)
                {
                    pim.PendingInsuranceStatus = SR.NotPending;
                }
                if (SelectedPatient.DiscountType != null)
                {
                    List<DiscountRuleSummary> discounts = Platform.GetService<IDiscountRuleService>()
                        .ListAllDiscount(
                        new ListDiscountRuleRequest(item.Type.ProcedureTypeRef,
                            SelectedPatient.DiscountType.Code,
                        SelectedPatient.DiscountType.Value,
                        SelectedPatient.DiscountType.Description))._Discounts;
                    if (discounts.Count > 0)
                    {
                        DiscountRuleSummary discount = discounts[0];
                        switch (discount.AmountType)
                        {
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
                                pim.AfterDiscount = discount.Amount;
                                break;
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
                                pim.AfterDiscount = pim.BasePrice - discount.Amount;
                                break;
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
                                pim.AfterDiscount = pim.BasePrice * (1 - (discount.Amount / 100));
                                break;
                        }
                    }
                }
                if (SelectedPatient.InsuranceType != null)
                {
                    List<InsuranceRuleSummary> Insurances = Platform.GetService<IInsuranceRuleService>()
                        .ListAllInsurance(
                        new ListInsuranceRuleRequest(item.Type.ProcedureTypeRef,
                            SelectedPatient.InsuranceType.Code,
                        SelectedPatient.InsuranceType.Value,
                        SelectedPatient.InsuranceType.Description))._Insurances;
                    if (Insurances.Count > 0)
                    {
                        InsuranceRuleSummary Insurance = Insurances[0];
                        switch (Insurance.AmountType)
                        {
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
                                pim.AfterInsurance = Insurance.Amount;
                                break;
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
                                pim.AfterInsurance = pim.BasePrice - Insurance.Amount;
                                break;
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
                                pim.AfterInsurance = pim.BasePrice * (1 - (Insurance.Amount / 100));
                                break;
                        }
                    }
                }
                if (pim.AdjestmentPrice == null || pim.AdjestmentPrice == 0)
                    pim.AdjestmentPrice = 0;
                pim.InsurancePayment = pim.BasePrice - pim.AfterInsurance;
                if (SelectedPatient.DiscountType != null)
                {
                    List<DiscountRuleSummary> Discounts = Platform.GetService<IDiscountRuleService>()
                        .ListAllDiscount(
                        new ListDiscountRuleRequest(item.Type.ProcedureTypeRef,
                            SelectedPatient.InsuranceType.Code,
                        SelectedPatient.InsuranceType.Value,
                        SelectedPatient.InsuranceType.Description))._Discounts;
                    if (Discounts.Count > 0)
                    {
                        DiscountRuleSummary Discount = Discounts[0];
                        switch (Discount.AmountType)
                        {
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.FIXEDPRICE:
                                pim.AfterDiscount = Discount.Amount;
                                break;
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.REDUCEAMOUNT:
                                pim.AfterDiscount = pim.BasePrice - Discount.Amount;
                                break;
                            case ClearCanvas.Enterprise.Common.DisCountInsuranceAmountType.PERCENTAGE:
                                pim.AfterInsurance = pim.BasePrice * (1 - (Discount.Amount / 100));
                                break;
                        }
                    }
                }
                pim.DiscountPayment = pim.BasePrice - pim.AfterDiscount;
                pim.DueFromYou = pim.BasePrice - (pim.InsurancePayment + pim.AdjestmentPrice + pim.PaymentByYou + pim.WaitingInsuranceAmount + pim.DiscountPayment);
                pim.DueFromYou = pim.DueFromYou < 0 ? 0 : pim.DueFromYou;
                list.Add(pim);
            }
            foreach (var item in list)
            {
                if (item.IsPackageProcedure)
                {
                    item.AfterDiscount = 0;
                    item.AfterInsurance = 0;
                    item.InsurancePayment = 0;
                    item.DiscountPayment = 0;
                    item.DueFromYou = 0;
                    item.AdjestmentPrice = 0;
                    item.Adjustments = 0;
                    item.PaymentByYou = 0;
                    item.WaitingInsuranceAmount = 0;
                    item.TotalCharge = 0;
                    item.TotalBalanceDue = 0;
                }
            }
            f.SetDataSource(list);
            //f.SetDataSource(listOrdersInvoiceDetail);
            this.crystalReportViewer1.ReportSource = f;
        }


        //OrderInvoicesDetail getInvoiceDetailFromInvoiceNumber(string invoiceNumber)
        //{
        //    foreach (var item in listOrdersInvoiceDetail)
        //    {
        //        if (item.Invoices.Count() > 0)
        //        {
        //            foreach (var invoice in item.Invoices)
        //            {
        //                if (invoice.InvoiceNumber != null && invoice.InvoiceNumber.Trim().ToLower() == invoiceNumber.Trim().ToLower())
        //                {
        //                    return invoice;
        //                }
        //            }
        //            //return null;
        //        }
        //    }
        //    return null;
        //}

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
    }

}
