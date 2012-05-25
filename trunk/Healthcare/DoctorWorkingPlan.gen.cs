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
    /// DoctorWorkingPlan component
    /// </summary>
	public sealed partial class DoctorWorkingPlan : ValueObject, IEquatable<DoctorWorkingPlan>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Staff _doctor;
	  	
	  	private DateTime _planDate;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public DoctorWorkingPlan()
	  	{
		 	
		  	_planDate = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public DoctorWorkingPlan(ClearCanvas.Healthcare.Staff doctor1, DateTime plandate1, ClearCanvas.Healthcare.Facility clinic1)
	  	{
		  	CustomInitialize();

			
		  	_doctor = doctor1;
		  	
		  	_planDate = plandate1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.Staff Doctor
	  	{
			
			get { return _doctor; }
			
			
			set { _doctor = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public DateTime PlanDate
	  	{
			
			get { return _planDate; }
			
			
			set { _planDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			set { _clinic = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(DoctorWorkingPlan that)
		{
			return (that != null) &&
	  	
			((this._doctor == default(ClearCanvas.Healthcare.Staff)) ? (that._doctor == default(ClearCanvas.Healthcare.Staff)) : this._doctor.Equals(that._doctor)) &&
	  	
			((this._planDate == default(DateTime)) ? (that._planDate == default(DateTime)) : this._planDate.Equals(that._planDate)) &&
	  	
			((this._clinic == default(ClearCanvas.Healthcare.Facility)) ? (that._clinic == default(ClearCanvas.Healthcare.Facility)) : this._clinic.Equals(that._clinic)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as DoctorWorkingPlan);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_doctor == default(ClearCanvas.Healthcare.Staff) ? 0 : _doctor.GetHashCode()) ^
	  	
				(_planDate == default(DateTime) ? 0 : _planDate.GetHashCode()) ^
	  	
				(_clinic == default(ClearCanvas.Healthcare.Facility) ? 0 : _clinic.GetHashCode()) ^
	  	
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
			DoctorWorkingPlan clone = new DoctorWorkingPlan();
		
		
	  		clone._doctor = this._doctor;
		
	  		clone._planDate = this._planDate;
		
	  		clone._clinic = this._clinic;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Doctor", _doctor);
		  	
		  	writer.WriteProperty("PlanDate", _planDate);
		  	
		  	writer.WriteProperty("Clinic", _clinic);
		  	
		}

		#endregion
	}
}
