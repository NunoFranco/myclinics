using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Ris.Application.Common.Admin.PatientAdmin;
using ClearCanvas.Common;

namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    public partial class ListPatientControl : UserControl
    {
        internal class GridBinding
        {
            public string OrderNumber { get; set; }
            public string PatientID { get; set; }
            public string GivenName { get; set; }
            public string FamilyName { get; set; }
            public string Reason { get; set; }
            public DateTime? Requested { get; set; }
            public string Facility { get; set; }
            public const string OrderNumberField = "OrderNumber";
        }
        public int CurrentRowIndex { get; set; }
        [Browsable(true)]
        public ClearCanvas.Enterprise.Common.OrderBillingStatusEnum PatientBillingStatus { get; set; }

        IList<OrderDetail> listOrdersDetail = new List<OrderDetail>();
        OrderDetail _selectedorder;
        public OrderDetail CurrentSelectedOrder {
            get
            {
                if (this.listOrdersDetail.Count == 0)
                {
                    return null;
                }
                return _selectedorder;
            }
            set {
                _selectedorder = value;
            } 
        }
        public event EventHandler OrderSelectionChanged;
        //static IOrderEntryService _orderService = null;
        //public static IOrderEntryService OrderService
        //{
        //    get
        //    {
        //        if (_orderService == null)
        //        {
        //            _orderService = (IOrderEntryService)Platform.GetService(typeof(IOrderEntryService));
        //        }
        //        return _orderService;
        //    }
        //}

        public ListPatientControl()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            if (PatientBillingStatus == null)
                return;

            if (PatientBillingStatus == ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED)
            {
                Platform.GetService<IOrderEntryService>
                    (delegate(IOrderEntryService service)
                    {
                        listOrdersDetail = service.LoadCompleteOrders(new LoadOrderRequest(null)).orderDetailList;
                    }
                    );

            }
            else if (PatientBillingStatus == ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.WAITING)
            {
                Platform.GetService<IOrderEntryService>
                     (delegate(IOrderEntryService service)
                     {
                         listOrdersDetail = service.LoadWaitingOrders(new LoadOrderRequest(null)).orderDetailList;
                     });

            }
            else if (PatientBillingStatus == ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.PENDING || PatientBillingStatus == ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.COLLECTEDINSURANCE)
            {
                Platform.GetService<IOrderEntryService>
                    (delegate(IOrderEntryService service)
                    {
                        listOrdersDetail = service.LoadPendingOrders(new LoadOrderRequest(null)).orderDetailList;
                    });
            }
            List<GridBinding> datasource = new List<GridBinding>();
            foreach (var item in listOrdersDetail)
            {
                //OrderRequisition rqs = Platform.GetService<IOrderEntryService>().GetOrderRequisitionForEdit(new GetOrderRequisitionForEditRequest(item)).Requisition;
                datasource.Add(
                    new GridBinding
                    {
                        OrderNumber = item.OrderNumber,
                        Reason = item.ReasonForStudy,
                        Facility = item.OrderingFacility.Name,
                        Requested = item.SchedulingRequestTime,
                        GivenName = item.PatinentProfiles.Count > 0 ? item.PatinentProfiles[0].Name.GivenName : "",
                        FamilyName = item.PatinentProfiles.Count > 0 ? item.PatinentProfiles[0].Name.FamilyName : ""
                    }
                    );

            }
            //Bind Data to Grid
            this.gridControl1.DataSource = datasource;

            if (datasource.Count > 0)
            {
                CurrentSelectedOrder = GetOrderFromOrderNumber(datasource[0].OrderNumber);
            }
        }
        private void ListPatientControl_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            if (listOrdersDetail.Count == 0)
                return;
            int[] selectedrows = gv.GetSelectedRows();
            if (selectedrows.Length == 0)
                return;
            CurrentRowIndex = gv.GetSelectedRows()[0];
            if (gv.GetRowCellValue(CurrentRowIndex, GridBinding.OrderNumberField) == null)
                return;
            string orderNumber = gv.GetRowCellValue(CurrentRowIndex, GridBinding.OrderNumberField).ToString();
            CurrentSelectedOrder = GetOrderFromOrderNumber(orderNumber);
            if (OrderSelectionChanged != null)
                this.OrderSelectionChanged(CurrentSelectedOrder, System.EventArgs.Empty);
        }
        OrderDetail GetOrderFromOrderNumber(string ordernumber)
        {
            foreach (var item in listOrdersDetail)
            {
                if (item.OrderNumber != null && item.OrderNumber.Trim().ToLower() == ordernumber.Trim().ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
