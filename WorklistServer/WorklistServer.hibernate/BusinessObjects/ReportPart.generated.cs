using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ReportPart : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private int _index = default(Int32);
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime? _preliminaryTime = null;
		private System.DateTime? _completedTime = null;
		private System.DateTime? _cancelledTime = null;
		
		private Staff _staff1 = null;
		private Report _report = null;
		private ReportPartStatusEnum _reportPartStatusEnum = null;
		private Staff _staff2 = null;
		private Staff _staff3 = null;
		private TranscriptionRejectReasonEnum _transcriptionRejectReasonEnum = null;
		private Staff _staff4 = null;
		private Staff _staff5 = null;
		
		private IList<ProcedureStep> _procedureSteps = new List<ProcedureStep>();
		
		#endregion

        #region Constructors

        public ReportPart() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_index);
			sb.Append(_creationTime);
			sb.Append(_preliminaryTime);
			sb.Append(_completedTime);
			sb.Append(_cancelledTime);

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
		
		public virtual int Index
        {
            get { return _index; }
			set
			{
				OnIndexChanging();
				_index = value;
				OnIndexChanged();
			}
        }
		partial void OnIndexChanging();
		partial void OnIndexChanged();
		
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
		
		public virtual System.DateTime? PreliminaryTime
        {
            get { return _preliminaryTime; }
			set
			{
				OnPreliminaryTimeChanging();
				_preliminaryTime = value;
				OnPreliminaryTimeChanged();
			}
        }
		partial void OnPreliminaryTimeChanging();
		partial void OnPreliminaryTimeChanged();
		
		public virtual System.DateTime? CompletedTime
        {
            get { return _completedTime; }
			set
			{
				OnCompletedTimeChanging();
				_completedTime = value;
				OnCompletedTimeChanged();
			}
        }
		partial void OnCompletedTimeChanging();
		partial void OnCompletedTimeChanged();
		
		public virtual System.DateTime? CancelledTime
        {
            get { return _cancelledTime; }
			set
			{
				OnCancelledTimeChanging();
				_cancelledTime = value;
				OnCancelledTimeChanged();
			}
        }
		partial void OnCancelledTimeChanging();
		partial void OnCancelledTimeChanged();
		
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
		
		public virtual Report Report
        {
            get { return _report; }
			set
			{
				OnReportChanging();
				_report = value;
				OnReportChanged();
			}
        }
		partial void OnReportChanging();
		partial void OnReportChanged();
		
		public virtual ReportPartStatusEnum ReportPartStatusEnum
        {
            get { return _reportPartStatusEnum; }
			set
			{
				OnReportPartStatusEnumChanging();
				_reportPartStatusEnum = value;
				OnReportPartStatusEnumChanged();
			}
        }
		partial void OnReportPartStatusEnumChanging();
		partial void OnReportPartStatusEnumChanged();
		
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
		
		public virtual Staff Staff3
        {
            get { return _staff3; }
			set
			{
				OnStaff3Changing();
				_staff3 = value;
				OnStaff3Changed();
			}
        }
		partial void OnStaff3Changing();
		partial void OnStaff3Changed();
		
		public virtual TranscriptionRejectReasonEnum TranscriptionRejectReasonEnum
        {
            get { return _transcriptionRejectReasonEnum; }
			set
			{
				OnTranscriptionRejectReasonEnumChanging();
				_transcriptionRejectReasonEnum = value;
				OnTranscriptionRejectReasonEnumChanged();
			}
        }
		partial void OnTranscriptionRejectReasonEnumChanging();
		partial void OnTranscriptionRejectReasonEnumChanged();
		
		public virtual Staff Staff4
        {
            get { return _staff4; }
			set
			{
				OnStaff4Changing();
				_staff4 = value;
				OnStaff4Changed();
			}
        }
		partial void OnStaff4Changing();
		partial void OnStaff4Changed();
		
		public virtual Staff Staff5
        {
            get { return _staff5; }
			set
			{
				OnStaff5Changing();
				_staff5 = value;
				OnStaff5Changed();
			}
        }
		partial void OnStaff5Changing();
		partial void OnStaff5Changed();
		
		public virtual IList<ProcedureStep> ProcedureSteps
        {
            get { return _procedureSteps; }
            set
			{
				OnProcedureStepsChanging();
				_procedureSteps = value;
				OnProcedureStepsChanged();
			}
        }
		partial void OnProcedureStepsChanging();
		partial void OnProcedureStepsChanged();
		
        #endregion
    }
}
