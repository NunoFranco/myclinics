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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.View.WinForms
{
    public partial class PatientProfileDetailsEditorControl : ApplicationComponentUserControl
    {
        private PatientProfileDetailsEditorComponent _component;

        public PatientProfileDetailsEditorControl(PatientProfileDetailsEditorComponent component)
            : base(component)
        {
            InitializeComponent();
            _component = component;

            // create bindings
            _familyName.DataBindings.Add("Value", _component, "FamilyName", true, DataSourceUpdateMode.OnPropertyChanged);
            _givenName.DataBindings.Add("Value", _component, "GivenName", true, DataSourceUpdateMode.OnPropertyChanged);
            _middleName.DataBindings.Add("Value", _component, "MiddleName", true, DataSourceUpdateMode.OnPropertyChanged);

            _sex.DataSource = _component.SexChoices;
            _sex.DataBindings.Add("Value", _component, "Sex", true, DataSourceUpdateMode.OnPropertyChanged);

            _dateOfBirth.DataBindings.Add("Value", _component, "DateOfBirth", true, DataSourceUpdateMode.OnPropertyChanged);
            _dateOfDeath.DataBindings.Add("Value", _component, "TimeOfDeath", true, DataSourceUpdateMode.OnPropertyChanged);

            _mrn.DataBindings.Add("Value", _component, "MrnID", true, DataSourceUpdateMode.OnPropertyChanged);

            _mrnAuthority.DataSource = _component.MrnAuthorityChoices;
            _mrnAuthority.DataBindings.Add("Value", _component, "MrnAuthority", true, DataSourceUpdateMode.OnPropertyChanged);

            _healthcard.DataBindings.Add("Value", _component, "HealthcardID", true, DataSourceUpdateMode.OnPropertyChanged);

            _insurer.DataSource = _component.HealthcardAuthorityChoices;
            _insurer.DataBindings.Add("Value", _component, "HealthcardAuthority", true, DataSourceUpdateMode.OnPropertyChanged);

            _healthcardVersionCode.DataBindings.Add("Value", _component, "HealthcardVersionCode", true, DataSourceUpdateMode.OnPropertyChanged);
            _healthcardExpiry.DataBindings.Add("Value", _component, "HealthcardExpiryDate", true, DataSourceUpdateMode.OnPropertyChanged);

            string type = "";
            ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType none = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE;

            //if (_component.SelectedDiscount != null)
            //{

                _discountClass.DataSource = _component.DiscountChoices;
                _discountClass.DataBindings.Add("Value", _component, "SelectedDiscount", true, DataSourceUpdateMode.OnPropertyChanged);
                //type = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.DISCOUNT.ToString();
            //}
            //else if (_component.SelectedInsurnce != null)
            //{
                
                _inSuranceClass.DataSource = _component.InsunranceChoices;
                _inSuranceClass.DataBindings.Add("Value", _component, "SelectedInsurnce", true, DataSourceUpdateMode.OnPropertyChanged);
                //type = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.INSURANCE.ToString();
            //}
            //else
            //{
            //    type = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE.ToString();
            //}

            //bool? isdiscount = _component.SelectedDiscount == null && _component.SelectedInsurnce == null;
            //_discountInsuranceClass.DataSource = _component.DiscountChoices;
            //_discountInsuranceClass.Value = _component.SelectedDiscount;
            
            ////there is no case the both insurance and discount != null
            //if (isdiscount == false)
            //{
            //    type = _component.SelectedInsurnce != null ? type = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.INSURANCE.ToString() : type;
            //    _discountInsuranceClass.Value = _component.SelectedInsurnce;
            //}
            //else
            //{
            //    type = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE.ToString();
            //    _discountInsuranceClass.Value = null;
            //}

            //_radIsDiscount.EditValue = type;
        }
        //void UpdateDiscountInsurceValue()
        //{
        //    if (_radIsDiscount.EditValue == null)
        //        return;
        //    string type = _radIsDiscount.EditValue.ToString();
        //    if (type == ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE.ToString())
        //    {
        //        _component.SelectedDiscount = null;
        //        _component.SelectedInsurnce = null;
        //    }
        //    else if (type == ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.DISCOUNT.ToString())
        //    {
        //        _component.SelectedDiscount = _discountClass.Value;
        //        _component.SelectedInsurnce = null;
        //    }
        //    else
        //    {
        //        _component.SelectedInsurnce = _discountClass.Value;
        //        _component.SelectedDiscount = null;
        //    }

        //}
        private void PatientEditorControl_Load(object sender, EventArgs e)
        {
            _dateOfBirth.Mask = _component.DateOfBirthMask;
            _healthcard.Mask = _component.HealthcardMask;
            _healthcardVersionCode.Mask = _component.HealthcardVersionCodeMask;
        }

        private void _radIsDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_radIsDiscount.EditValue == null)
            //    return;
            //string type = _radIsDiscount.EditValue.ToString();

           // _component.SelectedDiscountInsuranceType = Billing.Common.Util.GetEnumFromString<Billing.Common.DiscountInsuranceClassType>(type);
           // _component.SetModified(true);

           // ArrayList tmp = new ArrayList();
           // foreach (var item in _discountClass.DataBindings)
           // {
           //     tmp.Add(item);
           // }
           // foreach (var item in tmp)
           // {
           //     _discountClass.DataBindings.Remove(item as Binding);                
           // }
           // if (type == ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE.ToString())
           // {
           //     _discountClass.DataSource = null;
               
           // }
           // else if (type == ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.DISCOUNT.ToString())
           // {
           //     _discountClass.DataSource = _component.DiscountChoices;
           //     _discountClass.DataBindings.Add("Value", _component, "SelectedDiscount", true, DataSourceUpdateMode.OnPropertyChanged);
           //}
           // else
           // {
           //     _discountClass.DataSource = _component.InsunranceChoices;
           //     _discountClass.DataBindings.Add("Value", _component, "SelectedInsurnce", true, DataSourceUpdateMode.OnPropertyChanged);
           // }
        }

        private void _discountInsuranceClass_ValueChanged(object sender, EventArgs e)
        {
            //UpdateDiscountInsurceValue();
        }
    }
}