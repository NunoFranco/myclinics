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
    public interface IInsuranceRuleService
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
        string GetProcedureTypeRefCode(EntityRef ProcedureTypeRef);

        [OperationContract]
        ListInsuranceRuleDetailResponse LoadInsuranceDetail(ListInsuranceRuleDetailRequest request);

        [OperationContract]
        DeleteInsuranceSummaryResponse DeleteObjectDetail(DeleteInsuranceSummaryRequest request);

        [OperationContract]
        LoadInsuranceSummaryEditResponse LoadObjectSummaryForedit(LoadObjectSummaryEditRequest request);
        [OperationContract]
        LoadInsuranceResponse LoadInsuranceBinding(LoadInsuranceRequest request);

        [OperationContract]
        UpdateObjectSummaryResponse UpdateObjectSummary(UpdateObjectSummaryRequest request);

        [OperationContract]
        AddInsuranceSummaryResponse AddObjectSummary(AddInsuranceSummaryRequest request);

    }
}
