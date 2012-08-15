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

namespace ClearCanvas.Material.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="Instock_Medicine"/>.
    /// </summary>
    public partial class StockTransactionEditorComponentControl : ApplicationComponentUserControl
    {
        private StockTransactionEditorComponent _component;

        /// <summary>
        /// Constructor.
        /// </summary>
        public StockTransactionEditorComponentControl(StockTransactionEditorComponent component)
            :base(component)
        {
			_component = component;
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = _component;
            //this.lkuSupplier.LookupHandler = _component.supplierlookup;
            //this.lkuSupplier.DataBindings.Add("Value", _component, "SelectedSupplier", true, DataSourceUpdateMode.OnPropertyChanged);
            this.lkuMedicine.LookupHandler = _component.medicineLookup;
            this.lkuMedicine.DataBindings.Add("Value", _component, "SelectMedicine", true, DataSourceUpdateMode.OnPropertyChanged);
            this.lkuMaterialLot.LookupHandler = _component.materilLotLookup;
            this.lkuMaterialLot.DataBindings.Add("Value", _component, "SelectedMedicineLot", true, DataSourceUpdateMode.OnPropertyChanged);

            this.lookupFromWareHouse.LookupHandler = _component.inWareHouseLookup;
            this.lookupFromWareHouse.DataBindings.Add("Value", _component, "InWareHouse", true, DataSourceUpdateMode.OnPropertyChanged);

            this.lookupToWareHouse.LookupHandler = _component.outWareHouseLookup;
            this.lookupToWareHouse.DataBindings.Add("Value", _component, "OutWareHouse", true, DataSourceUpdateMode.OnPropertyChanged);
            this.lookupToWareHouse.DataBindings.Add("Visible", _component, "IsShowWareHouse2", true, DataSourceUpdateMode.OnPropertyChanged);


            txtInputCode.DataBindings.Add("Value", _component, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
            //dtpInputDate.DataBindings.Add("Value", _component, "TransactionDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.tableView_Medicines.Table = _component.Lines;
            this.tableView_Medicines.MenuModel = _component.LineItemAction;
            this.tableView_Medicines.ToolbarModel = _component.LineItemAction;
            this.tableView_Medicines.DataBindings.Add("Selection", _component, "SelectedLine", true, DataSourceUpdateMode.OnPropertyChanged);


            txtDescription.DataBindings.Add("Value", _component, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            txtInputPrice.DataBindings.Add("Value", _component, "InputPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            txtInputQuantity.DataBindings.Add("Value", _component, "Amount", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTaxRate.DataBindings.Add("Value", _component, "Tax", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpExpireDate.DataBindings.Add("Value", _component, "ExpireDate", true, DataSourceUpdateMode.OnPropertyChanged);

            //Information Fields
            txtCurrentQuantity.DataBindings.Add("Value", _component, "CurrentQuantity", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMedicineDose.DataBindings.Add("Value", _component, "MedicineDose", true, DataSourceUpdateMode.OnPropertyChanged);
            txtUOM.DataBindings.Add("Value", _component, "UOM", true, DataSourceUpdateMode.OnPropertyChanged);
             //TODO add .NET databindings to bindingSource
            btnAdd.DataBindings.Add("Enabled", _component, "AllowAddLineItems", true, DataSourceUpdateMode.OnPropertyChanged);
            btnOK.DataBindings.Add("Enabled", _component, "AcceptEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
            btnLineCancel.DataBindings.Add("Enabled", _component, "IsEnableCancel", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _component.AddLineItems();
            this.lkuMedicine.Focus();
        }

        private void tableView_Medicines_SelectionChanged(object sender, EventArgs e)
        {
            _component.LineItemsSelectChanged();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _component.Accept();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }

        private void btnLineCancel_Click(object sender, EventArgs e)
        {
            _component.CancelEditLineItem();
        }
    }
}
