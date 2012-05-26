using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Ris.Application .Common.Billing.ServiecInterfaces.BillingDTO ;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using Iesi.Collections.Generic;
namespace ClearCanvas.Ris.Application.Services.Billing
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IOrderInvoicesService))]
    public class OrderInvoicesService : ApplicationServiceBase, IOrderInvoicesService
    {
        [ReadOperation]
        public ListOrderInvoicesResponse ListAllOrderInvoice(ListOrderInvoicesRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            OrderInvoicesSearchCriteria where = new OrderInvoicesSearchCriteria();
            //where.InvoiceNumber.SortAsc(0);
            //if (!string.IsNullOrEmpty(request))
            //    where.ClassCode.StartsWith(request.ClassCode);
            //if (!string.IsNullOrEmpty(request.ClassName))
            //    where.ClassName.Like(string.Format("%{0}%", request.ClassName));
            //if (!request.IncludeDeactivated)
            //    where.Deactivated.EqualTo(false);
            if (!string.IsNullOrEmpty(request.InvoiceNumber))
                where.InvoiceNumber.EqualTo(request.InvoiceNumber);
            if (request.fromdate != null && request.todate != null)
            {
                where.CreatedDate.Between(((DateTime)request.fromdate).Date,((DateTime)request.todate).AddDays(1).Date);
            }
            if (request.OrderRef != null)
            {
                Order order = PersistenceContext.Load<Order>(request.OrderRef);
                where.InvoiceOrder.EqualTo(order);
            }
            IOrderInvoicesBroker broker = PersistenceContext.GetBroker<IOrderInvoicesBroker>();
            IList<OrderInvoices> items = broker.Find(where, request.Page);

            OrderInvoicesAssembler assembler = new OrderInvoicesAssembler();
            return new ListOrderInvoicesResponse(
                CollectionUtils.Map<OrderInvoices, OrderInvoicesDetail>(items,
                    delegate(OrderInvoices item)
                    {
                        return assembler.CreateDetail(item);
                    })
                );
        }


        public void DeleteObjectSummary(DeleteObjectSummaryRequest request)
        {
        }

        [ReadOperation]
        public LoadOrderInvoicesEditResponse LoadOrderInvoicesForedit(LoadOrderInvoicesEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.OrderInvoicesRef, "request.orderInvoiceref");

            OrderInvoices item = PersistenceContext.Load<OrderInvoices>(request.OrderInvoicesRef);

            OrderInvoicesAssembler assembler = new OrderInvoicesAssembler();
            return new LoadOrderInvoicesEditResponse(assembler.CreateDetail(item));
        }

        [UpdateOperation]
        public UpdateOrderInvoicesResponse UpdateOrderInvoices(UpdateOrderInvoicesRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.ObjectDetail, "request.ObjectDetail");


            //validate data valid

            OrderInvoices item = PersistenceContext.Load<OrderInvoices>(request.ObjectDetail.OrderInvoiceRef);

            OrderInvoicesAssembler assembler = new OrderInvoicesAssembler();
            assembler.UpdateOrderInvoices(item, request.ObjectDetail, PersistenceContext);

            PersistenceContext.SynchState();

            return new UpdateOrderInvoicesResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        public AddOrderInvoicesResponse AddOrderInvoices(AddOrderInvoicesRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.ObjectDetail, "request.ObjectDetail");

            //validate data valid

            OrderInvoices item = new OrderInvoices();

            OrderInvoicesAssembler assembler = new OrderInvoicesAssembler();
            assembler.UpdateOrderInvoices(item, request.ObjectDetail, PersistenceContext);
            ListOrderInvoicesResponse checkresponse = ListAllOrderInvoice(new ListOrderInvoicesRequest(item.InvoiceNumber, null));
            if (checkresponse.OrderInvoicesDetail.Count > 0)
            {
                return null;
            }

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();

            return new AddOrderInvoicesResponse(assembler.CreateSummary(item));
        }
        [UpdateOperation]
        public UpdateProcedureAdjestmentPriceResponse UpdateProcedureAdjestmentPrice(UpdateProcedureAdjestmentPriceRequest request)
        {
            Procedure pro = new Procedure();
            pro = PersistenceContext.Load<Procedure>(request.ProcedureRef);
            pro.CollectedAmount = request.CollectAmount;
            pro.WaitingInsuranceAmount = request.PendingInsruanceAmount;
            if (request.PendingInsruanceAmount == 0)
            {
                pro.PendingProcedureStatus = ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.NOWAITING.ToString();
            }
            if (request.PendingInsruanceAmount > 0
                && pro.Order.BillingStatus != ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED.ToString())
            {
                //pro.IsPendingInsurance = true;
                pro.PendingProcedureStatus = ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM.ToString();
            }
            PersistenceContext.Lock(pro, DirtyState.Dirty);
            PersistenceContext.SynchState();
            return new UpdateProcedureAdjestmentPriceResponse();
        }
        [UpdateOperation]
        public ConfirmInsuranceResponse ConfirmInsurance(ConfirmInsuranceRequest request)
        {
            Procedure pro = new Procedure();
            pro = PersistenceContext.Load<Procedure>(request.ProcedureRef);
            pro.IsPendingInsurance = request.IsPendingInsurance;

            ClearCanvas.Enterprise.Common.OrderBillingStatusEnum status = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.PENDING;
            bool isAllConfirmOrRejected = true;
            bool isCollectedinsurance = true;
            foreach (var item in pro.Order.Procedures)
            {
                if (!item.Equals(pro) && item.PendingProcedureStatus == ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM.ToString())
                {
                    isAllConfirmOrRejected = false;
                    break;
                }
            }
            foreach (var invoice in pro.Order.Invoices)
            {
                if (invoice.TotalInsurance > 0
                    && !invoice.IsCollectedInsurance
                    )
                {
                    isCollectedinsurance = false;
                }
            }
            if (isAllConfirmOrRejected && isCollectedinsurance)
            {
                status = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED;
            }
            //if ()
            pro.Order.BillingStatus = status.ToString();
            pro.PendingProcedureStatus = ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.CONFIRMED.ToString();
            foreach (var item in pro.Order.Invoices)//if update status back to history
            {
                item.ListProcedures = request.ListHistoryProcedures;
            }
            PersistenceContext.Lock(pro, DirtyState.Dirty);
            PersistenceContext.SynchState();
            return new ConfirmInsuranceResponse();
        }

        [UpdateOperation]
        public RejectInsuranceResponse RejectInsurance(RejectInsuranceRequest request)
        {
            Procedure pro = new Procedure();
            pro = PersistenceContext.Load<Procedure>(request.ProcedureRef);
            pro.PendingProcedureStatus = request.Status;
            pro.IsPendingInsurance = false;
            ClearCanvas.Enterprise.Common.OrderBillingStatusEnum status = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.PENDING;
            bool isAllConfirmOrReject = true;
            bool isCollectedinsurance = true;
            foreach (var item in pro.Order.Procedures)
            {
                if (!item.Equals(pro) && item.PendingProcedureStatus == ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.WAITINGFORCONFIRM.ToString())
                {
                    isAllConfirmOrReject = false;
                    break;
                }
            }
            foreach (var invoice in pro.Order.Invoices)
            {
                if (invoice.TotalInsurance > 0
                    && !invoice.IsCollectedInsurance
                    )
                {
                    isCollectedinsurance = false;
                }
            }
            if (isAllConfirmOrReject && isCollectedinsurance)
            {
                status = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED;
            }
            //if ()
            pro.Order.BillingStatus = status.ToString();
            pro.PendingProcedureStatus = ClearCanvas.Enterprise.Common.WaitingInsuranceStatus.REJECTED.ToString();
            foreach (var item in pro.Order.Invoices)//if update status back to history
            {
                item.ListProcedures = request.ListHistoryProcedures;
            }

            PersistenceContext.Lock(pro, DirtyState.Dirty);
            PersistenceContext.SynchState();
            return new RejectInsuranceResponse();
        }
    }
}
