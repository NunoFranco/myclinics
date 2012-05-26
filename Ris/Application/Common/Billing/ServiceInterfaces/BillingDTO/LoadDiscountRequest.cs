using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class LoadDiscountRequest : ListRequestBase
    {
        public LoadDiscountRequest(EntityRef discountRuleRef, string amountType, decimal amount, EntityRef FacilityRef)
        {
            this.DiscountRuleRef = discountRuleRef;
            this.AmountType = amountType;
            this.Amount = amount;
            ClinicRef = FacilityRef;
        }

        public LoadDiscountRequest()
        {
        }




        public LoadDiscountRequest(SearchResultPage page, EntityRef FacilityRef)
            : base(page, FacilityRef)
        {
            ClinicRef = FacilityRef;
        }

        [DataMember]
        public string ClassID;

        [DataMember]
        public EntityRef DiscountRuleRef;

        [DataMember]
        public string AmountType;


        [DataMember]
        public decimal Amount;

        [DataMember]
        public EntityRef ClinicRef;



    }
}
