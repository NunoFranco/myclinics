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
    /// HealthcardNumber component
    /// </summary>
	public sealed partial class HealthcardNumber : ValueObject, IEquatable<HealthcardNumber>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private ClearCanvas.Healthcare.InsuranceAuthorityEnum _assigningAuthority;
	  	
	  	private string _versionCode;
	  	
	  	private DateTime? _expiryDate;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public HealthcardNumber()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public HealthcardNumber(string id1, ClearCanvas.Healthcare.InsuranceAuthorityEnum assigningauthority1, string versioncode1, DateTime? expirydate1)
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_assigningAuthority = assigningauthority1;
		  	
		  	_versionCode = versioncode1;
		  	
		  	_expiryDate = expirydate1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Length(30)]
	  	public string Id
	  	{
			
			get { return _id; }
			
			
			set { _id = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.InsuranceAuthorityEnum AssigningAuthority
	  	{
			
			get { return _assigningAuthority; }
			
			
			set { _assigningAuthority = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(20)]
	  	public string VersionCode
	  	{
			
			get { return _versionCode; }
			
			
			set { _versionCode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public DateTime? ExpiryDate
	  	{
			
			get { return _expiryDate; }
			
			
			set { _expiryDate = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(HealthcardNumber that)
		{
			return (that != null) &&
	  	
			((this._id == default(string)) ? (that._id == default(string)) : this._id.Equals(that._id)) &&
	  	
			((this._assigningAuthority == default(ClearCanvas.Healthcare.InsuranceAuthorityEnum)) ? (that._assigningAuthority == default(ClearCanvas.Healthcare.InsuranceAuthorityEnum)) : this._assigningAuthority.Equals(that._assigningAuthority)) &&
	  	
			((this._versionCode == default(string)) ? (that._versionCode == default(string)) : this._versionCode.Equals(that._versionCode)) &&
	  	
			((this._expiryDate == default(DateTime?)) ? (that._expiryDate == default(DateTime?)) : this._expiryDate.Equals(that._expiryDate)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as HealthcardNumber);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_id == default(string) ? 0 : _id.GetHashCode()) ^
	  	
				(_assigningAuthority == default(ClearCanvas.Healthcare.InsuranceAuthorityEnum) ? 0 : _assigningAuthority.GetHashCode()) ^
	  	
				(_versionCode == default(string) ? 0 : _versionCode.GetHashCode()) ^
	  	
				(_expiryDate == default(DateTime?) ? 0 : _expiryDate.GetHashCode()) ^
	  	
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
			HealthcardNumber clone = new HealthcardNumber();
		
		
	  		clone._id = this._id;
		
	  		clone._assigningAuthority = this._assigningAuthority;
		
	  		clone._versionCode = this._versionCode;
		
	  		clone._expiryDate = this._expiryDate;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Id", _id);
		  	
		  	writer.WriteProperty("AssigningAuthority", _assigningAuthority);
		  	
		  	writer.WriteProperty("VersionCode", _versionCode);
		  	
		  	writer.WriteProperty("ExpiryDate", _expiryDate);
		  	
		}

		#endregion
	}
}
