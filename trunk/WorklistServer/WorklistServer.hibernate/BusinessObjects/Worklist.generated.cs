using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Worklist : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _discriminator = String.Empty;
		private int _version = default(Int32);
		private string _fullClassName = String.Empty;
		private string _name = String.Empty;
		private string _description = null;
		private bool? _procedureTypeGroupFilterIsEnabled = null;
		private bool? _facilityFilterIsEnabled = null;
		private bool? _facilityFilterIncludeWorkingFacility = null;
		private bool? _patientClassFilterIsEnabled = null;
		private bool? _patientLocationFilterIsEnabled = null;
		private bool? _orderPriorityFilterIsEnabled = null;
		private bool? _orderingPractitionerFilterIsEnabled = null;
		private bool? _portableFilterIsEnabled = null;
		private bool? _portableFilterValue = null;
		private bool? _timeFilterIsEnabled = null;
		private System.DateTime? _startTimeFilterFixedValue = null;
		private long? _startTimeFilterRelativeValue = null;
		private long? _startTimeFilterResolution = null;
		private System.DateTime? _endTimeFilterFixedValue = null;
		private long? _endTimeFilterRelativeValue = null;
		private long? _endTimeFilterResolution = null;
		private bool? _interpretedByStaffFilterIsEnabled = null;
		private bool? _interpretedByStaffFilterIncludeCurrentUser = null;
		private bool? _transcribedByStaffFilterIsEnabled = null;
		private bool? _transcribedByStaffFilterIncludeCurrentUser = null;
		private bool? _verifiedByStaffFilterIsEnabled = null;
		private bool? _verifiedByStaffFilterIncludeCurrentUser = null;
		private bool? _supervisedByStaffFilterIsEnabled = null;
		private bool? _supervisedByStaffFilterIncludeCurrentUser = null;
		
		private StaffGroup _staffGroup = null;
		private Staff _staff = null;
		
		
		#endregion

        #region Constructors

        public Worklist() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_discriminator);
			sb.Append(_version);
			sb.Append(_fullClassName);
			sb.Append(_name);
			sb.Append(_description);
			sb.Append(_procedureTypeGroupFilterIsEnabled);
			sb.Append(_facilityFilterIsEnabled);
			sb.Append(_facilityFilterIncludeWorkingFacility);
			sb.Append(_patientClassFilterIsEnabled);
			sb.Append(_patientLocationFilterIsEnabled);
			sb.Append(_orderPriorityFilterIsEnabled);
			sb.Append(_orderingPractitionerFilterIsEnabled);
			sb.Append(_portableFilterIsEnabled);
			sb.Append(_portableFilterValue);
			sb.Append(_timeFilterIsEnabled);
			sb.Append(_startTimeFilterFixedValue);
			sb.Append(_startTimeFilterRelativeValue);
			sb.Append(_startTimeFilterResolution);
			sb.Append(_endTimeFilterFixedValue);
			sb.Append(_endTimeFilterRelativeValue);
			sb.Append(_endTimeFilterResolution);
			sb.Append(_interpretedByStaffFilterIsEnabled);
			sb.Append(_interpretedByStaffFilterIncludeCurrentUser);
			sb.Append(_transcribedByStaffFilterIsEnabled);
			sb.Append(_transcribedByStaffFilterIncludeCurrentUser);
			sb.Append(_verifiedByStaffFilterIsEnabled);
			sb.Append(_verifiedByStaffFilterIncludeCurrentUser);
			sb.Append(_supervisedByStaffFilterIsEnabled);
			sb.Append(_supervisedByStaffFilterIncludeCurrentUser);

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
		
		public virtual string FullClassName
        {
            get { return _fullClassName; }
			set
			{
				OnFullClassNameChanging();
				_fullClassName = value;
				OnFullClassNameChanged();
			}
        }
		partial void OnFullClassNameChanging();
		partial void OnFullClassNameChanged();
		
		public virtual string Name
        {
            get { return _name; }
			set
			{
				OnNameChanging();
				_name = value;
				OnNameChanged();
			}
        }
		partial void OnNameChanging();
		partial void OnNameChanged();
		
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
		
		public virtual bool? ProcedureTypeGroupFilterIsEnabled
        {
            get { return _procedureTypeGroupFilterIsEnabled; }
			set
			{
				OnProcedureTypeGroupFilterIsEnabledChanging();
				_procedureTypeGroupFilterIsEnabled = value;
				OnProcedureTypeGroupFilterIsEnabledChanged();
			}
        }
		partial void OnProcedureTypeGroupFilterIsEnabledChanging();
		partial void OnProcedureTypeGroupFilterIsEnabledChanged();
		
		public virtual bool? FacilityFilterIsEnabled
        {
            get { return _facilityFilterIsEnabled; }
			set
			{
				OnFacilityFilterIsEnabledChanging();
				_facilityFilterIsEnabled = value;
				OnFacilityFilterIsEnabledChanged();
			}
        }
		partial void OnFacilityFilterIsEnabledChanging();
		partial void OnFacilityFilterIsEnabledChanged();
		
		public virtual bool? FacilityFilterIncludeWorkingFacility
        {
            get { return _facilityFilterIncludeWorkingFacility; }
			set
			{
				OnFacilityFilterIncludeWorkingFacilityChanging();
				_facilityFilterIncludeWorkingFacility = value;
				OnFacilityFilterIncludeWorkingFacilityChanged();
			}
        }
		partial void OnFacilityFilterIncludeWorkingFacilityChanging();
		partial void OnFacilityFilterIncludeWorkingFacilityChanged();
		
		public virtual bool? PatientClassFilterIsEnabled
        {
            get { return _patientClassFilterIsEnabled; }
			set
			{
				OnPatientClassFilterIsEnabledChanging();
				_patientClassFilterIsEnabled = value;
				OnPatientClassFilterIsEnabledChanged();
			}
        }
		partial void OnPatientClassFilterIsEnabledChanging();
		partial void OnPatientClassFilterIsEnabledChanged();
		
		public virtual bool? PatientLocationFilterIsEnabled
        {
            get { return _patientLocationFilterIsEnabled; }
			set
			{
				OnPatientLocationFilterIsEnabledChanging();
				_patientLocationFilterIsEnabled = value;
				OnPatientLocationFilterIsEnabledChanged();
			}
        }
		partial void OnPatientLocationFilterIsEnabledChanging();
		partial void OnPatientLocationFilterIsEnabledChanged();
		
		public virtual bool? OrderPriorityFilterIsEnabled
        {
            get { return _orderPriorityFilterIsEnabled; }
			set
			{
				OnOrderPriorityFilterIsEnabledChanging();
				_orderPriorityFilterIsEnabled = value;
				OnOrderPriorityFilterIsEnabledChanged();
			}
        }
		partial void OnOrderPriorityFilterIsEnabledChanging();
		partial void OnOrderPriorityFilterIsEnabledChanged();
		
		public virtual bool? OrderingPractitionerFilterIsEnabled
        {
            get { return _orderingPractitionerFilterIsEnabled; }
			set
			{
				OnOrderingPractitionerFilterIsEnabledChanging();
				_orderingPractitionerFilterIsEnabled = value;
				OnOrderingPractitionerFilterIsEnabledChanged();
			}
        }
		partial void OnOrderingPractitionerFilterIsEnabledChanging();
		partial void OnOrderingPractitionerFilterIsEnabledChanged();
		
		public virtual bool? PortableFilterIsEnabled
        {
            get { return _portableFilterIsEnabled; }
			set
			{
				OnPortableFilterIsEnabledChanging();
				_portableFilterIsEnabled = value;
				OnPortableFilterIsEnabledChanged();
			}
        }
		partial void OnPortableFilterIsEnabledChanging();
		partial void OnPortableFilterIsEnabledChanged();
		
		public virtual bool? PortableFilterValue
        {
            get { return _portableFilterValue; }
			set
			{
				OnPortableFilterValueChanging();
				_portableFilterValue = value;
				OnPortableFilterValueChanged();
			}
        }
		partial void OnPortableFilterValueChanging();
		partial void OnPortableFilterValueChanged();
		
		public virtual bool? TimeFilterIsEnabled
        {
            get { return _timeFilterIsEnabled; }
			set
			{
				OnTimeFilterIsEnabledChanging();
				_timeFilterIsEnabled = value;
				OnTimeFilterIsEnabledChanged();
			}
        }
		partial void OnTimeFilterIsEnabledChanging();
		partial void OnTimeFilterIsEnabledChanged();
		
		public virtual System.DateTime? StartTimeFilterFixedValue
        {
            get { return _startTimeFilterFixedValue; }
			set
			{
				OnStartTimeFilterFixedValueChanging();
				_startTimeFilterFixedValue = value;
				OnStartTimeFilterFixedValueChanged();
			}
        }
		partial void OnStartTimeFilterFixedValueChanging();
		partial void OnStartTimeFilterFixedValueChanged();
		
		public virtual long? StartTimeFilterRelativeValue
        {
            get { return _startTimeFilterRelativeValue; }
			set
			{
				OnStartTimeFilterRelativeValueChanging();
				_startTimeFilterRelativeValue = value;
				OnStartTimeFilterRelativeValueChanged();
			}
        }
		partial void OnStartTimeFilterRelativeValueChanging();
		partial void OnStartTimeFilterRelativeValueChanged();
		
		public virtual long? StartTimeFilterResolution
        {
            get { return _startTimeFilterResolution; }
			set
			{
				OnStartTimeFilterResolutionChanging();
				_startTimeFilterResolution = value;
				OnStartTimeFilterResolutionChanged();
			}
        }
		partial void OnStartTimeFilterResolutionChanging();
		partial void OnStartTimeFilterResolutionChanged();
		
		public virtual System.DateTime? EndTimeFilterFixedValue
        {
            get { return _endTimeFilterFixedValue; }
			set
			{
				OnEndTimeFilterFixedValueChanging();
				_endTimeFilterFixedValue = value;
				OnEndTimeFilterFixedValueChanged();
			}
        }
		partial void OnEndTimeFilterFixedValueChanging();
		partial void OnEndTimeFilterFixedValueChanged();
		
		public virtual long? EndTimeFilterRelativeValue
        {
            get { return _endTimeFilterRelativeValue; }
			set
			{
				OnEndTimeFilterRelativeValueChanging();
				_endTimeFilterRelativeValue = value;
				OnEndTimeFilterRelativeValueChanged();
			}
        }
		partial void OnEndTimeFilterRelativeValueChanging();
		partial void OnEndTimeFilterRelativeValueChanged();
		
		public virtual long? EndTimeFilterResolution
        {
            get { return _endTimeFilterResolution; }
			set
			{
				OnEndTimeFilterResolutionChanging();
				_endTimeFilterResolution = value;
				OnEndTimeFilterResolutionChanged();
			}
        }
		partial void OnEndTimeFilterResolutionChanging();
		partial void OnEndTimeFilterResolutionChanged();
		
		public virtual bool? InterpretedByStaffFilterIsEnabled
        {
            get { return _interpretedByStaffFilterIsEnabled; }
			set
			{
				OnInterpretedByStaffFilterIsEnabledChanging();
				_interpretedByStaffFilterIsEnabled = value;
				OnInterpretedByStaffFilterIsEnabledChanged();
			}
        }
		partial void OnInterpretedByStaffFilterIsEnabledChanging();
		partial void OnInterpretedByStaffFilterIsEnabledChanged();
		
		public virtual bool? InterpretedByStaffFilterIncludeCurrentUser
        {
            get { return _interpretedByStaffFilterIncludeCurrentUser; }
			set
			{
				OnInterpretedByStaffFilterIncludeCurrentUserChanging();
				_interpretedByStaffFilterIncludeCurrentUser = value;
				OnInterpretedByStaffFilterIncludeCurrentUserChanged();
			}
        }
		partial void OnInterpretedByStaffFilterIncludeCurrentUserChanging();
		partial void OnInterpretedByStaffFilterIncludeCurrentUserChanged();
		
		public virtual bool? TranscribedByStaffFilterIsEnabled
        {
            get { return _transcribedByStaffFilterIsEnabled; }
			set
			{
				OnTranscribedByStaffFilterIsEnabledChanging();
				_transcribedByStaffFilterIsEnabled = value;
				OnTranscribedByStaffFilterIsEnabledChanged();
			}
        }
		partial void OnTranscribedByStaffFilterIsEnabledChanging();
		partial void OnTranscribedByStaffFilterIsEnabledChanged();
		
		public virtual bool? TranscribedByStaffFilterIncludeCurrentUser
        {
            get { return _transcribedByStaffFilterIncludeCurrentUser; }
			set
			{
				OnTranscribedByStaffFilterIncludeCurrentUserChanging();
				_transcribedByStaffFilterIncludeCurrentUser = value;
				OnTranscribedByStaffFilterIncludeCurrentUserChanged();
			}
        }
		partial void OnTranscribedByStaffFilterIncludeCurrentUserChanging();
		partial void OnTranscribedByStaffFilterIncludeCurrentUserChanged();
		
		public virtual bool? VerifiedByStaffFilterIsEnabled
        {
            get { return _verifiedByStaffFilterIsEnabled; }
			set
			{
				OnVerifiedByStaffFilterIsEnabledChanging();
				_verifiedByStaffFilterIsEnabled = value;
				OnVerifiedByStaffFilterIsEnabledChanged();
			}
        }
		partial void OnVerifiedByStaffFilterIsEnabledChanging();
		partial void OnVerifiedByStaffFilterIsEnabledChanged();
		
		public virtual bool? VerifiedByStaffFilterIncludeCurrentUser
        {
            get { return _verifiedByStaffFilterIncludeCurrentUser; }
			set
			{
				OnVerifiedByStaffFilterIncludeCurrentUserChanging();
				_verifiedByStaffFilterIncludeCurrentUser = value;
				OnVerifiedByStaffFilterIncludeCurrentUserChanged();
			}
        }
		partial void OnVerifiedByStaffFilterIncludeCurrentUserChanging();
		partial void OnVerifiedByStaffFilterIncludeCurrentUserChanged();
		
		public virtual bool? SupervisedByStaffFilterIsEnabled
        {
            get { return _supervisedByStaffFilterIsEnabled; }
			set
			{
				OnSupervisedByStaffFilterIsEnabledChanging();
				_supervisedByStaffFilterIsEnabled = value;
				OnSupervisedByStaffFilterIsEnabledChanged();
			}
        }
		partial void OnSupervisedByStaffFilterIsEnabledChanging();
		partial void OnSupervisedByStaffFilterIsEnabledChanged();
		
		public virtual bool? SupervisedByStaffFilterIncludeCurrentUser
        {
            get { return _supervisedByStaffFilterIncludeCurrentUser; }
			set
			{
				OnSupervisedByStaffFilterIncludeCurrentUserChanging();
				_supervisedByStaffFilterIncludeCurrentUser = value;
				OnSupervisedByStaffFilterIncludeCurrentUserChanged();
			}
        }
		partial void OnSupervisedByStaffFilterIncludeCurrentUserChanging();
		partial void OnSupervisedByStaffFilterIncludeCurrentUserChanged();
		
		public virtual StaffGroup StaffGroup
        {
            get { return _staffGroup; }
			set
			{
				OnStaffGroupChanging();
				_staffGroup = value;
				OnStaffGroupChanged();
			}
        }
		partial void OnStaffGroupChanging();
		partial void OnStaffGroupChanged();
		
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
		
        #endregion
    }
}
