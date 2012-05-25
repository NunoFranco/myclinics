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
    /// NoteAcknowledgement component
    /// </summary>
	public sealed partial class NoteAcknowledgement : ValueObject, IEquatable<NoteAcknowledgement>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Staff _staff;
	  	
	  	private DateTime? _time;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public NoteAcknowledgement()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public NoteAcknowledgement(ClearCanvas.Healthcare.Staff staff1, DateTime? time1)
	  	{
		  	CustomInitialize();

			
		  	_staff = staff1;
		  	
		  	_time = time1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.Staff Staff
	  	{
			
			get { return _staff; }
			
			
			set { _staff = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public DateTime? Time
	  	{
			
			get { return _time; }
			
			
			set { _time = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(NoteAcknowledgement that)
		{
			return (that != null) &&
	  	
			((this._staff == default(ClearCanvas.Healthcare.Staff)) ? (that._staff == default(ClearCanvas.Healthcare.Staff)) : this._staff.Equals(that._staff)) &&
	  	
			((this._time == default(DateTime?)) ? (that._time == default(DateTime?)) : this._time.Equals(that._time)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as NoteAcknowledgement);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_staff == default(ClearCanvas.Healthcare.Staff) ? 0 : _staff.GetHashCode()) ^
	  	
				(_time == default(DateTime?) ? 0 : _time.GetHashCode()) ^
	  	
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
			NoteAcknowledgement clone = new NoteAcknowledgement();
		
		
	  		clone._staff = this._staff;
		
	  		clone._time = this._time;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Staff", _staff);
		  	
		  	writer.WriteProperty("Time", _time);
		  	
		}

		#endregion
	}
}
