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

namespace ClearCanvas.Ris.Client.Admin.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="WorkingShiftEditorComponent"/>.
    /// </summary>
    public partial class WorkingShiftEditorComponentControl : ApplicationComponentUserControl
    {
        private WorkingShiftEditorComponent _component;

        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkingShiftEditorComponentControl(WorkingShiftEditorComponent component)
            :base(component)
        {
            InitializeComponent();

            _component = component;

            _txtName.DataBindings.Add("Value", _component, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            _txtDescription.DataBindings.Add("Value", _component, "Description", true, DataSourceUpdateMode.OnPropertyChanged);

            _dtpstartTime.DataBindings.Add("Enabled", _component, "StartTime", true, DataSourceUpdateMode.OnPropertyChanged);
            _dtpEndTime.DataBindings.Add("Enabled", _component, "EndTime", true, DataSourceUpdateMode.OnPropertyChanged);
            
            _chkMonday.DataBindings.Add("Checked", _component, "WorkingOnMonday", true, DataSourceUpdateMode.OnPropertyChanged);
            _chkTuesday.DataBindings.Add("Checked", _component, "WorkingOnTuesday", true, DataSourceUpdateMode.OnPropertyChanged);
            _chkWednesday.DataBindings.Add("Checked", _component, "WorkingOnWednesday", true, DataSourceUpdateMode.OnPropertyChanged);
            _chkThursday.DataBindings.Add("Checked", _component, "WorkingOnThursday", true, DataSourceUpdateMode.OnPropertyChanged);
            _chkFriday.DataBindings.Add("Checked", _component, "WorkingOnFriday", true, DataSourceUpdateMode.OnPropertyChanged);
            _chkSaturday.DataBindings.Add("Checked", _component, "WorkingOnSaturday", true, DataSourceUpdateMode.OnPropertyChanged);
            _chkSunday.DataBindings.Add("Checked", _component, "WorkingOnSunday", true, DataSourceUpdateMode.OnPropertyChanged);

            //_chkSunday.DataBindings.Add("Value", _component, "ExactDate", true, DataSourceUpdateMode.OnPropertyChanged);

            _staffSelector.AvailableItemsTable = _component.AvailableStaffTable;
            _staffSelector.SelectedItemsTable = _component.SelectedStaffTable;
            _staffSelector.ItemAdded += OnItemsAddedOrRemoved;
            _staffSelector.ItemRemoved += OnItemsAddedOrRemoved;

            btnOk.DataBindings.Add("Enabled", _component, "AcceptEnabled", true, DataSourceUpdateMode.OnPropertyChanged);
            // TODO add .NET databindings to bindingSource
        }
        private void OnItemsAddedOrRemoved(object sender, EventArgs args)
        {
            _component.ItemsAddedOrRemoved();
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
