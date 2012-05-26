
using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
	[DataContract]
    public class AddDiscountSummaryRequest : DataContractBase
	{
        public AddDiscountSummaryRequest(DiscountRuleDetail detail)
		{
            this.DiscountRuleDetail = detail;
		}
       
		[DataMember]
        public DiscountRuleDetail DiscountRuleDetail;  
	}
}
