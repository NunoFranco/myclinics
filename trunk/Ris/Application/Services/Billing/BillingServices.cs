using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Common;
using ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO ;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Healthcare;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;

namespace ClearCanvas.Ris.Application.Services.Billing
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IBillingService))]
    public class BillingServices : ApplicationServiceBase, IBillingService
    {
        public string helloworld() 
        {
            return "hello world ";
        }
        [ReadOperation]
        public List<ProcedureTypeSummary> ListProcedureType(Enterprise.Common.EntityRef FacilityRef)
        {
            List<ProcedureTypeSummary> ListData = new List<ProcedureTypeSummary>();
            Platform.GetService<IProcedureTypeAdminService>(delegate(IProcedureTypeAdminService service)
            {
                ListData = service.ListProcedureTypes(new ListProcedureTypesRequest(FacilityRef )).ProcedureTypes;
            });            

            return ListData;
        }
        

        //[ReadOperation]
        //public LoadOrderResponse LoadOrder(LoadOrderRequest request)
        //{
        //    var criteria = new OrderSearchCriteria();
        //    //criteria.Patient.EqualTo(profile.Patient);
        //    if (request.StartTimeEnteredOrder != null && request.EndTimeEnteredOrder != null)
        //    {
        //        criteria.EnteredTime.Between(request.StartTimeEnteredOrder, request.EndTimeEnteredOrder);
        //    }
        //    if (!string.IsNullOrEmpty(request.OrderNumber))
        //    {
        //        criteria.OrderNumber.EqualTo(request.OrderNumber);
        //    }
        //    criteria.Status.In(new[] { OrderStatus.SC, OrderStatus.IP });

        //    IList<Order> results = this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria);
        //    IList<EntityRef> ResponseResult = new List<EntityRef>();
        //    OrderAssembler assember = new OrderAssembler();
        //    IList<OrderDetail> details = new List<OrderDetail>();
        //    foreach (Order item in results)
        //    {
        //        EntityRef EREF = results[0].GetRef();
        //        ResponseResult.Add(EREF);
        //        details.Add(assember.CreateOrderDetail(item, this.PersistenceContext));
        //    }
            
        //    return new LoadOrderResponse(ResponseResult, details);
        //}        



    }
}
