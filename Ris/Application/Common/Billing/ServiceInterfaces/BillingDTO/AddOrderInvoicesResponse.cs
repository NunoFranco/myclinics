using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
	[DataContract]
	public class AddOrderInvoicesResponse : DataContractBase
	{
        public AddOrderInvoicesResponse(OrderInvoicesSummary summary)
		{
            this.ObjectSummary = summary;
		}

		[DataMember]
        public OrderInvoicesSummary ObjectSummary;
	}
}

