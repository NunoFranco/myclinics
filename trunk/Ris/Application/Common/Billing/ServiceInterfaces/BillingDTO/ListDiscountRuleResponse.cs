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
   public  class ListDiscountRuleResponse
   {
        public ListDiscountRuleResponse(List<DiscountRuleSummary> Discounts)
		{
            this._Discounts = Discounts;
		}
		[DataMember]
        public List<DiscountRuleSummary> _Discounts;

        
    }
}
