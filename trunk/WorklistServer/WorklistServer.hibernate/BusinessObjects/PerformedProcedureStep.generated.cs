using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class PerformedProcedureStep : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _discriminator = String.Empty;
		private int _version = default(Int32);
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime _lastStateChangeTime = new DateTime();
		private System.DateTime? _startTime = null;
		private System.DateTime? _endTime = null;
		
		private Staff _staff = null;
		private PerformedStepStatusEnum _performedStepStatusEnum = null;
		
		private IList<DicomSeries> _dicomSeriesMember = new List<DicomSeries>();
		private IList<ProcedureStep> _procedureSteps = new List<ProcedureStep>();
		
		#endregion

        #region Constructors

        public PerformedProcedureStep() { }

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
			sb.Append(_startTime);
			sb.Append(_endTime);

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
		
		public virtual Staff Staff
        {
            get { return _staff; }
			set
			{
				OnStaffChanging();
				_staff = value;
				OnStaffChanged();
			}
        }
		partial void OnStaffChanging();
		partial void OnStaffChanged();
		
		public virtual PerformedStepStatusEnum PerformedStepStatusEnum
        {
            get { return _performedStepStatusEnum; }
			set
			{
				OnPerformedStepStatusEnumChanging();
				_performedStepStatusEnum = value;
				OnPerformedStepStatusEnumChanged();
			}
        }
		partial void OnPerformedStepStatusEnumChanging();
		partial void OnPerformedStepStatusEnumChanged();
		
		public virtual IList<DicomSeries> DicomSeriesMember
        {
            get { return _dicomSeriesMember; }
            set
			{
				OnDicomSeriesMemberChanging();
				_dicomSeriesMember = value;
				OnDicomSeriesMemberChanged();
			}
        }
		partial void OnDicomSeriesMemberChanging();
		partial void OnDicomSeriesMemberChanged();
		
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
