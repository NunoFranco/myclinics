using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class LoadInsuranceRequest: ListRequestBase
    {
        public LoadInsuranceRequest(EntityRef InsuranceRuleRef, string amountType, decimal amount,EntityRef FacilityRef)
        {
            this.InsuranceRuleRef = InsuranceRuleRef;
            this.AmountType = amountType;
            this.Amount = amount;
            ClinicRef = FacilityRef;
        }

        public LoadInsuranceRequest()
        {            
        }




        public LoadInsuranceRequest(SearchResultPage page, EntityRef FacilityRef)
			: base(page, FacilityRef)
		{
            ClinicRef = FacilityRef;
		}

        [DataMember]
        public string ClassID;

        [DataMember]
        public EntityRef InsuranceRuleRef;
        
        [DataMember]
        public string AmountType;


        [DataMember]
        public decimal Amount;

[DataMember]
        public EntityRef  ClinicRef;
        
        
    }
}
