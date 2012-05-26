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

using System.Drawing;
using ClearCanvas.Common;
using System.Windows.Forms;
using System.Collections.Generic;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Client.View.WinForms
{
	[ExtensionOf(typeof(LoginDialogExtensionPoint))]
	public class LoginDialog : ILoginDialog
	{
		private readonly LoginForm _form;
		private LoginDialogMode _mode;

		public LoginDialog()
		{
			_form = new LoginForm();
		}

		#region ILoginDialog Members
        public List<FacilitySummary> Facilities { get; set; }
		public bool Show()
		{
			System.Windows.Forms.Application.EnableVisualStyles();

			// if location was not set manually, centre the dialog in the screen
			_form.StartPosition = _form.Location == Point.Empty ? FormStartPosition.CenterScreen : FormStartPosition.Manual;
            _form.Facilities = Facilities;
			return _form.ShowDialog() == DialogResult.OK;
		}

		public Point Location
		{
			get { return _form.Location; }
			set { _form.Location = value; }
		}

		public LoginDialogMode Mode
		{
			get { return _mode; }
			set
			{
				_mode = value;
				_form.SetMode(_mode);
			}
		}

		public string UserName
		{
			get { return _form.UserName; }
			set { _form.UserName = value; }
		}

		public string Password
		{
			get { return _form.Password; }
		}

		public string Facility
		{
			get { return _form.SelectedFacility; }
			set { _form.SelectedFacility = value; }
		}

		public string[] FacilityChoices
		{
			get { return _form.FacilityChoices; }
			set { _form.FacilityChoices = value; }
		}

		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			// nothing to do
		}

		#endregion
	}
}