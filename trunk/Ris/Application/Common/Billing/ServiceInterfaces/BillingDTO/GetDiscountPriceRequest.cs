using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    public class GetDiscountPriceRequest : ListRequestBase
    {
        public GetDiscountPriceRequest (EntityRef discountref, string discounttypecode)
		{
            DiscountType = discounttypecode;
            DiscountRef = discountref;
		}
        public GetDiscountPriceRequest()
        { 
        }

        [DataMember]
        public EntityRef DiscountRef;
        [DataMember]
        public string DiscountType;

        
    }
}
