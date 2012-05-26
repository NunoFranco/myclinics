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

using ClearCanvas.Desktop.View.WinForms;
using System.Threading;
using System.Globalization;
namespace ClearCanvas.Ris.Billing.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="BillingCurrencyEditComponent"/>.
    /// </summary>
    public partial class BillingCurrencyEditComponentControl : ApplicationComponentUserControl
    {
        private BillingCurrencyEditComponent _component;
        List<CultureInfo> localeList = new List<CultureInfo>();
        List<string> listLocaleText = new List<string>();
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingCurrencyEditComponentControl(BillingCurrencyEditComponent component)
            : base(component)
        {
            _component = component;
            InitializeComponent();
            this.chkPrimaryCurrency.Enabled = false;
            this.chkPrimaryExRateCurrency.Enabled = false;
            txtCode.DataBindings.Add("Value", _component, "CurrencyCode", true, DataSourceUpdateMode.OnPropertyChanged);
            txtName.DataBindings.Add("Value", _component, "CurrencyName", true, DataSourceUpdateMode.OnPropertyChanged);
            GetLocale();
            txtCustomFormat.DataBindings.Add("Value", _component, "CustomDisplayFormat", true, DataSourceUpdateMode.OnPropertyChanged);
            this.txtRateToPrimary.DataBindings.Add("Value", _component, "RateToPrimaryCurrency", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkPrimaryCurrency.DataBindings.Add("Checked", _component, "IsPrimaryCurrency", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkPrimaryExRateCurrency.DataBindings.Add("Checked", _component, "IsPrimaryExRateCurrency", true, DataSourceUpdateMode.OnPropertyChanged);

            if (this.chkPrimaryExRateCurrency.Checked)
            {
                this.txtRateToPrimary.Enabled = false;
            }
            // TODO add .NET databindings to bindingSource
        }

        void GetLocale()
        {
            
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {

                //try { specName = CultureInfo.CreateSpecificCulture(ci.Name).Name; }
                //catch { }
                // list.Add(String.Format("{0,-12}{1,-12}{2}", ci.Name, specName, ci.EnglishName));
                if (ci.Name.Contains("-")) 
                {
                    listLocaleText.Add(ci.EnglishName);
                    localeList.Add(ci);
                }
            }
            string specName = "(none)";
            listLocaleText.Sort();

            listLocaleText.Insert(0, specName);

            this.cmbDisplayLocal.DataSource = listLocaleText;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {

            _component.Accept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }

        private void cmbDisplayLocal_ValueChanged(object sender, EventArgs e)
        {
            
            if (this.cmbDisplayLocal.Value!=null)
            {                
                CultureInfo c = localeList.Find(x=>x.EnglishName==this.cmbDisplayLocal.Value.ToString());
                if (c != null)
                {
                    _component.DisplayLocale = c.Name;
                }
            }
        }

        private void BillingCurrencyEditComponentControl_Load(object sender, EventArgs e)
        {
            CultureInfo c = localeList.Find(x => x.Name == _component.DisplayLocale);
            if (c != null)
            {
                cmbDisplayLocal.Value = c.EnglishName;
            }
            else
            {
                cmbDisplayLocal.Value = listLocaleText[0];
            }
            this.txtCode.Enabled = _component._isNew;
            this.txtRateToPrimary.Enabled = !_component.IsPrimaryExRateCurrency;
        }
    }
}
