using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using ClearCanvas.Enterprise.Common;
using System.Xml;

namespace ClearCanvas.Ris.Application.Common.Billing
{
    [DataContract]
    public class DiscountInsuranceDetail : DataContractBase
    {

        public DiscountInsuranceDetail()
        {
        }

        public DiscountInsuranceDetail(EntityRef entityRef, string code, string name, DiscountInsuranceClassType type, DisCountInsuranceAmountType amounttype, decimal amount, DateTime? startdate, DateTime? expiredate, bool deactivated)
        {
            this.DiscountInsuranceRef = entityRef;
            this.Code = code;
            this.Name = name;
            this.ClassType = type;
            this.AmountType = amounttype;
            this.Amount = amount;
            if (startdate != null)
                this.StartDate = (DateTime)startdate;
            if (expiredate != null)
                this.ExpireDate = (DateTime)expiredate;
            Deactivated = deactivated;

        }

        [DataMember]
        public EntityRef DiscountInsuranceRef;

        [DataMember]
        public string Name;

        [DataMember]
        public string Code;

        [DataMember]
        public DiscountInsuranceClassType ClassType;

        [DataMember]
        public DisCountInsuranceAmountType AmountType;

        [DataMember]
        public decimal Amount;

        [DataMember]
        public DateTime StartDate;

        [DataMember]
        public DateTime ExpireDate;

        [DataMember]
        public string CreatedUser;

        [DataMember]
        public DateTime CreatedTime;

        [DataMember]
        public bool Deactivated;

        public DiscountInsuranceSummary GetSummary()
        {
            return new DiscountInsuranceSummary(this.DiscountInsuranceRef, this.Code, this.Name, this.ClassType, this.AmountType, this.Amount);
        }
    }
}
