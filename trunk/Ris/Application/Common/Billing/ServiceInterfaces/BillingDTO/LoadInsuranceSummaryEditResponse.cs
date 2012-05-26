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
    public class LoadInsuranceSummaryEditResponse : DataContractBase
    {
        public LoadInsuranceSummaryEditResponse(InsuranceRuleDetail detail)
        {
            this.InsuranceDetail = detail;
        }
        [DataMember]
        public EntityRef EntityRef;

        [DataMember]
        public InsuranceRuleDetail InsuranceDetail;
    }
}
