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

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Client
{
	/// <summary>
	/// Extension point for views onto <see cref="EmailAddressEditorComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class EmailAddressEditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

	/// <summary>
	/// EmailAddressEditorComponent class
	/// </summary>
	[AssociateView(typeof(EmailAddressEditorComponentViewExtensionPoint))]
	public class EmailAddressEditorComponent : ApplicationComponent
	{
		private readonly EmailAddressDetail _emailAddress;

		/// <summary>
		/// Constructor
		/// </summary>
		public EmailAddressEditorComponent(EmailAddressDetail emailAddress)
		{
			_emailAddress = emailAddress;
		}

		public override void Start()
		{
			this.Validation.Add(new ValidationRule("ValidUntil",
				delegate
				{
					// only need to validate the if both ValidFrom and ValidUntil are specified
					if (!_emailAddress.ValidRangeFrom.HasValue || !_emailAddress.ValidRangeUntil.HasValue)
						return new ValidationResult(true, "");

					var ok = DateTime.Compare(_emailAddress.ValidRangeUntil.Value, _emailAddress.ValidRangeFrom.Value) >= 0;
					return new ValidationResult(ok, SR.MessageValidUntilMustBeLaterOrEqualValidFrom);
				}));
			
			base.Start();
		}

		#region Presentation Model

		[ValidateNotNull]
		[ValidateRegex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", AllowNull = true)]
		public string Address
		{
			get { return _emailAddress.Address; }
			set
			{
				_emailAddress.Address = value;
				this.Modified = true;
			}
		}


		public DateTime? ValidFrom
		{
			get { return _emailAddress.ValidRangeFrom; }
			set
			{
				_emailAddress.ValidRangeFrom = value == null ? value : value.Value.Date;
				this.Modified = true;
			}
		}

		public DateTime? ValidUntil
		{
			get { return _emailAddress.ValidRangeUntil; }
			set
			{
				_emailAddress.ValidRangeUntil = value == null ? value : value.Value.Date;
				this.Modified = true;
			}
		}

		public void Accept()
		{
			if (this.HasValidationErrors)
			{
				this.ShowValidation(true);
			}
			else
			{
				this.ExitCode = ApplicationComponentExitCode.Accepted;
				Host.Exit();
			}
		}

		public void Cancel()
		{
			this.ExitCode = ApplicationComponentExitCode.None;
			Host.Exit();
		}

		public bool AcceptEnabled
		{
			get { return this.Modified; }
		}

		public event EventHandler AcceptEnabledChanged
		{
			add { this.ModifiedChanged += value; }
			remove { this.ModifiedChanged -= value; }
		}

		#endregion
	}
}