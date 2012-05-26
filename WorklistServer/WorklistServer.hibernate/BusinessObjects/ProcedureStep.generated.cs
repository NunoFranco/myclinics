using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ProcedureStep : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _discriminator = String.Empty;
		private int _version = default(Int32);
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime _lastStateChangeTime = new DateTime();
		private System.DateTime? _scheduledStartTime = null;
		private System.DateTime? _scheduledEndTime = null;
		private System.DateTime? _startTime = null;
		private System.DateTime? _endTime = null;
		private string _description = null;
		private bool? _hasErrors = null;
		private int? _failureCount = null;
		private System.DateTime? _lastFailureTime = null;
		
		private ProcedureStep _procedureStepMember = null;
		private Modality _modality = null;
		private Staff _staff1 = null;
		private Procedure _procedure = null;
		private Protocol _protocol = null;
		private ReportPart _reportPart = null;
		private Staff _staff2 = null;
		private ActivityStatusEnum _activityStatusEnum = null;
		
		private IList<PerformedProcedureStep> _performedProcedureSteps = new List<PerformedProcedureStep>();
		
		#endregion

        #region Constructors

        public ProcedureStep() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_discriminator);
			sb.Append(_version);
			sb.Append(_creationTime);
			sb.Append(_lastStateChangeTime);
			sb.Append(_scheduledStartTime);
			sb.Append(_scheduledEndTime);
			sb.Append(_startTime);
			sb.Append(_endTime);
			sb.Append(_description);
			sb.Append(_hasErrors);
			sb.Append(_failureCount);
			sb.Append(_lastFailureTime);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string Discriminator
        {
            get { return _discriminator; }
			set
			{
				OnDiscriminatorChanging();
				_discriminator = value;
				OnDiscriminatorChanged();
			}
        }
		partial void OnDiscriminatorChanging();
		partial void OnDiscriminatorChanged();
		
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
		
		public virtual System.DateTime CreationTime
        {
            get { return _creationTime; }
			set
			{
				OnCreationTimeChanging();
				_creationTime = value;
				OnCreationTimeChanged();
			}
        }
		partial void OnCreationTimeChanging();
		partial void OnCreationTimeChanged();
		
		public virtual System.DateTime LastStateChangeTime
        {
            get { return _lastStateChangeTime; }
			set
			{
				OnLastStateChangeTimeChanging();
				_lastStateChangeTime = value;
				OnLastStateChangeTimeChanged();
			}
        }
		partial void OnLastStateChangeTimeChanging();
		partial void OnLastStateChangeTimeChanged();
		
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
		
		public virtual System.DateTime? ScheduledEndTime
        {
            get { return _scheduledEndTime; }
			set
			{
				OnScheduledEndTimeChanging();
				_scheduledEndTime = value;
				OnScheduledEndTimeChanged();
			}
        }
		partial void OnScheduledEndTimeChanging();
		partial void OnScheduledEndTimeChanged();
		
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
		
		public virtual string Description
        {
            get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				OnDescriptionChanged();
			}
        }
		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		
		public virtual bool? HasErrors
        {
            get { return _hasErrors; }
			set
			{
				OnHasErrorsChanging();
				_hasErrors = value;
				OnHasErrorsChanged();
			}
        }
		partial void OnHasErrorsChanging();
		partial void OnHasErrorsChanged();
		
		public virtual int? FailureCount
        {
            get { return _failureCount; }
			set
			{
				OnFailureCountChanging();
				_failureCount = value;
				OnFailureCountChanged();
			}
        }
		partial void OnFailureCountChanging();
		partial void OnFailureCountChanged();
		
		public virtual System.DateTime? LastFailureTime
        {
            get { return _lastFailureTime; }
			set
			{
				OnLastFailureTimeChanging();
				_lastFailureTime = value;
				OnLastFailureTimeChanged();
			}
        }
		partial void OnLastFailureTimeChanging();
		partial void OnLastFailureTimeChanged();
		
		public virtual ProcedureStep ProcedureStepMember
        {
            get { return _procedureStepMember; }
			set
			{
				OnProcedureStepMemberChanging();
				_procedureStepMember = value;
				OnProcedureStepMemberChanged();
			}
        }
		partial void OnProcedureStepMemberChanging();
		partial void OnProcedureStepMemberChanged();
		
		public virtual Modality Modality
        {
            get { return _modality; }
			set
			{
				OnModalityChanging();
				_modality = value;
				OnModalityChanged();
			}
        }
		partial void OnModalityChanging();
		partial void OnModalityChanged();
		
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
		
		public virtual Procedure Procedure
        {
            get { return _procedure; }
			set
			{
				OnProcedureChanging();
				_procedure = value;
				OnProcedureChanged();
			}
        }
		partial void OnProcedureChanging();
		partial void OnProcedureChanged();
		
		public virtual Protocol Protocol
        {
            get { return _protocol; }
			set
			{
				OnProtocolChanging();
				_protocol = value;
				OnProtocolChanged();
			}
        }
		partial void OnProtocolChanging();
		partial void OnProtocolChanged();
		
		public virtual ReportPart ReportPart
        {
            get { return _reportPart; }
			set
			{
				OnReportPartChanging();
				_reportPart = value;
				OnReportPartChanged();
			}
        }
		partial void OnReportPartChanging();
		partial void OnReportPartChanged();
		
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
		
		public virtual ActivityStatusEnum ActivityStatusEnum
        {
            get { return _activityStatusEnum; }
			set
			{
				OnActivityStatusEnumChanging();
				_activityStatusEnum = value;
				OnActivityStatusEnumChanged();
			}
        }
		partial void OnActivityStatusEnumChanging();
		partial void OnActivityStatusEnumChanged();
		
		public virtual IList<PerformedProcedureStep> PerformedProcedureSteps
        {
            get { return _performedProcedureSteps; }
            set
			{
				OnPerformedProcedureStepsChanging();
				_performedProcedureSteps = value;
				OnPerformedProcedureStepsChanged();
			}
        }
		partial void OnPerformedProcedureStepsChanging();
		partial void OnPerformedProcedureStepsChanged();
		
        #endregion
    }
}
