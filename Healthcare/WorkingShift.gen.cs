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
       	
		
	  	private string _name;
	  	
	  	private string _description;
	  	
	  	private DateTime? _validFromDate;
	  	
	  	private DateTime? _startTime;
	  	
	  	private DateTime? _validToDate;
	  	
	  	private DateTime? _endTime;
	  	
	  	private bool _workOnSunday;
	  	
	  	private bool _workOnMonday;
	  	
	  	private bool _workOnTuesday;
	  	
	  	private bool _workOnWednesday;
	  	
	  	private bool _workOnThursday;
	  	
	  	private bool _workOnFriday;
	  	
	  	private bool _workOnSaturday;
	  	
	  	private ISet<ClearCanvas.Healthcare.Staff> _doctors;
	  	
	  	private DateTime? _exactDate;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public WorkingShift()
	  	{
		 	
		  	_doctors = new HashedSet<ClearCanvas.Healthcare.Staff>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public WorkingShift(string name1, string description1, DateTime? validfromdate1, DateTime? starttime1, DateTime? validtodate1, DateTime? endtime1, bool workonsunday1, bool workonmonday1, bool workontuesday1, bool workonwednessday1, bool workonthursday1, bool workonfriday1, bool workonsaturday1, ISet<ClearCanvas.Healthcare.Staff> doctors1, DateTime? exactdate1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_description = description1;
		  	
		  	_validFromDate = validfromdate1;
		  	
		  	_startTime = starttime1;
		  	
		  	_validToDate = validtodate1;
		  	
		  	_endTime = endtime1;
		  	
		  	_workOnSunday = workonsunday1;
		  	
		  	_workOnMonday = workonmonday1;
		  	
		  	_workOnTuesday = workontuesday1;
		  	
		  	_workOnWednesday = workonwednessday1;
		  	
		  	_workOnThursday = workonthursday1;
		  	
		  	_workOnFriday = workonfriday1;
		  	
		  	_workOnSaturday = workonsaturday1;
		  	
		  	_doctors = doctors1;
		  	
		  	_exactDate = exactdate1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
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
	  	public virtual bool WorkOnSunday
	  	{
			
			get { return _workOnSunday; }
			
			
			 set { _workOnSunday = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool WorkOnMonday
	  	{
			
			get { return _workOnMonday; }
			
			
			 set { _workOnMonday = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool WorkOnTuesday
	  	{
			
			get { return _workOnTuesday; }
			
			
			 set { _workOnTuesday = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool WorkOnWednesday
	  	{
			
			get { return _workOnWednesday; }
			
			
			 set { _workOnWednesday = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool WorkOnThursday
	  	{
			
			get { return _workOnThursday; }
			
			
			 set { _workOnThursday = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool WorkOnFriday
	  	{
			
			get { return _workOnFriday; }
			
			
			 set { _workOnFriday = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool WorkOnSaturday
	  	{
			
			get { return _workOnSaturday; }
			
			
			 set { _workOnSaturday = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.Staff> Doctors
	  	{
			
			get { return _doctors; }
			
			
			protected set { _doctors = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ExactDate
	  	{
			
			get { return _exactDate; }
			
			
			 set { _exactDate = value; }
			
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
