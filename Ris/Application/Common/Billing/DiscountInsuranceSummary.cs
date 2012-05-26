using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common.Billing
{
    public class DiscountInsuranceSummary : DataContractBase, IEquatable<DiscountInsuranceSummary>
    {
        public DiscountInsuranceSummary(EntityRef entityRef, string code, string name,DiscountInsuranceClassType type, DisCountInsuranceAmountType amounttype, decimal amount)
        {
            this.DiscountInsuranceRef = entityRef;
            this.ClassCode = code;
            this.ClassName= name;
            this.ClassType = type;
            this.AmountType = amounttype;
            this.Amount = amount;
        }

        public DiscountInsuranceSummary()
        {
        }

        [DataMember]
        public EntityRef DiscountInsuranceRef;

        [DataMember]
        public string ClassName;

        [DataMember]
        public string ClassCode;

        [DataMember]
        public DiscountInsuranceClassType ClassType;

        [DataMember]
        public DisCountInsuranceAmountType AmountType;

        [DataMember]
        public decimal Amount;

        public bool Equals(DiscountInsuranceSummary that)
        {
            if (that == null) return false;
            return Equals(this.DiscountInsuranceRef, that.DiscountInsuranceRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DiscountInsuranceSummary);
        }

        public override int GetHashCode()
        {
            return DiscountInsuranceRef.GetHashCode();
        }
    }
}
