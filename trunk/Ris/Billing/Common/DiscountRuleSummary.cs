using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Billing.Common
{
    [DataContract]
    public class DiscountRuleSummary : DataContractBase, IEquatable<DiscountRuleSummary>
    {
        public DiscountRuleSummary(EntityRef entityRef, string code, string name, DisCountInsuranceAmountType amounttype, decimal amount, 
            DateTime? startdate, 
            DateTime? expiredate, 
            bool deactivated,
            string proceduretypeid,
            string discountclasscode)
        {
            this.DiscountRef = entityRef;
            this.DiscountClassCode = discountclasscode;
            this.Procedureid = proceduretypeid;
            this.Code = code;
            this.Name = name;
            
            this.AmountType = amounttype;
            this.Amount = amount;
            if (startdate != null)
                this.StartDate = (DateTime)startdate;
            if (expiredate != null)
                this.ExpireDate = (DateTime)expiredate;
            Deactivated = deactivated;
        }

        public DiscountRuleSummary()
        {
        }

        [DataMember]
        public EntityRef DiscountRef;

        [DataMember]
        public string Procedureid;

        [DataMember]
        public string DiscountClassCode;

        [DataMember]
        public string Name;

        [DataMember]
        public string Code;       

        [DataMember]
        public DisCountInsuranceAmountType AmountType;

        [DataMember]
        public decimal Amount;

        [DataMember]
        public DateTime? StartDate;

        [DataMember]
        public DateTime? ExpireDate;

        [DataMember]
        public string CreatedUser;

        [DataMember]
        public DateTime? CreatedDate;

        [DataMember]
        public bool Deactivated;


        public DiscountRuleSummary GetSummary()
        {
            return new DiscountRuleSummary(this.DiscountRef, this.Code, this.Name,  this.AmountType, this.Amount, this.StartDate, this.ExpireDate, this.Deactivated,"","");
        }

        public bool Equals(DiscountRuleSummary that)
        {
            if (that == null) return false;
            return Equals(this.DiscountRef, that.DiscountRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DiscountRuleSummary);
        }

        public override int GetHashCode()
        {
            return DiscountRef.GetHashCode();
        }
    }
}
