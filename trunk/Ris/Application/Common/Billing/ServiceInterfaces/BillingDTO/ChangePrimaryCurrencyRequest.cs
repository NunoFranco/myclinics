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
    public class ChangePrimaryCurrencyRequest : DataContractBase
    {
        public ChangePrimaryCurrencyRequest(List<CurrencyDetail> changeItems)
        {
            ChangeItems = changeItems;

        }
        public ChangePrimaryCurrencyRequest(List<CurrencyDetail> changeItems, CurrencyDetail oldCurrency)
        {
            ChangeItems = changeItems;
            OldPrimaryCurrency = oldCurrency;
        }
        public ChangePrimaryCurrencyRequest(List<CurrencyDetail> changeItems, CurrencyDetail oldCurrency,
            CurrencyDetail newPrimaryCurrency,
            CurrencyDetail oldExrateCurrency,
            CurrencyDetail newPrimaryExRateCurrency)
        {
            ChangeItems = changeItems;
            OldPrimaryCurrency = oldCurrency;
            OldPrimaryExRateCurrency = oldExrateCurrency;
            NewPrimaryCurrency = newPrimaryCurrency;
            NewPrimaryExRateCurrency = newPrimaryExRateCurrency;
        }
        [DataMember]
        public List<CurrencyDetail> ChangeItems;


        [DataMember]
        public CurrencyDetail OldPrimaryCurrency;

        [DataMember]
        public CurrencyDetail NewPrimaryCurrency;

        [DataMember]
        public CurrencyDetail OldPrimaryExRateCurrency;

        [DataMember]
        public CurrencyDetail NewPrimaryExRateCurrency;
    }
}
