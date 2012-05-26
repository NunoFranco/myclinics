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
    public class ListDiscountRuleRequest : ListRequestBase
    {
       
        public ListDiscountRuleRequest(EntityRef proceduretyperef, string code,string value,string description)
        {
            ProcedureTypeRef = proceduretyperef;
            DiscountCode = code;
            DiscountDescription = description;
            DiscountValue = value;
               
        }

        public ListDiscountRuleRequest(EntityRef proceduretyperef, EnumValueInfo DiscountTypeEnum)
        {
            ProcedureTypeRef = proceduretyperef;
            DiscountCode = DiscountTypeEnum.Code;
            DiscountValue = DiscountTypeEnum.Value;
            DiscountDescription = DiscountTypeEnum.Description;
            
        }
        public ListDiscountRuleRequest()
        { 
        }

        public ListDiscountRuleRequest(SearchResultPage page, EntityRef FacilityRef)
			: base(page,  FacilityRef)
		{
		}
        [DataMember]
        public EntityRef ProcedureTypeRef;
        [DataMember]
      
        public string DiscountValue;

        [DataMember]
        public string DiscountCode;

        [DataMember]
        public string DiscountDescription;

        [DataMember]
        public bool Deactivated;

        
    }
}
