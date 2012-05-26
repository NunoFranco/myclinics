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
using System.Threading;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Healthcare.Workflow;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using AuthorityTokens = ClearCanvas.Ris.Application.Common.AuthorityTokens;
using Iesi.Collections.Generic;
namespace ClearCanvas.Ris.Application.Services.RegistrationWorkflow
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(IOrderEntryService))]
    public class OrderEntryService : WorkflowServiceBase, IOrderEntryService
    {
        public class WorklistItemKey
        {
            private readonly EntityRef _orderRef;

            public WorklistItemKey(EntityRef orderRef)
            {
                _orderRef = orderRef;
            }

            public EntityRef OrderRef
            {
                get { return _orderRef; }
            }
        }

        #region IOrderEntryService Members

        [ReadOperation]
        public LoadOrderResponse LoadOrder(LoadOrderRequest request)
        {
            var criteria = new OrderSearchCriteria();
            //criteria.Patient.EqualTo(profile.Patient);
            if (!string.IsNullOrEmpty(request.OrderNumber))
            {
                criteria.OrderNumber.EqualTo(request.OrderNumber);
            }
            if (request.StartTimeEnteredOrder != null && request.EndTimeEnteredOrder != null)
            {
                criteria.EnteredTime.Between(((DateTime)request.StartTimeEnteredOrder).Date, ((DateTime)request.EndTimeEnteredOrder).AddDays(1).Date);
            }
            //    criteria.Status.In(new[] { OrderStatus.SC, OrderStatus.IP });

            IList<Order> results = this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria);
            IList<EntityRef> ResponseResult = new List<EntityRef>();
            OrderAssembler assember = new OrderAssembler();
            IList<OrderDetail> details = new List<OrderDetail>();
            foreach (Order item in results)
            {
                EntityRef EREF = results[0].GetRef();
                ResponseResult.Add(EREF);
                details.Add(assember.CreateOrderDetail(item, this.PersistenceContext));
            }

            return new LoadOrderResponse(ResponseResult, details);
        }


        [ReadOperation]
        public LoadOrderResponse LoadWorklist(LoadOrderRequest request)
        {
            var criteria = new OrderSearchCriteria();
            //criteria.Patient.EqualTo(profile.Patient);

            criteria.Status.In(new[] { EnumValue.GetEnumerValue<OrderStatusEnum>(OrderStatus.SC), EnumValue.GetEnumerValue<OrderStatusEnum>(OrderStatus.IP) });

            IList<Order> results = this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria);
            IList<EntityRef> ResponseResult = new List<EntityRef>();
            OrderAssembler assember = new OrderAssembler();
            IList<OrderDetail> details = new List<OrderDetail>();
            foreach (Order item in results)
            {
                EntityRef EREF = results[0].GetRef();
                ResponseResult.Add(EREF);
                details.Add(assember.CreateOrderDetail(item, this.PersistenceContext));
            }

            return new LoadOrderResponse(ResponseResult, details);
        }

        [ReadOperation]
        public LoadOrderResponse LoadWaitingOrders(LoadOrderRequest request)
        {
            var criteria = new OrderSearchCriteria();
            //criteria.Patient.EqualTo(profile.Patient);

            criteria.BillingStatus.EqualTo(ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.WAITING.ToString());

            IList<Order> results = this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria);
            IList<EntityRef> ResponseResult = new List<EntityRef>();
            OrderAssembler assember = new OrderAssembler();
            IList<OrderDetail> details = new List<OrderDetail>();
            foreach (Order item in results)
            {
                EntityRef EREF = results[0].GetRef();
                ResponseResult.Add(EREF);
                details.Add(assember.CreateOrderDetail(item, this.PersistenceContext));
            }

            return new LoadOrderResponse(ResponseResult, details);

        }

        [ReadOperation]
        public LoadOrderResponse LoadPendingOrders(LoadOrderRequest request)
        {
            var criteria = new OrderSearchCriteria();
            //criteria.Patient.EqualTo(profile.Patient);
            //criteria.Status.In(new[] { OrderStatus.CM });
            criteria.BillingStatus.In(new string[]
            {
                ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.PENDING.ToString()
                ,ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.COLLECTEDINSURANCE.ToString()
            });
            IList<Order> results = this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria);
            IList<EntityRef> ResponseResult = new List<EntityRef>();
            OrderAssembler assember = new OrderAssembler();
            IList<OrderDetail> details = new List<OrderDetail>();
            foreach (Order item in results)
            {
                //if (IsPendingOrder(item))
                //{
                EntityRef EREF = results[0].GetRef();
                ResponseResult.Add(EREF);
                details.Add(assember.CreateOrderDetail(item, this.PersistenceContext));
                //}
            }

            return new LoadOrderResponse(ResponseResult, details);
        }
        bool IsPendingOrder(Order item)
        {
            foreach (var Pro in item.Procedures)
            {
                if (Pro.WaitingInsuranceAmount > 0)
                    return true;
            }
            return false;
        }
        [ReadOperation]
        public LoadOrderResponse LoadCompleteOrders(LoadOrderRequest request)
        {
            var criteria = new OrderSearchCriteria();
            //criteria.Patient.EqualTo(profile.Patient);

            criteria.BillingStatus.EqualTo(ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED.ToString());
            IList<Order> results = this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria);
            IList<EntityRef> ResponseResult = new List<EntityRef>();
            OrderAssembler assember = new OrderAssembler();
            IList<OrderDetail> details = new List<OrderDetail>();
            foreach (Order item in results)
            {
                EntityRef EREF = results[0].GetRef();
                ResponseResult.Add(EREF);
                details.Add(assember.CreateOrderDetail(item, this.PersistenceContext));
            }

            return new LoadOrderResponse(ResponseResult, details);
        }

        [ReadOperation]
        public ListVisitsForPatientResponse ListVisitsForPatient(ListVisitsForPatientRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.PatientRef, "PatientRef");

            var patient = this.PersistenceContext.GetBroker<IPatientBroker>().Load(request.PatientRef, EntityLoadFlags.Proxy);

            var criteria = new VisitSearchCriteria();
            criteria.Patient.EqualTo(patient);
            criteria.AdmitTime.SortDesc(0);

            var assembler = new VisitAssembler();
            return new ListVisitsForPatientResponse(
                CollectionUtils.Map<Visit, VisitSummary, List<VisitSummary>>(
                    this.PersistenceContext.GetBroker<IVisitBroker>().Find(criteria),
                    v => assembler.CreateVisitSummary(v, this.PersistenceContext)));
        }

        [ReadOperation]
        public ListOrdersForPatientResponse ListActiveOrdersForPatient(ListOrdersForPatientRequest request)
        {
            var criteria = new OrderSearchCriteria();

            var profile = this.PersistenceContext.Load<PatientProfile>(request.PatientProfileRef);
            criteria.Patient.EqualTo(profile.Patient);
            if (request.ActiveOnly)
                criteria.Status.In(new[] { EnumValue.GetEnumerValue<OrderStatusEnum>(OrderStatus.SC), EnumValue.GetEnumerValue<OrderStatusEnum>(OrderStatus.IP) });

            var assembler = new OrderAssembler();
            return new ListOrdersForPatientResponse(
                CollectionUtils.Map<Order, OrderSummary, List<OrderSummary>>(
                    this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria),
                    order => assembler.CreateOrderSummary(order, this.PersistenceContext)));
        }

        [ReadOperation]
        public GetOrderEntryFormDataResponse GetOrderEntryFormData(GetOrderEntryFormDataRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            var facilityAssembler = new FacilityAssembler();
            return new GetOrderEntryFormDataResponse(
                CollectionUtils.Map<Facility, FacilitySummary, List<FacilitySummary>>(
                    this.PersistenceContext.GetBroker<IFacilityBroker>().FindAll(false),
                    facilityAssembler.CreateFacilitySummary),
                EnumUtils.GetEnumValueList<OrderPriorityEnum>( this.PersistenceContext),
                EnumUtils.GetEnumValueList<OrderCancelReasonEnum>( this.PersistenceContext),
                EnumUtils.GetEnumValueList<LateralityEnum>( this.PersistenceContext)
                );
        }

        [ReadOperation]
        public LoadDiagnosticServiceBreakdownResponse LoadDiagnosticServiceBreakdown(LoadDiagnosticServiceBreakdownRequest request)
        {
            var dsBroker = this.PersistenceContext.GetBroker<IDiagnosticServiceBroker>();

            var diagnosticService = dsBroker.Load(request.DiagnosticServiceRef);

            var assembler = new DiagnosticServiceAssembler();
            return new LoadDiagnosticServiceBreakdownResponse(assembler.CreateDetail(diagnosticService, this.PersistenceContext));
        }

        [ReadOperation]
        public ListOrderableProcedureTypesResponse ListOrderableProcedureTypes(ListOrderableProcedureTypesRequest request)
        {
            // TODO: we need to build a list of orderable procedure types, based on what has already been ordered
            // for now, just return everything
            var broker = this.PersistenceContext.GetBroker<IProcedureTypeBroker>();
            var rpTypes = broker.FindAll(false);

            var rptAssembler = new ProcedureTypeAssembler();
            var summaries = CollectionUtils.Map(rpTypes, (ProcedureType rpt) => rptAssembler.CreateSummary(rpt, PersistenceContext));

            return new ListOrderableProcedureTypesResponse(summaries);
        }

        [ReadOperation]
        public GetExternalPractitionerContactPointsResponse GetExternalPractitionerContactPoints(GetExternalPractitionerContactPointsRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.PractitionerRef, "PractitionerRef");

            var practitioner = this.PersistenceContext.Load<ExternalPractitioner>(request.PractitionerRef);
            var assembler = new ExternalPractitionerAssembler();

            // sort contact points such that default is first (descending sort)
            var sortedContactPoints = CollectionUtils.Sort(practitioner.ContactPoints,
                                                           (x, y) => -x.IsDefaultContactPoint.CompareTo(y.IsDefaultContactPoint));

            var responseContactPoints = sortedContactPoints;
            if (!request.IncludeDeactivated)
            {
                responseContactPoints = CollectionUtils.Select(sortedContactPoints, cp => !cp.Deactivated);
            }

            return new GetExternalPractitionerContactPointsResponse(
                CollectionUtils.Map(
                    responseContactPoints,
                    (ExternalPractitionerContactPoint cp) => assembler.CreateExternalPractitionerContactPointDetail(cp, null, this.PersistenceContext)));
        }

        [ReadOperation]
        public GetCancelOrderFormDataResponse GetCancelOrderFormData(GetCancelOrderFormDataRequest request)
        {
            return new GetCancelOrderFormDataResponse(EnumUtils.GetEnumValueList<OrderCancelReasonEnum>( this.PersistenceContext));
        }

        [ReadOperation]
        public GetOrderRequisitionForEditResponse GetOrderRequisitionForEdit(GetOrderRequisitionForEditRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.OrderRef, "OrderRef");

            var assembler = new OrderEntryAssembler();

            var order = this.PersistenceContext.GetBroker<IOrderBroker>().Load(request.OrderRef);

            var requisition = assembler.CreateOrderRequisition(order, this.PersistenceContext);
            return new GetOrderRequisitionForEditResponse(order.GetRef(), requisition, order.IsTerminated);
        }


        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Order.Create)]
        public PlaceOrderResponse PlaceOrder(PlaceOrderRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Requisition, "Requisition");

            //long chang added
            request.Requisition.BillingStatus = ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.WAITING.ToString();
            var order = PlaceOrderHelper(request.Requisition);


            ValidatePatientProfilesExist(order);

            // ensure the new order is assigned an OID before using it in the return value
            this.PersistenceContext.SynchState();

            var orderAssembler = new OrderAssembler();
            return new PlaceOrderResponse(orderAssembler.CreateOrderSummary(order, this.PersistenceContext));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Order.Modify)]
        [OperationEnablement("CanModifyOrder")]
        public ModifyOrderResponse ModifyOrder(ModifyOrderRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.OrderRef, "OrderRef");
            Platform.CheckMemberIsSet(request.Requisition, "Requisition");

            var order = this.PersistenceContext.Load<Order>(request.OrderRef);

            var assembler = new OrderEntryAssembler();
            assembler.UpdateOrderFromRequisition(order, request.Requisition, this.CurrentUserStaff, this.PersistenceContext);

            UpdateProceduresHelper(order, request.Requisition.Procedures);
            ValidatePatientProfilesExist(order);

            this.PersistenceContext.SynchState();

            var orderAssembler = new OrderAssembler();
            return new ModifyOrderResponse(orderAssembler.CreateOrderSummary(order, this.PersistenceContext));
        }

        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Order.Replace)]
        [OperationEnablement("CanReplaceOrder")]
        public ReplaceOrderResponse ReplaceOrder(ReplaceOrderRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.OrderRef, "OrderRef");
            Platform.CheckMemberIsSet(request.Requisition, "Requisition");

            var orderToReplace = this.PersistenceContext.Load<Order>(request.OrderRef);
            ValidateOrderReplacable(orderToReplace);

            // reason is optional
            var reason = (request.CancelReason != null) ?
                EnumUtils.GetEnumValue<OrderCancelReasonEnum>(request.CancelReason, this.PersistenceContext) : null;

            // place new order
            var newOrder = PlaceOrderHelper(request.Requisition);
            ValidatePatientProfilesExist(newOrder);

            // cancel existing order
            CancelOrderHelper(orderToReplace, new OrderCancelInfo(reason, this.CurrentUserStaff, null, newOrder));

            this.PersistenceContext.SynchState();

            var orderAssembler = new OrderAssembler();
            return new ReplaceOrderResponse(orderAssembler.CreateOrderSummary(newOrder, this.PersistenceContext));
        }

        [UpdateOperation]
        [OperationEnablement("CanCancelOrder")]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Order.Cancel)]
        public CancelOrderResponse CancelOrder(CancelOrderRequest request)
        {
            var order = this.PersistenceContext.GetBroker<IOrderBroker>().Load(request.OrderRef);
            var reason = EnumUtils.GetEnumValue<OrderCancelReasonEnum>(request.CancelReason, this.PersistenceContext);

            CancelOrderHelper(order, new OrderCancelInfo(reason, this.CurrentUserStaff));

            return new CancelOrderResponse();
        }
        [UpdateOperation]
        [PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Workflow.Order.Cancel)]
        public ReConfirmOrderResponse ReconfirmOrder(ReConfirmOrderRequest request)
        {
            var order = this.PersistenceContext.GetBroker<IOrderBroker>().Load(request.OrderRef);
            ReConfirmOrderHelper(order);
            return new ReConfirmOrderResponse();
        }

        [ReadOperation]
        public QueryCancelOrderWarningsResponse QueryCancelOrderWarnings(QueryCancelOrderWarningsRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.OrderRef, "OrderRef");

            var order = this.PersistenceContext.Load<Order>(request.OrderRef);
            var warnings = new List<string>();

            var hasActiveReportingSteps = CollectionUtils.Contains(
                order.Procedures,
                p => CollectionUtils.Contains(p.ReportingProcedureSteps, ps => !ps.IsTerminated));

            if (hasActiveReportingSteps)
            {
                warnings.Add("This order has been performed and may have reports in progress.");
            }

            return new QueryCancelOrderWarningsResponse(warnings);
        }

        [UpdateOperation]
        public TimeShiftOrderResponse TimeShiftOrder(TimeShiftOrderRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.OrderRef, "OrderRef");

            // load the order, explicitly ignoring the version (since this is only used for testing/demo data creation, we don't care)
            var order = this.PersistenceContext.Load<Order>(request.OrderRef, EntityLoadFlags.None);

            // shift the order, which will also shift all procedures, etc.
            order.TimeShift(request.NumberOfMinutes);

            // shift the visit
            order.Visit.TimeShift(request.NumberOfMinutes);

            this.PersistenceContext.SynchState();

            var orderAssembler = new OrderAssembler();
            return new TimeShiftOrderResponse(orderAssembler.CreateOrderSummary(order, this.PersistenceContext));
        }

        [UpdateOperation]
        public ReserveAccessionNumberResponse ReserveAccessionNumber(ReserveAccessionNumberRequest request)
        {
            // obtain a new acc number
            var broker = this.PersistenceContext.GetBroker<IAccessionNumberBroker>();
            var accNum = broker.GetNextAccessionNumber();

            return new ReserveAccessionNumberResponse(accNum);
        }

        #endregion

        #region Operation Enablement

        protected override object GetWorkItemKey(object item)
        {
            var summary = item as WorklistItemSummaryBase;
            return summary == null ? null : new WorklistItemKey(summary.OrderRef);
        }

        public bool CanReplaceOrder(WorklistItemKey itemKey)
        {
            if (!Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Workflow.Order.Replace))
                return false;

            // the worklist item may represent a patient without an order,
            // in which case there is no order to cancel
            if (itemKey.OrderRef == null)
                return false;

            var order = this.PersistenceContext.GetBroker<IOrderBroker>().Load(itemKey.OrderRef);

            // the order can be replaced iff it can be cancelled/discontinued
            var cancelOp = new CancelOrderOperation();
            var discOp = new DiscontinueOrderOperation();
            return discOp.CanExecute(order) || cancelOp.CanExecute(order);
        }

        public bool CanModifyOrder(WorklistItemKey itemKey)
        {
            if (!Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Workflow.Order.Modify))
                return false;

            // the worklist item may represent a patient without an order,
            // in which case there is no order to modify
            if (itemKey.OrderRef == null)
                return false;

            return true;
        }

        public bool CanCancelOrder(WorklistItemKey itemKey)
        {
            if (!Thread.CurrentPrincipal.IsInRole(AuthorityTokens.Workflow.Order.Cancel))
                return false;

            // the worklist item may represent a patient without an order,
            // in which case there is no order to cancel
            if (itemKey.OrderRef == null)
                return false;

            var order = this.PersistenceContext.GetBroker<IOrderBroker>().Load(itemKey.OrderRef);

            // cancel or discontinue
            var cancelOp = new CancelOrderOperation();
            var discOp = new DiscontinueOrderOperation();
            return discOp.CanExecute(order) || cancelOp.CanExecute(order);
        }

        #endregion

        private void ValidateOrderReplacable(Order order)
        {
            if (order.IsTerminated)
                throw new RequestValidationException(string.Format("Orders with a status of '{0}' cannot be replaced.",
                    EnumUtils.GetEnumValueInfo(order.Status)));

            if (CollectionUtils.Contains(order.Procedures, p => p.DowntimeRecoveryMode))
                throw new RequestValidationException("Downtime orders cannot be replaced.  You must cancel the order and create a new one.");
        }

        // TODO: ideally this should be done in the model layer
        private static void ValidatePatientProfilesExist(Order order)
        {
            foreach (var procedure in order.Procedures)
            {
                var hasProfile = CollectionUtils.Contains(order.Patient.Profiles,
                                        profile => profile.Mrn.AssigningAuthority.Equals(procedure.PerformingFacility.InformationAuthority));
                if (!hasProfile)
                    throw new RequestValidationException(string.Format("{0} is not a valid performing facility for this patient because the patient does not have a demographics profile for this facility.",
                        procedure.PerformingFacility.Name));
            }
        }

        private Order PlaceOrderHelper(OrderRequisition requisition)
        {
            var patient = this.PersistenceContext.Load<Patient>(requisition.Patient, EntityLoadFlags.Proxy);
            var visit = this.PersistenceContext.Load<Visit>(requisition.Visit.VisitRef, EntityLoadFlags.Proxy);
            var orderingPhysician = this.PersistenceContext.Load<ExternalPractitioner>(requisition.OrderingPractitioner.PractitionerRef, EntityLoadFlags.Proxy);
            var diagnosticService = this.PersistenceContext.Load<DiagnosticService>(requisition.DiagnosticService.DiagnosticServiceRef);
            var priority = EnumUtils.GetEnumValue<OrderPriority>(requisition.Priority);

            var orderingFacility = this.PersistenceContext.Load<Facility>(requisition.OrderingFacility.FacilityRef, EntityLoadFlags.Proxy);

            var resultRecipients = CollectionUtils.Map(
                requisition.ResultRecipients,
                (ResultRecipientDetail s) => new ResultRecipient(
                                                this.PersistenceContext.Load<ExternalPractitionerContactPoint>(s.ContactPoint.ContactPointRef, EntityLoadFlags.Proxy),
                                                EnumUtils.GetEnumValue<ResultCommunicationModeEnum>(s.PreferredCommunicationMode,PersistenceContext )));

            // generate set of procedures
            // create a temp map from procedure back to its requisition, this will be needed later
            var orderAssembler = new OrderEntryAssembler();
            var mapProcToReq = new Dictionary<Procedure, ProcedureRequisition>();
            var procedures = CollectionUtils.Map(
                requisition.Procedures,
                delegate(ProcedureRequisition req)
                {
                    var rpt = this.PersistenceContext.Load<ProcedureType>(req.ProcedureType.ProcedureTypeRef);
                    var rp = new Procedure(rpt);
                    rp.PendingProcedureStatus = Enterprise.Common.WaitingInsuranceStatus.NOWAITING.ToString();
                    mapProcToReq.Add(rp, req);

                    // important to set this flag prior to creating the procedure steps, because it may affect
                    // which procedure steps are created
                    rp.DowntimeRecoveryMode = requisition.IsDowntimeOrder;
                    return rp;
                });

            // get appropriate A# for this order
            var accNum = GetAccessionNumberForOrder(requisition);

            // generate a new order with the default set of procedures
            var order = Order.NewOrder(
                new OrderCreationArgs(
                    Platform.Time,
                    this.CurrentUserStaff,
                    null,
                    accNum,
                    patient,
                    visit,
                    diagnosticService,
                    requisition.ReasonForStudy,
                    requisition.OrderNumber,
                    requisition.BillingStatus,
                    priority,
                    orderingFacility,
                    requisition.SchedulingRequestTime,
                    orderingPhysician,
                    resultRecipients,
                    procedures));

            // note: need to lock the new order now, prior to creating the procedure steps
            // otherwise may get exceptions saying the Procedure is a transient object
            this.PersistenceContext.Lock(order, DirtyState.New);

            // create procedure steps and update from requisition
            foreach (var procedure in order.Procedures)
            {
                procedure.CreateProcedureSteps();
                orderAssembler.UpdateProcedureFromRequisition(procedure, mapProcToReq[procedure], this.PersistenceContext);
            }

            // add order notes
            var noteAssembler = new OrderNoteAssembler();
            noteAssembler.SynchronizeOrderNotes(order, requisition.Notes, this.CurrentUserStaff, this.PersistenceContext);

            // add attachments
            var attachmentAssembler = new OrderAttachmentAssembler();
            attachmentAssembler.Synchronize(order.Attachments, requisition.Attachments, this.CurrentUserStaff, this.PersistenceContext);

            if (requisition.ExtendedProperties != null)
            {
                // copy properties individually so as not to overwrite any that were not sent by the client
                foreach (var pair in requisition.ExtendedProperties)
                {
                    order.ExtendedProperties[pair.Key] = pair.Value;
                }
            }

            return order;
        }

        private static void CancelOrderHelper(Order order, OrderCancelInfo info)
        {
            if (Healthcare.Common.IsEqual(order.Status, OrderStatus.SC))
            {
                var op = new CancelOrderOperation();
                op.Execute(order, info);
            }
            else if (Healthcare.Common.IsEqual(order.Status, OrderStatus.IP))
            {
                var op = new DiscontinueOrderOperation();
                op.Execute(order, info);
            }
        }
        private static void ReConfirmOrderHelper(Order order)
        {
            if (Healthcare.Common.IsEqual(order.Status, OrderStatus.CA))
            {
                var op = new ReConfirmOrderOperation();
                op.Execute(order);
            }
        }
        private string GetAccessionNumberForOrder(OrderRequisition requisition)
        {
            // if this is a downtime requisition, validate the downtime A#, otherwise obtain a new A#
            var accessionBroker = this.PersistenceContext.GetBroker<IAccessionNumberBroker>();
            if (requisition.IsDowntimeOrder)
            {
                // validate that the downtime A# is less than then current sequence position
                var currentMaxAccession = accessionBroker.PeekNextAccessionNumber();
                if (requisition.DowntimeAccessionNumber.CompareTo(currentMaxAccession) > -1)
                    throw new RequestValidationException("Invalid downtime accession number.");

                return requisition.DowntimeAccessionNumber;
            }

            // get new A#
            return this.PersistenceContext.GetBroker<IAccessionNumberBroker>().GetNextAccessionNumber();
        }

        private void UpdateProceduresHelper(Order order, IEnumerable<ProcedureRequisition> procedureReqs)
        {
            // do not update the procedures if the order is completed
            if (order.IsTerminated)
                return;

            var assembler = new OrderEntryAssembler();

            // if any procedure is in downtime recovery mode, assume the entire order is a "downtime order"
            var isDowntime = CollectionUtils.Contains(order.Procedures, p => p.DowntimeRecoveryMode);

            // separate the list into additions and updates
            var existingReqs = new List<ProcedureRequisition>();
            var addedReqs = new List<ProcedureRequisition>();

            foreach (var req in procedureReqs)
            {
                if (CollectionUtils.Contains(order.Procedures, x => req.ProcedureIndex == x.Index))
                {
                    existingReqs.Add(req);
                }
                else
                {
                    addedReqs.Add(req);
                }
            }

            // process the additions first, so that we don't accidentally cancel an order (if all its procedures are cancelled momentarily)
            foreach (var req in addedReqs)
            {
                var requestedType = this.PersistenceContext.Load<ProcedureType>(req.ProcedureType.ProcedureTypeRef);

                // create a new procedure for this requisition
                var rp = new Procedure(requestedType) { DowntimeRecoveryMode = isDowntime };
                order.AddProcedure(rp);

                // note: need to lock the new procedure now, prior to creating the procedure steps
                // otherwise may get exceptions saying the Procedure is a transient object
                this.PersistenceContext.Lock(rp, DirtyState.New);

                // create the procedure steps
                rp.CreateProcedureSteps();

                // apply the requisition information to the actual procedure
                assembler.UpdateProcedureFromRequisition(rp, req, this.PersistenceContext);
            }

            // process updates
            foreach (var req in existingReqs)
            {
                var requestedType = this.PersistenceContext.Load<ProcedureType>(req.ProcedureType.ProcedureTypeRef);
                var rp = CollectionUtils.SelectFirst(order.Procedures, x => req.ProcedureIndex == x.Index);

                // validate that the type has not changed
                if (!rp.Type.Equals(requestedType))
                    throw new RequestValidationException("Order modification must not modify the type of a requested procedure.");

                // apply the requisition information to the actual procedure
                assembler.UpdateProcedureFromRequisition(rp, req, this.PersistenceContext);
            }
        }
        [UpdateOperation]
        public UpdateOrderStatusResponse UpdateOrderStatus(UpdateOrderStatusRequest request)
        {
            OrderAssembler assembler = new OrderAssembler();
            Order order = this.PersistenceContext.Load<Order>(request.OrderRef);
            order.BillingStatus = request.BillingStatus;
            if (order.Invoices != null && order.Invoices.Count > 0)
            {
                foreach (var item in order.Invoices)
                {
                    item.IsCollectedInsurance = true;
                }
            }
            this.PersistenceContext.Lock(order, DirtyState.Dirty);
            this.PersistenceContext.SynchState();
            return new UpdateOrderStatusResponse(assembler.CreateOrderSummary(order, PersistenceContext));
        }
    }
}
