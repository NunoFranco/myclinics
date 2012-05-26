using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class UpdateProcedureAdjestmentPriceRequest : DataContractBase
    {
        public UpdateProcedureAdjestmentPriceRequest(EntityRef procedureRef,decimal collectamount, decimal waitinginsuranceamount)
        {
            ProcedureRef = procedureRef;
            CollectAmount = collectamount;
            PendingInsruanceAmount = waitinginsuranceamount;
            //UpdatedListProceudres = updatedprocedures;
        }

        [DataMember]
        public EntityRef ProcedureRef;

        [DataMember]
        public decimal PendingInsruanceAmount;

        [DataMember]
        public EntityRef OrderRef;

        [DataMember]
        public decimal CollectAmount;

        [DataMember]
        public string UpdatedListProceudres;

    }
}
