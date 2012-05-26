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
    public class ListCurrencyResponse
    {
        public ListCurrencyResponse()
        {
         
        }
        public ListCurrencyResponse(List<CurrencySummary> listCurrency)
        {
            this.Currency = listCurrency;
        }

        public ListCurrencyResponse(List<CurrencyDetail> listCurrency)
        {
            this.Details = listCurrency;
        }
        [DataMember]
        public List<CurrencySummary> Currency;

        [DataMember]
        public List<CurrencyDetail> Details;
    }
}
