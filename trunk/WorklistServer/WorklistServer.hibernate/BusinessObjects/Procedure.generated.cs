using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Procedure : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _index = String.Empty;
		private System.DateTime? _scheduledStartTime = null;
		private System.DateTime? _startTime = null;
		private System.DateTime? _endTime = null;
		private bool? _portable = null;
		private bool _downtimeRecoveryMode = default(Boolean);
		
		private ImageAvailabilityEnum _imageAvailabilityEnum = null;
		private LateralityEnum _lateralityEnum = null;
		private Order _order = null;
		private Facility _facility = null;
		private ProcedureCheckIn _procedureCheckIn = null;
		private ProcedureType _procedureType = null;
		private ProcedureStatusEnum _procedureStatusEnum = null;
		
		private IList<ProcedureStep> _procedureSteps = new List<ProcedureStep>();
		
		#endregion

        #region Constructors

        public Procedure() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_index);
			sb.Append(_scheduledStartTime);
			sb.Append(_startTime);
			sb.Append(_endTime);
			sb.Append(_portable);
			sb.Append(_downtimeRecoveryMode);

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
		
		public virtual string Index
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
		
		public virtual bool? Portable
        {
            get { return _portable; }
			set
			{
				OnPortableChanging();
				_portable = value;
				OnPortableChanged();
			}
        }
		partial void OnPortableChanging();
		partial void OnPortableChanged();
		
		public virtual bool DowntimeRecoveryMode
        {
            get { return _downtimeRecoveryMode; }
			set
			{
				OnDowntimeRecoveryModeChanging();
				_downtimeRecoveryMode = value;
				OnDowntimeRecoveryModeChanged();
			}
        }
		partial void OnDowntimeRecoveryModeChanging();
		partial void OnDowntimeRecoveryModeChanged();
		
		public virtual ImageAvailabilityEnum ImageAvailabilityEnum
        {
            get { return _imageAvailabilityEnum; }
			set
			{
				OnImageAvailabilityEnumChanging();
				_imageAvailabilityEnum = value;
				OnImageAvailabilityEnumChanged();
			}
        }
		partial void OnImageAvailabilityEnumChanging();
		partial void OnImageAvailabilityEnumChanged();
		
		public virtual LateralityEnum LateralityEnum
        {
            get { return _lateralityEnum; }
			set
			{
				OnLateralityEnumChanging();
				_lateralityEnum = value;
				OnLateralityEnumChanged();
			}
        }
		partial void OnLateralityEnumChanging();
		partial void OnLateralityEnumChanged();
		
		public virtual Order Order
        {
            get { return _order; }
			set
			{
				OnOrderChanging();
				_order = value;
				OnOrderChanged();
			}
        }
		partial void OnOrderChanging();
		partial void OnOrderChanged();
		
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
		
		public virtual ProcedureCheckIn ProcedureCheckIn
        {
            get { return _procedureCheckIn; }
			set
			{
				OnProcedureCheckInChanging();
				_procedureCheckIn = value;
				OnProcedureCheckInChanged();
			}
        }
		partial void OnProcedureCheckInChanging();
		partial void OnProcedureCheckInChanged();
		
		public virtual ProcedureType ProcedureType
        {
            get { return _procedureType; }
			set
			{
				OnProcedureTypeChanging();
				_procedureType = value;
				OnProcedureTypeChanged();
			}
        }
		partial void OnProcedureTypeChanging();
		partial void OnProcedureTypeChanged();
		
		public virtual ProcedureStatusEnum ProcedureStatusEnum
        {
            get { return _procedureStatusEnum; }
			set
			{
				OnProcedureStatusEnumChanging();
				_procedureStatusEnum = value;
				OnProcedureStatusEnumChanged();
			}
        }
		partial void OnProcedureStatusEnumChanging();
		partial void OnProcedureStatusEnumChanged();
		
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
