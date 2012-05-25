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
    /// WorkingShift entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class WorkingShift : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private IList<ClearCanvas.Healthcare.DoctorWorkingPlan> _doctors;
	  	
	  	private string _name;
	  	
	  	private string _description;
	  	
	  	private DateTime? _validFromDate;
	  	
	  	private DateTime? _startTime;
	  	
	  	private DateTime? _validToDate;
	  	
	  	private DateTime? _endTime;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public WorkingShift()
	  	{
		 	
		  	_doctors = new List<ClearCanvas.Healthcare.DoctorWorkingPlan>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public WorkingShift(IList<ClearCanvas.Healthcare.DoctorWorkingPlan> doctors1, string name1, string description1, DateTime? validfromdate1, DateTime? starttime1, DateTime? validtodate1, DateTime? endtime1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_doctors = doctors1;
		  	
		  	_name = name1;
		  	
		  	_description = description1;
		  	
		  	_validFromDate = validfromdate1;
		  	
		  	_startTime = starttime1;
		  	
		  	_validToDate = validtodate1;
		  	
		  	_endTime = endtime1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.DoctorWorkingPlan))]
	  	public virtual IList<ClearCanvas.Healthcare.DoctorWorkingPlan> Doctors
	  	{
			
			get { return _doctors; }
			
			
			protected set { _doctors = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Unique]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(1024)]
	  	public virtual string Description
	  	{
			
			get { return _description; }
			
			
			 set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ValidFromDate
	  	{
			
			get { return _validFromDate; }
			
			
			 set { _validFromDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? StartTime
	  	{
			
			get { return _startTime; }
			
			
			 set { _startTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ValidToDate
	  	{
			
			get { return _validToDate; }
			
			
			 set { _validToDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? EndTime
	  	{
			
			get { return _endTime; }
			
			
			 set { _endTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
