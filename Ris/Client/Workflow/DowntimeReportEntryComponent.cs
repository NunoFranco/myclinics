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

using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.ModalityWorkflow;
using ClearCanvas.Ris.Application.Common.ReportingWorkflow;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Desktop.Validation;

namespace ClearCanvas.Ris.Client.Workflow
{
    [MenuAction("apply", "folderexplorer-items-contextmenu/Complete Downtime Recovery...", "Apply")]
	[ButtonAction("apply", "folderexplorer-items-toolbar/Complete Downtime Recovery...", "Apply")]
	[IconSet("apply", IconScheme.Colour, "VerifyReportSmall.png", "VerifyReportMedium.png", "VerifyReportLarge.png")]
	[ActionPermission("apply", Application.Common.AuthorityTokens.Workflow.Downtime.RecoveryOperations)]
    [EnabledStateObserver("apply", "Enabled", "EnabledChanged")]
	[VisibleStateObserver("apply", "Visible", "VisibleChanged")]
	[ExtensionOf(typeof(PerformingWorkflowItemToolExtensionPoint))]
	public class DowntimeReportEntryTool : WorkflowItemTool<ModalityWorklistItem, IPerformingWorkflowItemToolContext>
    {
    	public DowntimeReportEntryTool()
			: base("CompleteDowntimeProcedure")
    	{
    	}

    	public override void Initialize()
		{
			base.Initialize();

    		DowntimeRecovery.InDowntimeRecoveryModeChanged += delegate { UpdateReportingWorkflowServiceRegistration(); };

			// init 
    		UpdateReportingWorkflowServiceRegistration();
		}

    	public bool Visible
    	{
			get { return DowntimeRecovery.InDowntimeRecoveryMode; }
    	}

		public event EventHandler VisibleChanged
		{
			add { }
			remove { }
		}

		public override bool Enabled
		{
			get
			{
				return DowntimeRecovery.InDowntimeRecoveryMode // bug #5616: don't check base enablement unless we are actually in downtime mode
					&& base.Enabled;
			}
		}
		
    	protected override bool Execute(ModalityWorklistItem item)
    	{
			if (item.ProcedureRef == null)
				return false;

			var exitCode = ApplicationComponent.LaunchAsDialog(
				this.Context.DesktopWindow,
				new DowntimeReportEntryComponent(item.ProcedureRef),
				"Complete Downtime Recovery");

			if (exitCode == ApplicationComponentExitCode.Accepted)
			{
				DocumentManager.InvalidateFolder(typeof(Folders.Performing.PerformedFolder));
				return true;
			}
    		return false;
		}

		private void UpdateReportingWorkflowServiceRegistration()
		{
			if (DowntimeRecovery.InDowntimeRecoveryMode)
			{
				// bug  #4866: in downtime mode register reporting service so we can get operation enablement
				this.Context.RegisterWorkflowService(typeof(IReportingWorkflowService));
			}
			else
			{
				// otherwise unregister reporting service, so we don't degrade performance for no reason
				this.Context.UnregisterWorkflowService(typeof(IReportingWorkflowService));
			}
		}
	}




	/// <summary>
	/// Extension point for views onto <see cref="DowntimeReportEntryComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class DowntimeReportEntryComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

	/// <summary>
	/// DowntimeReportEntryComponent class
	/// </summary>
	[AssociateView(typeof(DowntimeReportEntryComponentViewExtensionPoint))]
	public class DowntimeReportEntryComponent : ApplicationComponent
	{
		private readonly EntityRef _procedureRef;
		private bool _hasReport;
		private string _reportText;
		private StaffSummary _interpreter;
		private StaffSummary _transcriptionist;

		private ILookupHandler _interpreterLookupHandler;
		private ILookupHandler _transcriptionistLookupHandler;



		/// <summary>
		/// Constructor
		/// </summary>
		public DowntimeReportEntryComponent(EntityRef procedureRef)
		{
			_procedureRef = procedureRef;
		}

		public override void Start()
		{
			// radiologist staff lookup handler, using filters provided by application configuration
			var radFilters = DowntimeSettings.Default.ReportEntryRadiologistStaffTypeFilters;
			var radStaffTypes = string.IsNullOrEmpty(radFilters) ? new string[] { } :
				CollectionUtils.Map<string, string>(radFilters.Split(','), s => s.Trim()).ToArray();
            _interpreterLookupHandler = new StaffLookupHandler(this.Host.DesktopWindow, radStaffTypes, new string[] { });

			// transcriptionist staff lookup handler, using filters provided by application configuration
			var transFilters = DowntimeSettings.Default.ReportEntryTranscriptionistStaffTypeFilters;
			var transStaffTypes = string.IsNullOrEmpty(transFilters) ? new string[] { } :
				CollectionUtils.Map<string, string>(transFilters.Split(','), s => s.Trim()).ToArray();
            _transcriptionistLookupHandler = new StaffLookupHandler(this.Host.DesktopWindow, transStaffTypes, new string[] { });

			base.Start();
		}

		#region Presentation Model


		public bool HasReport
		{
			get { return _hasReport; }
			set
			{
				_hasReport = value;

				// only need to validate if submitting a report
				this.ShowValidation(_hasReport && this.HasValidationErrors);
			}
		}

		[ValidateNotNull]
		public string ReportText
		{
			get { return _reportText; }
			set { _reportText = value; }
		}

		public ILookupHandler InterpreterLookupHandler
		{
			get { return _interpreterLookupHandler; }
		}

		public ILookupHandler TranscriptionistLookupHandler
		{
			get { return _transcriptionistLookupHandler; }
		}

		[ValidateNotNull]
		public StaffSummary Interpreter
		{
			get { return _interpreter; }
			set { _interpreter = value; }
		}

		public StaffSummary Transcriptionist
		{
			get { return _transcriptionist; }
			set { _transcriptionist = value; }
		}

		public void Accept()
		{
			// only need to validate if submitting a report
			if(_hasReport && this.HasValidationErrors)
			{
				this.ShowValidation(true);
				return;
			}

			try
			{
				Platform.GetService<IReportingWorkflowService>(
					service =>
					{
						var reportData = new Dictionary<string, string>();
						if (_hasReport)
						{
							var content = new ReportContent(_reportText);
							reportData[ReportPartDetail.ReportContentKey] = content.ToJsml();
						}

						service.CompleteDowntimeProcedure(
							new CompleteDowntimeProcedureRequest(
								_procedureRef,
								_hasReport,
								reportData,
								_interpreter == null ? null : _interpreter.StaffRef,
								_transcriptionist == null ? null : _transcriptionist.StaffRef));
					});

				Exit(ApplicationComponentExitCode.Accepted);
			}
			catch(Exception e)
			{
				ExceptionHandler.Report(e, "", this.Host.DesktopWindow, () => Exit(ApplicationComponentExitCode.Error));
			}
		}

		public void Cancel()
		{
			Exit(ApplicationComponentExitCode.None);
		}

		#endregion
	}
}
