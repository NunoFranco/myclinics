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
using System.Security.Permissions;
using System.ServiceModel;
using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.ProtocollingWorkflow;
using ClearCanvas.Ris.Application.Common.ReportingWorkflow;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Ris.Client.Workflow
{
	/// <summary>
	/// Extension point for views onto <see cref="ProtocollingComponent"/>
	/// </summary>
	[ExtensionPoint]
	public class ProtocollingComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

	/// <summary>
	/// ProtocollingComponent class
	/// </summary>
	[AssociateView(typeof(ProtocollingComponentViewExtensionPoint))]
	public class ProtocollingComponent : ApplicationComponent
	{
		#region Private Fields

		private readonly ProtocollingComponentWorklistItemManager _worklistItemManager;

		private EntityRef _protocolAssignmentStepRef;
		private EntityRef _assignedStaffRef;
		private List<OrderNoteDetail> _notes;
		private OrderDetail _orderDetail;

		private ChildComponentHost _bannerComponentHost;
		private ChildComponentHost _protocolEditorComponentHost;
		private ChildComponentHost _orderNotesComponentHost;
		private ChildComponentHost _rightHandComponentContainerHost;
		private TabComponentContainer _rightHandComponentContainer;

		private ProtocollingOrderDetailViewComponent _orderDetailViewComponent;
		private OrderAdditionalInfoComponent _additionalInfoComponent;
		private AttachedDocumentPreviewComponent _orderAttachmentsComponent;
		private PriorReportComponent _priorReportsComponent;

		private bool _acceptEnabled;
		private bool _submitForApprovalEnabled;
		private bool _rejectEnabled;
		private bool _saveEnabled;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		public ProtocollingComponent(ReportingWorklistItem worklistItem, IContinuousWorkflowComponentMode mode, string folderName, EntityRef worklistRef, string worklistClassName)
		{
			_worklistItemManager = new ProtocollingComponentWorklistItemManager(folderName, worklistRef, worklistClassName);
			_worklistItemManager.Initialize(worklistItem, mode);
			_worklistItemManager.WorklistItemChanged += OnWorklistItemChangedEvent;
		}

		#endregion

		#region ApplicationComponent overrides

		public override void Start()
		{
			StartProtocollingWorklistItem();

			this.Host.Title = ProtocolDocument.GetTitle(this.WorklistItem);

			_bannerComponentHost = new ChildComponentHost(this.Host, new BannerComponent(this.WorklistItem));
			_bannerComponentHost.StartComponent();

			_orderNotesComponentHost = new ChildComponentHost(this.Host, new OrderNoteSummaryComponent(OrderNoteCategory.Protocol, this.SaveEnabled));
			_orderNotesComponentHost.StartComponent();
			((OrderNoteSummaryComponent)_orderNotesComponentHost.Component).Notes = _notes;
			_orderNotesComponentHost.Component.ModifiedChanged += ((sender, args) =>
				this.Modified = this.Modified || _orderNotesComponentHost.Component.Modified);

			_protocolEditorComponentHost = new ChildComponentHost(this.Host, new ProtocolEditorComponent(this.WorklistItem));
			_protocolEditorComponentHost.StartComponent();
			((ProtocolEditorComponent)_protocolEditorComponentHost.Component).CanEdit = this.SaveEnabled;
			_protocolEditorComponentHost.Component.ModifiedChanged += ((sender, args) =>
				this.Modified = this.Modified || _protocolEditorComponentHost.Component.Modified);

			_rightHandComponentContainer = new TabComponentContainer();

			_orderDetailViewComponent = new ProtocollingOrderDetailViewComponent(this.WorklistItem.PatientRef, this.WorklistItem.OrderRef);
			_rightHandComponentContainer.Pages.Add(new TabPage(SR.TitleOrder, _orderDetailViewComponent));

			_orderAttachmentsComponent = new AttachedDocumentPreviewComponent(true, AttachedDocumentPreviewComponent.AttachmentMode.Order);
			_orderAttachmentsComponent.OrderRef = this.WorklistItem.OrderRef;
			_rightHandComponentContainer.Pages.Add(new TabPage(SR.TitleOrderAttachments, _orderAttachmentsComponent));
	
			_additionalInfoComponent = new OrderAdditionalInfoComponent(true);
			_additionalInfoComponent.OrderExtendedProperties = _orderDetail.ExtendedProperties;
			_additionalInfoComponent.HealthcareContext = this.WorklistItem;
			_rightHandComponentContainer.Pages.Add(new TabPage(SR.TitleAdditionalInfo, _additionalInfoComponent));

			_rightHandComponentContainer.Pages.Add(new TabPage(SR.TitlePriors, _priorReportsComponent = new PriorReportComponent(this.WorklistItem)));

			_rightHandComponentContainerHost = new ChildComponentHost(this.Host, _rightHandComponentContainer);
			_rightHandComponentContainerHost.StartComponent();

			SetInitialProtocollingTabPage();

			base.Start();
		}

		public override void Stop()
		{
			if (_bannerComponentHost != null)
			{
				_bannerComponentHost.StopComponent();
				_bannerComponentHost = null;
			}

			if (_orderNotesComponentHost != null)
			{
				_orderNotesComponentHost.StopComponent();
				_orderNotesComponentHost = null;
			}

			if (_protocolEditorComponentHost != null)
			{
				_protocolEditorComponentHost.StopComponent();
				_protocolEditorComponentHost = null;
			}

			if (_rightHandComponentContainerHost != null)
			{
				_rightHandComponentContainerHost.StopComponent();
				_rightHandComponentContainerHost = null;
			}

			base.Stop();
		}

		public override bool HasValidationErrors
		{
			get
			{
				return _protocolEditorComponentHost.Component.HasValidationErrors || base.HasValidationErrors;
			}
		}

		public override void ShowValidation(bool show)
		{
			if (_protocolEditorComponentHost != null)
			{
				_protocolEditorComponentHost.Component.ShowValidation(show);
			}
			base.ShowValidation(show);
		}

		public override bool PrepareExit()
		{
			var exit = base.PrepareExit();
			if (exit)
			{
				// same as cancel
				DoCancelCleanUp();
			}
			return exit;
		}

		#endregion

		public int BannerHeight
		{
			get { return BannerSettings.Default.BannerHeight; }
		}

		private ReportingWorklistItem WorklistItem
		{
			get { return _worklistItemManager.WorklistItem; }
		}

		#region Public members

		public string StatusText
		{
			get { return _worklistItemManager.StatusText; }
		}

		public bool ShowStatusText
		{
			get { return _worklistItemManager.StatusTextVisible; }
		}

		public string ProceduresText
		{
			get { return "Protocolled Procedure(s): " + ((ProtocolEditorComponent)_protocolEditorComponentHost.Component).ProceduresText; }
		}

		public bool ProtocolNextItem
		{
			get { return _worklistItemManager.ReportNextItem; }
			set { _worklistItemManager.ReportNextItem = value; }
		}

		public bool ProtocolNextItemEnabled
		{
			get { return _worklistItemManager.ReportNextItemEnabled; }
		}

		public ApplicationComponentHost BannerComponentHost
		{
			get { return _bannerComponentHost; }
		}

		public ApplicationComponentHost ProtocolEditorComponentHost
		{
			get { return _protocolEditorComponentHost; }
		}

		public ApplicationComponentHost OrderNotesComponentHost
		{
			get { return _orderNotesComponentHost; }
		}

		public ApplicationComponentHost RightHandComponentContainerHost
		{
			get { return _rightHandComponentContainerHost; }
		}

		#region Accept

		[PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.Accept)]
		public void Accept()
		{
			// don't allow accept if there are validation errors
			if (HasValidationErrors)
			{
				ShowValidation(true);
				return;
			}

			if (SupervisorRequired())
				return;

			try
			{
				Platform.GetService<IProtocollingWorkflowService>(service =>
					service.AcceptProtocol(new AcceptProtocolRequest(_protocolAssignmentStepRef, this.ProtocolDetail, _notes)));

				DocumentManager.InvalidateFolder(typeof(Folders.Reporting.CompletedProtocolFolder));

				_worklistItemManager.ProceedToNextWorklistItem(WorklistItemCompletedResult.Completed);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, this.Host.DesktopWindow);
			}
		}

		public bool AcceptVisible
		{
			get
			{
				return Thread.CurrentPrincipal.IsInRole(ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.Accept);
			}
		}

		public bool AcceptEnabled
		{
			get { return _acceptEnabled; }
		}

		#endregion

		#region Submit For Approval

		[PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.Create)]
		public void SubmitForApproval()
		{
			// don't allow accept if there are validation errors
			if (HasValidationErrors)
			{
				ShowValidation(true);
				return;
			}

			if (SupervisorRequired())
				return;

			try
			{
				Platform.GetService<IProtocollingWorkflowService>(service =>
					service.SubmitProtocolForApproval(new SubmitProtocolForApprovalRequest(_protocolAssignmentStepRef, this.ProtocolDetail, _notes)));

				DocumentManager.InvalidateFolder(typeof(Folders.Reporting.AwaitingApprovalProtocolFolder));

				_worklistItemManager.ProceedToNextWorklistItem(WorklistItemCompletedResult.Completed);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, this.Host.DesktopWindow);
			}
		}

		public bool SubmitForApprovalEnabled
		{
			get { return _submitForApprovalEnabled; }
		}

		public bool SubmitForApprovalVisible
		{
			get { return Thread.CurrentPrincipal.IsInRole(ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.SubmitForReview); }
		}

		#endregion

		#region Reject

		[PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.Create)]
		public void Reject()
		{
			if (SupervisorRequired())
				return;

			try
			{
				EnumValueInfo reason;
				string additionalComments;

				var result = GetSuspendReason("Reject Reason", out reason, out additionalComments);

				if (!result || reason == null)
					return;

				Platform.GetService<IProtocollingWorkflowService>(service =>
					service.RejectProtocol(new RejectProtocolRequest(
						_protocolAssignmentStepRef,
						this.ProtocolDetail,
						_notes,
						reason,
						CreateAdditionalCommentsNote(additionalComments))));

				DocumentManager.InvalidateFolder(typeof(Folders.Reporting.RejectedProtocolFolder));

				_worklistItemManager.ProceedToNextWorklistItem(WorklistItemCompletedResult.Completed);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, this.Host.DesktopWindow);
			}
		}

		public bool RejectEnabled
		{
			get { return _rejectEnabled; }
		}

		#endregion

		#region Save

		[PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.Create)]
		public void Save()
		{
			Save(false);
		}

		[PrincipalPermission(SecurityAction.Demand, Role = ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.Create)]
		public void Save(bool overrideDoNotPerformNextItem)
		{
			try
			{
				Platform.GetService<IProtocollingWorkflowService>(service =>
					service.SaveProtocol(new SaveProtocolRequest(_protocolAssignmentStepRef, this.ProtocolDetail, _notes)));

				DocumentManager.InvalidateFolder(typeof(Folders.Reporting.ToBeProtocolledFolder));
				DocumentManager.InvalidateFolder(typeof(Folders.Reporting.DraftProtocolFolder));

				_worklistItemManager.ProceedToNextWorklistItem(WorklistItemCompletedResult.Completed, overrideDoNotPerformNextItem);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, this.Host.DesktopWindow);
			}
		}

		public bool SaveEnabled
		{
			get { return _saveEnabled; }
		}

		#endregion

		#region Skip

		public void Skip()
		{
			try
			{
				if (_worklistItemManager.ShouldUnclaim)
				{
					Platform.GetService<IProtocollingWorkflowService>(service =>
						service.DiscardProtocol(new DiscardProtocolRequest(_protocolAssignmentStepRef, _assignedStaffRef)));
				}

				_worklistItemManager.ProceedToNextWorklistItem(WorklistItemCompletedResult.Skipped);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, this.Host.DesktopWindow);
			}
		}

		public bool SkipEnabled
		{
			get { return _worklistItemManager.CanSkipItem; }
		}

		#endregion

		#region Cancel

		public void Cancel()
		{
			try
			{
				DoCancelCleanUp();

				this.Exit(ApplicationComponentExitCode.None);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, this.Host.DesktopWindow);
			}
		}

		#endregion

		#endregion

		#region Private methods

		private void DoCancelCleanUp()
		{
			if (_worklistItemManager.ShouldUnclaim)
			{
				Platform.GetService<IProtocollingWorkflowService>(service =>
					service.DiscardProtocol(new DiscardProtocolRequest(_protocolAssignmentStepRef, _assignedStaffRef)));
			}

			// To be protocolled folder will be invalid if it is the source of the worklist item;  the original item will have been
			// discontinued with a new scheduled one replacing it
			DocumentManager.InvalidateFolder(typeof(Folders.Reporting.ToBeProtocolledFolder));

			SaveInitialProtocollingTabPage();
		}

		private void OnWorklistItemChangedEvent(object sender, EventArgs args)
		{
			this.Modified = false;

			if (this.WorklistItem != null)
			{
				try
				{
					StartProtocollingWorklistItem();
					UpdateChildComponents();
				}
				catch (FaultException<ConcurrentModificationException>)
				{
					this._worklistItemManager.ProceedToNextWorklistItem(WorklistItemCompletedResult.Invalid);
				}
			}
			else
			{
				this.Exit(ApplicationComponentExitCode.Accepted);
			}
		}

		private void StartProtocollingWorklistItem()
		{
			// begin with validation turned off
			ShowValidation(false);

			Platform.GetService<IProtocollingWorkflowService>(service =>
			{
				List<ReportingWorklistItem> linkedProtocols;
				List<ReportingWorklistItem> candidateProtocols;
				PromptForLinkedInterpretations(this.WorklistItem, out linkedProtocols, out candidateProtocols);

				var linkedProtocolRefs = linkedProtocols.ConvertAll(x => x.ProcedureStepRef);

				var shouldClaim = _worklistItemManager.ShouldUnclaim;

				var response = service.StartProtocol(
					new StartProtocolRequest(this.WorklistItem.ProcedureStepRef, linkedProtocolRefs, shouldClaim, OrderNoteCategory.Protocol.Key));
				_protocolAssignmentStepRef = response.ProtocolAssignmentStepRef;
				_assignedStaffRef = response.AssignedStaffRef;

				_notes = response.ProtocolNotes;
				_orderDetail = response.Order;

				if (response.ProtocolClaimed == shouldClaim)
				{
					var enablementResponse = service.GetOperationEnablement(new GetOperationEnablementRequest(this.WorklistItem));

					_acceptEnabled = enablementResponse.OperationEnablementDictionary["AcceptProtocol"];
					_rejectEnabled = enablementResponse.OperationEnablementDictionary["RejectProtocol"];
					_submitForApprovalEnabled = enablementResponse.OperationEnablementDictionary["SubmitProtocolForApproval"];
					_saveEnabled = enablementResponse.OperationEnablementDictionary["SaveProtocol"];
				}
				else
				{
					// If start interpretation failed and there were candidates for linking, let the user know and move to next item.
					if (candidateProtocols.Count > 0 && this.IsStarted)
					{
						this.Host.ShowMessageBox(SR.ExceptionCannotStartLinkedProcedures, MessageBoxActions.Ok);
						_worklistItemManager.IgnoreWorklistItems(candidateProtocols);
					}
					throw new Exception();
				}
			});
		}

		private void PromptForLinkedInterpretations(ReportingWorklistItem item, out List<ReportingWorklistItem> linkedItems, out List<ReportingWorklistItem> candidateItems)
		{
			linkedItems = new List<ReportingWorklistItem>();
			candidateItems = new List<ReportingWorklistItem>();

			// query server for link candidates
			var anonCandidates = new List<ReportingWorklistItem>();  // cannot use out param in anonymous delegate.
			Platform.GetService<IProtocollingWorkflowService>(service =>
				{
					var linkableProtocolsResponse = service.GetLinkableProtocols(new GetLinkableProtocolsRequest(item.ProcedureStepRef));
					anonCandidates = linkableProtocolsResponse.ProtocolItems;
				});
			candidateItems.AddRange(anonCandidates);

			// if there are no candidates just return
			if (candidateItems.Count <= 0)
				return;

			// otherwise, prompt the user to select
			ResetChildComponents();

			var linkProceduresComponent = new LinkProceduresComponent(
				item, candidateItems, SR.TextLinkProtocolInstructions, SR.TextLinkProtocolHeading);
			if (LaunchAsDialog(this.Host.DesktopWindow, linkProceduresComponent, SR.TitleLinkProcedures) ==
				ApplicationComponentExitCode.Accepted)
			{
				linkedItems.AddRange(linkProceduresComponent.SelectedItems);
			}
		}

		private void ResetChildComponents()
		{
			// if no child components have been initialized, just return
			if (_bannerComponentHost == null)
				return;

			_acceptEnabled = false;
			_rejectEnabled = false;
			_submitForApprovalEnabled = false;
			_saveEnabled = false;

			UpdateChildComponents();
		}

		private void UpdateChildComponents()
		{
			((BannerComponent)_bannerComponentHost.Component).HealthcareContext = this.WorklistItem;
			((ProtocolEditorComponent)_protocolEditorComponentHost.Component).WorklistItem = this.WorklistItem;
			((ProtocolEditorComponent)_protocolEditorComponentHost.Component).CanEdit = this.SaveEnabled;
			_priorReportsComponent.WorklistItem = this.WorklistItem;
			_orderDetailViewComponent.Context = new OrderDetailViewComponent.OrderContext(this.WorklistItem.OrderRef);
			_orderAttachmentsComponent.OrderRef = this.WorklistItem.OrderRef;

			// Load notes for new current item.
			((OrderNoteSummaryComponent)_orderNotesComponentHost.Component).Notes = _notes;

			// Update title
			this.Host.Title = ProtocolDocument.GetTitle(this.WorklistItem);

			NotifyPropertyChanged("StatusText");
			NotifyPropertyChanged("ProceduresText");
		}

		private bool GetSuspendReason(string title, out EnumValueInfo reason, out string additionalComments)
		{
            var protocolReasonComponent = new ProtocolReasonComponent(LoginSession.Current.WorkingFacility);

			var exitCode = LaunchAsDialog(this.Host.DesktopWindow, protocolReasonComponent, title);

			reason = protocolReasonComponent.Reason;
			additionalComments = protocolReasonComponent.OtherReason;

			return exitCode == ApplicationComponentExitCode.Accepted;
		}

		private static OrderNoteDetail CreateAdditionalCommentsNote(string additionalComments)
		{
			return !string.IsNullOrEmpty(additionalComments) 
				? new OrderNoteDetail(OrderNoteCategory.Protocol.Key, additionalComments, null, false, null, null) 
				: null;
		}

		private ProtocolDetail ProtocolDetail
		{
			get { return ((ProtocolEditorComponent)_protocolEditorComponentHost.Component).ProtocolDetail; }
		}

		private bool SupervisorRequired()
		{
			if (Thread.CurrentPrincipal.IsInRole(ClearCanvas.Ris.Application.Common.AuthorityTokens.Workflow.Protocol.OmitSupervisor))
				return false;

			if (this.ProtocolDetail.Supervisor != null)
				return false;

			this.Host.DesktopWindow.ShowMessageBox(SR.MessageChooseRadiologist, MessageBoxActions.Ok);

			return true;
		}

		private void SetInitialProtocollingTabPage()
		{
			var selectedTabName = ProtocollingSettings.Default.InitiallySelectedTabPageName;
			if (string.IsNullOrEmpty(selectedTabName))
				return;

			var requestedTabPage = CollectionUtils.SelectFirst(
				_rightHandComponentContainer.Pages,
				tabPage => tabPage.Name.Equals(selectedTabName, StringComparison.InvariantCultureIgnoreCase));

			if (requestedTabPage != null)
				_rightHandComponentContainer.CurrentPage = requestedTabPage;
		}

		private void SaveInitialProtocollingTabPage()
		{
			ProtocollingSettings.Default.InitiallySelectedTabPageName = _rightHandComponentContainer.CurrentPage.Name;
			ProtocollingSettings.Default.Save();
		}

		#endregion
	}
}
