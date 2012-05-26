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
    public class ListCurrencyDetailRequest : DataContractBase
    {
               
        public ListCurrencyDetailRequest(EntityRef entityRef)
        {
            this.CurrencyRef = entityRef;
        }

        [DataMember]
        public EntityRef CurrencyRef;
        
    }
}
