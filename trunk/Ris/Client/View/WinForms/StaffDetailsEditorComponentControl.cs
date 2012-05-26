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

using System.Windows.Forms;
using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.View.WinForms
{
	/// <summary>
	/// Provides a Windows Forms user-interface for <see cref="StaffDetailsEditorComponent"/>
	/// </summary>
	public partial class StaffDetailsEditorComponentControl : ApplicationComponentUserControl
	{
		private readonly StaffDetailsEditorComponent _component;

		/// <summary>
		/// Constructor
		/// </summary>
		public StaffDetailsEditorComponentControl(StaffDetailsEditorComponent component)
			: base(component)
		{
			InitializeComponent();
			_component = component;

			_userLookup.LookupHandler = _component.UserLookupHandler;
			_userLookup.DataBindings.Add("Value", _component, "SelectedUser", true, DataSourceUpdateMode.OnPropertyChanged);

			_familyName.DataBindings.Add("Value", _component, "FamilyName", true, DataSourceUpdateMode.OnPropertyChanged);
			_givenName.DataBindings.Add("Value", _component, "GivenName", true, DataSourceUpdateMode.OnPropertyChanged);
			_middleName.DataBindings.Add("Value", _component, "MiddleName", true, DataSourceUpdateMode.OnPropertyChanged);

			_sex.DataSource = _component.SexChoices;
			_sex.DataBindings.Add("Value", _component, "Sex", true, DataSourceUpdateMode.OnPropertyChanged);

			_staffId.DataBindings.Add("Value", _component, "StaffId", true, DataSourceUpdateMode.OnPropertyChanged);

			_staffType.DataSource = _component.StaffTypeChoices;
			_staffType.DataBindings.Add("Value", _component, "StaffType", true, DataSourceUpdateMode.OnPropertyChanged);
            _staffType.Format += delegate(object source, ListControlConvertEventArgs e) { e.Value = _component.FormatStaffChoice (e.ListItem); };
			_title.DataBindings.Add("Value", _component, "Title", true, DataSourceUpdateMode.OnPropertyChanged);

			_licenseNumber.DataBindings.Add("Value", _component, "LicenseNumber", true, DataSourceUpdateMode.OnPropertyChanged);
			_billingNumber.DataBindings.Add("Value", _component, "BillingNumber", true, DataSourceUpdateMode.OnPropertyChanged);

			SetReadOnlyMode(_component.ReadOnly);
		}

		private void SetReadOnlyMode(bool readOnly)
		{
			_familyName.ReadOnly = readOnly;
			_givenName.ReadOnly = readOnly;
			_middleName.ReadOnly = readOnly;
			_staffId.ReadOnly = readOnly;
			_title.ReadOnly = readOnly;
			_licenseNumber.ReadOnly = readOnly;
			_billingNumber.ReadOnly = readOnly;

			_userLookup.Enabled = !readOnly && _component.IsUserAdmin;
			_sex.Enabled = !readOnly;
			_staffType.Enabled = !readOnly;
		}
	}
}