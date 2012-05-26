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
using System.Windows.Forms;
using ClearCanvas.Desktop.View.WinForms;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Common;
namespace ClearCanvas.Ris.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="ProcedureTypeEditorComponent"/>.
    /// </summary>
    public partial class ProcedureTypeEditorComponentControl : ApplicationComponentUserControl
    {
        private ProcedureTypeEditorComponent _component;
        ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail _primayrCurrency = null;
        ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail PrimaryCurrency
        {
            get
            {
                if (_primayrCurrency != null)
                    return _primayrCurrency;
                try
                {
                    ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail result = new ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail();
                    Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
                    {
                        ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
                        request.IsListDetail = true;
                        request.IsPrimaryCurrency = true;
                        result = service.ListAllCurrency(request).Details[0];
                    });
                    _primayrCurrency= result;
                    return _primayrCurrency;
                }
                catch (Exception ex)
                {
                    Platform.Log(LogLevel.Error, ex);
                    Platform.Log(LogLevel.Error, "Primary Currency Not found");
                }
                return new ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail();
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public ProcedureTypeEditorComponentControl(ProcedureTypeEditorComponent component)
            : base(component)
        {
            _component = component;
            InitializeComponent();

            _name.DataBindings.Add("Value", _component, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            _id.DataBindings.Add("Value", _component, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            _acceptButton.DataBindings.Add("Enabled", _component, "AcceptEnabled", true, DataSourceUpdateMode.OnPropertyChanged);

            _baseType.DataSource = _component.BaseTypeChoices;
            _baseType.DataBindings.Add("Value", _component, "BaseType", true, DataSourceUpdateMode.OnPropertyChanged);
            _baseType.Format += delegate(object sender, ListControlConvertEventArgs e) { e.Value = _component.FormatBaseTypeItem(e.ListItem); };

            _comboUnit.DataSource = _component.UOMS ;
            _comboUnit.DataBindings.Add("Value", _component, "UOM", true, DataSourceUpdateMode.OnPropertyChanged);
            _comboUnit.Format += delegate(object sender, ListControlConvertEventArgs e) { e.Value = _component.FormatEnumInfoValue(e.ListItem); };

            _comboCategory.DataSource = _component.Categories ;
            _comboCategory.DataBindings.Add("Value", _component, "Category", true, DataSourceUpdateMode.OnPropertyChanged);
            _comboCategory.Format += delegate(object sender, ListControlConvertEventArgs e) { e.Value = _component.FormatEnumInfoValue(e.ListItem); };

            chkIsRequired.DataBindings.Add("Checked", _component, "IsRequired", true, DataSourceUpdateMode.OnPropertyChanged);

            _itemPrice.DataBindings.Add("Value", _component, "BasePrice", true, DataSourceUpdateMode.OnPropertyChanged);
            _itemTax.DataBindings.Add("Value", _component, "Tax", true, DataSourceUpdateMode.OnPropertyChanged);

            Control xmlEditor = (Control)_component.XmlEditorHost.ComponentView.GuiElement;
            xmlEditor.Dock = DockStyle.Fill;
            _xmlEditorPanel.Controls.Add(xmlEditor);
        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            _component.Accept();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }
        void UpdateTotal()
        {
            double UnitPrice = 0;
            double tax = 0;
            if (!double.TryParse(_itemPrice.Value, out UnitPrice) || !double.TryParse(_itemTax.Value, out tax))
                return;

            this._totalPrice.Value = Common.Utilities.NumberUtils.GetCurrencyDisplayFormat(PrimaryCurrency.DisplayLocale, PrimaryCurrency.CustomDisplayFormat,UnitPrice + (tax / 100.0 * UnitPrice));
        }
        private void _itemTax_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }
        bool validate(string value)
        {
            decimal result = 0;
            if (decimal.TryParse(value, out result))
            {
                if (result > 100 || result <0)
                    return false;
            }
            return true;
        }
        private void _itemPrice_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void _itemPrice_Leave(object sender, EventArgs e)
        {
            //_itemPrice.Value = Common.Utilities.NumberUtils.GetCurrencyDisplayFormat(PrimaryCurrency.DisplayLocale,PrimaryCurrency.CustomDisplayFormat, _itemPrice.Value);
        }

        private void _itemTax_Leave(object sender, EventArgs e)
        {

            _itemTax.Value = _itemTax.Value;
        }

        private void _itemTax_Load(object sender, EventArgs e)
        {

        }
    }
}
