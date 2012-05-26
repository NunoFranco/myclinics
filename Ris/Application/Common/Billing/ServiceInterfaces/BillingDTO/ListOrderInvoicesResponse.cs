using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class ListOrderInvoicesResponse : DataContractBase
   {
        public ListOrderInvoicesResponse(List<OrderInvoicesSummary> orderinvoices)
		{
            this.OrderInvoices = orderinvoices;
		}
        public ListOrderInvoicesResponse(List<OrderInvoicesDetail> orderinvoicesDetail)
        {
            this.OrderInvoicesDetail = orderinvoicesDetail;
        }
		[DataMember]
        public List<OrderInvoicesSummary> OrderInvoices;

        [DataMember]
        public List<OrderInvoicesDetail> OrderInvoicesDetail;
    }
}
