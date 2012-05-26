using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Order : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _placerNumber = null;
		private string _accessionNumber = String.Empty;
		private System.DateTime _enteredTime = new DateTime();
		private string _enteredComment = null;
		private System.DateTime? _schedulingRequestTime = null;
		private System.DateTime? _scheduledStartTime = null;
		private System.DateTime? _startTime = null;
		private System.DateTime? _endTime = null;
		private string _reasonForStudy = null;
		private string _cancelComment = null;
		
		private Staff _staff1 = null;
		private OrderCancelReasonEnum _orderCancelReasonEnum = null;
		private DiagnosticService _diagnosticService = null;
		private Staff _staff2 = null;
		private Facility _facility = null;
		private ExternalPractitioner _externalPractitioner = null;
		private Patient _patient = null;
		private OrderPriorityEnum _orderPriorityEnum = null;
		private Order _orderMember = null;
		private OrderStatusEnum _orderStatusEnum = null;
		private Visit _visit = null;
		
		private IList<OrderResultRecipient> _orderResultRecipients = new List<OrderResultRecipient>();
		private IList<OrderAttachment> _orderAttachments = new List<OrderAttachment>();
		private IList<Note> _notes = new List<Note>();
		private IList<Procedure> _procedures = new List<Procedure>();
		
		#endregion

        #region Constructors

        public Order() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_placerNumber);
			sb.Append(_accessionNumber);
			sb.Append(_enteredTime);
			sb.Append(_enteredComment);
			sb.Append(_schedulingRequestTime);
			sb.Append(_scheduledStartTime);
			sb.Append(_startTime);
			sb.Append(_endTime);
			sb.Append(_reasonForStudy);
			sb.Append(_cancelComment);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual int Version
        {
            get { return _version; }
			set
			{
				OnVersionChanging();
				_version = value;
				OnVersionChanged();
			}
        }
		partial void OnVersionChanging();
		partial void OnVersionChanged();
		
		public virtual string PlacerNumber
        {
            get { return _placerNumber; }
			set
			{
				OnPlacerNumberChanging();
				_placerNumber = value;
				OnPlacerNumberChanged();
			}
        }
		partial void OnPlacerNumberChanging();
		partial void OnPlacerNumberChanged();
		
		public virtual string AccessionNumber
        {
            get { return _accessionNumber; }
			set
			{
				OnAccessionNumberChanging();
				_accessionNumber = value;
				OnAccessionNumberChanged();
			}
        }
		partial void OnAccessionNumberChanging();
		partial void OnAccessionNumberChanged();
		
		public virtual System.DateTime EnteredTime
        {
            get { return _enteredTime; }
			set
			{
				OnEnteredTimeChanging();
				_enteredTime = value;
				OnEnteredTimeChanged();
			}
        }
		partial void OnEnteredTimeChanging();
		partial void OnEnteredTimeChanged();
		
		public virtual string EnteredComment
        {
            get { return _enteredComment; }
			set
			{
				OnEnteredCommentChanging();
				_enteredComment = value;
				OnEnteredCommentChanged();
			}
        }
		partial void OnEnteredCommentChanging();
		partial void OnEnteredCommentChanged();
		
		public virtual System.DateTime? SchedulingRequestTime
        {
            get { return _schedulingRequestTime; }
			set
			{
				OnSchedulingRequestTimeChanging();
				_schedulingRequestTime = value;
				OnSchedulingRequestTimeChanged();
			}
        }
		partial void OnSchedulingRequestTimeChanging();
		partial void OnSchedulingRequestTimeChanged();
		
		public virtual System.DateTime? ScheduledStartTime
        {
            get { return _scheduledStartTime; }
			set
			{
				OnScheduledStartTimeChanging();
				_scheduledStartTime = value;
				OnScheduledStartTimeChanged();
			}
        }
		partial void OnScheduledStartTimeChanging();
		partial void OnScheduledStartTimeChanged();
		
		public virtual System.DateTime? StartTime
        {
            get { return _startTime; }
			set
			{
				OnStartTimeChanging();
				_startTime = value;
				OnStartTimeChanged();
			}
        }
		partial void OnStartTimeChanging();
		partial void OnStartTimeChanged();
		
		public virtual System.DateTime? EndTime
        {
            get { return _endTime; }
			set
			{
				OnEndTimeChanging();
				_endTime = value;
				OnEndTimeChanged();
			}
        }
		partial void OnEndTimeChanging();
		partial void OnEndTimeChanged();
		
		public virtual string ReasonForStudy
        {
            get { return _reasonForStudy; }
			set
			{
				OnReasonForStudyChanging();
				_reasonForStudy = value;
				OnReasonForStudyChanged();
			}
        }
		partial void OnReasonForStudyChanging();
		partial void OnReasonForStudyChanged();
		
		public virtual string CancelComment
        {
            get { return _cancelComment; }
			set
			{
				OnCancelCommentChanging();
				_cancelComment = value;
				OnCancelCommentChanged();
			}
        }
		partial void OnCancelCommentChanging();
		partial void OnCancelCommentChanged();
		
		public virtual Staff Staff1
        {
            get { return _staff1; }
			set
			{
				OnStaff1Changing();
				_staff1 = value;
				OnStaff1Changed();
			}
        }
		partial void OnStaff1Changing();
		partial void OnStaff1Changed();
		
		public virtual OrderCancelReasonEnum OrderCancelReasonEnum
        {
            get { return _orderCancelReasonEnum; }
			set
			{
				OnOrderCancelReasonEnumChanging();
				_orderCancelReasonEnum = value;
				OnOrderCancelReasonEnumChanged();
			}
        }
		partial void OnOrderCancelReasonEnumChanging();
		partial void OnOrderCancelReasonEnumChanged();
		
		public virtual DiagnosticService DiagnosticService
        {
            get { return _diagnosticService; }
			set
			{
				OnDiagnosticServiceChanging();
				_diagnosticService = value;
				OnDiagnosticServiceChanged();
			}
        }
		partial void OnDiagnosticServiceChanging();
		partial void OnDiagnosticServiceChanged();
		
		public virtual Staff Staff2
        {
            get { return _staff2; }
			set
			{
				OnStaff2Changing();
				_staff2 = value;
				OnStaff2Changed();
			}
        }
		partial void OnStaff2Changing();
		partial void OnStaff2Changed();
		
		public virtual Facility Facility
        {
            get { return _facility; }
			set
			{
				OnFacilityChanging();
				_facility = value;
				OnFacilityChanged();
			}
        }
		partial void OnFacilityChanging();
		partial void OnFacilityChanged();
		
		public virtual ExternalPractitioner ExternalPractitioner
        {
            get { return _externalPractitioner; }
			set
			{
				OnExternalPractitionerChanging();
				_externalPractitioner = value;
				OnExternalPractitionerChanged();
			}
        }
		partial void OnExternalPractitionerChanging();
		partial void OnExternalPractitionerChanged();
		
		public virtual Patient Patient
        {
            get { return _patient; }
			set
			{
				OnPatientChanging();
				_patient = value;
				OnPatientChanged();
			}
        }
		partial void OnPatientChanging();
		partial void OnPatientChanged();
		
		public virtual OrderPriorityEnum OrderPriorityEnum
        {
            get { return _orderPriorityEnum; }
			set
			{
				OnOrderPriorityEnumChanging();
				_orderPriorityEnum = value;
				OnOrderPriorityEnumChanged();
			}
        }
		partial void OnOrderPriorityEnumChanging();
		partial void OnOrderPriorityEnumChanged();
		
		public virtual Order OrderMember
        {
            get { return _orderMember; }
			set
			{
				OnOrderMemberChanging();
				_orderMember = value;
				OnOrderMemberChanged();
			}
        }
		partial void OnOrderMemberChanging();
		partial void OnOrderMemberChanged();
		
		public virtual OrderStatusEnum OrderStatusEnum
        {
            get { return _orderStatusEnum; }
			set
			{
				OnOrderStatusEnumChanging();
				_orderStatusEnum = value;
				OnOrderStatusEnumChanged();
			}
        }
		partial void OnOrderStatusEnumChanging();
		partial void OnOrderStatusEnumChanged();
		
		public virtual Visit Visit
        {
            get { return _visit; }
			set
			{
				OnVisitChanging();
				_visit = value;
				OnVisitChanged();
			}
        }
		partial void OnVisitChanging();
		partial void OnVisitChanged();
		
		public virtual IList<OrderResultRecipient> OrderResultRecipients
        {
            get { return _orderResultRecipients; }
            set
			{
				OnOrderResultRecipientsChanging();
				_orderResultRecipients = value;
				OnOrderResultRecipientsChanged();
			}
        }
		partial void OnOrderResultRecipientsChanging();
		partial void OnOrderResultRecipientsChanged();
		
		public virtual IList<OrderAttachment> OrderAttachments
        {
            get { return _orderAttachments; }
            set
			{
				OnOrderAttachmentsChanging();
				_orderAttachments = value;
				OnOrderAttachmentsChanged();
			}
        }
		partial void OnOrderAttachmentsChanging();
		partial void OnOrderAttachmentsChanged();
		
		public virtual IList<Note> Notes
        {
            get { return _notes; }
            set
			{
				OnNotesChanging();
				_notes = value;
				OnNotesChanged();
			}
        }
		partial void OnNotesChanging();
		partial void OnNotesChanged();
		
		public virtual IList<Procedure> Procedures
        {
            get { return _procedures; }
            set
			{
				OnProceduresChanging();
				_procedures = value;
				OnProceduresChanged();
			}
        }
		partial void OnProceduresChanging();
		partial void OnProceduresChanged();
		
        #endregion
    }
}
