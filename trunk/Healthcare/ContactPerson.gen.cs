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
    /// ContactPerson component
    /// </summary>
	public sealed partial class ContactPerson : ValueObject, IEquatable<ContactPerson>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _name;
	  	
	  	private string _address;
	  	
	  	private string _homePhone;
	  	
	  	private string _businessPhone;
	  	
	  	private ClearCanvas.Healthcare.ContactPersonTypeEnum _type;
	  	
	  	private ClearCanvas.Healthcare.ContactPersonRelationshipEnum _relationship;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ContactPerson()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ContactPerson(string name1, string address1, string homephone1, string businessphone1, ClearCanvas.Healthcare.ContactPersonTypeEnum type1, ClearCanvas.Healthcare.ContactPersonRelationshipEnum relationship1)
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_address = address1;
		  	
		  	_homePhone = homephone1;
		  	
		  	_businessPhone = businessphone1;
		  	
		  	_type = type1;
		  	
		  	_relationship = relationship1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(50)]
	  	public string Name
	  	{
			
			get { return _name; }
			
			
			set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(255)]
	  	public string Address
	  	{
			
			get { return _address; }
			
			
			set { _address = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(25)]
	  	public string HomePhone
	  	{
			
			get { return _homePhone; }
			
			
			set { _homePhone = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(25)]
	  	public string BusinessPhone
	  	{
			
			get { return _businessPhone; }
			
			
			set { _businessPhone = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.ContactPersonTypeEnum Type
	  	{
			
			get { return _type; }
			
			
			set { _type = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.ContactPersonRelationshipEnum Relationship
	  	{
			
			get { return _relationship; }
			
			
			set { _relationship = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(ContactPerson that)
		{
			return (that != null) &&
	  	
			((this._name == default(string)) ? (that._name == default(string)) : this._name.Equals(that._name)) &&
	  	
			((this._address == default(string)) ? (that._address == default(string)) : this._address.Equals(that._address)) &&
	  	
			((this._homePhone == default(string)) ? (that._homePhone == default(string)) : this._homePhone.Equals(that._homePhone)) &&
	  	
			((this._businessPhone == default(string)) ? (that._businessPhone == default(string)) : this._businessPhone.Equals(that._businessPhone)) &&
	  	
			((this._type == default(ClearCanvas.Healthcare.ContactPersonTypeEnum)) ? (that._type == default(ClearCanvas.Healthcare.ContactPersonTypeEnum)) : this._type.Equals(that._type)) &&
	  	
			((this._relationship == default(ClearCanvas.Healthcare.ContactPersonRelationshipEnum)) ? (that._relationship == default(ClearCanvas.Healthcare.ContactPersonRelationshipEnum)) : this._relationship.Equals(that._relationship)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as ContactPerson);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_name == default(string) ? 0 : _name.GetHashCode()) ^
	  	
				(_address == default(string) ? 0 : _address.GetHashCode()) ^
	  	
				(_homePhone == default(string) ? 0 : _homePhone.GetHashCode()) ^
	  	
				(_businessPhone == default(string) ? 0 : _businessPhone.GetHashCode()) ^
	  	
				(_type == default(ClearCanvas.Healthcare.ContactPersonTypeEnum) ? 0 : _type.GetHashCode()) ^
	  	
				(_relationship == default(ClearCanvas.Healthcare.ContactPersonRelationshipEnum) ? 0 : _relationship.GetHashCode()) ^
	  	
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
			ContactPerson clone = new ContactPerson();
		
		
	  		clone._name = this._name;
		
	  		clone._address = this._address;
		
	  		clone._homePhone = this._homePhone;
		
	  		clone._businessPhone = this._businessPhone;
		
	  		clone._type = this._type;
		
	  		clone._relationship = this._relationship;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Name", _name);
		  	
		  	writer.WriteProperty("Address", _address);
		  	
		  	writer.WriteProperty("HomePhone", _homePhone);
		  	
		  	writer.WriteProperty("BusinessPhone", _businessPhone);
		  	
		  	writer.WriteProperty("Type", _type);
		  	
		  	writer.WriteProperty("Relationship", _relationship);
		  	
		}

		#endregion
	}
}
