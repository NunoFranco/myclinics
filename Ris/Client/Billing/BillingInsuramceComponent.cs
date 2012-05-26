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
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Admin.PatientAdmin;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin;

namespace ClearCanvas.Ris.Client.Billing
{
    /// <summary>
    /// Extension point for views onto <see cref="BillingInsuramceComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingInsuramceComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingInsuramceComponent class.
    /// </summary>
    [AssociateView(typeof(BillingInsuramceComponentViewExtensionPoint))]
    public class BillingInsuramceComponent : ApplicationComponent
    {
       /// <summary>
        /// Constructor.
        /// </summary>
        /// 

        //public List<System.Windows.Forms.TreeView> ListChecked;
        //public List<System.Windows.Forms.TreeView> ListCheckedUP;
        public List<InsuranceRuleDetail> ListInsurance;
        public List<EnumValueInfo> InsuranceTypeEnumList;
        public System.Data.DataTable DTableInsuranceBinding;
        public FacilitySummary Clinic;
        public BillingInsuramceComponent( FacilitySummary f)
        {
            Clinic = f;
        }
        public IDesktopWindow ActiveWindow { get; set; }
        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            // TODO prepare the component for its live phase

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
        public List<InsuranceRuleSummary> ClassChoice
        {
            get
            {
                List<InsuranceRuleSummary> tmp = null;
                Platform.GetService<IInsuranceRuleService>(delegate(IInsuranceRuleService service)
                {
                    ListInsuranceRuleRequest request = new ListInsuranceRuleRequest();
                    tmp = service.ListAllInsurance(request)._Insurances;

                });
                return tmp;
            }
        }

        //public string InsuranceCode { get; set; }
        //public string  Amounttype { get; set; }
        //public decimal Amount { get; set; }
        public bool Save(List<InsuranceRuleDetail> list, int InsuranceTypeEnumIndex)
        {
            ListInsurance = list;
            bool noExistItem = true;

            Platform.GetService<IInsuranceRuleService>(
            delegate(IInsuranceRuleService service)
            {
                foreach (InsuranceRuleDetail InsuranceDetail in list)
                {
                    if (service.ListAllInsurance(new ListInsuranceRuleRequest(InsuranceDetail.ProcedureTypeRef,                        
                        InsuranceTypeEnumList[InsuranceTypeEnumIndex]))._Insurances.Count == 0)
                    {
                        AddInsuranceSummaryResponse response = service.AddObjectSummary(new AddInsuranceSummaryRequest(InsuranceDetail));
                    }
                    else
                        noExistItem = false;                   
                }
            });
            return noExistItem;

        }

        public List<InsuranceRuleSummary> ClassEnum
        {
            get
            {
                List<InsuranceRuleSummary> tmp = null;
                Platform.GetService<IInsuranceRuleService>(delegate(IInsuranceRuleService service)
                {
                    ListInsuranceRuleRequest request = new ListInsuranceRuleRequest();
                    tmp = service.ListAllInsurance(request)._Insurances;

                });
                return tmp;
            }
        }
        public List<string> InsuranceTypeEnumValueList
        {
            get
            {
                List<string> valueList = new List<string>();
                Platform.GetService<IInsuranceRuleService>(delegate(IInsuranceRuleService service)
                {
                    LoadPatientProfileEditorFormDataRequest request = new LoadPatientProfileEditorFormDataRequest(Clinic );

                    var formData = service.LoadPatientProfileEditorFormData(request);
                    InsuranceTypeEnumList = new List<EnumValueInfo>();
                    foreach(EnumValueInfo value in formData.InsuranceChoices)
                    {
                        valueList.Add(value.Value);
                        InsuranceTypeEnumList.Add(value);
                    }
                });
                return valueList;
            }

        }

        public  System.Data.DataTable BindProcedureType(string InsuranceTypeCode)
        {

            DTableInsuranceBinding = new System.Data.DataTable();
            DTableInsuranceBinding.Columns.Add("TypeCode");
            DTableInsuranceBinding.Columns.Add("TypeName");
            DTableInsuranceBinding.Columns.Add("Type");
            DTableInsuranceBinding.Columns.Add("Amount");
            DTableInsuranceBinding.Columns.Add("InsuranceRuleID");
            DTableInsuranceBinding.Columns.Add("EntityRef");




            
            LoadInsuranceResponse ResultResponse = null;

            List<ProcedureTypeSummary> ListProcedureType = null;
            Platform.GetService<IProcedureTypeAdminService>(delegate(IProcedureTypeAdminService service)
            {
                ListProcedureType = service.ListProcedureTypes(new ListProcedureTypesRequest()).ProcedureTypes;
            });

            Platform.GetService<IInsuranceRuleService>(delegate(IInsuranceRuleService service)
            {
                LoadInsuranceRequest request = new LoadInsuranceRequest();
                request.ClassID = InsuranceTypeCode;
                ResultResponse = service.LoadInsuranceBinding(request);

            });
            //Platform.ShowMessageBox("1");
            if (ResultResponse != null)
            {
                foreach (InsuranceRuleDetail ds in ResultResponse.InsuranceList)
                {


                    ProcedureTypeSummary prodetail = new ProcedureTypeSummary();
                    foreach (ProcedureTypeSummary summary in ListProcedureType)
                    {
                        if (summary.ProcedureTypeRef == ds.ProcedureTypeRef)
                        {
                            prodetail = summary;
                            break;
                        }
                    }


                    System.Data.DataRow row = DTableInsuranceBinding.NewRow();
                    row[0] = prodetail.Id;
                    row[1] = prodetail.Name;
                    row[2] = InsuranceAmountTypeEnumText(ds.AmountType.ToString());
                    row[3] = ds.Amount.ToString();
                    row[4] = ds.InsuranceDetailRef.Serialize();
                    DTableInsuranceBinding.Rows.Add(row);

                }
            }
            return DTableInsuranceBinding;

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

        public string InsuranceTypeEnumCode(int Index)
        {
            return InsuranceTypeEnumList[Index].Code;
        }
        public string InsuranceTypeEnumValue(int Index)
        {
            return InsuranceTypeEnumList[Index].Value;
        }
        public void OpenEditInsuranceForm(IDesktopWindow desktop, BillingInsuranceEditComponent form)
        {  
            ApplicationComponent.LaunchAsDialog(desktop, form, "Edit Insurance Rule Detail");

        }
        
    }
}
