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
    /// EmailAddress component
    /// </summary>
	public sealed partial class EmailAddress : ValueObject, IEquatable<EmailAddress>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _address;
	  	
	  	private ClearCanvas.Healthcare.DateTimeRange _validRange;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public EmailAddress()
	  	{
		 	
		  	_validRange = new ClearCanvas.Healthcare.DateTimeRange();
		  	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public EmailAddress(string address1, ClearCanvas.Healthcare.DateTimeRange validrange1)
	  	{
		  	CustomInitialize();

			
		  	_address = address1;
		  	
		  	_validRange = validrange1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(255)]
	  	public string Address
	  	{
			
			get { return _address; }
			
			
			set { _address = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.DateTimeRange ValidRange
	  	{
			
			get { return _validRange; }
			
			
			set { _validRange = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(EmailAddress that)
		{
			return (that != null) &&
	  	
			((this._address == default(string)) ? (that._address == default(string)) : this._address.Equals(that._address)) &&
	  	
			((this._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) ? (that._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) : this._validRange.Equals(that._validRange)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as EmailAddress);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_address == default(string) ? 0 : _address.GetHashCode()) ^
	  	
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
			EmailAddress clone = new EmailAddress();
		
			clone._validRange = (this._validRange == default(ClearCanvas.Healthcare.DateTimeRange)) ? default(ClearCanvas.Healthcare.DateTimeRange) : (ClearCanvas.Healthcare.DateTimeRange)this._validRange.Clone();
		
		
	  		clone._address = this._address;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Address", _address);
		  	
		  	writer.WriteProperty("ValidRange", _validRange);
		  	
		}

		#endregion
	}
}
