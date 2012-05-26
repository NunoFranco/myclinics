using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class LoadInsuranceResponse : DataContractBase
    {
        public LoadInsuranceResponse(IList<InsuranceRuleDetail> Insurances)
        {
            InsuranceList = Insurances;
        }

        [DataMember]
        public IList<InsuranceRuleDetail> InsuranceList;

        
    }
}
