using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ExternalPractitionerContactPointAddress : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _street = String.Empty;
		private string _unit = null;
		private string _city = String.Empty;
		private string _province = String.Empty;
		private string _postalCode = null;
		private string _country = null;
		private System.DateTime? _validFrom = null;
		private System.DateTime? _validUntil = null;
		
		private ExternalPractitionerContactPoint _externalPractitionerContactPoint = null;
		private AddressTypeEnum _addressTypeEnum = null;
		
		
		#endregion

        #region Constructors

        public ExternalPractitionerContactPointAddress() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_street);
			sb.Append(_unit);
			sb.Append(_city);
			sb.Append(_province);
			sb.Append(_postalCode);
			sb.Append(_country);
			sb.Append(_validFrom);
			sb.Append(_validUntil);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string Street
        {
            get { return _street; }
			set
			{
				OnStreetChanging();
				_street = value;
				OnStreetChanged();
			}
        }
		partial void OnStreetChanging();
		partial void OnStreetChanged();
		
		public virtual string Unit
        {
            get { return _unit; }
			set
			{
				OnUnitChanging();
				_unit = value;
				OnUnitChanged();
			}
        }
		partial void OnUnitChanging();
		partial void OnUnitChanged();
		
		public virtual string City
        {
            get { return _city; }
			set
			{
				OnCityChanging();
				_city = value;
				OnCityChanged();
			}
        }
		partial void OnCityChanging();
		partial void OnCityChanged();
		
		public virtual string Province
        {
            get { return _province; }
			set
			{
				OnProvinceChanging();
				_province = value;
				OnProvinceChanged();
			}
        }
		partial void OnProvinceChanging();
		partial void OnProvinceChanged();
		
		public virtual string PostalCode
        {
            get { return _postalCode; }
			set
			{
				OnPostalCodeChanging();
				_postalCode = value;
				OnPostalCodeChanged();
			}
        }
		partial void OnPostalCodeChanging();
		partial void OnPostalCodeChanged();
		
		public virtual string Country
        {
            get { return _country; }
			set
			{
				OnCountryChanging();
				_country = value;
				OnCountryChanged();
			}
        }
		partial void OnCountryChanging();
		partial void OnCountryChanged();
		
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
		
		public virtual ExternalPractitionerContactPoint ExternalPractitionerContactPoint
        {
            get { return _externalPractitionerContactPoint; }
			set
			{
				OnExternalPractitionerContactPointChanging();
				_externalPractitionerContactPoint = value;
				OnExternalPractitionerContactPointChanged();
			}
        }
		partial void OnExternalPractitionerContactPointChanging();
		partial void OnExternalPractitionerContactPointChanged();
		
		public virtual AddressTypeEnum AddressTypeEnum
        {
            get { return _addressTypeEnum; }
			set
			{
				OnAddressTypeEnumChanging();
				_addressTypeEnum = value;
				OnAddressTypeEnumChanged();
			}
        }
		partial void OnAddressTypeEnumChanging();
		partial void OnAddressTypeEnumChanged();
		
        #endregion
    }
}
