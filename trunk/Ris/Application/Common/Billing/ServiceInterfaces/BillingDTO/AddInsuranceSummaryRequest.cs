
using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
	[DataContract]
    public class AddInsuranceSummaryRequest : DataContractBase
	{
        public AddInsuranceSummaryRequest(InsuranceRuleDetail detail)
		{
            this.InsuranceRuleDetail = detail;
		}
       
		[DataMember]
        public InsuranceRuleDetail InsuranceRuleDetail;  
	}
}
