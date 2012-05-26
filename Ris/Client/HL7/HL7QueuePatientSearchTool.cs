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
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Ris.Application.HL7.Common;
using ClearCanvas.Ris.Application.HL7.Common.Admin;

namespace ClearCanvas.Ris.Client.HL7
{
	[MenuAction("view2", "hl7queue-contextmenu/View Details", "View")]
	[EnabledStateObserver("view2", "Enabled", "EnabledChanged")]
	[Tooltip("view2", "Open patient biography")]
	[IconSet("view2", IconScheme.Colour, "PatientDetailsToolSmall.png", "PatientDetailsToolSmall.png", "PatientDetailsToolSmall.png")]
	[ActionPermission("view2", ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.PatientBiography.View)]
	[ExtensionOf(typeof(HL7QueueToolExtensionPoint))]
	public class HL7QueuePatientSearchTool : Tool<IHL7QueueToolContext>
	{
		private bool _enabled;
		private event EventHandler _enabledChanged;

		public override void Initialize()
		{
			base.Initialize();
			this.Context.DefaultAction = View;
			this.Context.SelectedHL7QueueItemChanged += delegate { this.Enabled = (this.Context.SelectedHL7QueueItem != null); };
		}

		public bool Enabled
		{
			get { return _enabled; }
			set
			{
				if (_enabled == value)
					return;

				_enabled = value;
				EventsHelper.Fire(_enabledChanged, this, EventArgs.Empty);
			}
		}

		public event EventHandler EnabledChanged
		{
			add { _enabledChanged += value; }
			remove { _enabledChanged -= value; }
		}

		public void View()
		{
			OpenPatient(this.Context.SelectedHL7QueueItem, this.Context.DesktopWindow);
		}

		protected void OpenPatient(HL7QueueItemDetail selectedQueueItem, IDesktopWindow window)
		{
			try
			{
				Platform.GetService(
					delegate(IHL7QueueService service)
					{
						var request = new GetReferencedPatientRequest(selectedQueueItem.QueueItemRef);
						var response = service.GetReferencedPatient(request);

						var document = DocumentManager.Get<PatientBiographyDocument>(response.PatientProfileRef);
						if (document == null)
						{
							document = new PatientBiographyDocument(response.PatientRef, response.PatientProfileRef, window);
							document.Open();
						}
						else
						{
							document.Open();
						}
					});
			}
			catch(Exception e)
			{
				ExceptionHandler.Report(e, Context.DesktopWindow);
			}
		}
	}
}