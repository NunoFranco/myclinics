﻿#region License

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
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Common;
namespace ClearCanvas.Ris.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="DiagnosticServiceEditorComponent"/>.
    /// </summary>
    public partial class DiagnosticServiceEditorComponentControl : ApplicationComponentUserControl
    {
        private DiagnosticServiceEditorComponent _component;
        ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail PrimaryCurrency
        {
            get
            {
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
                    return result;
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
        public DiagnosticServiceEditorComponentControl(DiagnosticServiceEditorComponent component)
            : base(component)
        {
            _component = component;
            InitializeComponent();

            _idBox.DataBindings.Add("Value", _component, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            _nameBox.DataBindings.Add("Value", _component, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            _acceptButton.DataBindings.Add("Enabled", _component, "AcceptEnabled", true, DataSourceUpdateMode.OnPropertyChanged);

            _itemSelector.AvailableItemsTable = _component.AvailableDiagnosticServices;
            _itemSelector.SelectedItemsTable = _component.SelectedDiagnosticServices;

            _radAutoUpdate.DataBindings.Add("EditValue", _component, "IsAutoUpdatePrice", true, DataSourceUpdateMode.OnPropertyChanged);
            _packagePrice.DataBindings.Add("Value", _component, "PackagePrice", true, DataSourceUpdateMode.OnPropertyChanged);
            chkIsPackageProcedure.DataBindings.Add("Checked", _component, "IsPackageProcedure", true, DataSourceUpdateMode.OnPropertyChanged);

            grpPackagePrice.Enabled = isProcedurePackage;
            this._packagePrice.Enabled = isManuallyUpdatePrice;

            _itemSelector.ItemAdded += OnItemsAddedOrRemoved;
            _itemSelector.ItemRemoved += OnItemsAddedOrRemoved;
        }


        bool isProcedurePackage
        {
            get
            {
                return chkIsPackageProcedure.Checked;
            }
        }
        bool isManuallyUpdatePrice
        {
            get
            {
                if (_radAutoUpdate.EditValue == null)
                    return false;
                return !(bool)_radAutoUpdate.EditValue;
            }
        }
        private void _acceptButton_Click(object sender, EventArgs e)
        {
            _component.Accept();
        }

        private void OnItemsAddedOrRemoved(object sender, EventArgs e)
        {
            this._packagePrice.Value = GetAutoPriceAmount();
            _component.ItemsAddedOrRemoved();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }

        private void chkIsPackageProcedure_CheckedChanged(object sender, EventArgs e)
        {
            grpPackagePrice.Enabled = isProcedurePackage;
        }

        private void _radAutoUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._packagePrice.Enabled = isManuallyUpdatePrice;
            this._packagePrice.Value = GetAutoPriceAmount();
        }
        public string GetAutoPriceAmount()
        {
            object amount = GetDecimalAmount();
            if (amount == null)
                return null;
            return Common.Utilities.NumberUtils.GetCurrencyDisplayFormat(PrimaryCurrency.DisplayLocale, PrimaryCurrency.CustomDisplayFormat, amount);
        }
        public decimal? GetDecimalAmount()
        {
            decimal amount = 0;// 
            if (isProcedurePackage && !isManuallyUpdatePrice)//package and auto update price
            {
                decimal totalAutoPrice = 0;
                foreach (ProcedureTypeSummary item in this._itemSelector.SelectedItemsTable.Items)
                {
                    totalAutoPrice += item.BasePrice + (item.Tax / 100 * item.BasePrice);
                }
                amount = totalAutoPrice;
            }
            if (isManuallyUpdatePrice)
                decimal.TryParse(this._packagePrice.Value, out amount);
            return amount;
        }
        private void btnReUpdatePrice_Click(object sender, EventArgs e)
        {

        }
    }
}