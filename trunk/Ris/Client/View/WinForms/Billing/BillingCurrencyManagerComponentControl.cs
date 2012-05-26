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
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Common;
using ClearCanvas.Ris.Client.Billing;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="BillingCurrencyManagerComponent"/>.
    /// </summary>
    public partial class BillingCurrencyManagerComponentControl : ApplicationComponentUserControl
    {
        private BillingCurrencyManagerComponent _component;
        public CurrencyDetail CurrencyPrimaryCurrency
        {
            get
            {
                
                foreach (var item in AllCurrency)
                {
                    if (item.IsPrimaryCurrency)
                        return item;
                }
                Platform.Log(LogLevel.Error, "Primary Currency Not found");
                return null;
            }
        }
        List<CurrencyDetail> _Currency;
        public List<CurrencyDetail> AllCurrency
        {
            get
            {
                if (_Currency == null)
                {
                    _Currency = new List<CurrencyDetail>();
                    Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
                    {
                        ListCurrencyRequest request = new ListCurrencyRequest();
                        request.IsListDetail = true;
                        _Currency = service.ListAllCurrency(request).Details;
                    });
                }
                return _Currency;
            }
            set {
                _Currency = value;
            }
        }
        
        public CurrencyDetail CurrencyPrimaryExRateCurrency
        {
            get
            {
                foreach (var item in AllCurrency)
                {
                    if (item.IsPrimaryExRateCurrency)
                        return item;
                }
                return null;
                //CurrencyDetail tmp = new CurrencyDetail();
                //Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
                //{
                //    ListCurrencyRequest request = new ListCurrencyRequest();
                //    request.IsListDetail = true;
                //    request.IsPrimaryExRateCurrency = true;
                //    tmp = service.ListAllCurrency(request).Details[0];
                //});
                //return tmp;
            }
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingCurrencyManagerComponentControl(BillingCurrencyManagerComponent component)
            : base(component)
        {
            _component = component;
            InitializeComponent();
            this._CurrencyTableView.DoubleClick += CurrencyTableView_ItemDoubleClicked;

            _CurrencyTableView.ToolbarModel = _component.SummaryTableActionModel;
            _CurrencyTableView.MenuModel = _component.SummaryTableActionModel;

            _CurrencyTableView.Table = _component.SummaryTable;
            _CurrencyTableView.DataBindings.Add("Selection", _component, "SummarySelection", true, DataSourceUpdateMode.OnPropertyChanged);

            _id.DataBindings.Add("Value", _component, "CurrencyCode", true, DataSourceUpdateMode.OnPropertyChanged);
            _name.DataBindings.Add("Value", _component, "CurrencyName", true, DataSourceUpdateMode.OnPropertyChanged);

            _okButton.DataBindings.Add("Visible", _component, "ShowAcceptCancelButtons");
            _okButton.DataBindings.Add("Enabled", _component, "AcceptEnabled");
            _cancelButton.DataBindings.Add("Visible", _component, "ShowAcceptCancelButtons");
            _component.PropertyChanged += new PropertyChangedEventHandler(_component_PropertyChanged);
            // TODO add .NET databindings to bindingSource
        }

        void _component_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            AllCurrency = null;
        }

       
        private void _searchButton_Click(object sender, EventArgs e)
        {
            using (new CursorManager(Cursors.WaitCursor))
            {
                _component.Search();
                
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            _component.Accept();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }

        private void CurrencyTableView_ItemDoubleClicked(object sender, EventArgs e)
        {
            _component.DoubleClickSelectedItem();
        }

        private void _clearButton_Click(object sender, EventArgs e)
        {
            _id.Value = "";
            _name.Value = "";
            _component.Search();
        }

        private void _field_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = _searchButton;
        }

        private void _field_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = _okButton;
        }

        private void btnSetPrimaryCurrnency_Click(object sender, EventArgs e)
        {
            frmSetPrimaryCurrency frm = new frmSetPrimaryCurrency(CurrencyPrimaryCurrency, CurrencyPrimaryExRateCurrency, AllCurrency);
            frm.IsPrimaryCurrencyChanged = true;
            frm.ShowDialog();
            if (frm.isNeedReload)
            {
                _component.Search();
            }
        }
        private void btnChangedPrimaryExRateCurrnency_Click(object sender, EventArgs e)
        {
            frmSetPrimaryCurrency frm = new frmSetPrimaryCurrency(CurrencyPrimaryCurrency, CurrencyPrimaryExRateCurrency, AllCurrency);
            frm.IsPrimaryExRateCurrencyChanged = true;
            frm.ShowDialog();
            if (frm.isNeedReload)
            {
                _component.Search();
            }
        }
    }
}
