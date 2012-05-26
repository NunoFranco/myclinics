using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class LoadCurrencyEditResponse : DataContractBase
    {
        public LoadCurrencyEditResponse(CurrencyDetail detail)
        {
            this.CurrencyDetail = detail;
        }
        [DataMember]
        public EntityRef EntityRef;

        [DataMember]
        public CurrencyDetail CurrencyDetail;
    }
}
