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
using ClearCanvas.Ris.Client.Billing;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="BillingOptionComponent"/>.
    /// </summary>
    public partial class BillingOptionComponentControl : ApplicationComponentUserControl
    {
        private BillingOptionComponent _component;

        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingOptionComponentControl(BillingOptionComponent component)
            :base(component)
        {
			_component = component;
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = _component;
            this.cmbCurrency.DataSource = _component.AvailableCurrency;
            this.cmbCurrency.DataBindings.Add("Value", _component, "PrimaryCurrency", false, DataSourceUpdateMode.OnPropertyChanged);
            this.cmbCurrency.Value = _component.PrimaryCurrency;
            ////Configure Language
            //this.cmbLanguague.DataBindings.Add("Value", _component, "SystemLanguage", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.cmbLanguague.Value = _component.SystemLanggue;
            // TODO add .NET databindings to bindingSource
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _component.Accept();   
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }
    }
}
