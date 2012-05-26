using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class ConfirmInsuranceRequest : DataContractBase
    {
        //public ConfirmInsuranceRequest(EntityRef procedureRef, bool isPendingInsurance)
        //{
        //    ProcedureRef = procedureRef;
        //    IsPendingInsurance = isPendingInsurance;
        //}
        public ConfirmInsuranceRequest(EntityRef procedureRef, string status, string listHistoryProcedure)
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
        public string Status;

        [DataMember]
        public bool IsPendingInsurance;

        [DataMember]
        public string ListHistoryProcedures;

    }
}
