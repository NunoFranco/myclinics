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
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.Billing;
using ClearCanvas.Ris.Billing.View.WinForms.reports;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.FacilityAdmin;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;

namespace ClearCanvas.Ris.Billing.View.WinForms
{
    public partial class FacilityForm : Form
    {
        private string[] _facilityChoices;
        IList<OrderDetail> listOrdersInvoiceDetail = new List<OrderDetail>();
        IList<FacilitySummary> listFacilities = new List<FacilitySummary>();
        public PatientProfileDetail SelectedPatient;
        public OrderInvoicesDetail currentSelectedOrderInvoice;
        public OrderSummary currentSelectedOrder;
        public FacilityForm()
        {
            InitializeComponent();
            var facilities = this.LoadAllFacilites();
            this._facilityChoices = CollectionUtils.Map(facilities, (FacilitySummary fs) => fs.Code).ToArray();

            this.comboBoxFacility.Items.Clear();
            this.comboBoxFacility.Items.AddRange(this._facilityChoices);

            var initialFacilityCode = "";
            // if no saved facility, just choose the first one
            if (string.IsNullOrEmpty(initialFacilityCode) && this._facilityChoices.Length > 0)
                initialFacilityCode = this._facilityChoices[0];
        }

        private void FacilityForm_Load(object sender, EventArgs e)
        {
            var facilities = this.LoadAllFacilites();
            this._facilityChoices = CollectionUtils.Map(facilities, (FacilitySummary fs) => fs.Code).ToArray();

            var initialFacilityCode = "";
            // if no saved facility, just choose the first one
            if (string.IsNullOrEmpty(initialFacilityCode) && this._facilityChoices.Length > 0)
                initialFacilityCode = this._facilityChoices[0];
            Facility f = new Facility();
            List<Object> result = new List<Object>();
            f.SetDataSource(result);
            this.crystalReportViewer1.ReportSource = f;
        }

        private decimal GetTotalOnOrder(OrderDetail orderDetail)
        {
            decimal totalOnOrder = 0;
            if (orderDetail.Invoices.Count == 0)
                return 0;
            totalOnOrder = orderDetail.Invoices[0].TotalCollect;
            //foreach (var item in orderDetail.Procedures)
            //{
            //    totalOnOrder += item.Type.BasePrice;
            //}
            return totalOnOrder;
        }
        private List<OrderDetail> FilterOrderByFacility(string facilityCode)
        {
            List<OrderDetail> result = new List<OrderDetail>();
            foreach (var item in this.listOrdersInvoiceDetail)
            {
                if (string.IsNullOrEmpty(facilityCode) || facilityCode.Equals(item.OrderingFacility.Code))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private void buttonFacility_Click(object sender, EventArgs e)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            string selectedf = this.comboBoxFacility.SelectedItem != null ? this.comboBoxFacility.SelectedItem.ToString() : "";
            if (string.IsNullOrEmpty(selectedf))
            {
                Platform.ShowMessageBox(SR.DropDownMandatorySelected);
                return;
            }
            Facility f = new Facility();

            Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            {
                LoadOrderRequest request = new LoadOrderRequest(null);
                request.StartTimeEnteredOrder = this.fromDate.Value;
                request.EndTimeEnteredOrder = this.toDate.Value;
                listOrdersInvoiceDetail = service.LoadOrder(request).orderDetailList;
            }
            );
            list = this.FilterOrderByFacility(selectedf);

            List<Object> result = new List<Object>();
            OrderMember om;

            foreach (var item in list)
            {
                om = new OrderMember();
                om.FacilityName = item.OrderingFacility.Name;
                om.FromDate = this.fromDate.Text;
                om.ToDate = this.toDate.Text;
                om.OrderName = item.OrderNumber;
                om.DateCreated = item.EnteredTime.ToString();
                om.PatientName = item.PatinentProfiles[0].Name.FamilyName + " " + item.PatinentProfiles[0].Name.MiddleName + " " + item.PatinentProfiles[0].Name.GivenName;
                om.TotalOnOrder = this.GetTotalOnOrder(item);

                //show only Invoice Created Order
                if (item.Invoices != null && item.Invoices.Count > 0 && item.Invoices[0] != null)
                {
                    var lst = ClearCanvas.Common.Utilities.ObjectSerialization.DeSerialze<List<BindingGridColumns>>(item.Invoices[0].ListProcedures);
                    if (lst != null && lst[0] != null)
                        om.CollectedCurrency = lst[0].UserCofigureCurrency;
                    result.Add(om);
                }
            }
            f.Subreports["HospitalInfoHeader.rpt"].SetDataSource(reports.LoadHospitalInfo.GetHospitalInfoDataSource());
            f.SetDataSource(result);
            this.crystalReportViewer1.ReportSource = f;
            this.crystalReportViewer1.Refresh();
        }
        private IList<FacilitySummary> LoadAllFacilites()
        {
            Platform.GetService<IFacilityAdminService>(delegate(IFacilityAdminService service)
            {
                listFacilities = service.ListAllFacilities(new ListAllFacilitiesRequest(new SearchResultPage())).Facilities;
            });
            return listFacilities;
        }

        //private static List<FacilitySummary> GetFacilityChoices()
        //{
        //    List<FacilitySummary> choices = null;
        //    Platform.GetService<ILoginService>(
        //        service => choices = service.GetWorkingFacilityChoices(new GetWorkingFacilityChoicesRequest()).FacilityChoices);
        //    return choices;
        //}
        public string[] FacilityChoices
        {
            get { return this._facilityChoices; }
            set
            {
                this._facilityChoices = value;
                this.comboBoxFacility.Items.Clear();
                this.comboBoxFacility.Items.AddRange(this._facilityChoices);
            }
        }

        public string SelectedFacility
        {
            get { return (string)this.comboBoxFacility.SelectedItem; }
            set
            {
                this.comboBoxFacility.SelectedItem = value;
            }
        }
    }
    public class OrderMember
    {
        public string FacilityName;
        public string OrderName;
        public string FromDate;
        public string ToDate;
        public string DateCreated;
        public string PatientName;
        public string CollectedCurrency;
        public decimal TotalOnOrder;
    }

    public class FacilityMember
    {
        public string ProcedureName;
        public int Quanlity;
        public decimal UnitPrice;
        public decimal RowTotal;
    }
}
