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
    /// PersonName component
    /// </summary>
	public sealed partial class PersonName : ValueObject, IEquatable<PersonName>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _familyName;
	  	
	  	private string _givenName;
	  	
	  	private string _middleName;
	  	
	  	private string _prefix;
	  	
	  	private string _suffix;
	  	
	  	private string _degree;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public PersonName()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public PersonName(string familyname1, string givenname1, string middlename1, string prefix1, string suffix1, string degree1)
	  	{
		  	CustomInitialize();

			
		  	_familyName = familyname1;
		  	
		  	_givenName = givenname1;
		  	
		  	_middleName = middlename1;
		  	
		  	_prefix = prefix1;
		  	
		  	_suffix = suffix1;
		  	
		  	_degree = degree1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(40)]
	  	public string FamilyName
	  	{
			
			get { return _familyName; }
			
			
			set { _familyName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(40)]
	  	public string GivenName
	  	{
			
			get { return _givenName; }
			
			
			set { _givenName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(40)]
	  	public string MiddleName
	  	{
			
			get { return _middleName; }
			
			
			set { _middleName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(10)]
	  	public string Prefix
	  	{
			
			get { return _prefix; }
			
			
			set { _prefix = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(10)]
	  	public string Suffix
	  	{
			
			get { return _suffix; }
			
			
			set { _suffix = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(10)]
	  	public string Degree
	  	{
			
			get { return _degree; }
			
			
			set { _degree = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(PersonName that)
		{
			return (that != null) &&
	  	
			((this._familyName == default(string)) ? (that._familyName == default(string)) : this._familyName.Equals(that._familyName)) &&
	  	
			((this._givenName == default(string)) ? (that._givenName == default(string)) : this._givenName.Equals(that._givenName)) &&
	  	
			((this._middleName == default(string)) ? (that._middleName == default(string)) : this._middleName.Equals(that._middleName)) &&
	  	
			((this._prefix == default(string)) ? (that._prefix == default(string)) : this._prefix.Equals(that._prefix)) &&
	  	
			((this._suffix == default(string)) ? (that._suffix == default(string)) : this._suffix.Equals(that._suffix)) &&
	  	
			((this._degree == default(string)) ? (that._degree == default(string)) : this._degree.Equals(that._degree)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as PersonName);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_familyName == default(string) ? 0 : _familyName.GetHashCode()) ^
	  	
				(_givenName == default(string) ? 0 : _givenName.GetHashCode()) ^
	  	
				(_middleName == default(string) ? 0 : _middleName.GetHashCode()) ^
	  	
				(_prefix == default(string) ? 0 : _prefix.GetHashCode()) ^
	  	
				(_suffix == default(string) ? 0 : _suffix.GetHashCode()) ^
	  	
				(_degree == default(string) ? 0 : _degree.GetHashCode()) ^
	  	
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
			PersonName clone = new PersonName();
		
		
	  		clone._familyName = this._familyName;
		
	  		clone._givenName = this._givenName;
		
	  		clone._middleName = this._middleName;
		
	  		clone._prefix = this._prefix;
		
	  		clone._suffix = this._suffix;
		
	  		clone._degree = this._degree;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("FamilyName", _familyName);
		  	
		  	writer.WriteProperty("GivenName", _givenName);
		  	
		  	writer.WriteProperty("MiddleName", _middleName);
		  	
		  	writer.WriteProperty("Prefix", _prefix);
		  	
		  	writer.WriteProperty("Suffix", _suffix);
		  	
		  	writer.WriteProperty("Degree", _degree);
		  	
		}

		#endregion
	}
}
