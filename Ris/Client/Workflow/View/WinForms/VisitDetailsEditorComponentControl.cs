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

namespace ClearCanvas.Ris.Client.Workflow.View.WinForms
{
	/// <summary>
	/// Provides a Windows Forms user-interface for <see cref="VisitDetailsEditorComponent"/>
	/// </summary>
	public partial class VisitDetailsEditorComponentControl : ApplicationComponentUserControl
	{
		private readonly VisitDetailsEditorComponent _component;

		/// <summary>
		/// Constructor
		/// </summary>
		public VisitDetailsEditorComponentControl(VisitDetailsEditorComponent component)
			:base(component)
		{
			InitializeComponent();

			_component = component;

			_visitNumber.DataBindings.Add("Value", _component, "VisitNumber", true, DataSourceUpdateMode.OnPropertyChanged);
			_visitNumberAssigningAuthority.DataSource = _component.VisitNumberAssigningAuthorityChoices;
			_visitNumberAssigningAuthority.DataBindings.Add("Value", _component, "VisitNumberAssigningAuthority", true, DataSourceUpdateMode.OnPropertyChanged);

			_admitDateTime.DataBindings.Add("Value", _component, "AdmitDateTime", true, DataSourceUpdateMode.OnPropertyChanged);
			_dischargeDateTime.DataBindings.Add("Value", _component, "DischargeDateTime", true, DataSourceUpdateMode.OnPropertyChanged);
			_dischargeDisposition.DataBindings.Add("Value", _component, "DischargeDisposition", true, DataSourceUpdateMode.OnPropertyChanged);

			_vip.DataBindings.Add("Checked", _component, "Vip", true, DataSourceUpdateMode.OnPropertyChanged);
			_preadmitNumber.DataBindings.Add("Value", _component, "PreAdmitNumber", true, DataSourceUpdateMode.OnPropertyChanged);

			_patientClass.DataSource = _component.PatientClassChoices;
			_patientClass.DataBindings.Add("Value", _component, "PatientClass", true, DataSourceUpdateMode.OnPropertyChanged);

			_patientType.DataSource = _component.PatientTypeChoices;
			_patientType.DataBindings.Add("Value", _component, "PatientType", true, DataSourceUpdateMode.OnPropertyChanged);

			_admissionType.DataSource = _component.AdmissionTypeChoices;
			_admissionType.DataBindings.Add("Value", _component, "AdmissionType", true, DataSourceUpdateMode.OnPropertyChanged);

			_visitStatus.DataSource = _component.VisitStatusChoices;
			_visitStatus.DataBindings.Add("Value", _component, "VisitStatus", true, DataSourceUpdateMode.OnPropertyChanged);

			_facility.DataSource = _component.FacilityChoices;
			_facility.DataBindings.Add("Value", _component, "Facility", true, DataSourceUpdateMode.OnPropertyChanged);
			_facility.Format += delegate(object sender, ListControlConvertEventArgs e)
								{
									e.Value = _component.FormatFacility(e.ListItem);
								};

			_currentLocation.DataSource = _component.CurrentLocationChoices;
			_currentLocation.DataBindings.Add("Value", _component, "CurrentLocation", true, DataSourceUpdateMode.OnPropertyChanged);
			_currentLocation.Format += delegate(object sender, ListControlConvertEventArgs e)
								{
									e.Value = _component.FormatCurrentLocation(e.ListItem);
								};

			_ambulatoryStatus.DataSource = _component.AmbulatoryStatusChoices;
			_ambulatoryStatus.DataBindings.Add("Value", _component, "AmbulatoryStatus", true, DataSourceUpdateMode.OnPropertyChanged);
		}
	}
}
