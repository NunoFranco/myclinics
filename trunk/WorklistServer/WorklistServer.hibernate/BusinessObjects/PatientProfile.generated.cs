using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class PatientProfile : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _mrnId = String.Empty;
		private string _healthcardId = null;
		private string _healthcardVersionCode = null;
		private System.DateTime? _healthcardExpiryDate = null;
		private string _familyName = String.Empty;
		private string _givenName = String.Empty;
		private string _middleName = null;
		private string _prefix = null;
		private string _suffix = null;
		private string _degree = null;
		private System.DateTime? _dateOfBirth = null;
		private bool _deathIndicator = default(Boolean);
		private System.DateTime? _timeOfDeath = null;
		
		private InsuranceAuthorityEnum _insuranceAuthorityEnum = null;
		private InformationAuthorityEnum _informationAuthorityEnum = null;
		private Patient _patient = null;
		private SpokenLanguageEnum _spokenLanguageEnum = null;
		private ReligionEnum _religionEnum = null;
		private SexEnum _sexEnum = null;
		
		private IList<PatientProfileContactPerson> _patientProfileContactPeople = new List<PatientProfileContactPerson>();
		private IList<PatientProfileAddress> _patientProfileAddresses = new List<PatientProfileAddress>();
		private IList<PatientProfileEmailAddress> _patientProfileEmailAddresses = new List<PatientProfileEmailAddress>();
		private IList<PatientProfileExpiredMrn> _patientProfileExpiredMrns = new List<PatientProfileExpiredMrn>();
		private IList<PatientProfileTelephoneNumber> _patientProfileTelephoneNumbers = new List<PatientProfileTelephoneNumber>();
		
		#endregion

        #region Constructors

        public PatientProfile() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_mrnId);
			sb.Append(_healthcardId);
			sb.Append(_healthcardVersionCode);
			sb.Append(_healthcardExpiryDate);
			sb.Append(_familyName);
			sb.Append(_givenName);
			sb.Append(_middleName);
			sb.Append(_prefix);
			sb.Append(_suffix);
			sb.Append(_degree);
			sb.Append(_dateOfBirth);
			sb.Append(_deathIndicator);
			sb.Append(_timeOfDeath);

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
		
		public virtual string MrnId
        {
            get { return _mrnId; }
			set
			{
				OnMrnIdChanging();
				_mrnId = value;
				OnMrnIdChanged();
			}
        }
		partial void OnMrnIdChanging();
		partial void OnMrnIdChanged();
		
		public virtual string HealthcardId
        {
            get { return _healthcardId; }
			set
			{
				OnHealthcardIdChanging();
				_healthcardId = value;
				OnHealthcardIdChanged();
			}
        }
		partial void OnHealthcardIdChanging();
		partial void OnHealthcardIdChanged();
		
		public virtual string HealthcardVersionCode
        {
            get { return _healthcardVersionCode; }
			set
			{
				OnHealthcardVersionCodeChanging();
				_healthcardVersionCode = value;
				OnHealthcardVersionCodeChanged();
			}
        }
		partial void OnHealthcardVersionCodeChanging();
		partial void OnHealthcardVersionCodeChanged();
		
		public virtual System.DateTime? HealthcardExpiryDate
        {
            get { return _healthcardExpiryDate; }
			set
			{
				OnHealthcardExpiryDateChanging();
				_healthcardExpiryDate = value;
				OnHealthcardExpiryDateChanged();
			}
        }
		partial void OnHealthcardExpiryDateChanging();
		partial void OnHealthcardExpiryDateChanged();
		
		public virtual string FamilyName
        {
            get { return _familyName; }
			set
			{
				OnFamilyNameChanging();
				_familyName = value;
				OnFamilyNameChanged();
			}
        }
		partial void OnFamilyNameChanging();
		partial void OnFamilyNameChanged();
		
		public virtual string GivenName
        {
            get { return _givenName; }
			set
			{
				OnGivenNameChanging();
				_givenName = value;
				OnGivenNameChanged();
			}
        }
		partial void OnGivenNameChanging();
		partial void OnGivenNameChanged();
		
		public virtual string MiddleName
        {
            get { return _middleName; }
			set
			{
				OnMiddleNameChanging();
				_middleName = value;
				OnMiddleNameChanged();
			}
        }
		partial void OnMiddleNameChanging();
		partial void OnMiddleNameChanged();
		
		public virtual string Prefix
        {
            get { return _prefix; }
			set
			{
				OnPrefixChanging();
				_prefix = value;
				OnPrefixChanged();
			}
        }
		partial void OnPrefixChanging();
		partial void OnPrefixChanged();
		
		public virtual string Suffix
        {
            get { return _suffix; }
			set
			{
				OnSuffixChanging();
				_suffix = value;
				OnSuffixChanged();
			}
        }
		partial void OnSuffixChanging();
		partial void OnSuffixChanged();
		
		public virtual string Degree
        {
            get { return _degree; }
			set
			{
				OnDegreeChanging();
				_degree = value;
				OnDegreeChanged();
			}
        }
		partial void OnDegreeChanging();
		partial void OnDegreeChanged();
		
		public virtual System.DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
			set
			{
				OnDateOfBirthChanging();
				_dateOfBirth = value;
				OnDateOfBirthChanged();
			}
        }
		partial void OnDateOfBirthChanging();
		partial void OnDateOfBirthChanged();
		
		public virtual bool DeathIndicator
        {
            get { return _deathIndicator; }
			set
			{
				OnDeathIndicatorChanging();
				_deathIndicator = value;
				OnDeathIndicatorChanged();
			}
        }
		partial void OnDeathIndicatorChanging();
		partial void OnDeathIndicatorChanged();
		
		public virtual System.DateTime? TimeOfDeath
        {
            get { return _timeOfDeath; }
			set
			{
				OnTimeOfDeathChanging();
				_timeOfDeath = value;
				OnTimeOfDeathChanged();
			}
        }
		partial void OnTimeOfDeathChanging();
		partial void OnTimeOfDeathChanged();
		
		public virtual InsuranceAuthorityEnum InsuranceAuthorityEnum
        {
            get { return _insuranceAuthorityEnum; }
			set
			{
				OnInsuranceAuthorityEnumChanging();
				_insuranceAuthorityEnum = value;
				OnInsuranceAuthorityEnumChanged();
			}
        }
		partial void OnInsuranceAuthorityEnumChanging();
		partial void OnInsuranceAuthorityEnumChanged();
		
		public virtual InformationAuthorityEnum InformationAuthorityEnum
        {
            get { return _informationAuthorityEnum; }
			set
			{
				OnInformationAuthorityEnumChanging();
				_informationAuthorityEnum = value;
				OnInformationAuthorityEnumChanged();
			}
        }
		partial void OnInformationAuthorityEnumChanging();
		partial void OnInformationAuthorityEnumChanged();
		
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
		
		public virtual SpokenLanguageEnum SpokenLanguageEnum
        {
            get { return _spokenLanguageEnum; }
			set
			{
				OnSpokenLanguageEnumChanging();
				_spokenLanguageEnum = value;
				OnSpokenLanguageEnumChanged();
			}
        }
		partial void OnSpokenLanguageEnumChanging();
		partial void OnSpokenLanguageEnumChanged();
		
		public virtual ReligionEnum ReligionEnum
        {
            get { return _religionEnum; }
			set
			{
				OnReligionEnumChanging();
				_religionEnum = value;
				OnReligionEnumChanged();
			}
        }
		partial void OnReligionEnumChanging();
		partial void OnReligionEnumChanged();
		
		public virtual SexEnum SexEnum
        {
            get { return _sexEnum; }
			set
			{
				OnSexEnumChanging();
				_sexEnum = value;
				OnSexEnumChanged();
			}
        }
		partial void OnSexEnumChanging();
		partial void OnSexEnumChanged();
		
		public virtual IList<PatientProfileContactPerson> PatientProfileContactPeople
        {
            get { return _patientProfileContactPeople; }
            set
			{
				OnPatientProfileContactPeopleChanging();
				_patientProfileContactPeople = value;
				OnPatientProfileContactPeopleChanged();
			}
        }
		partial void OnPatientProfileContactPeopleChanging();
		partial void OnPatientProfileContactPeopleChanged();
		
		public virtual IList<PatientProfileAddress> PatientProfileAddresses
        {
            get { return _patientProfileAddresses; }
            set
			{
				OnPatientProfileAddressesChanging();
				_patientProfileAddresses = value;
				OnPatientProfileAddressesChanged();
			}
        }
		partial void OnPatientProfileAddressesChanging();
		partial void OnPatientProfileAddressesChanged();
		
		public virtual IList<PatientProfileEmailAddress> PatientProfileEmailAddresses
        {
            get { return _patientProfileEmailAddresses; }
            set
			{
				OnPatientProfileEmailAddressesChanging();
				_patientProfileEmailAddresses = value;
				OnPatientProfileEmailAddressesChanged();
			}
        }
		partial void OnPatientProfileEmailAddressesChanging();
		partial void OnPatientProfileEmailAddressesChanged();
		
		public virtual IList<PatientProfileExpiredMrn> PatientProfileExpiredMrns
        {
            get { return _patientProfileExpiredMrns; }
            set
			{
				OnPatientProfileExpiredMrnsChanging();
				_patientProfileExpiredMrns = value;
				OnPatientProfileExpiredMrnsChanged();
			}
        }
		partial void OnPatientProfileExpiredMrnsChanging();
		partial void OnPatientProfileExpiredMrnsChanged();
		
		public virtual IList<PatientProfileTelephoneNumber> PatientProfileTelephoneNumbers
        {
            get { return _patientProfileTelephoneNumbers; }
            set
			{
				OnPatientProfileTelephoneNumbersChanging();
				_patientProfileTelephoneNumbers = value;
				OnPatientProfileTelephoneNumbersChanged();
			}
        }
		partial void OnPatientProfileTelephoneNumbersChanging();
		partial void OnPatientProfileTelephoneNumbersChanged();
		
        #endregion
    }
}
