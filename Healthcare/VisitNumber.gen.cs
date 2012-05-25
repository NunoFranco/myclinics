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
    /// VisitNumber component
    /// </summary>
	public sealed partial class VisitNumber : ValueObject, IEquatable<VisitNumber>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private ClearCanvas.Healthcare.InformationAuthorityEnum _assigningAuthority;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public VisitNumber()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public VisitNumber(string id1, ClearCanvas.Healthcare.InformationAuthorityEnum assigningauthority1)
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_assigningAuthority = assigningauthority1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(50)]
	  	public string Id
	  	{
			
			get { return _id; }
			
			
			set { _id = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.InformationAuthorityEnum AssigningAuthority
	  	{
			
			get { return _assigningAuthority; }
			
			
			set { _assigningAuthority = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(VisitNumber that)
		{
			return (that != null) &&
	  	
			((this._id == default(string)) ? (that._id == default(string)) : this._id.Equals(that._id)) &&
	  	
			((this._assigningAuthority == default(ClearCanvas.Healthcare.InformationAuthorityEnum)) ? (that._assigningAuthority == default(ClearCanvas.Healthcare.InformationAuthorityEnum)) : this._assigningAuthority.Equals(that._assigningAuthority)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as VisitNumber);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_id == default(string) ? 0 : _id.GetHashCode()) ^
	  	
				(_assigningAuthority == default(ClearCanvas.Healthcare.InformationAuthorityEnum) ? 0 : _assigningAuthority.GetHashCode()) ^
	  	
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
			VisitNumber clone = new VisitNumber();
		
		
	  		clone._id = this._id;
		
	  		clone._assigningAuthority = this._assigningAuthority;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Id", _id);
		  	
		  	writer.WriteProperty("AssigningAuthority", _assigningAuthority);
		  	
		}

		#endregion
	}
}
