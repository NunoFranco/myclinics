using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Billing;

namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces
{
    [RisApplicationService]
    [ServiceContract]
    public interface IOrderInvoicesService
    {
        [OperationContract]
        ListOrderInvoicesResponse ListAllOrderInvoice(ListOrderInvoicesRequest request);
        
        [OperationContract]
        LoadOrderInvoicesEditResponse LoadOrderInvoicesForedit(LoadOrderInvoicesEditRequest request);

        [OperationContract]
        UpdateOrderInvoicesResponse UpdateOrderInvoices(UpdateOrderInvoicesRequest request);

        [OperationContract]
        AddOrderInvoicesResponse AddOrderInvoices(AddOrderInvoicesRequest request);

        [OperationContract]
        UpdateProcedureAdjestmentPriceResponse UpdateProcedureAdjestmentPrice(UpdateProcedureAdjestmentPriceRequest request);

        [OperationContract]
        ConfirmInsuranceResponse ConfirmInsurance(ConfirmInsuranceRequest request);

        [OperationContract]
        RejectInsuranceResponse RejectInsurance(RejectInsuranceRequest request);
    }
}
