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
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Client.View.WinForms.Billing.reports;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Ris.Application.Common.Admin.ExternalPractitionerAdmin;
using ClearCanvas.Ris.Client.View.WinForms.Billing.reports;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    public partial class PrintDoctorForm : Form
    {
        IList<OrderDetail> listOrdersDetail = new List<OrderDetail>();
        List<ExternalPractitionerSummary> doctors = new List<ExternalPractitionerSummary>();
        public PrintDoctorForm()
        {
            InitializeComponent();
        }

        private void PrintDoctorForm_Load(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            List<DoctorMember> list = new List<DoctorMember>();

            Platform.GetService<IExternalPractitionerAdminService>(delegate(IExternalPractitionerAdminService service)
            {
                doctors = service.ListExternalPractitioners(new ListExternalPractitionersRequest()).Practitioners;
            });
            doctors.OrderBy(x => x.Name.FamilyName);
            BindDoctors(doctors);
            d.SetDataSource(list);
            this.crystalReportViewer1.ReportSource = d;
        }
        void BindDoctors(List<ExternalPractitionerSummary> list)
        {
            this.cmbPractitioner.Items.Clear();
            this.cmbPractitioner.Items.AddRange(list.Select(x => x.Name).ToArray());

        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            List<DoctorMember> list = new List<DoctorMember>();

            List<OrderDetail> ordersByPractitioner = new List<OrderDetail>();
            string selectedf = this.cmbPractitioner.SelectedItem != null ? this.cmbPractitioner.SelectedItem.ToString() : "";
            if (string.IsNullOrEmpty(selectedf))
            {
                Platform.ShowMessageBox(SR.DropDownMandatorySelected);
                return;
            }
            Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            {
                listOrdersDetail = service.LoadOrder(new LoadOrderRequest(null)).orderDetailList;
            }
           );
            ordersByPractitioner = this.ListOrderByPractitioner(this.cmbPractitioner.SelectedIndex);
            foreach (var item in ordersByPractitioner)
            {
                DoctorMember dm = new DoctorMember();
                if (item.Invoices.Count > 0)
                {
                    dm.DoctorName = item.OrderingPractitioner.Name.FamilyName + " " + item.OrderingPractitioner.Name.MiddleName + " " + item.OrderingPractitioner.Name.GivenName;
                    dm.LicenseNumber = item.OrderingPractitioner.LicenseNumber;
                    //dm.Address = item.PatinentProfiles[0].Addresses[0].Street == null ? "" : item.PatinentProfiles[0].Addresses[0].Street;
                    dm.InvNumber = item.Invoices[0].InvoiceNumber;
                    dm.DateCreated = item.EnteredTime.Value;
                    dm.PatientName = item.PatinentProfiles[0].Name.FamilyName + " " + item.PatinentProfiles[0].Name.MiddleName + " " + item.PatinentProfiles[0].Name.GivenName;
                    dm.BillingStatus = item.BillingStatus;
                    dm.Price = item.Invoices[0].TotalCollect;
                    var lst = ClearCanvas.Common.Utilities.ObjectSerialization.DeSerialze<List<BindingGridColumns>>(item.Invoices[0].ListProcedures);
                    if (lst == null || lst[0] == null)
                        continue;
                    dm.CollectedCurrency = lst[0].UserCofigureCurrency;
                    list.Add(dm);
                }
            }
            d.Subreports["HospitalInfoHeader.rpt"].SetDataSource(LoadHospitalInfo.GetHospitalInfoDataSource());
            d.SetDataSource(list);
            this.crystalReportViewer1.ReportSource = d;
        }
        private List<OrderDetail> ListOrderByPractitioner(int index)
        {
            List<OrderDetail> result = new List<OrderDetail>();
            if (index >= 0 && index <= doctors.Count - 1)
            {
                foreach (var item in listOrdersDetail)
                {
                    if (doctors[index].Name.ToString() == (item.OrderingPractitioner.Name.ToString()))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
    public class DoctorMember
    {
        public string DoctorName;
        public string LicenseNumber;
        public string PhoneNumber;
        public string Address;
        public string InvNumber;
        public DateTime DateCreated;
        public string PatientName;
        public string BillingStatus;
        public string CollectedCurrency;
        public decimal Price;
    }
}
