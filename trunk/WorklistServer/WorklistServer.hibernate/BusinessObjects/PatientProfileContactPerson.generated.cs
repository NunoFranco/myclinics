using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class PatientProfileContactPerson : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _name = String.Empty;
		private string _address = null;
		private string _homePhone = null;
		private string _businessPhone = null;
		
		private PatientProfile _patientProfile = null;
		private ContactPersonRelationshipEnum _contactPersonRelationshipEnum = null;
		private ContactPersonTypeEnum _contactPersonTypeEnum = null;
		
		
		#endregion

        #region Constructors

        public PatientProfileContactPerson() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_name);
			sb.Append(_address);
			sb.Append(_homePhone);
			sb.Append(_businessPhone);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

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
		
		public virtual string Address
        {
            get { return _address; }
			set
			{
				OnAddressChanging();
				_address = value;
				OnAddressChanged();
			}
        }
		partial void OnAddressChanging();
		partial void OnAddressChanged();
		
		public virtual string HomePhone
        {
            get { return _homePhone; }
			set
			{
				OnHomePhoneChanging();
				_homePhone = value;
				OnHomePhoneChanged();
			}
        }
		partial void OnHomePhoneChanging();
		partial void OnHomePhoneChanged();
		
		public virtual string BusinessPhone
        {
            get { return _businessPhone; }
			set
			{
				OnBusinessPhoneChanging();
				_businessPhone = value;
				OnBusinessPhoneChanged();
			}
        }
		partial void OnBusinessPhoneChanging();
		partial void OnBusinessPhoneChanged();
		
		public virtual PatientProfile PatientProfile
        {
            get { return _patientProfile; }
			set
			{
				OnPatientProfileChanging();
				_patientProfile = value;
				OnPatientProfileChanged();
			}
        }
		partial void OnPatientProfileChanging();
		partial void OnPatientProfileChanged();
		
		public virtual ContactPersonRelationshipEnum ContactPersonRelationshipEnum
        {
            get { return _contactPersonRelationshipEnum; }
			set
			{
				OnContactPersonRelationshipEnumChanging();
				_contactPersonRelationshipEnum = value;
				OnContactPersonRelationshipEnumChanged();
			}
        }
		partial void OnContactPersonRelationshipEnumChanging();
		partial void OnContactPersonRelationshipEnumChanged();
		
		public virtual ContactPersonTypeEnum ContactPersonTypeEnum
        {
            get { return _contactPersonTypeEnum; }
			set
			{
				OnContactPersonTypeEnumChanging();
				_contactPersonTypeEnum = value;
				OnContactPersonTypeEnumChanged();
			}
        }
		partial void OnContactPersonTypeEnumChanging();
		partial void OnContactPersonTypeEnumChanged();
		
        #endregion
    }
}
