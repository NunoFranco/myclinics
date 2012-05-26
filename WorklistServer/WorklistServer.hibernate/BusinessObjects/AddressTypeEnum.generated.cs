using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class AddressTypeEnum : BusinessBase<string>
    {
        #region Declarations

		private string _value = null;
		private string _description = null;
		private float? _displayOrder = null;
		private bool _deactivated = default(Boolean);
		
		
		private IList<PatientProfileAddress> _patientProfileAddresses = new List<PatientProfileAddress>();
		private IList<StaffAddress> _staffAddresses = new List<StaffAddress>();
		private IList<ExternalPractitionerContactPointAddress> _externalPractitionerContactPointAddresses = new List<ExternalPractitionerContactPointAddress>();
		
		#endregion

        #region Constructors

        public AddressTypeEnum() { }

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
		
		public virtual IList<StaffAddress> StaffAddresses
        {
            get { return _staffAddresses; }
            set
			{
				OnStaffAddressesChanging();
				_staffAddresses = value;
				OnStaffAddressesChanged();
			}
        }
		partial void OnStaffAddressesChanging();
		partial void OnStaffAddressesChanged();
		
		public virtual IList<ExternalPractitionerContactPointAddress> ExternalPractitionerContactPointAddresses
        {
            get { return _externalPractitionerContactPointAddresses; }
            set
			{
				OnExternalPractitionerContactPointAddressesChanging();
				_externalPractitionerContactPointAddresses = value;
				OnExternalPractitionerContactPointAddressesChanged();
			}
        }
		partial void OnExternalPractitionerContactPointAddressesChanging();
		partial void OnExternalPractitionerContactPointAddressesChanged();
		
        #endregion
    }
}
