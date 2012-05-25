using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core.Modelling;

namespace ClearCanvas.Healthcare
{
    public class InsuranceRule : ClearCanvas.Enterprise.Core.Entity
    {

        //public override object OID { get { return Id; } }


        [PersistentProperty]
        public virtual string InsuranceRuleID { get; set; }
        [PersistentProperty]
        public virtual InsuranceTypeEnum ClassID { get; set; }
        [PersistentProperty]
        public virtual ProcedureType ProcedureType { get; set; }
        [PersistentProperty]
        public virtual string RuleCode { get; set; }
        [PersistentProperty]
        public virtual string RuleName { get; set; }
        [PersistentProperty]
        public virtual DisCountInsuranceAmountType AmountType { get; set; }
        [PersistentProperty]
        public virtual decimal Amount { get; set; }
        [PersistentProperty]
        public virtual DateTime? StartDate { get; set; }
        [PersistentProperty]
        public virtual DateTime? ExpireDate { get; set; }
        [PersistentProperty]
        public virtual bool Deactivated { get; set; }
        [PersistentProperty]
        public virtual string CreatedUser { get; set; }
        [PersistentProperty]
        public virtual DateTime? CreatedDate { get; set; }
        [PersistentProperty]
        public virtual DateTime? LastUpdated { get; set; }


        public InsuranceRule(InsuranceTypeEnum classID, ProcedureType procedureTypeID_, string ruleCode, string ruleName,
            DisCountInsuranceAmountType amounttype, decimal amount, DateTime? startDate, DateTime? expireDate, bool deactivated,
            string createdUser, DateTime? createdDate, DateTime? lastUpdated)
            : base()
        {
            ClassID = classID;
            ProcedureType = procedureTypeID_;
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
        public InsuranceRule()
        {
        }
    }
}
