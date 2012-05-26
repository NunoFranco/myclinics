using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class RejectInsuranceRequest : DataContractBase
    {
        public RejectInsuranceRequest(EntityRef procedureRef,string status,string listHistoryProcedure)
        {
            ProcedureRef = procedureRef;
            Status = status;
            ListHistoryProcedures = listHistoryProcedure;
        }

        [DataMember]
        public EntityRef ProcedureRef;

        [DataMember]
        public EntityRef OrderRef;

        [DataMember]
        public string  Status;

        [DataMember]
        public string ListHistoryProcedures;
    }
}
