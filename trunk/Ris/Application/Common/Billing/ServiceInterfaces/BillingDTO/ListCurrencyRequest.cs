using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    public class ListCurrencyRequest : ListRequestBase
    {
       
        public ListCurrencyRequest(string code,string name, EntityRef FacilityRef)
        {
            Code = code;
            Name= name;
            ClinicRef = FacilityRef; 
        }

        public ListCurrencyRequest(EntityRef entityref)
        {
            CurrencyRef = entityref;
            
        }
        public ListCurrencyRequest()
        { 
        }

        public ListCurrencyRequest(SearchResultPage page, EntityRef FacilityRef)
			: base(page, FacilityRef)
		{
            ClinicRef = FacilityRef;
		}
        [DataMember]
        public EntityRef CurrencyRef;

        [DataMember]
        public bool IsListDetail;

        [DataMember]
        public string Name;

        [DataMember]
        public string Code;

        [DataMember]
        public bool IsPrimaryCurrency;

        [DataMember]
        public bool IsPrimaryExRateCurrency; 

        [DataMember]
        public bool Deactivated;

        [DataMember]
        public string Listprocedures;

 [DataMember]
        public EntityRef ClinicRef;

        
    }
}
