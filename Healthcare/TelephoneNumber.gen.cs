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
    /// TelephoneNumber component
    /// </summary>
	public sealed partial class TelephoneNumber : ValueObject, IEquatable<TelephoneNumber>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _countryCode;
	  	
	  	private string _areaCode;
	  	
	  	private string _number;
	  	
	  	private string _extension;
	  	
	  	private ClearCanvas.Healthcare.TelephoneUseEnum _use;
	  	
	  	private ClearCanvas.Healthcare.TelephoneEquipmentEnum _equipment;
	  	
	  	private ClearCanvas.Healthcare.DateTimeRange _validRange;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public TelephoneNumber()
	  	{
		 	
		  	_validRange = new ClearCanvas.Healthcare.DateTimeRange();
		  	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public TelephoneNumber(string countrycode1, string areacode1, string number1, string extension1, ClearCanvas.Healthcare.TelephoneUseEnum use1, ClearCanvas.Healthcare.TelephoneEquipmentEnum equipment1, ClearCanvas.Healthcare.DateTimeRange validrange1)
	  	{
		  	CustomInitialize();

			
		  	_countryCode = countrycode1;
		  	
		  	_areaCode = areacode1;
		  	
		  	_number = number1;
		  	
		  	_extension = extension1;
		  	
		  	_use = use1;
		  	
		  	_equipment = equipment1;
		  	
		  	_validRange = validrange1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Length(10)]
	  	public string CountryCode
	  	{
			
			get { return _countryCode; }
			
			
			set { _countryCode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(10)]
	  	public string AreaCode
	  	{
			
			get { return _areaCode; }
			
			
			set { _areaCode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(10)]
	  	public string Number
	  	{
			
			get { return _number; }
			
			
			set { _number = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(10)]
	  	public string Extension
	  	{
			
			get { return _extension; }
			
			
			set { _extension = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.TelephoneUseEnum Use
	  	{
			
			get { return _use; }
			
			
			set { _use = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.TelephoneEquipmentEnum Equipment
	  	{
			
			get { return _equipment; }
			
			
			set { _equipment = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.DateTimeRange ValidRange
	  	{
			
			get { return _validRange; }
			
			
			set { _validRange = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(TelephoneNumber that)
		{
			return (that != null) &&
	  	
			((this._countryCode == default(string)) ? (that._countryCode == default(string)) : this._countryCode.Equals(that._countryCode)) &&
	  	
			((this._areaCode == default(string)) ? (that._areaCode == default(string)) : this._areaCode.Equals(that._areaCode)) &&
	  	
			((this._number == default(string)) ? (that._number == default(string)) : this._number.Equals(that._number)) &&
	  	
			((this._extension == default(string)) ? (that._extension == default(string)) : this._extension.Equals(that._extension)) &&
	  	
			((this._use == default(ClearCanvas.Healthcare.TelephoneUseEnum)) ? (that._use == default(ClearCanvas.Healthcare.TelephoneUseEnum)) : this._use.Equals(that._use)) &&
	  	
			((this._equipment == default(ClearCanvas.Healthcare.TelephoneEquipmentEnum)) ? (that._equipment == default(ClearCanvas.Healthcare.TelephoneEquipmentEnum)) : this._equipment.Equals(that._equipment)) &&
	  	
			((this._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) ? (that._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) : this._validRange.Equals(that._validRange)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as TelephoneNumber);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_countryCode == default(string) ? 0 : _countryCode.GetHashCode()) ^
	  	
				(_areaCode == default(string) ? 0 : _areaCode.GetHashCode()) ^
	  	
				(_number == default(string) ? 0 : _number.GetHashCode()) ^
	  	
				(_extension == default(string) ? 0 : _extension.GetHashCode()) ^
	  	
				(_use == default(ClearCanvas.Healthcare.TelephoneUseEnum) ? 0 : _use.GetHashCode()) ^
	  	
				(_equipment == default(ClearCanvas.Healthcare.TelephoneEquipmentEnum) ? 0 : _equipment.GetHashCode()) ^
	  	
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
			TelephoneNumber clone = new TelephoneNumber();
		
			clone._validRange = (this._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) ? default(ClearCanvas.Healthcare.DateTimeRange) : (ClearCanvas.Healthcare.DateTimeRange)this._validRange.Clone();
		
		
	  		clone._countryCode = this._countryCode;
		
	  		clone._areaCode = this._areaCode;
		
	  		clone._number = this._number;
		
	  		clone._extension = this._extension;
		
	  		clone._use = this._use;
		
	  		clone._equipment = this._equipment;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("CountryCode", _countryCode);
		  	
		  	writer.WriteProperty("AreaCode", _areaCode);
		  	
		  	writer.WriteProperty("Number", _number);
		  	
		  	writer.WriteProperty("Extension", _extension);
		  	
		  	writer.WriteProperty("Use", _use);
		  	
		  	writer.WriteProperty("Equipment", _equipment);
		  	
		  	writer.WriteProperty("ValidRange", _validRange);
		  	
		}

		#endregion
	}
}
