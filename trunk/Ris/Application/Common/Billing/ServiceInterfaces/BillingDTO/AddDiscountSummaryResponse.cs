using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
	[DataContract]
    public class AddDiscountSummaryResponse : DataContractBase
	{
		public AddDiscountSummaryResponse(DiscountRuleSummary summary)
		{
            this.DiscountRuleSummary = summary;
		}

        public AddDiscountSummaryResponse()
        {

        }
		[DataMember]
        public DiscountRuleSummary DiscountRuleSummary;        
	}
}

