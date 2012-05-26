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
    public class UpdateObjectSummaryResponse : DataContractBase
    {
        public UpdateObjectSummaryResponse(DiscountRuleSummary summary)
        {
            this.ObjectDiscountRuleSummary = summary;
        }

        public UpdateObjectSummaryResponse(InsuranceRuleSummary summary)
        {
            this.ObjectInsuranceRuleSummary = summary;
        }

        [DataMember]
        public DiscountRuleSummary ObjectDiscountRuleSummary;
        [DataMember]
        public InsuranceRuleSummary ObjectInsuranceRuleSummary;
    }
}
