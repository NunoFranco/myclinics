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

using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common.Admin.PatientAdmin;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
namespace ClearCanvas.Ris.Application.Services.Billing
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IDiscountRuleService))]
    public class DiscountRuleService : ApplicationServiceBase, IDiscountRuleService
    {
        [ReadOperation]
        public ListDiscountRuleResponse ListAllDiscount(ListDiscountRuleRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            DiscountRuleSearchCriteria where = new DiscountRuleSearchCriteria();
            where.RuleCode.SortAsc(0);

            if (request.ProcedureTypeRef != null)
            {
                where.ProcedureType.EqualTo(PersistenceContext.Load<ProcedureType>(request.ProcedureTypeRef));
            }
            if (!string.IsNullOrEmpty(request.DiscountCode))
            {
                EnumValueInfo discount = new EnumValueInfo(request.DiscountCode, request.DiscountValue, request.DiscountDescription);
                where.Discount.EqualTo(EnumUtils.GetEnumValue<DiscountTypeEnum>(discount, this.PersistenceContext));
                //where.Discount.EqualTo(request.DiscountCode);
            }

            IDiscountRuleBroker broker = PersistenceContext.GetBroker<IDiscountRuleBroker>();
            IList<DiscountRule> items = broker.Find(where, request.Page);

            DiscountAssembler assembler = new DiscountAssembler();
            ListDiscountRuleResponse response = new ListDiscountRuleResponse(
                CollectionUtils.Map<DiscountRule, DiscountRuleSummary>(items,
                    delegate(DiscountRule item)
                    {
                        return assembler.CreateSummary(item);
                    })
                );
            //response.DiscountChoices = EnumUtils.GetEnumValueList<DiscountTypeEnum>(PersistenceContext);

            return response;
        }

        [ReadOperation]
        public string GetProcedureTypeRefCode(EntityRef ProcedureTypeRef)
        {
            return PersistenceContext.Load<ProcedureType>(ProcedureTypeRef).Id;
        }
        [ReadOperation]
        public ListDiscountRuleDetailResponse LoadDiscountDetail(ListDiscountRuleDetailRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.DiscountRuleRef, "request.DiagnosticServiceRef");

            DiscountRule item = PersistenceContext.Load<DiscountRule>(request.DiscountRuleRef);

            DiscountAssembler assembler = new DiscountAssembler();
            return new ListDiscountRuleDetailResponse(assembler.CreateDetail(item));
        }


        [ReadOperation]
        public ListInsuranceRuleResponse ListAllInsurance(ListInsuranceRuleRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            InsuranceRuleSearchCriteria where = new InsuranceRuleSearchCriteria();
            //where.RuleCode.SortAsc(0);
            //if (!string.IsNullOrEmpty(request.Code))
            //    where.RuleCode.StartsWith(request.Code);
            //if (!string.IsNullOrEmpty(request.Name))
            //    where.RuleName.Like(string.Format("%{0}%", request.Name));
            if (!request.IncludeDeactivated)
                where.Deactivated.EqualTo(false);

            IInsuranceRuleBroker broker = PersistenceContext.GetBroker<IInsuranceRuleBroker>();
            IList<InsuranceRule> items = broker.Find(where, request.Page);

            InsuranceAssembler assembler = new InsuranceAssembler();
            return new ListInsuranceRuleResponse(
                CollectionUtils.Map<InsuranceRule, InsuranceRuleSummary>(items,
                    delegate(InsuranceRule item)
                    {
                        return assembler.CreateSummary(item);
                    })
                );
        }

        [ReadOperation]
        public ListInsuranceRuleDetailResponse ListInsuranceDetail(ListInsuranceRuleDetailRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.InsuranceRuleRef, "request.DiagnosticServiceRef");

            InsuranceRule item = PersistenceContext.Load<InsuranceRule>(request.InsuranceRuleRef);

            InsuranceAssembler assembler = new InsuranceAssembler();
            return new ListInsuranceRuleDetailResponse(assembler.CreateDetail(item));
        }
        [ReadOperation]
        public LoadPatientProfileEditorFormDataResponse LoadPatientProfileEditorFormData(LoadPatientProfileEditorFormDataRequest request)
        {
            LoadPatientProfileEditorFormDataResponse response = new LoadPatientProfileEditorFormDataResponse();
            response.DiscountChoices = EnumUtils.GetEnumValueList<DiscountTypeEnum>( PersistenceContext);
            return response;
        }



        public void DeleteObjectSummary(DeleteObjectSummaryRequest request)
        {

        }

        [UpdateOperation]
        public DeleteObjectSummaryResponse DeleteObjectDetail(DeleteObjectSummaryRequest request)
        {
            try
            {

                IDiscountRuleBroker broker = PersistenceContext.GetBroker<IDiscountRuleBroker>();
                DiscountRule item = broker.Load(request.ObjectSummaryRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteObjectSummaryResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format("ExceptionFailedToDelete", TerminologyTranslator.Translate(typeof(DiscountRule))));
            }
        }

        [ReadOperation]
        public LoadObjectSummaryEditResponse LoadObjectSummaryForedit(LoadObjectSummaryEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.ObjectSummaryRef, "request.ObjectSummaryRef");

            DiscountRule item = PersistenceContext.Load<DiscountRule>(request.ObjectSummaryRef);

            DiscountAssembler assembler = new DiscountAssembler();
            return new LoadObjectSummaryEditResponse(assembler.CreateDetail(item));
        }
        [ReadOperation]
        public LoadDiscountResponse ListDiscountRule(LoadDiscountRequest request)
        {
            //Platform.CheckForNullReference(request, "request");

            //DiscountSearchCriteria where = new DiscountSearchCriteria();
            //where.DiscountRuleID.SortAsc(0);
            //if (!string.IsNullOrEmpty(request.ProcedureTypeID_))
            //    where.ProcedureTypeID_.StartsWith(request.ProcedureTypeID_);
            //if (!string.IsNullOrEmpty(request.ClassID))
            //    where.ClassID.Like(string.Format("%{0}%", request.ClassID));
            ////if (!request.IncludeDeactivated)
            ////    where.Deactivated.EqualTo(false);

            //IDiscountRuleBroker broker = PersistenceContext.GetBroker<IDiscountRuleBroker>();
            //IList<DiscountRule> items = broker.Find(where, request.Page);

            //DiscountAssembler assembler = new DiscountAssembler();
            //return new LoadDiscountResponse(
            //    CollectionUtils.Map<DiscountRule, DiscountRuleSummary>(items,
            //        delegate(DiscountRule item)
            //        {
            //            return assembler.CreateSummary(item);
            //        })
            //    );
            DiscountRule item = PersistenceContext.Load<DiscountRule>(request.DiscountRuleRef);
            List<DiscountRuleDetail> list = new List<DiscountRuleDetail>();
            DiscountAssembler assembler = new DiscountAssembler();
            list.Add(assembler.CreateDetail(item));
            LoadDiscountResponse ResponseResult = new LoadDiscountResponse(list);


            return ResponseResult;
        }

        [ReadOperation]
        public LoadDiscountResponse LoadDiscountBinding(LoadDiscountRequest request)
        {
            //var criteria = new DiscountSearchCriteria();
            DiscountRuleSearchCriteria where = new DiscountRuleSearchCriteria();
            if (!string.IsNullOrEmpty(request.ClassID))
                where.ClassID.Like(string.Format("%{0}%", request.ClassID));
            //criteria.Patient.EqualTo(profile.Patient);
            //criteria.Status.In(new[] { DiscountStatus.SC, DiscountStatus.IP });
            IDiscountRuleBroker broker = PersistenceContext.GetBroker<IDiscountRuleBroker>();
            IList<DiscountRule> results = broker.Find(where);
            //IList<EntityRef> ResponseResult = new List<EntityRef>();
            DiscountAssembler dAblr = new DiscountAssembler();
            IList<DiscountRuleDetail> ResponseResult = new List<DiscountRuleDetail>();
            foreach (DiscountRule item in results)
            {
                ResponseResult.Add(dAblr.CreateDetail(item));
                //ResponseResult.Add();
            }
            return new LoadDiscountResponse(ResponseResult);
        }

        [UpdateOperation]
        public UpdateObjectSummaryResponse UpdateObjectSummary(UpdateObjectSummaryRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.ObjectDiscountRuleDetail, "request.ObjectDiscountRuleDetail");
            Platform.CheckMemberIsSet(request.ObjectDiscountRuleDetail.ProcedureTypeRef, "request.ObjectDiscountRuleDetail.ProcedureTypeRef");

            //validate data valid

            DiscountRule item = PersistenceContext.Load<DiscountRule>(request.ObjectDiscountRuleDetail.DiscountDetailRef);

            DiscountAssembler assembler = new DiscountAssembler();
            assembler.UpdateDiscountClass(item, request.ObjectDiscountRuleDetail, PersistenceContext);

            PersistenceContext.SynchState();

            return new UpdateObjectSummaryResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        public AddDiscountSummaryResponse AddObjectSummary(AddDiscountSummaryRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.DiscountRuleDetail, "request.ObjectDetail");

            //validate data valid
            //ListDiscountRuleRequest checkItemExist = new ListDiscountRuleRequest();
            //checkItemExist.ProcedureTypeRef = request.DiscountRuleDetail.ProcedureTypeRef;
            //ListDiscountRuleResponse checkingResponse = ListAllDiscount(checkItemExist);
            //if (checkingResponse._Discounts.Count > 0)
            //return new AddDiscountSummaryResponse();

            DiscountRule item = new DiscountRule();

            DiscountAssembler assembler = new DiscountAssembler();
            assembler.UpdateDiscountClass(item, request.DiscountRuleDetail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();


            return new AddDiscountSummaryResponse(assembler.CreateSummary(item));
        }

        public string Helloworld()
        {
            return "HelloWorld";
        }
    }
}
