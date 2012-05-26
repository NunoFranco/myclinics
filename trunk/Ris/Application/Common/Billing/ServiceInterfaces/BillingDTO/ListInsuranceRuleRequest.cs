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
    public class ListInsuranceRuleRequest : ListRequestBase
    {
       public ListInsuranceRuleRequest(EntityRef proceduretyperef, string code,string value,string description)
        {
            ProcedureTypeRef = proceduretyperef;
            InsuranceCode = code;
            InsuranceDescription = description;
            InsuranceValue = value;
               
        }
       public ListInsuranceRuleRequest(EntityRef proceduretyperef, EnumValueInfo InsuranceTypeEnum)
       {
           ProcedureTypeRef = proceduretyperef;
           InsuranceCode = InsuranceTypeEnum.Code;
           InsuranceDescription = InsuranceTypeEnum.Description;
           InsuranceValue = InsuranceTypeEnum.Value;

       }
        public ListInsuranceRuleRequest()
        { 
        }

        public ListInsuranceRuleRequest(SearchResultPage page, EntityRef FacilityRef)
			: base(page,  FacilityRef)
		{
		}
        [DataMember]
        public EntityRef ProcedureTypeRef;
        [DataMember]
      
        public string InsuranceValue;

        [DataMember]
        public string InsuranceCode;

        [DataMember]
        public string InsuranceDescription;

        [DataMember]
        public bool Deactivated;




    }
}
