#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Admin.PatientAdmin;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin;
namespace ClearCanvas.Ris.Client.Billing
{
    /// <summary>
    /// Extension point for views onto <see cref="BillingInsuranceEditComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingInsuranceEditComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingInsuranceEditComponent class.
    /// </summary>
    [AssociateView(typeof(BillingInsuranceEditComponentViewExtensionPoint))]
    public class BillingInsuranceEditComponent : ApplicationComponent
    {
       /// <summary>
        /// Constructor.
        /// </summary>
        /// 

        public InsuranceRuleDetail insuranceRuleDetail;
        public ProcedureTypeDetail procedureTypeDetail;
        public List<EnumValueInfo> InsuranceTypeEnumList;
        private EntityRef _insuranceruleRef;    
         public FacilitySummary Clinic;
        public BillingInsuranceEditComponent(FacilitySummary f)
        {
            Clinic = f;
        }
        public BillingInsuranceEditComponent()
        {
        }
        public BillingInsuranceEditComponent(EntityRef objectref)
        {
            _insuranceruleRef = objectref;
        }
        public BillingInsuranceEditComponent(string objectref)
        {
            _insuranceruleRef = new EntityRef(objectref);
        }
        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            ListInsuranceRuleDetailResponse responseResult = null;
            Platform.GetService<IInsuranceRuleService>(
            delegate(IInsuranceRuleService service)
            {

                responseResult = service.LoadInsuranceDetail(new ListInsuranceRuleDetailRequest(_insuranceruleRef));

                //ObjectSummary = response.ObjectInsuranceRuleSummary;
            });
            insuranceRuleDetail = responseResult.InsuranceRuleService;
            procedureTypeDetail = Platform.GetService<IProcedureTypeAdminService>()
                        .LoadProcedureTypeForEdit(
                        new LoadProcedureTypeForEditRequest(responseResult.InsuranceRuleService.ProcedureTypeRef)).ProcedureType;

            base.Start();

        }

        /// <summary>
        /// Called by the host when the application component is being terminated.
        /// </summary>
        public override void Stop()
        {
            // TODO prepare the component to exit the live phase
            // This is a good place to do any clean up
            base.Stop();
        }

        public void Cancel()
        {
            this.ExitCode = ApplicationComponentExitCode.None;
            this.Host.Exit();
        }
        public void Update()
        {
            Platform.GetService<IInsuranceRuleService>(
            delegate(IInsuranceRuleService service)
            {
                if (AmountType == DisCountInsuranceAmountType.PERCENTAGE && insuranceRuleDetailAmount > 100)
                    insuranceRuleDetailAmount = 100;


                UpdateObjectSummaryResponse response = service.UpdateObjectSummary(new UpdateObjectSummaryRequest(insuranceRuleDetail));
                //ObjectSummary = response.ObjectInsuranceRuleSummary;

            });
            this.Cancel();
        }

        public void Delete()
        {
            Platform.GetService<IInsuranceRuleService>(
            delegate(IInsuranceRuleService service)
            {

                DeleteInsuranceSummaryResponse response = service.DeleteObjectDetail(new DeleteInsuranceSummaryRequest(insuranceRuleDetail.InsuranceDetailRef));
                //ObjectSummary = response.ObjectInsuranceRuleSummary;

            });
            this.Host.Exit();
        }

        public int indexInsuranceType()
        {
            int result = -1;
            for(int index = 0;index< InsuranceTypeEnumList.Count;index++)
                if (InsuranceTypeEnumList[index].Code == insuranceRuleDetail.AmountType.ToString())
                {
                    result = index;
                    break;
                }
            return result;
        }

        public List<string> InsuranceTypeEnumValueList
        {
            get
            {
                List<string> valueList = new List<string>();
                Platform.GetService<IInsuranceRuleService>(delegate(IInsuranceRuleService service)
                {
                    LoadPatientProfileEditorFormDataRequest request = new LoadPatientProfileEditorFormDataRequest(Clinic);

                    var formData = service.LoadPatientProfileEditorFormData(request);
                    InsuranceTypeEnumList = new List<EnumValueInfo>();
                    foreach (EnumValueInfo value in formData.InsuranceChoices)
                    {
                        valueList.Add(value.Value);
                        InsuranceTypeEnumList.Add(value);
                    }
                });
                return valueList;
            }

        }

        //public InsuranceRuleDetail bindingData()
        //{
        //        ListInsuranceRuleDetailResponse responseResult = null; 
        //    Platform.GetService<IInsuranceRuleService>(
        //    delegate(IInsuranceRuleService service)
        //    {

        //        responseResult = service.LoadInsuranceDetail(new ListInsuranceRuleDetailRequest(insuranceRuleDetail.InsuranceDetailRef));

        //        //ObjectSummary = response.ObjectInsuranceRuleSummary;
        //    });
        //    procedureTypeDetail = Platform.GetService<IProcedureTypeAdminService>()
        //                .LoadProcedureTypeForEdit(
        //                new LoadProcedureTypeForEditRequest(insuranceRuleDetail.ProcedureTypeRef)).ProcedureType;

        //    return responseResult.InsuranceRuleService;
        //}

        public void BindData(string insuranceRef)
        {
            insuranceRuleDetail = new InsuranceRuleDetail();
            insuranceRuleDetail.InsuranceDetailRef = new EntityRef(insuranceRef);
            procedureTypeDetail = new ProcedureTypeDetail();

        }


        public string procedureTypeDetailId
        {
            get { return procedureTypeDetail.Id; }
            set
            {
                procedureTypeDetail.Id = value;
            }
        }

        public string procedureTypeDetailName
        {
            get { return procedureTypeDetail.Name; }
            set
            {
                procedureTypeDetail.Name = value;
            }
        }

        public string insuranceRuleDetailClassIDValue
        {
            get { return insuranceRuleDetail.ClassIDCode; }
            set
            {
                insuranceRuleDetail.ClassIDValue = value;
            }
        }

        private string InsuranceAmountTypeEnumText(string Code)
        {
            string Text = "";
            if (Code == DisCountInsuranceAmountType.PERCENTAGE.ToString())
                Text = SR.PERCENTAGE;
            if (Code == DisCountInsuranceAmountType.REDUCEAMOUNT.ToString())
                Text = SR.REDUCEAMOUNT;
            if (Code == DisCountInsuranceAmountType.FIXEDPRICE.ToString())
                Text = SR.FIXEDPRICE;
            return Text;
        }

        public string insuranceRuleDetailClassIDCode
        {
            get { return insuranceRuleDetail.ClassIDCode; }
            set
            {
                insuranceRuleDetail.ClassIDCode = value;
            }
        }

        public decimal insuranceRuleDetailAmount
        {
            get { return insuranceRuleDetail.Amount; }
            set
            {
                insuranceRuleDetail.Amount = value;
            }
        }
        public DisCountInsuranceAmountType AmountType
        {
            get { return insuranceRuleDetail.AmountType; }
            set
            {
                insuranceRuleDetail.AmountType = value;
            }
        }



        public string DisCountInsuranceAmountTypeValue//(DisCountInsuranceAmountType amountType)
        {
            get
            {
                
                string type = SR.REDUCEAMOUNT;
                switch (AmountType) 
                {
                    case DisCountInsuranceAmountType.PERCENTAGE: type = SR.PERCENTAGE;
                        break;
                    case DisCountInsuranceAmountType.REDUCEAMOUNT: type = SR.REDUCEAMOUNT;
                        break;
                    case DisCountInsuranceAmountType.FIXEDPRICE: type = SR.FIXEDPRICE;
                        break;

                }
                return type;
            }
            set
            {
                DisCountInsuranceAmountType typeEnum = DisCountInsuranceAmountType.REDUCEAMOUNT;

                if(value == SR.PERCENTAGE) typeEnum = DisCountInsuranceAmountType.PERCENTAGE;
                if(value == SR.REDUCEAMOUNT) typeEnum = DisCountInsuranceAmountType.REDUCEAMOUNT;
                if(value == SR.FIXEDPRICE) typeEnum = DisCountInsuranceAmountType.FIXEDPRICE;
                
                AmountType = typeEnum;
            }
        }

        
        

        public int DiscountAmountTypeEnumIndex
        {
            get
            {
                int index = -1;
                if (insuranceRuleDetail.AmountType == DisCountInsuranceAmountType.PERCENTAGE)
                    index = 0;
                if (insuranceRuleDetail.AmountType == DisCountInsuranceAmountType.REDUCEAMOUNT)
                    index = 1;
                if (insuranceRuleDetail.AmountType == DisCountInsuranceAmountType.FIXEDPRICE)
                    index = 2;
                return index;
            }
            set
            {
                DisCountInsuranceAmountType typeEnum = DisCountInsuranceAmountType.REDUCEAMOUNT;
                switch (value)
                {

                    case 0: typeEnum = DisCountInsuranceAmountType.PERCENTAGE;
                        break;
                    case 1: typeEnum = DisCountInsuranceAmountType.REDUCEAMOUNT;
                        break;
                    case 2: typeEnum = DisCountInsuranceAmountType.FIXEDPRICE;
                        break;
                }

                insuranceRuleDetail.AmountType = typeEnum;
            }
        }

    }
}
