using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;

namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces
{
    [DataContract] 
    public class ListDiscountRuleDetailRequest : DataContractBase
    {
               
        public ListDiscountRuleDetailRequest(EntityRef entityRef)
        {
            this.DiscountRuleRef = entityRef;
        }

        [DataMember]
        public EntityRef DiscountRuleRef;
        
    }
}
