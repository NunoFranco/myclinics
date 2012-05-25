// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using Iesi.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{


    /// <summary>
    /// Address component
    /// </summary>
	public sealed partial class Address : ValueObject, IEquatable<Address>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _street;
	  	
	  	private string _unit;
	  	
	  	private string _city;
	  	
	  	private string _province;
	  	
	  	private string _postalCode;
	  	
	  	private string _country;
	  	
	  	private ClearCanvas.Healthcare.AddressTypeEnum _type;
	  	
	  	private ClearCanvas.Healthcare.DateTimeRange _validRange;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Address()
	  	{
		 	
		  	_validRange = new ClearCanvas.Healthcare.DateTimeRange();
		  	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Address(string street1, string unit1, string city1, string province1, string postalcode1, string country1, ClearCanvas.Healthcare.AddressTypeEnum type1, ClearCanvas.Healthcare.DateTimeRange validrange1)
	  	{
		  	CustomInitialize();

			
		  	_street = street1;
		  	
		  	_unit = unit1;
		  	
		  	_city = city1;
		  	
		  	_province = province1;
		  	
		  	_postalCode = postalcode1;
		  	
		  	_country = country1;
		  	
		  	_type = type1;
		  	
		  	_validRange = validrange1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(100)]
	  	public string Street
	  	{
			
			get { return _street; }
			
			
			set { _street = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public string Unit
	  	{
			
			get { return _unit; }
			
			
			set { _unit = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(50)]
	  	public string City
	  	{
			
			get { return _city; }
			
			
			set { _city = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(50)]
	  	public string Province
	  	{
			
			get { return _province; }
			
			
			set { _province = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(20)]
	  	public string PostalCode
	  	{
			
			get { return _postalCode; }
			
			
			set { _postalCode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public string Country
	  	{
			
			get { return _country; }
			
			
			set { _country = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.AddressTypeEnum Type
	  	{
			
			get { return _type; }
			
			
			set { _type = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.DateTimeRange ValidRange
	  	{
			
			get { return _validRange; }
			
			
			set { _validRange = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(Address that)
		{
			return (that != null) &&
	  	
			((this._street == default(string)) ? (that._street == default(string)) : this._street.Equals(that._street)) &&
	  	
			((this._unit == default(string)) ? (that._unit == default(string)) : this._unit.Equals(that._unit)) &&
	  	
			((this._city == default(string)) ? (that._city == default(string)) : this._city.Equals(that._city)) &&
	  	
			((this._province == default(string)) ? (that._province == default(string)) : this._province.Equals(that._province)) &&
	  	
			((this._postalCode == default(string)) ? (that._postalCode == default(string)) : this._postalCode.Equals(that._postalCode)) &&
	  	
			((this._country == default(string)) ? (that._country == default(string)) : this._country.Equals(that._country)) &&
	  	
			((this._type == default(ClearCanvas.Healthcare.AddressTypeEnum)) ? (that._type == default(ClearCanvas.Healthcare.AddressTypeEnum)) : this._type.Equals(that._type)) &&
	  	
			((this._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) ? (that._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) : this._validRange.Equals(that._validRange)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as Address);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_street == default(string) ? 0 : _street.GetHashCode()) ^
	  	
				(_unit == default(string) ? 0 : _unit.GetHashCode()) ^
	  	
				(_city == default(string) ? 0 : _city.GetHashCode()) ^
	  	
				(_province == default(string) ? 0 : _province.GetHashCode()) ^
	  	
				(_postalCode == default(string) ? 0 : _postalCode.GetHashCode()) ^
	  	
				(_country == default(string) ? 0 : _country.GetHashCode()) ^
	  	
				(_type == default(ClearCanvas.Healthcare.AddressTypeEnum) ? 0 : _type.GetHashCode()) ^
	  	
				(_validRange == default(ClearCanvas.Healthcare.DateTimeRange) ? 0 : _validRange.GetHashCode()) ^
	  	
				0;
		}
				
	  	#endregion
	  	
	  	/// <summary>
	  	/// Returns a clone of this object.  A deep-copy is performed, so the clone will not share
	  	/// any mutable data with this object.
	  	/// NB. Note that collections are not currently supported.  If this object contains collections
	  	/// they will not be cloned.  It should be relatively easy to add collection support when the need arises.
	  	/// </summary>
        public override object Clone()
        {
			Address clone = new Address();
		
			clone._validRange = (this._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) ? default(ClearCanvas.Healthcare.DateTimeRange) : (ClearCanvas.Healthcare.DateTimeRange)this._validRange.Clone();
		
		
	  		clone._street = this._street;
		
	  		clone._unit = this._unit;
		
	  		clone._city = this._city;
		
	  		clone._province = this._province;
		
	  		clone._postalCode = this._postalCode;
		
	  		clone._country = this._country;
		
	  		clone._type = this._type;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Street", _street);
		  	
		  	writer.WriteProperty("Unit", _unit);
		  	
		  	writer.WriteProperty("City", _city);
		  	
		  	writer.WriteProperty("Province", _province);
		  	
		  	writer.WriteProperty("PostalCode", _postalCode);
		  	
		  	writer.WriteProperty("Country", _country);
		  	
		  	writer.WriteProperty("Type", _type);
		  	
		  	writer.WriteProperty("ValidRange", _validRange);
		  	
		}

		#endregion
	}
}
