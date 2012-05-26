using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Admin.PatientAdmin;

namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces
{
    [RisApplicationService]
    [ServiceContract]
    public interface ICurrencyService
    {
        [OperationContract]
        ListCurrencyResponse ListAllCurrency(ListCurrencyRequest request);

        [OperationContract]
        ListPrimaryCurrencyResponse GetPrimaryCurrency(ListPrimaryCurrencyRequest request);

        [OperationContract]
        ListCurrencyDetailResponse ListCurrencyDetail(ListCurrencyDetailRequest request);

                   [OperationContract]
        [FaultContract(typeof(ConcurrentModificationException))]
        [FaultContract(typeof(RequestValidationException))]
        DeleteCurrencyResponse DeleteCurrencyDetail(DeleteCurrencyRequest request);

        [OperationContract]
        LoadCurrencyEditResponse LoadCurrencyForedit(LoadCurrencyEditRequest request);
       
        [OperationContract]
        [FaultContract(typeof(ConcurrentModificationException))]
        [FaultContract(typeof(RequestValidationException))]
        UpdateCurrencyResponse UpdateCurrency(UpdateCurrencyRequest request);

        [OperationContract]
        [FaultContract(typeof(RequestValidationException))]
        AddCurrencyResponse AddCurrency(AddCurrencyRequest request);

        [OperationContract]
        ChangePrimaryCurrencyResponse ChangePrimaryAndExRateCurrency(ChangePrimaryCurrencyRequest request);
    }
}
