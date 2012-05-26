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
    [DataContract]
   public  class GetDiscountPriceResponse
   {
        public GetDiscountPriceResponse(ProcedureTypeSummary proceduretype)
        {
            this.ProcedureType = proceduretype;
        }
        [DataMember]
        public ProcedureTypeSummary ProcedureType;

        
    }
}
