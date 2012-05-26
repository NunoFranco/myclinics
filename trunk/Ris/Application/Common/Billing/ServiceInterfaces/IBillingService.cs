using System;
using System.ServiceModel;
using System.Collections.Generic;
using ClearCanvas.Enterprise.Common;

using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO ;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;

using ClearCanvas.Healthcare;

namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces
{
    [RisApplicationService]
    [ServiceContract]
    public interface IBillingService
    {
        [OperationContract]
        string helloworld();
        [OperationContract]
        List<ProcedureTypeSummary> ListProcedureType(EntityRef FacilityRef);
        //[OperationContract]
        //List<int> CountProcedureType(DateTime startTime, DateTime endTime);
        //[OperationContract]
        //LoadOrderResponse LoadOrder(LoadOrderRequest request);
        //[OperationContract]
        //IList<Procedure> GetProcedure(Order order);
        
   }
}
