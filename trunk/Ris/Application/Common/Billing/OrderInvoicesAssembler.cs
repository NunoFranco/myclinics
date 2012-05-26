using System.IO;
using System.Text;
using System.Collections.Generic;
using ClearCanvas.Common.Utilities;

using ClearCanvas.Healthcare;
using System.Xml;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Ris.Application.Common.Billing;

using System;
namespace ClearCanvas.Ris.Application.Common.Billing
{
    public class OrderInvoicesAssembler
    {
        public OrderInvoicesSummary CreateSummary(OrderInvoices objectClass)
        {
            return new OrderInvoicesSummary(objectClass.GetRef(),
                objectClass.InvoiceNumber,
                objectClass.IsCollectedInsurance);
        }
        public OrderInvoicesDetail CreateDetail(OrderInvoices objectClass)
        {

            return new OrderInvoicesDetail(objectClass.GetRef(),
                objectClass.InvoiceOrder.GetRef(),
                objectClass.InvoiceNumber,
                objectClass.TotalCollect,
                objectClass.TotalDiscount,
                objectClass.TotalInsurance,
                objectClass.TotalWaitingAmount,
                objectClass.TotalReceived,
                objectClass.TotalChanges,
                objectClass.ListProcedures,
                objectClass.Deactivated,
                objectClass.CreatedDate
                );
        }

        public void UpdateOrderInvoices(OrderInvoices objectClass, OrderInvoicesDetail objectdetail, IPersistenceContext context)
        {

            objectClass.Deactivated = objectdetail.Deactivated;
            objectClass.InvoiceNumber = objectdetail.InvoiceNumber;
            objectClass.InvoiceOrder = context.Load<Order>(objectdetail.OrderRef);
            objectClass.IsCollectedInsurance = objectdetail.IsFinished;
            objectClass.TotalCollect = objectdetail.TotalCollect;
            objectClass.TotalDiscount = objectdetail.TotalDiscount;
            objectClass.TotalInsurance = objectdetail.TotalInsurance;
            objectClass.TotalChanges = objectdetail.TotalChanges;
            objectClass.TotalReceived = objectdetail.TotalReceived;
            Enterprise.Common.OrderBillingStatusEnum status = Enterprise.Common.OrderBillingStatusEnum.FINISHED;
            if (objectdetail.TotalWaitingAmount > 0  || objectdetail.TotalInsurance > 0)
            {
                status = Enterprise.Common.OrderBillingStatusEnum.PENDING;
            }
            objectClass.CreatedDate = DateTime.Now;
            objectClass.InvoiceOrder.BillingStatus = status.ToString();
            objectClass.ListProcedures = objectdetail.ListProcedures;
        }
    }
}
