using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;

namespace ClearCanvas.Healthcare
{
    public class DiscountInsuranceClass : ClearCanvas.Enterprise.Core.Entity
    {

        //public override object OID { get { return Id; } }

        [PersistentProperty]
        public Guid Id { get; set; }

        [PersistentProperty]
        public virtual string ClassCode { get; set; }
        [PersistentProperty]
        public virtual string ClassName { get; set; }
        [PersistentProperty]
        public virtual string ClassType { get; set; }
        [PersistentProperty]
        public virtual string AmountType { get; set; }
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
        public virtual DateTime? CreatedTime { get; set; }

        public DiscountInsuranceClass(string code, string name, string classtype, string amounttype, decimal amount)
            : base()
        {
            ClassCode = code;
            ClassName = name;
            ClassType = classtype;
            AmountType = amounttype;
            Amount = amount;
            StartDate = null;
            ExpireDate = null;
            Deactivated = false;
            CreatedUser = "";
            CreatedTime = null;
        }
        public DiscountInsuranceClass()
            : base()
        {
        }
    }
}
