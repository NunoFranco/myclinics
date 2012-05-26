using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using ClearCanvas.Enterprise.Common;
using System.Xml;

namespace ClearCanvas.Ris.Billing.Common
{
    [DataContract]
    public class DiscountRuleDetail : DataContractBase
    {

        //public DiscountRuleDetail()
        //{
        //}

        //public DiscountRuleDetail(EntityRef entityRef, string code, string name, DiscountAmountType amounttype, decimal amount, DateTime? startdate, DateTime? expiredate, bool deactivated)
        //{
        //    this.DiscountRef = entityRef;
        //    this.Code = code;
        //    this.Name = name;
            
        //    this.AmountType = amounttype;
        //    this.Amount = amount;
        //    if (startdate != null)
        //        this.StartDate = (DateTime)startdate;
        //    if (expiredate != null)
        //        this.ExpireDate = (DateTime)expiredate;
        //    Deactivated = deactivated;

        //}

        //[DataMember]
        //public EntityRef DiscountRef;

        //[DataMember]
        //public string Name;

        //[DataMember]
        //public string Code;
        
        //[DataMember]
        //public DiscountAmountType AmountType;

        //[DataMember]
        //public decimal Amount;

        //[DataMember]
        //public DateTime? StartDate;

        //[DataMember]
        //public DateTime? ExpireDate;

        //[DataMember]
        //public string CreatedUser;

        //[DataMember]
        //public DateTime? CreatedDate;

        //[DataMember]
        //public bool Deactivated;

        //[DataMember]
        //public virtual DateTime? LastUpdated { get; set; }

        public DiscountRuleSummary GetSummary()
        {
            return new DiscountRuleSummary(this.DiscountDetailRef, this.RuleCode, this.RuleName, this.AmountType, this.Amount, this.StartDate, this.ExpireDate, this.Deactivated,"","");
            
        }
        
        
      
        [DataMember]
        public virtual string ClassIDCode { get; set; }
        [DataMember]
        public virtual string ClassIDValue { get; set; }
        [DataMember]
        public virtual EntityRef ProcedureTypeRef { get; set; }
        [DataMember]
        public virtual string RuleCode { get; set; }
        [DataMember]
        public virtual string RuleName { get; set; }
        [DataMember]
        public virtual DisCountInsuranceAmountType AmountType { get; set; }
        [DataMember]
        public virtual decimal Amount { get; set; }
        [DataMember]
        public virtual DateTime? StartDate { get; set; }
        [DataMember]
        public virtual DateTime? ExpireDate { get; set; }
        [DataMember]
        public virtual bool Deactivated { get; set; }
        [DataMember]
        public virtual string CreatedUser { get; set; }
        [DataMember]
        public virtual DateTime? CreatedDate { get; set; }
        [DataMember]
        public virtual DateTime? LastUpdated { get; set; }
        [DataMember]
        public virtual EntityRef DiscountDetailRef { get; set; }

        public DiscountRuleDetail(EntityRef objectRef,string classIDCode, string classIDValue, EntityRef procedureTypeID_, string ruleCode, string ruleName,
            DisCountInsuranceAmountType amounttype, decimal amount, DateTime? startDate, DateTime? expireDate, bool deactivated, 
            string createdUser, DateTime? createdDate, DateTime? lastUpdated)
            : base()
        {
            DiscountDetailRef = objectRef;
            ClassIDCode = classIDCode;
            ProcedureTypeRef = procedureTypeID_;
            RuleCode = ruleCode;
            RuleName = ruleName;
            AmountType = amounttype;
            Amount = amount;
            StartDate = startDate;
            ExpireDate = expireDate;
            Deactivated = deactivated;
            CreatedUser = createdUser;
            CreatedDate = createdDate;
            LastUpdated = lastUpdated;            
        }
        public DiscountRuleDetail()            
        {
        }
    }
}
