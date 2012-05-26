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
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
namespace ClearCanvas.Ris.Application.Services.Billing
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IInsuranceRuleService))]
    public class InsuranceRuleService : ApplicationServiceBase, IInsuranceRuleService
    {
        [ReadOperation]
        public ListInsuranceRuleResponse ListAllInsurance(ListInsuranceRuleRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            InsuranceRuleSearchCriteria where = new InsuranceRuleSearchCriteria();
            where.RuleCode.SortAsc(0);
            //if (!string.IsNullOrEmpty(request.InsuranceCode))
            //    where.RuleCode.StartsWith(request.InsuranceCode);
            //if (!string.IsNullOrEmpty(request.InsuranceValue))
            //    where.RuleName.Like(string.Format("%{0}%", request.InsuranceValue));
            //if (!request.Deactivated)
            //    where.Deactivated.EqualTo(false);
            if (request.ProcedureTypeRef != null)
            {
                where.ProcedureType.EqualTo(PersistenceContext.Load<ProcedureType>(request.ProcedureTypeRef));
            }
            if (!string.IsNullOrEmpty(request.InsuranceValue))
            {
                EnumValueInfo discount = new EnumValueInfo(request.InsuranceCode, request.InsuranceValue, request.InsuranceDescription);
                where.Insurance.EqualTo(EnumUtils.GetEnumValue<InsuranceTypeEnum>(discount, this.PersistenceContext));
            }

            IInsuranceRuleBroker broker = PersistenceContext.GetBroker<IInsuranceRuleBroker>();
            IList<InsuranceRule> items = broker.Find(where, request.Page);

            InsuranceAssembler assembler = new InsuranceAssembler();
            ListInsuranceRuleResponse response = new ListInsuranceRuleResponse(
                CollectionUtils.Map<InsuranceRule, InsuranceRuleSummary>(items,
                    delegate(InsuranceRule item)
                    {
                        return assembler.CreateSummary(item);
                    })
                );
            //response.InsuranceChoices = EnumUtils.GetEnumValueList<InsuranceTypeEnum>(PersistenceContext);

            return response;
        }
        [ReadOperation]
        public ListInsuranceRuleDetailResponse LoadInsuranceDetail(ListInsuranceRuleDetailRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.InsuranceRuleRef, "request.DiagnosticServiceRef");

            InsuranceRule item = PersistenceContext.Load<InsuranceRule>(request.InsuranceRuleRef);

            InsuranceAssembler assembler = new InsuranceAssembler();
            return new ListInsuranceRuleDetailResponse(assembler.CreateDetail(item));
        }


        //[ReadOperation]
        //public ListInsuranceRuleResponse ListAllInsurance(ListInsuranceRuleRequest request)
        //{
        //    Platform.CheckForNullReference(request, "request");

        //    InsuranceRuleSearchCriteria where = new InsuranceRuleSearchCriteria();
        //    where.RuleCode.SortAsc(0);
        //    if (!string.IsNullOrEmpty(request.Code))
        //        where.RuleCode.StartsWith(request.Code);
        //    if (!string.IsNullOrEmpty(request.Name))
        //        where.RuleName.Like(string.Format("%{0}%", request.Name));
        //    if (!request.IncludeDeactivated)
        //        where.Deactivated.EqualTo(false);

        //    IInsuranceRuleBroker broker = PersistenceContext.GetBroker<IInsuranceRuleBroker>();
        //    IList<InsuranceRule> items = broker.Find(where, request.Page);

        //    InsuranceAssembler assembler = new InsuranceAssembler();
        //    return new ListInsuranceRuleResponse(
        //        CollectionUtils.Map<InsuranceRule, InsuranceRuleSummary>(items,
        //            delegate(InsuranceRule item)
        //            {
        //                return assembler.CreateSummary(item);
        //            })
        //        );
        //}

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
            response.InsuranceChoices = EnumUtils.GetEnumValueList<InsuranceTypeEnum>( PersistenceContext);
            return response;
        }

        [ReadOperation]
        public string GetProcedureTypeRefCode(EntityRef ProcedureTypeRef)
        {
            return PersistenceContext.Load<ProcedureType>(ProcedureTypeRef).Id;
        }



        public void DeleteObjectSummary(DeleteObjectSummaryRequest request)
        {

        }

        [UpdateOperation]
        public DeleteInsuranceSummaryResponse DeleteObjectDetail(DeleteInsuranceSummaryRequest request)
        {
            try
            {

                IInsuranceRuleBroker broker = PersistenceContext.GetBroker<IInsuranceRuleBroker>();
                InsuranceRule item = broker.Load(request.ObjectSummaryRef, EntityLoadFlags.Proxy);
                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteInsuranceSummaryResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format("ExceptionFailedToDelete", TerminologyTranslator.Translate(typeof(InsuranceRule))));
            }
        }

        [ReadOperation]
        public LoadInsuranceSummaryEditResponse LoadObjectSummaryForedit(LoadObjectSummaryEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.ObjectSummaryRef, "request.ObjectSummaryRef");

            InsuranceRule item = PersistenceContext.Load<InsuranceRule>(request.ObjectSummaryRef);

            InsuranceAssembler assembler = new InsuranceAssembler();
            return new LoadInsuranceSummaryEditResponse(assembler.CreateDetail(item));
        }
        [ReadOperation]
        public LoadInsuranceResponse ListInsuranceRule(LoadInsuranceRequest request)
        {
            //Platform.CheckForNullReference(request, "request");

            //InsuranceRuleSearchCriteria where = new InsuranceRuleSearchCriteria();
            //where.InsuranceRuleID.SortAsc(0);
            //if (!string.IsNullOrEmpty(request.ProcedureTypeID_))
            //    where.ProcedureTypeID_.StartsWith(request.ProcedureTypeID_);
            //if (!string.IsNullOrEmpty(request.ClassID))
            //    where.ClassID.Like(string.Format("%{0}%", request.ClassID));
            ////if (!request.IncludeDeactivated)
            ////    where.Deactivated.EqualTo(false);

            //IInsuranceRuleBroker broker = PersistenceContext.GetBroker<IInsuranceRuleBroker>();
            //IList<InsuranceRule> items = broker.Find(where, request.Page);

            //InsuranceAssembler assembler = new InsuranceAssembler();
            //return new LoadInsuranceResponse(
            //    CollectionUtils.Map<InsuranceRule, InsuranceRuleSummary>(items,
            //        delegate(InsuranceRule item)
            //        {
            //            return assembler.CreateSummary(item);
            //        })
            //    );
            InsuranceRule item = PersistenceContext.Load<InsuranceRule>(request.InsuranceRuleRef);
            List<InsuranceRuleDetail> list = new List<InsuranceRuleDetail>();
            InsuranceAssembler assembler = new InsuranceAssembler();
            list.Add(assembler.CreateDetail(item));
            LoadInsuranceResponse ResponseResult = new LoadInsuranceResponse(list);


            return ResponseResult;
        }

        [ReadOperation]
        public LoadInsuranceResponse LoadInsuranceBinding(LoadInsuranceRequest request)
        {
            //var criteria = new InsuranceRuleSearchCriteria();
            InsuranceRuleSearchCriteria where = new InsuranceRuleSearchCriteria();
            if (!string.IsNullOrEmpty(request.ClassID))
                where.ClassID.Like(string.Format("%{0}%", request.ClassID));
            //criteria.Patient.EqualTo(profile.Patient);
            //criteria.Status.In(new[] { InsuranceStatus.SC, InsuranceStatus.IP });
            IInsuranceRuleBroker broker = PersistenceContext.GetBroker<IInsuranceRuleBroker>();
            IList<InsuranceRule> results = broker.Find(where);
            //IList<EntityRef> ResponseResult = new List<EntityRef>();
            InsuranceAssembler dAblr = new InsuranceAssembler();
            IList<InsuranceRuleDetail> ResponseResult = new List<InsuranceRuleDetail>();
            foreach (InsuranceRule item in results)
            {
                ResponseResult.Add(dAblr.CreateDetail(item));
                //ResponseResult.Add();
            }
            return new LoadInsuranceResponse(ResponseResult);
        }

        [UpdateOperation]
        public UpdateObjectSummaryResponse UpdateObjectSummary(UpdateObjectSummaryRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.ObjectInsuranceRuleDetail, "request.ObjectInsuranceRuleDetail");
            Platform.CheckMemberIsSet(request.ObjectInsuranceRuleDetail.ProcedureTypeRef, "request.ObjectInsuranceRuleDetail.ProcedureTypeRef");

            //validate data valid

            InsuranceRule item = PersistenceContext.Load<InsuranceRule>(request.ObjectInsuranceRuleDetail.InsuranceDetailRef);

            InsuranceAssembler assembler = new InsuranceAssembler();
            assembler.UpdateInsuranceClass(item, request.ObjectInsuranceRuleDetail, PersistenceContext);

            PersistenceContext.SynchState();

            return new UpdateObjectSummaryResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        public AddInsuranceSummaryResponse AddObjectSummary(AddInsuranceSummaryRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.InsuranceRuleDetail, "request.ObjectDetail");

            //validate data valid

            InsuranceRule item = new InsuranceRule();

            InsuranceAssembler assembler = new InsuranceAssembler();
            assembler.UpdateInsuranceClass(item, request.InsuranceRuleDetail, PersistenceContext);

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();


            return new AddInsuranceSummaryResponse(assembler.CreateSummary(item));
        }



        public string Helloworld()
        {
            return "HelloWorld";
        }
    }
}
