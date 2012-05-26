using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Ris.Client.Billing;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Client.View.WinForms.Billing.reports;
using ClearCanvas.Common ;

namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    public partial class ServiceTypeForm : Form
    {
        public ServiceTypeForm()
        {
            InitializeComponent();
        }



        private void ServiceTypeForm_Load(object sender, EventArgs e)
        {
            ServiceTypes reportSource = new ServiceTypes();
            reportSource.SetParameterValue("startDate", dateTimePickerStart.Value);
            reportSource.SetParameterValue("endDate", dateTimePickerEnd.Value);
            this.crystalReportViewer1.ReportSource = reportSource;

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            dateTimePickerEnd.Value = new DateTime(dateTimePickerEnd.Value.Year, dateTimePickerEnd.Value.Month, dateTimePickerEnd.Value.Day, 23, 59, 59);
            dateTimePickerStart.Value = new DateTime(dateTimePickerStart.Value.Year, dateTimePickerStart.Value.Month, dateTimePickerStart.Value.Day, 0, 0, 0, DateTimeKind.Unspecified);

            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                ClearCanvas.Common.Platform.ShowMessageBox("Start Date should be before End Date");
                dateTimePickerStart.Focus();
            }
            else
            {
                List<ServiceTypeMeber> dataList = new List<ServiceTypeMeber>();
                ServiceTypesComponent _component = new ServiceTypesComponent();
                List<ProcedureTypeSummary> ListServiceTypes = _component.ListProcedureType(Enterprise.Common.Common.CurrentLoginUserProfile.CurrentClinicRef );
                List<OrderInvoicesDetail> details = new List<OrderInvoicesDetail>();
                Platform.GetService<IOrderInvoicesService>(delegate(IOrderInvoicesService service)
                { 
                    ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListOrderInvoicesRequest request=new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListOrderInvoicesRequest();
                    request.fromdate = dateTimePickerStart.Value;
                    request.todate = dateTimePickerEnd.Value;
                    details=service.ListAllOrderInvoice(request).OrderInvoicesDetail;
                });
                foreach (var item in details)
                {
                    var lst = ClearCanvas.Common.Utilities.ObjectSerialization.DeSerialze<List<BindingGridColumns>>(item.ListProcedures);
                    foreach (var data in lst)
                    {
                        ServiceTypeMeber row = new ServiceTypeMeber();
                        row.CollectCurrency = data.UserCofigureCurrency;
                        row.Quantity = 1;
                        row.ServiceName = data.Name;
                        row.Total = data.TotalPrice;
                        row.UnitPrice = data.BasePrice;
                        dataList.Add(row);
                    }
                }
                //List<int> CountServiceTypes = _component.CountProcedureType(dateTimePickerStart.Value, dateTimePickerEnd.Value);
                //for (int index = 1; index < ListServiceTypes.Count; index++)
                //{
                //    ServiceTypeMeber row = new ServiceTypeMeber();
                //    row.ServiceName = ListServiceTypes[index].Name;
                //    row.UnitPrice = ListServiceTypes[index].BasePrice;
                //    row.Quantity = CountServiceTypes[index];
                //    row.Total = ListServiceTypes[index].BasePrice * CountServiceTypes[index];
                //    dataList.Add(row);
                //}

                ServiceTypes reportSource = new ServiceTypes();
                reportSource.Subreports["HospitalInfoHeader.rpt"].SetDataSource(LoadHospitalInfo.GetHospitalInfoDataSource());
                reportSource.SetDataSource(dataList);
                reportSource.SetParameterValue("startDate", dateTimePickerStart.Value);
                reportSource.SetParameterValue("endDate", dateTimePickerEnd.Value);
                this.crystalReportViewer1.ReportSource = reportSource;

            }
        }
    }
    public class ServiceTypeMeber
    {
        public string ServiceName;
        public int Quantity;
        public decimal UnitPrice;
        public string CollectCurrency;
        public decimal Total;
    }
}
