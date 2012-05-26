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
    /// Extension point for views onto <see cref="BillingDiscountPriceComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingDiscountPriceComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingDiscountPriceComponent class.
    /// </summary>
    [AssociateView(typeof(BillingDiscountPriceComponentViewExtensionPoint))]
    public class BillingDiscountPriceComponent : ApplicationComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// 

        //public List<System.Windows.Forms.TreeView> ListChecked;
        //public List<System.Windows.Forms.TreeView> ListCheckedUP;
        public List<DiscountRuleDetail> ListDiscount;
        public List<EnumValueInfo> DiscountTypeEnumList;
        public System.Data.DataTable DTableDiscountBinding;
        public FacilitySummary Clinic;
        public BillingDiscountPriceComponent(FacilitySummary f)
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
        public List<DiscountRuleSummary> ClassChoice
        {
            get
            {
                List<DiscountRuleSummary> tmp = null;
                Platform.GetService<IDiscountRuleService>(delegate(IDiscountRuleService service)
                {
                    ListDiscountRuleRequest request = new ListDiscountRuleRequest();
                    tmp = service.ListAllDiscount(request)._Discounts;

                });
                return tmp;
            }
        }



        private string ProcedureTypeRefCode(EntityRef ProcedureTypeRef, string DiscountTypeCode)
        {
            System.Data.DataTable ListDiscountChecking = BindProcedureType(DiscountTypeCode);

            string ProcedureTypeRefCodeResult = "";
                Platform.GetService<IDiscountRuleService>(delegate(IDiscountRuleService service)
                {
                    ProcedureTypeRefCodeResult = service.GetProcedureTypeRefCode(ProcedureTypeRef);
                });
            
            return ProcedureTypeRefCodeResult;
        }
        public bool Save(List<DiscountRuleDetail> list, int DiscountTypeEnumIndex)
        {
            ListDiscount = list;
            bool noExistItem = true;
        
            Platform.GetService<IDiscountRuleService>(
            delegate(IDiscountRuleService service)
            {
                foreach (DiscountRuleDetail discountDetail in list)
                {
                    if (service.ListAllDiscount(new ListDiscountRuleRequest(discountDetail.ProcedureTypeRef,
                        DiscountTypeEnumList[DiscountTypeEnumIndex]))._Discounts.Count == 0)
                    {
                        AddDiscountSummaryResponse response = service.AddObjectSummary(new AddDiscountSummaryRequest(discountDetail));
                    }
                    else
                        noExistItem = false;
                   
                }
            });
            return noExistItem;
            
        }

        public List<DiscountRuleSummary> ClassEnum
        {
            get
            {
                List<DiscountRuleSummary> tmp = null;
                Platform.GetService<IDiscountRuleService>(delegate(IDiscountRuleService service)
                {
                    ListDiscountRuleRequest request = new ListDiscountRuleRequest();
                    tmp = service.ListAllDiscount(request)._Discounts;

                });
                return tmp;
            }
        }
        public List<string> DiscountTypeEnumValueList
        {
            get
            {
                List<string> valueList = new List<string>();
                Platform.GetService<IDiscountRuleService>(delegate(IDiscountRuleService service)
                {
                    LoadPatientProfileEditorFormDataRequest request = new LoadPatientProfileEditorFormDataRequest(Clinic );

                    var formData = service.LoadPatientProfileEditorFormData(request);
                    DiscountTypeEnumList = new List<EnumValueInfo>();
                    foreach(EnumValueInfo value in formData.DiscountChoices)
                    {
                        valueList.Add(value.Value);
                        DiscountTypeEnumList.Add(value);
                    }
                });
                return valueList;
            }

        }

        public  System.Data.DataTable BindProcedureType(string DiscountTypeCode)
        {

            DTableDiscountBinding = new System.Data.DataTable();
            DTableDiscountBinding.Columns.Add("TypeCode");
            DTableDiscountBinding.Columns.Add("TypeName");
            DTableDiscountBinding.Columns.Add("Type");
            DTableDiscountBinding.Columns.Add("Amount");
            DTableDiscountBinding.Columns.Add("DiscountRuleID");
            DTableDiscountBinding.Columns.Add("EntityRef");



            
            LoadDiscountResponse ResultResponse = null;


            Platform.GetService<IDiscountRuleService>(delegate (IDiscountRuleService service)
            {
            
                LoadDiscountRequest request = new LoadDiscountRequest();
                request.ClassID = DiscountTypeCode;
                ResultResponse = service.LoadDiscountBinding(request);

            });

            List<ProcedureTypeSummary> ListProcedureType = null;

            Platform.GetService<IProcedureTypeAdminService>(delegate(IProcedureTypeAdminService service)
            {
                ListProcedureType = service.ListProcedureTypes(new ListProcedureTypesRequest()).ProcedureTypes;
            });
            
            

            
            if (ResultResponse != null)
            {
                foreach (DiscountRuleDetail ds in ResultResponse.discountList)
                {
                    
                    //ListProcedureType.Find(new ProcedureTypeSummary(ds.ProcedureTypeRef,null,null,null,null,null,null,null);
                    ProcedureTypeSummary prodetail= new ProcedureTypeSummary();
                    foreach (ProcedureTypeSummary summary in ListProcedureType)
                    {
                        if(summary.ProcedureTypeRef == ds.ProcedureTypeRef)
                        {
                            prodetail = summary;
                            break;
                        }
                    }

                    System.Data.DataRow row = DTableDiscountBinding.NewRow();
                    row[0] = prodetail.Id;
                    row[1] = prodetail.Name;
                    row[2] = DiscountAmountTypeEnumText(ds.AmountType.ToString());
                    row[3] = ds.Amount.ToString();
                    row[4] = ds.DiscountDetailRef.Serialize();
                    DTableDiscountBinding.Rows.Add(row);

                }
            }
            return DTableDiscountBinding;

        }
        private string DiscountAmountTypeEnumText(string Code)
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

        public string DiscountTypeEnumCode(int Index)
        {
            return DiscountTypeEnumList[Index].Code;
        }
        public string DiscountTypeEnumValue(int Index)
        {
            return DiscountTypeEnumList[Index].Value;
        }
        public void OpenEditDiscountForm(IDesktopWindow desktop, BillingDiscountEditComponent form)
        {  
            ApplicationComponent.LaunchAsDialog(desktop, form, "Edit Discount Rule Detail");

        }
       
       
    }
}
