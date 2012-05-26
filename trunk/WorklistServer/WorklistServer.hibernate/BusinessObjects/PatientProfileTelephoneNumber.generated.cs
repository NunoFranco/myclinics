using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class PatientProfileTelephoneNumber : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _countryCode = null;
		private string _areaCode = null;
		private string _number = String.Empty;
		private string _extension = null;
		private System.DateTime? _validFrom = null;
		private System.DateTime? _validUntil = null;
		
		private TelephoneEquipmentEnum _telephoneEquipmentEnum = null;
		private PatientProfile _patientProfile = null;
		private TelephoneUseEnum _telephoneUseEnum = null;
		
		
		#endregion

        #region Constructors

        public PatientProfileTelephoneNumber() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_countryCode);
			sb.Append(_areaCode);
			sb.Append(_number);
			sb.Append(_extension);
			sb.Append(_validFrom);
			sb.Append(_validUntil);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string CountryCode
        {
            get { return _countryCode; }
			set
			{
				OnCountryCodeChanging();
				_countryCode = value;
				OnCountryCodeChanged();
			}
        }
		partial void OnCountryCodeChanging();
		partial void OnCountryCodeChanged();
		
		public virtual string AreaCode
        {
            get { return _areaCode; }
			set
			{
				OnAreaCodeChanging();
				_areaCode = value;
				OnAreaCodeChanged();
			}
        }
		partial void OnAreaCodeChanging();
		partial void OnAreaCodeChanged();
		
		public virtual string Number
        {
            get { return _number; }
			set
			{
				OnNumberChanging();
				_number = value;
				OnNumberChanged();
			}
        }
		partial void OnNumberChanging();
		partial void OnNumberChanged();
		
		public virtual string Extension
        {
            get { return _extension; }
			set
			{
				OnExtensionChanging();
				_extension = value;
				OnExtensionChanged();
			}
        }
		partial void OnExtensionChanging();
		partial void OnExtensionChanged();
		
		public virtual System.DateTime? ValidFrom
        {
            get { return _validFrom; }
			set
			{
				OnValidFromChanging();
				_validFrom = value;
				OnValidFromChanged();
			}
        }
		partial void OnValidFromChanging();
		partial void OnValidFromChanged();
		
		public virtual System.DateTime? ValidUntil
        {
            get { return _validUntil; }
			set
			{
				OnValidUntilChanging();
				_validUntil = value;
				OnValidUntilChanged();
			}
        }
		partial void OnValidUntilChanging();
		partial void OnValidUntilChanged();
		
		public virtual TelephoneEquipmentEnum TelephoneEquipmentEnum
        {
            get { return _telephoneEquipmentEnum; }
			set
			{
				OnTelephoneEquipmentEnumChanging();
				_telephoneEquipmentEnum = value;
				OnTelephoneEquipmentEnumChanged();
			}
        }
		partial void OnTelephoneEquipmentEnumChanging();
		partial void OnTelephoneEquipmentEnumChanged();
		
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
		
		public virtual TelephoneUseEnum TelephoneUseEnum
        {
            get { return _telephoneUseEnum; }
			set
			{
				OnTelephoneUseEnumChanging();
				_telephoneUseEnum = value;
				OnTelephoneUseEnumChanged();
			}
        }
		partial void OnTelephoneUseEnumChanging();
		partial void OnTelephoneUseEnumChanged();
		
        #endregion
    }
}
