using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class TelephoneEquipmentEnum : BusinessBase<string>
    {
        #region Declarations

		private string _value = null;
		private string _description = null;
		private float? _displayOrder = null;
		private bool _deactivated = default(Boolean);
		
		
		private IList<ExternalPractitionerContactPointTelephoneNumber> _externalPractitionerContactPointTelephoneNumbers = new List<ExternalPractitionerContactPointTelephoneNumber>();
		private IList<PatientProfileTelephoneNumber> _patientProfileTelephoneNumbers = new List<PatientProfileTelephoneNumber>();
		private IList<StaffTelephoneNumber> _staffTelephoneNumbers = new List<StaffTelephoneNumber>();
		
		#endregion

        #region Constructors

        public TelephoneEquipmentEnum() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_value);
			sb.Append(_description);
			sb.Append(_displayOrder);
			sb.Append(_deactivated);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string Value
        {
            get { return _value; }
			set
			{
				OnValueChanging();
				_value = value;
				OnValueChanged();
			}
        }
		partial void OnValueChanging();
		partial void OnValueChanged();
		
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
		
		public virtual float? DisplayOrder
        {
            get { return _displayOrder; }
			set
			{
				OnDisplayOrderChanging();
				_displayOrder = value;
				OnDisplayOrderChanged();
			}
        }
		partial void OnDisplayOrderChanging();
		partial void OnDisplayOrderChanged();
		
		public virtual bool Deactivated
        {
            get { return _deactivated; }
			set
			{
				OnDeactivatedChanging();
				_deactivated = value;
				OnDeactivatedChanged();
			}
        }
		partial void OnDeactivatedChanging();
		partial void OnDeactivatedChanged();
		
		public virtual IList<ExternalPractitionerContactPointTelephoneNumber> ExternalPractitionerContactPointTelephoneNumbers
        {
            get { return _externalPractitionerContactPointTelephoneNumbers; }
            set
			{
				OnExternalPractitionerContactPointTelephoneNumbersChanging();
				_externalPractitionerContactPointTelephoneNumbers = value;
				OnExternalPractitionerContactPointTelephoneNumbersChanged();
			}
        }
		partial void OnExternalPractitionerContactPointTelephoneNumbersChanging();
		partial void OnExternalPractitionerContactPointTelephoneNumbersChanged();
		
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
		
		public virtual IList<StaffTelephoneNumber> StaffTelephoneNumbers
        {
            get { return _staffTelephoneNumbers; }
            set
			{
				OnStaffTelephoneNumbersChanging();
				_staffTelephoneNumbers = value;
				OnStaffTelephoneNumbersChanged();
			}
        }
		partial void OnStaffTelephoneNumbersChanging();
		partial void OnStaffTelephoneNumbersChanged();
		
        #endregion
    }
}
