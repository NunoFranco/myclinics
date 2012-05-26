using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Common;

using System.Xml;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.ModalityAdmin;
using ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Client.View.WinForms.Billing.reports;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    public partial class ModalitiesForm : Form
    {
        IList<OrderDetail> listOrdersDetail = new List<OrderDetail>();
        List<ModalitiesMember> CombineObject = new List<ModalitiesMember>();
        List<ModalitiesMember> dataSource = new List<ModalitiesMember>();
        List<ModalitySummary> modalities = new List<ModalitySummary>();
        List<ProcedureTypeDetail> types = new List<ProcedureTypeDetail>();
        public ModalitiesForm()
        {
            InitializeComponent();
        }
        string GetModalityCode(string procedureTypeplanxml)
        {
            string modalityCode = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(procedureTypeplanxml);
            XmlNode node = null;
            if (doc.SelectNodes("procedure-plan/procedure-steps/procedure-step") != null)
                node = doc.SelectNodes("procedure-plan/procedure-steps/procedure-step")[0];

            if (node != null && node.Attributes["modality"] != null)
            {
                modalityCode = node.Attributes["modality"].Value;
            }

            return modalityCode;

        }
        private void ModalitiesForm_Load(object sender, EventArgs e)
        {

            Platform.GetService<IModalityAdminService>(delegate(IModalityAdminService service)
            {
                modalities = service.ListAllModalities(new ListAllModalitiesRequest()).Modalities;
            });
            Platform.GetService<IProcedureTypeAdminService>(delegate(IProcedureTypeAdminService service)
            {
                types = service.ListProcedureTypes(new ListProcedureTypesRequest(true)).ProcedureTypesDetails;
            });
            BindModalities(modalities);
            foreach (var item in modalities)
            {
                ModalitiesMember m = new ModalitiesMember();
                m.Code = item.Id;
                m.Name = item.Name;

                ProcedureTypeDetail matchType = types.FirstOrDefault<ProcedureTypeDetail>(t => GetModalityCode(t.PlanXml) == item.Id);
                if (matchType != null)
                {
                    m.TypeCode = matchType.Id;
                    m.TypeName = matchType.Name;
                }
                CombineObject.Add(m);
            }


            //reports.Modalities reportModality = new ClearCanvas.Ris.Client.View.WinForms.Billing.reports.Modalities();
            //reportModality.Subreports["HospitalInfoHeader.rpt"].SetDataSource(reports.LoadHospitalInfo.GetHospitalInfoDataSource());
            //this.crystalReportViewer1.ReportSource = reportModality;
            //this.crystalReportViewer1.Refresh();

            BindReport(null);
        }
        void BindReport(object datasource)
        {
            Modalities reportDocument = new Modalities();
            reportDocument.Subreports["HospitalInfoHeader.rpt"].SetDataSource(LoadHospitalInfo.GetHospitalInfoDataSource());
            if (datasource != null)
            {
                reportDocument.SetDataSource(dataSource);
            }
            this.crystalReportViewer1.ReportSource = reportDocument;
            this.crystalReportViewer1.Refresh();
        }
        void BindModalities(List<ModalitySummary> list)
        {
            this.cmbModalities.Items.Clear();
            this.cmbModalities.Items.AddRange(list.Select(x => x.Name).ToArray());

        }
        private void buttonFacility_Click(object sender, EventArgs e)
        {
            Modalities f = new Modalities();
            dataSource.RemoveAll(x => x != null);
            Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            {
                LoadOrderRequest request = new LoadOrderRequest(null);
                request.StartTimeEnteredOrder = this.fromDate.Value.Date;
                request.EndTimeEnteredOrder = this.toDate.Value.Date;
                listOrdersDetail = service.LoadOrder(request).orderDetailList;
            }
            );

            ModalitiesMember member = null;
            if (this.cmbModalities.SelectedItem != null)// if Modality selected
            {
                member = CombineObject.FirstOrDefault<ModalitiesMember>(x => x.Name == this.cmbModalities.SelectedItem.ToString());
            }

            foreach (var item in listOrdersDetail)
            {

                foreach (var pro in item.Procedures)
                {
                    var data = CombineObject.FirstOrDefault(d => d.TypeCode == pro.Type.Id);
                    if (member != null)
                    {
                        data = member;
                        if (data.TypeCode != pro.Type.Id)
                            continue;
                    }
                    if (data != null)
                    {
                        var dataItem = dataSource.FirstOrDefault(d => d.TypeCode == pro.Type.Id && d.RequestDate == (item.EnteredTime != null ? item.EnteredTime.Value.Date.ToString() : ""));
                        if (dataItem != null)
                        {
                            dataItem.TotalNumberOfPatient += 1;
                        }
                        else
                        {
                            ModalitiesMember mo = new ModalitiesMember()
                                                    {
                                                        Code = data.Code,
                                                        Name = data.Name,
                                                        RequestDate = item.EnteredTime != null ? item.EnteredTime.Value.Date.ToString() : "",
                                                        TotalNumberOfPatient = 1,
                                                        TypeCode = data.TypeCode,
                                                        TypeName = data.TypeName
                                                    };
                            dataSource.Add(mo);
                        }
                    }

                }
            }
            BindReport(dataSource);
            //reports.Modalities reportModality = new ClearCanvas.Ris.Client.View.WinForms.Billing.reports.Modalities();
            //reportModality.Subreports["HospitalInfoHeader.rpt"].SetDataSource(reports.LoadHospitalInfo.GetHospitalInfoDataSource());
            //reportModality.SetDataSource(dataSource);
            //this.crystalReportViewer1.ReportSource = reportModality;
            //this.crystalReportViewer1.Refresh();
        }
    }

    public class ModalitiesMember
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public string RequestDate { get; set; }
        public decimal TotalNumberOfPatient { get; set; }
    }
}
