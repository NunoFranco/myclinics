using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common.Billing
{
    [DataContract]
    public class InsuranceRuleSummary : DataContractBase, IEquatable<InsuranceRuleSummary>
    {
        public InsuranceRuleSummary(EntityRef entityRef, string code, string name, DisCountInsuranceAmountType amounttype, decimal amount, DateTime? startdate, DateTime? expiredate, bool deactivated)
        {
            this.InsuranceRef = entityRef;
            
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

        public InsuranceRuleSummary()
        {
        }

        [DataMember]
        public EntityRef InsuranceRef;

       

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

        public InsuranceRuleSummary GetSummary()
        {
            return new InsuranceRuleSummary(this.InsuranceRef, this.Code, this.Name,  this.AmountType, this.Amount, this.StartDate, this.ExpireDate, this.Deactivated);
        }

        public bool Equals(InsuranceRuleSummary that)
        {
            if (that == null) return false;
            return Equals(this.InsuranceRef, that.InsuranceRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InsuranceRuleSummary);
        }

        public override int GetHashCode()
        {
            return InsuranceRef.GetHashCode();
        }

        
    }
}
