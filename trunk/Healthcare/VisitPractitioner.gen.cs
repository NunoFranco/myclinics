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
    /// VisitPractitioner component
    /// </summary>
	public sealed partial class VisitPractitioner : ValueObject, IEquatable<VisitPractitioner>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.ExternalPractitioner _practitioner;
	  	
	  	private ClearCanvas.Healthcare.VisitPractitionerRoleEnum  _role;
	  	
	  	private DateTime? _startTime;
	  	
	  	private DateTime? _endTime;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public VisitPractitioner()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public VisitPractitioner(ClearCanvas.Healthcare.ExternalPractitioner practitioner1, ClearCanvas.Healthcare.VisitPractitionerRoleEnum  role1, DateTime? starttime1, DateTime? endtime1)
	  	{
		  	CustomInitialize();

			
		  	_practitioner = practitioner1;
		  	
		  	_role = role1;
		  	
		  	_startTime = starttime1;
		  	
		  	_endTime = endtime1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.ExternalPractitioner Practitioner
	  	{
			
			get { return _practitioner; }
			
			
			set { _practitioner = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.VisitPractitionerRoleEnum  Role
	  	{
			
			get { return _role; }
			
			
			set { _role = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public DateTime? StartTime
	  	{
			
			get { return _startTime; }
			
			
			set { _startTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public DateTime? EndTime
	  	{
			
			get { return _endTime; }
			
			
			set { _endTime = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(VisitPractitioner that)
		{
			return (that != null) &&
	  	
			((this._practitioner == default(ClearCanvas.Healthcare.ExternalPractitioner)) ? (that._practitioner == default(ClearCanvas.Healthcare.ExternalPractitioner)) : this._practitioner.Equals(that._practitioner)) &&
	  	
			((this._role == default(ClearCanvas.Healthcare.VisitPractitionerRoleEnum )) ? (that._role == default(ClearCanvas.Healthcare.VisitPractitionerRoleEnum )) : this._role.Equals(that._role)) &&
	  	
			((this._startTime == default(DateTime?)) ? (that._startTime == default(DateTime?)) : this._startTime.Equals(that._startTime)) &&
	  	
			((this._endTime == default(DateTime?)) ? (that._endTime == default(DateTime?)) : this._endTime.Equals(that._endTime)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as VisitPractitioner);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_practitioner == default(ClearCanvas.Healthcare.ExternalPractitioner) ? 0 : _practitioner.GetHashCode()) ^
	  	
				(_role == default(ClearCanvas.Healthcare.VisitPractitionerRoleEnum ) ? 0 : _role.GetHashCode()) ^
	  	
				(_startTime == default(DateTime?) ? 0 : _startTime.GetHashCode()) ^
	  	
				(_endTime == default(DateTime?) ? 0 : _endTime.GetHashCode()) ^
	  	
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
			VisitPractitioner clone = new VisitPractitioner();
		
		
	  		clone._practitioner = this._practitioner;
		
	  		clone._role = this._role;
		
	  		clone._startTime = this._startTime;
		
	  		clone._endTime = this._endTime;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Practitioner", _practitioner);
		  	
		  	writer.WriteProperty("Role", _role);
		  	
		  	writer.WriteProperty("StartTime", _startTime);
		  	
		  	writer.WriteProperty("EndTime", _endTime);
		  	
		}

		#endregion
	}
}
