using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
	[DataContract]
    public class AddCurrencyResponse : DataContractBase
	{
		public AddCurrencyResponse(CurrencySummary summary)
		{
            this.Summary = summary;
		}

        public AddCurrencyResponse()
        {

        }
		[DataMember]
        public CurrencySummary Summary;        
	}
}

