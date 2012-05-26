using System.IO;
using System.Text;
using System.Collections.Generic;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Healthcare;
using System.Xml;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Ris.Application .Common.Billing ;
using System;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
namespace ClearCanvas.Ris.Application.Services.Billing
{
    public class InsuranceAssembler
    {

        public InsuranceRuleSummary CreateSummary(InsuranceRule objectSummary)
        {
            return new InsuranceRuleSummary(objectSummary.GetRef(), objectSummary.RuleCode, objectSummary.RuleName,
                objectSummary.AmountType, objectSummary.Amount,
                objectSummary.StartDate, objectSummary.ExpireDate, objectSummary.Deactivated);
        }
        public InsuranceRuleDetail CreateDetail(InsuranceRule objectSummary)
        {

            return new InsuranceRuleDetail(objectSummary.GetRef(), objectSummary.ClassID.Code, objectSummary.ClassID.Value, objectSummary.ProcedureType.GetRef(),
                objectSummary.RuleCode,
                objectSummary.RuleName,
                objectSummary.AmountType,
                objectSummary.Amount, null, null, objectSummary.Deactivated,
                null, null, null);
        }

        public void UpdateInsuranceClass(InsuranceRule objectClass, InsuranceRuleDetail objectdetail, IPersistenceContext context)
        {
            //Application.Common.EnumValueInfo Insurance = new ClearCanvas.Ris.Application.Common.EnumValueInfo();
            //foreach (var item in EnumUtils.GetEnumValueList<InsuranceTypeEnum>(context))
            //{
            //    if (item.Code == objectdetail.ClassIDCode && item.Value == objectdetail.ClassIDValue)
            //    {
            //        Insurance = item;
            //    }
            //}
            InsuranceTypeEnum Insurance = EnumUtils.GetEnumValue<InsuranceTypeEnum>(new EnumValueInfo(objectdetail.ClassIDCode, objectdetail.ClassIDValue, ""), context);
            objectClass.ClassID = Insurance;
            objectClass.RuleCode = objectdetail.RuleCode;
            objectClass.RuleName = objectdetail.RuleName;
            objectClass.Deactivated = objectdetail.Deactivated;
            objectClass.Amount = objectdetail.Amount;
            objectClass.AmountType = objectdetail.AmountType;
            objectClass.StartDate = objectdetail.StartDate;
            objectClass.ExpireDate = objectdetail.ExpireDate;
            objectClass.CreatedUser = objectdetail.CreatedUser;
            objectClass.CreatedDate = objectdetail.CreatedDate;
            objectClass.LastUpdated = objectdetail.LastUpdated;
            objectClass.Deactivated = objectdetail.Deactivated;
            objectClass.ProcedureType = context.Load<ProcedureType>(objectdetail.ProcedureTypeRef);
        }
    }
}
