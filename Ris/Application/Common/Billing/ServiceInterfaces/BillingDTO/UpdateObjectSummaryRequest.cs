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
    public class UpdateObjectSummaryRequest : DataContractBase
    {
        public UpdateObjectSummaryRequest(DiscountRuleDetail objectdetail)
        {
            this.ObjectDiscountRuleDetail = objectdetail;
        }
        public UpdateObjectSummaryRequest(InsuranceRuleDetail objectdetail)
        {
            this.ObjectInsuranceRuleDetail = objectdetail;
        }
        public EntityRef ObjectDiscountRuleRef;

        [DataMember]
        public DiscountRuleDetail ObjectDiscountRuleDetail;
        [DataMember]
        public InsuranceRuleDetail ObjectInsuranceRuleDetail;
    }
    
}
