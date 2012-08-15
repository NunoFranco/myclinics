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
using ClearCanvas.Common;
namespace ClearCanvas.Material.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="WarehouseEditorComponent"/>.
    /// </summary>
    public partial class WarehouseEditorComponentControl : ApplicationComponentUserControl
    {
        private WarehouseEditorComponent _component;

        /// <summary>
        /// Constructor.
        /// </summary>
        public WarehouseEditorComponentControl(WarehouseEditorComponent component)
            : base(component)
        {
            _component = component;
            InitializeComponent();

            txtCode.DataBindings.Add("Value", _component, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDetailInformation.DataBindings.Add("Value", _component, "ContactDetailInformation", true, DataSourceUpdateMode.OnPropertyChanged);
            txtName.DataBindings.Add("Value", _component, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            lookupStaff.LookupHandler = _component.StaffLookup;
            lookupStaff.DataBindings.Add("Value", _component, "PIC", true, DataSourceUpdateMode.OnPropertyChanged);

            // _baseType.DataSource = _component.BaseTypeChoices;
            // _baseType.DataBindings.Add("Value", _component, "BaseType", true, DataSourceUpdateMode.OnPropertyChanged);
            // _baseType.Format += delegate(object sender, ListControlConvertEventArgs e) { e.Value = _component.FormatBaseTypeItem(e.ListItem); };


        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            _component.Accept();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            _component.Cancel();
        }

    }
}