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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Desktop.View.WinForms;


namespace ClearCanvas.Ris.Billing.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="BillingInsuranceEditComponent"/>.
    /// </summary>
    public partial class BillingInsuranceEditComponentControl : ApplicationComponentUserControl
    {
        private BillingInsuranceEditComponent _component;

         /// <summary>
        /// Constructor.
        /// </summary>
        public BillingInsuranceEditComponentControl(BillingInsuranceEditComponent component)
            :base(component)
        {
			_component = component;
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = _component;

            // TODO add .NET databindings to bindingSource
            this.textFieldProcedureCode.DataBindings.Add("Value", _component, "procedureTypeDetailId", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textFieldProcedureName.DataBindings.Add("Value", _component, "procedureTypeDetailName", true, DataSourceUpdateMode.OnPropertyChanged);
            this.textFieldInsuranceType.DataBindings.Add("Value", _component, "insuranceRuleDetailClassIDValue", true, DataSourceUpdateMode.OnPropertyChanged);
            
            this.textEditAmount.DataBindings.Add("Text", _component, "insuranceRuleDetailAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            //
            foreach (string item in CommonEnumList.ListDisCountInsuranceAmountType)
            {
                comboBoxEditAmountType.Properties.Items.Add(InsuranceAmountTypeEnumText(item));
            }
            comboBoxEditAmountType.Properties.Items.RemoveAt(2);
            this.comboBoxEditAmountType.DataBindings.Add("SelectedIndex", _component, "DiscountAmountTypeEnumIndex", true, DataSourceUpdateMode.OnPropertyChanged);
            //comboBoxEditAmountType.SelectedIndex = _component.indexInsuranceType();
            //bindingData();
            //setLengthAmountText();
        }

        

       

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _component.Cancel();
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            _component.Update();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _component.Delete();
            _component.Cancel();
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

        public DisCountInsuranceAmountType InsuranceAmountTypeEnumCode(int Index)
        {
            DisCountInsuranceAmountType type = DisCountInsuranceAmountType.PERCENTAGE;
            switch (Index)
            {
                case 0: type = DisCountInsuranceAmountType.PERCENTAGE;
                    break;
                case 1: type = DisCountInsuranceAmountType.REDUCEAMOUNT;
                    break;
                case 2: type = DisCountInsuranceAmountType.FIXEDPRICE;
                    break;

            }
            return type;
        }
        private void textEditAmount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = !(((DevExpress.XtraEditors.TextEdit)sender).SelectionStart != 0 && (e.KeyChar.ToString() ==
                    System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator &&
                    ((DevExpress.XtraEditors.TextEdit)sender).Text.IndexOf(System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) == -1)) &&
                    e.KeyChar != Convert.ToChar(8);
            }
            else
            {
                if (DiscountAmountTypeEnumCode(DiscountAmountTypeEnumIndex(comboBoxEditAmountType.Text)) ==
                    DisCountInsuranceAmountType.PERCENTAGE)
                {
                    try
                    {
                        e.Handled = Convert.ToDecimal(textEditAmount.Text + e.KeyChar) > 100;
                    }
                    catch
                    {
                    }

                }
            }

        }

        private void textEditAmount_Validating(object sender, CancelEventArgs e)
        {
            decimal isdecimal = 0;
            if (decimal.TryParse(textEditAmount.Text, out isdecimal))
            {
                if (DiscountAmountTypeEnumCode(DiscountAmountTypeEnumIndex(comboBoxEditAmountType.Text)) == DisCountInsuranceAmountType.PERCENTAGE)

                    e.Cancel = Convert.ToDecimal(textEditAmount.Text) > 100;

                else
                    e.Cancel = textEditAmount.Text.Length > 14;
            }
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

        public DisCountInsuranceAmountType DiscountAmountTypeEnumCode(int Index)
        {
            DisCountInsuranceAmountType type = DisCountInsuranceAmountType.PERCENTAGE;
            switch (Index)
            {
                case 0: type = DisCountInsuranceAmountType.PERCENTAGE;
                    break;
                case 1: type = DisCountInsuranceAmountType.REDUCEAMOUNT;
                    break;
                case 2: type = DisCountInsuranceAmountType.FIXEDPRICE;
                    break;

            }
            return type;
        }

        private void comboBoxEditAmountType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private int DiscountAmountTypeEnumIndex(string Value)
        {
            int index = -1;
            if (Value == SR.PERCENTAGE)
                index = 0;
            if (Value == SR.REDUCEAMOUNT)
                index = 1;
            if (Value == SR.FIXEDPRICE)
                index = 2;
            return index;
        }
        public void setLengthAmountText()
        {
            DisCountInsuranceAmountType DiscountAmountTypeSelected = DiscountAmountTypeEnumCode(DiscountAmountTypeEnumIndex(comboBoxEditAmountType.Text));

            if (DiscountAmountTypeSelected == DisCountInsuranceAmountType.PERCENTAGE)
            {
                if (Convert.ToDecimal(textEditAmount.Text) > 100) textEditAmount.Text = "100";
                textEditAmount.Properties.MaxLength = 6;
                comboBoxEditAmountType.Text = SR.PERCENTAGE;
            }
            else
                textEditAmount.Properties.MaxLength = 13;
        }

        private void comboBoxEditAmountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setLengthAmountText();
        }

        private void comboBoxEditAmountType_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

       

        

    }
}
