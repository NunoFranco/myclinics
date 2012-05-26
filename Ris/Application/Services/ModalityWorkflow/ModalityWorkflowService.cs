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

using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Healthcare.Workflow.Modality;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.ModalityWorkflow;
using ClearCanvas.Workflow;
using Iesi.Collections.Generic;
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services.ModalityWorkflow
{
	[ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
	[ServiceImplementsContract(typeof(IModalityWorkflowService))]
	public class ModalityWorkflowService : WorkflowServiceBase, IModalityWorkflowService
	{
		#region IModalityWorkflowService members

		/// <summary>
		/// SearchWorklists for worklist items based on specified criteria.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[ReadOperation]
		public TextQueryResponse<ModalityWorklistItem> SearchWorklists(WorklistItemTextQueryRequest request)
		{
			var assembler = new ModalityWorkflowAssembler();
			var broker = this.PersistenceContext.GetBroker<IModalityWorklistItemBroker>();
			return SearchHelper(request, broker, item => assembler.CreateWorklistItemSummary(item, this.PersistenceContext));
		}

		/// <summary>
		/// Query the specified worklist.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[ReadOperation]
		public QueryWorklistResponse<ModalityWorklistItem> QueryWorklist(QueryWorklistRequest request)
		{
			var assembler = new ModalityWorkflowAssembler();
			return QueryWorklistHelper<WorklistItem, ModalityWorklistItem>(
				request,
				item => assembler.CreateWorklistItemSummary(item, this.PersistenceContext));
		}

		/// <summary>
		/// Returns a summary of the procedure plan for a specified order.
		/// </summary>
		/// <param name="request"><see cref="GetProcedurePlanRequest"/></param>
		/// <returns><see cref="GetProcedurePlanResponse"/></returns>
		[ReadOperation]
		public GetProcedurePlanResponse GetProcedurePlan(GetProcedurePlanRequest request)
		{
			var order = this.PersistenceContext.Load<Order>(request.OrderRef);
			var assembler = new ProcedurePlanAssembler();
			return new GetProcedurePlanResponse(assembler.CreateProcedurePlanSummary(order, this.PersistenceContext));
		}

		/// <summary>
		/// Returns a list of all modality performed procedure steps for a particular order.
		/// </summary>
		/// <param name="request"><see cref="ListPerformedProcedureStepsRequest"/></param>
		/// <returns><see cref="ListPerformedProcedureStepsResponse"/></returns>
		[ReadOperation]
		public ListPerformedProcedureStepsResponse ListPerformedProcedureSteps(ListPerformedProcedureStepsRequest request)
		{
			var order = this.PersistenceContext.Load<Order>(request.OrderRef);

			var assembler = new ModalityPerformedProcedureStepAssembler();

			ISet<PerformedStep> mppsSet = new HashedSet<PerformedStep>();
			foreach (var procedure in order.Procedures)
			{
				foreach (var mps in procedure.ModalityProcedureSteps)
				{
					mppsSet.AddAll(mps.PerformedSteps);
				}
			}

			return new ListPerformedProcedureStepsResponse(
				CollectionUtils.Map<ModalityPerformedProcedureStep, ModalityPerformedProcedureStepDetail>(
					mppsSet,
					mpps => assembler.CreateModalityPerformedProcedureStepDetail(mpps, order.Clinic , this.PersistenceContext)));
		}


		/// <summary>
		/// Starts a specified set of modality procedure steps with a single modality performed procedure step.
		/// </summary>
		/// <param name="request"><see cref="StartModalityProcedureStepsRequest"/></param>
		/// <returns><see cref="StartModalityProcedureStepsResponse"/></returns>
		[UpdateOperation]
		public StartModalityProcedureStepsResponse StartModalityProcedureSteps(StartModalityProcedureStepsRequest request)
		{
			Platform.CheckForNullReference(request, "request");
			Platform.CheckMemberIsSet(request.ModalityProcedureSteps, "ModalityProcedureSteps");

			// load the set of mps
			var modalitySteps = CollectionUtils.Map<EntityRef, ModalityProcedureStep>(
				request.ModalityProcedureSteps,
				mpsRef => this.PersistenceContext.Load<ModalityProcedureStep>(mpsRef));

			var hasProcedureNotCheckedIn = CollectionUtils.Contains(
				modalitySteps,
				mps => mps.Procedure.ProcedureCheckIn.IsPreCheckIn);

			if (hasProcedureNotCheckedIn)
				throw new RequestValidationException(SR.ExceptionProcedureNotCheckedIn);

			var op = new StartModalityProcedureStepsOperation();
			var mpps = op.Execute(modalitySteps, request.StartTime, this.CurrentUserStaff, new PersistentWorkflow(PersistenceContext));

			this.PersistenceContext.SynchState();

			var procedurePlanAssembler = new ProcedurePlanAssembler();
			var mppsAssembler = new ModalityPerformedProcedureStepAssembler();
			return new StartModalityProcedureStepsResponse(
				procedurePlanAssembler.CreateProcedurePlanSummary(modalitySteps[0].Procedure.Order, this.PersistenceContext),
                mppsAssembler.CreateModalityPerformedProcedureStepDetail(mpps, modalitySteps[0].Procedure.Order.Clinic , this.PersistenceContext));
		}

		/// <summary>
		/// Discontinues a set of specified modality procedure steps.
		/// </summary>
		/// <param name="request"><see cref="DiscontinueModalityProcedureStepsResponse"/></param>
		/// <returns><see cref="DiscontinueModalityProcedureStepsRequest"/></returns>
		[UpdateOperation]
		public DiscontinueModalityProcedureStepsResponse DiscontinueModalityProcedureSteps(DiscontinueModalityProcedureStepsRequest request)
		{
			Platform.CheckForNullReference(request, "request");
			Platform.CheckMemberIsSet(request.ModalityProcedureSteps, "ModalityProcedureSteps");

			// load the set of mps
			var modalitySteps = CollectionUtils.Map<EntityRef, ModalityProcedureStep>(
				request.ModalityProcedureSteps,
				mpsRef => this.PersistenceContext.Load<ModalityProcedureStep>(mpsRef));

			foreach (var step in modalitySteps)
			{
				var op = new DiscontinueModalityProcedureStepOperation();
				op.Execute(step, request.DiscontinuedTime, new PersistentWorkflow(this.PersistenceContext));
			}

			this.PersistenceContext.SynchState();

			var assembler = new ProcedurePlanAssembler();
			return new DiscontinueModalityProcedureStepsResponse(
				assembler.CreateProcedurePlanSummary(modalitySteps[0].Procedure.Order, this.PersistenceContext));
		}

		/// <summary>
		/// Completes a specified modality performed procedure step.
		/// </summary>
		/// <param name="request"><see cref="CompleteModalityPerformedProcedureStepRequest"/></param>
		/// <returns><see cref="CompleteModalityPerformedProcedureStepResponse"/></returns>
		[UpdateOperation]
		public CompleteModalityPerformedProcedureStepResponse CompleteModalityPerformedProcedureStep(CompleteModalityPerformedProcedureStepRequest request)
		{
			var mpps = this.PersistenceContext.Load<ModalityPerformedProcedureStep>(request.Mpps.ModalityPerformendProcedureStepRef);

			// copy extended properties (should this be in an assembler?)
			foreach (var pair in request.Mpps.ExtendedProperties)
			{
				mpps.ExtendedProperties[pair.Key] = pair.Value;
			}

			var dicomSeriesAssembler = new DicomSeriesAssembler();
			dicomSeriesAssembler.SynchronizeDicomSeries(mpps, request.Mpps.DicomSeries, this.PersistenceContext);

			var op = new CompleteModalityPerformedProcedureStepOperation();
			op.Execute(mpps, request.CompletedTime, new PersistentWorkflow(PersistenceContext));

			this.PersistenceContext.SynchState();

			// Drill back to order so we can refresh procedure plan
			var onePs = CollectionUtils.FirstElement(mpps.Activities).As<ProcedureStep>();

			var planAssembler = new ProcedurePlanAssembler();
			var stepAssembler = new ModalityPerformedProcedureStepAssembler();
			return new CompleteModalityPerformedProcedureStepResponse(
				planAssembler.CreateProcedurePlanSummary(onePs.Procedure.Order, this.PersistenceContext),
				stepAssembler.CreateModalityPerformedProcedureStepDetail(mpps,onePs.Procedure.Order.Clinic , this.PersistenceContext));
		}

		/// <summary>
		/// Discontinues a specified modality performed procedure step.
		/// </summary>
		/// <param name="request"><see cref="DiscontinueModalityPerformedProcedureStepRequest"/></param>
		/// <returns><see cref="DiscontinueModalityPerformedProcedureStepResponse"/></returns>
		[UpdateOperation]
		public DiscontinueModalityPerformedProcedureStepResponse DiscontinueModalityPerformedProcedureStep(DiscontinueModalityPerformedProcedureStepRequest request)
		{
			var mpps = this.PersistenceContext.Load<ModalityPerformedProcedureStep>(request.Mpps.ModalityPerformendProcedureStepRef);

			CopyProperties(mpps.ExtendedProperties, request.Mpps.ExtendedProperties);

			var dicomSeriesAssembler = new DicomSeriesAssembler();
			dicomSeriesAssembler.SynchronizeDicomSeries(mpps, request.Mpps.DicomSeries, this.PersistenceContext);

			var op = new DiscontinueModalityPerformedProcedureStepOperation();
			op.Execute(mpps, request.DiscontinuedTime, new PersistentWorkflow(PersistenceContext));

			this.PersistenceContext.SynchState();

			// Drill back to order so we can refresh procedure plan
			var order = CollectionUtils.FirstElement(mpps.Activities).As<ProcedureStep>().Procedure.Order;

			var planAssembler = new ProcedurePlanAssembler();
			var stepAssembler = new ModalityPerformedProcedureStepAssembler();
			return new DiscontinueModalityPerformedProcedureStepResponse(
				planAssembler.CreateProcedurePlanSummary(order, this.PersistenceContext),
				stepAssembler.CreateModalityPerformedProcedureStepDetail(mpps, order.Clinic , this.PersistenceContext));
		}

		[ReadOperation]
		public LoadOrderDocumentationDataResponse LoadOrderDocumentationData(LoadOrderDocumentationDataRequest request)
		{
			Platform.CheckForNullReference(request, "request");
			Platform.CheckMemberIsSet(request.OrderRef, "OrderRef");

			var order = this.PersistenceContext.Load<Order>(request.OrderRef);

			var noteAssembler = new OrderNoteAssembler();

			return new LoadOrderDocumentationDataResponse
			{
				OrderRef = order.GetRef(),
				OrderExtendedProperties = new Dictionary<string, string>(order.ExtendedProperties),
				OrderNotes = CollectionUtils.Map<OrderNote, OrderNoteDetail>(
					OrderNote.GetNotesForOrder(order),
					note => noteAssembler.CreateOrderNoteDetail(note, PersistenceContext)),
				AssignedInterpreter = GetUniqueAssignedInterpreter(order)
			};
		}

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Documentation.Create)]
		public SaveOrderDocumentationDataResponse SaveOrderDocumentationData(SaveOrderDocumentationDataRequest request)
		{
			var order = this.PersistenceContext.Load<Order>(request.OrderRef);

			CopyProperties(order.ExtendedProperties, request.OrderExtendedProperties);

			var dicomSeriesAssembler = new DicomSeriesAssembler();
			foreach (var detail in request.ModalityPerformedProcedureSteps)
			{
				var mpps = this.PersistenceContext.Load<ModalityPerformedProcedureStep>(detail.ModalityPerformendProcedureStepRef);
				CopyProperties(mpps.ExtendedProperties, detail.ExtendedProperties);
				dicomSeriesAssembler.SynchronizeDicomSeries(mpps, detail.DicomSeries, this.PersistenceContext);
			}

			// add new order notes
			var noteAssembler = new OrderNoteAssembler();
			noteAssembler.SynchronizeOrderNotes(order, request.OrderNotes, CurrentUserStaff, this.PersistenceContext);

			// assign all procedures for this order to the specified interpreter (or unassign them, if null)
			var interpreter = request.AssignedInterpreter == null
				? null
				: this.PersistenceContext.Load<Staff>(request.AssignedInterpreter.StaffRef, EntityLoadFlags.Proxy);
			foreach (var procedure in order.Procedures)
			{
				if (procedure.IsPerformed)
				{
					var interpretationStep = GetPendingInterpretationStep(procedure);
					if (interpretationStep != null)
					{
						interpretationStep.Assign(interpreter);
					}
				}
			}

			this.PersistenceContext.SynchState();

			var planAssembler = new ProcedurePlanAssembler();
			return new SaveOrderDocumentationDataResponse(planAssembler.CreateProcedurePlanSummary(order, this.PersistenceContext));
		}

		[ReadOperation]
		public CanCompleteOrderDocumentationResponse CanCompleteOrderDocumentation(CanCompleteOrderDocumentationRequest request)
		{
			if (!Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Workflow.Documentation.Accept))
				return new CanCompleteOrderDocumentationResponse(false, false);

			var order = this.PersistenceContext.Load<Order>(request.OrderRef);

			// order documentation can be completed if all modality steps have been terminated
			var allModalityStepsTerminated = CollectionUtils.TrueForAll(
				order.Procedures,
				procedure => CollectionUtils.TrueForAll(procedure.ModalityProcedureSteps, mps => mps.IsTerminated));

			// order documentation is already completed if all procedures have a completed documentation step
			var alreadyCompleted = CollectionUtils.TrueForAll(
				order.Procedures,
				procedure => procedure.DocumentationProcedureStep != null && procedure.DocumentationProcedureStep.IsTerminated);

			return new CanCompleteOrderDocumentationResponse(
				allModalityStepsTerminated && alreadyCompleted == false,
				alreadyCompleted);
		}

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Documentation.Accept)]
		public CompleteOrderDocumentationResponse CompleteOrderDocumentation(CompleteOrderDocumentationRequest request)
		{
			var order = this.PersistenceContext.Load<Order>(request.OrderRef);

			var interpretationSteps = new List<InterpretationStep>();
			foreach (var procedure in order.Procedures)
			{
				if (procedure.DocumentationProcedureStep != null && !procedure.DocumentationProcedureStep.IsTerminated)
				{
					procedure.DocumentationProcedureStep.Complete();
				}

				// schedule the interpretation step if the procedure was performed
				// Note: this logic is probably UHN-specific... ideally this aspect of the workflow should be configurable,
				// because it may be desirable to scheduled the interpretation prior to completing the documentation
				if (procedure.IsPerformed)
				{
					var interpretationStep = GetPendingInterpretationStep(procedure);
					if (interpretationStep != null)
					{
						// bug #3037: schedule the interpretation for the performed time, which may be earlier than the current time 
						// in downtime mode
						interpretationStep.Schedule(procedure.PerformedTime);
						interpretationSteps.Add(interpretationStep);
					}
				}
			}

			this.PersistenceContext.SynchState();

			var planAssembler = new ProcedurePlanAssembler();
			return new CompleteOrderDocumentationResponse
			{
				ProcedurePlan = planAssembler.CreateProcedurePlanSummary(order, this.PersistenceContext),
				InterpretationStepRefs = CollectionUtils.Map<InterpretationStep, EntityRef>(interpretationSteps, step => step.GetRef())
			};
		}

		#endregion

		#region WorkflowServiceBase overrides

		protected override object GetWorkItemKey(object item)
		{
			var summary = item as ModalityWorklistItem;
			return summary == null ? null : new WorklistItemKey(summary.ProcedureStepRef);
		}

		#endregion

		#region Private Members

		private static void CopyProperties(IDictionary<string, string> dest, IDictionary<string, string> source)
		{
			foreach (var kvp in source)
			{
				dest[kvp.Key] = kvp.Value;
			}
		}

		private InterpretationStep GetPendingInterpretationStep(Procedure procedure)
		{
			// bug #3859: don't want to create an interpretation step for a completed procedure
			// (migrated data may not have any interpretation steps even for a completed procedure)
			if (procedure.IsTerminated)
				return null;

			var interpretationSteps = CollectionUtils.Select(
				procedure.ProcedureSteps,
				ps => ps.Is<InterpretationStep>());

			// no interp step, so create one
			if (interpretationSteps.Count == 0)
			{
				var interpretationStep = new InterpretationStep(procedure);
				this.PersistenceContext.Lock(interpretationStep, DirtyState.New);
				return interpretationStep;
			}

			// may be multiple interp steps (eg maybe one was started and discontinued), so find the one that is scheduled
			var pendingStep = CollectionUtils.SelectFirst(
				interpretationSteps,
				ps => ps.State == ActivityStatus.SC);

			return pendingStep == null ? null : pendingStep.As<InterpretationStep>();
		}

		private StaffSummary GetUniqueAssignedInterpreter(Order order)
		{
			StaffSummary uniqueAssignedInterpreter = null;
			var staffAssembler = new StaffAssembler();

			// establish whether there is a unique assigned interpreter for all procedures
			var interpreters = new HashedSet<Staff>();
			foreach (var procedure in order.Procedures)
			{
				var pendingInterpretationStep = procedure.GetProcedureStep(
					ps => ps.Is<InterpretationStep>() && ps.State == ActivityStatus.SC);

				if (pendingInterpretationStep != null && pendingInterpretationStep.AssignedStaff != null)
					interpreters.Add(pendingInterpretationStep.AssignedStaff);
			}

			if (interpreters.Count == 1)
			{
				uniqueAssignedInterpreter = staffAssembler.CreateStaffSummary(
					CollectionUtils.FirstElement(interpreters));
			}

			return uniqueAssignedInterpreter;
		}

		#endregion
	}
}