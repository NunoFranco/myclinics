using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class DeleteObjectSummaryRequest: DataContractBase
    {
        public DeleteObjectSummaryRequest(EntityRef objectSummaryRef)
		{
            this.ObjectSummaryRef = objectSummaryRef;
		}

		[DataMember]
        public EntityRef ObjectSummaryRef;
    }
}
