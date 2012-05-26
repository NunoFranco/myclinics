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
    public interface IDiscountRuleService
    {
        [OperationContract]
        string Helloworld();

        [OperationContract]
        ListInsuranceRuleResponse ListAllInsurance(ListInsuranceRuleRequest request);

        [OperationContract]
        ListInsuranceRuleDetailResponse ListInsuranceDetail(ListInsuranceRuleDetailRequest request);

        [OperationContract]
        LoadPatientProfileEditorFormDataResponse LoadPatientProfileEditorFormData(LoadPatientProfileEditorFormDataRequest request);

        [OperationContract]
        ListDiscountRuleResponse ListAllDiscount(ListDiscountRuleRequest request);
        [OperationContract]
        string GetProcedureTypeRefCode(EntityRef ProcedureTypeRef);

        [OperationContract]
        ListDiscountRuleDetailResponse LoadDiscountDetail(ListDiscountRuleDetailRequest request);

        [OperationContract]
        DeleteObjectSummaryResponse DeleteObjectDetail(DeleteObjectSummaryRequest request);

        [OperationContract]
        LoadObjectSummaryEditResponse LoadObjectSummaryForedit(LoadObjectSummaryEditRequest request);
        [OperationContract]
        LoadDiscountResponse LoadDiscountBinding(LoadDiscountRequest request);
        [OperationContract]
        UpdateObjectSummaryResponse UpdateObjectSummary(UpdateObjectSummaryRequest request);

        [OperationContract]
        AddDiscountSummaryResponse AddObjectSummary(AddDiscountSummaryRequest request);

    }
}
