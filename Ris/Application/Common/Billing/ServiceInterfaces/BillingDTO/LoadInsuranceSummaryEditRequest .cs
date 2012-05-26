using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class LoadInsuranceSummaryEditRequest : DataContractBase
    {
        public LoadInsuranceSummaryEditRequest(EntityRef InsuranceSummaryRef)
		{
            this.InsuranceSummaryRef = InsuranceSummaryRef;
		}

		[DataMember]
        public EntityRef InsuranceSummaryRef;
    }
}
