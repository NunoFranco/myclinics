using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Ris.Billing.View.WinForms.reports;
using ClearCanvas.Ris.Billing;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Common;
namespace ClearCanvas.Ris.Billing.View.WinForms
{
    public partial class RevenueForm : Form
    {
        public RevenueForm()
        {
            InitializeComponent();
            Revenue reportSource = new Revenue();
            reportSource.SetParameterValue("startDate", dateTimePickerStart.Value);
            reportSource.SetParameterValue("endDate", dateTimePickerEnd.Value);
            this.crystalReportViewer1.ReportSource = reportSource;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            dateTimePickerEnd.Value = new DateTime(dateTimePickerEnd.Value.Year, dateTimePickerEnd.Value.Month, dateTimePickerEnd.Value.Day, 23, 59, 59);
            DateTime startDate = dateTimePickerStart.Value.AddDays(-1);
            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 23, 59, 59);

            if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
            {
                ClearCanvas.Common.Platform.ShowMessageBox("Start Date should be before End Date");
                dateTimePickerStart.Focus();
            }
            else
            {
                //List<ServiceTypeMeber> dataList = new List<ServiceTypeMeber>();
                //ServiceTypesComponent _component = new ServiceTypesComponent();

                //List<TotalInDate> data = _component.ListOrderDateTimeEntered(startDate, dateTimePickerEnd.Value);
                List<revenueDaily> revenueItems = new List<revenueDaily>();
                List<OrderInvoicesDetail> details = new List<OrderInvoicesDetail>();
                Platform.GetService<IOrderInvoicesService>(delegate(IOrderInvoicesService service)
                {
                    ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.Billing.ListOrderInvoicesRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.Billing.ListOrderInvoicesRequest();
                    request.fromdate = dateTimePickerStart.Value;
                    request.todate = dateTimePickerEnd.Value;
                    details = service.ListAllOrderInvoice(request).OrderInvoicesDetail;
                });
                foreach (var item in details)
                {
                    var lst = ClearCanvas.Common.Utilities.ObjectSerialization.DeSerialze<List<BindingGridColumns>>(item.ListProcedures);
                    if (lst == null || lst[0] == null)
                        continue;
                    revenueDaily row = new revenueDaily();
                    row.CollectCurrency = lst[0].UserCofigureCurrency;
                    row.date = item.CreatedDate.Date;
                    row.total = item.TotalCollect;
                    revenueItems.Add(row);
                    
                }
                //foreach (TotalInDate item in data)
                //{
                //    revenueDaily daily = new revenueDaily();
                //    //daily.year = item.Entered.Value.Year;
                //    //daily.month = item.Entered.Value.Month;
                //    //daily.day = item.Entered.Value.Day;
                //    daily.date = item.Entered.Value;
                //    daily.total = item.Total;
                //    revenueItems.Add(daily);
                //}

                Revenue reportSource = new Revenue();
                reportSource.Subreports["HospitalInfoHeader.rpt"].SetDataSource(reports.LoadHospitalInfo.GetHospitalInfoDataSource());
                reportSource.SetDataSource(revenueItems);
                reportSource.SetParameterValue("startDate", dateTimePickerStart.Value);
                reportSource.SetParameterValue("endDate", dateTimePickerEnd.Value);
                this.crystalReportViewer1.ReportSource = reportSource;

            }
        }
    }
    public class revenueDaily
    {
        //public int year;
        //public int month;
        //public int day;
        public DateTime date;
        public decimal total;
        public string CollectCurrency;
    }
}
