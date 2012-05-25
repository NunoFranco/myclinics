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
    /// Procedure entity
    /// </summary>
	
	public partial class Procedure : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Order _order;
	  	
	  	private ClearCanvas.Healthcare.ProcedureType _type;
	  	
	  	private string _index;
	  	
	  	private ISet<ClearCanvas.Healthcare.ProcedureStep> _procedureSteps;
	  	
	  	private DateTime? _scheduledStartTime;
	  	
	  	private DateTime? _startTime;
	  	
	  	private DateTime? _endTime;
	  	
	  	private ClearCanvas.Healthcare.ProcedureStatusEnum _status;
	  	
	  	private ClearCanvas.Healthcare.Facility _performingFacility;
	  	
	  	private ClearCanvas.Healthcare.LateralityEnum _laterality;
	  	
	  	private bool _portable;
	  	
	  	private ClearCanvas.Healthcare.ProcedureCheckIn _procedureCheckIn;
	  	
	  	private ClearCanvas.Healthcare.ImageAvailabilityEnum _imageAvailability;
	  	
	  	private ClearCanvas.Healthcare.DiagnosticService _packageProcedure;
	  	
	  	private bool _downtimeRecoveryMode;
	  	
	  	private ISet<ClearCanvas.Healthcare.Report> _reports;
	  	
	  	private ISet<ClearCanvas.Healthcare.Protocol> _protocols;
	  	
	  	private Decimal _waitingInsuranceAmount;
	  	
	  	private Decimal _collectedAmount;
	  	
	  	private bool _isPendingInsurance;
	  	
	  	private bool _isPackageProcedure;
	  	
	  	private string _pendingProcedureStatus;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Procedure()
	  	{
		 	
		  	_procedureSteps = new HashedSet<ClearCanvas.Healthcare.ProcedureStep>();
		  	
		  	_reports = new HashedSet<ClearCanvas.Healthcare.Report>();
		  	
		  	_protocols = new HashedSet<ClearCanvas.Healthcare.Protocol>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Procedure(ClearCanvas.Healthcare.Order order1, ClearCanvas.Healthcare.ProcedureType type1, string index1, ISet<ClearCanvas.Healthcare.ProcedureStep> proceduresteps1, DateTime? scheduledstarttime1, DateTime? starttime1, DateTime? endtime1, ClearCanvas.Healthcare.ProcedureStatusEnum status1, ClearCanvas.Healthcare.Facility performingfacility1, ClearCanvas.Healthcare.LateralityEnum laterality1, bool portable1, ClearCanvas.Healthcare.ProcedureCheckIn procedurecheckin1, ClearCanvas.Healthcare.ImageAvailabilityEnum imageavailability1, ClearCanvas.Healthcare.DiagnosticService packageprocedure1, bool downtimerecoverymode1, ISet<ClearCanvas.Healthcare.Report> reports1, ISet<ClearCanvas.Healthcare.Protocol> protocols1, Decimal waitinginsuranceamount1, Decimal collectedamount1, bool ispendinginsurance1, bool ispackageprocedure1, string pendingprocedurestatus1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_order = order1;
		  	
		  	_type = type1;
		  	
		  	_index = index1;
		  	
		  	_procedureSteps = proceduresteps1;
		  	
		  	_scheduledStartTime = scheduledstarttime1;
		  	
		  	_startTime = starttime1;
		  	
		  	_endTime = endtime1;
		  	
		  	_status = status1;
		  	
		  	_performingFacility = performingfacility1;
		  	
		  	_laterality = laterality1;
		  	
		  	_portable = portable1;
		  	
		  	_procedureCheckIn = procedurecheckin1;
		  	
		  	_imageAvailability = imageavailability1;
		  	
		  	_packageProcedure = packageprocedure1;
		  	
		  	_downtimeRecoveryMode = downtimerecoverymode1;
		  	
		  	_reports = reports1;
		  	
		  	_protocols = protocols1;
		  	
		  	_waitingInsuranceAmount = waitinginsuranceamount1;
		  	
		  	_collectedAmount = collectedamount1;
		  	
		  	_isPendingInsurance = ispendinginsurance1;
		  	
		  	_isPackageProcedure = ispackageprocedure1;
		  	
		  	_pendingProcedureStatus = pendingprocedurestatus1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Order Order
	  	{
			
			get { return _order; }
			
			
			 set { _order = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ProcedureType Type
	  	{
			
			get { return _type; }
			
			
			 set { _type = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(10)]
	  	public virtual string Index
	  	{
			
			get { return _index; }
			
			
			 set { _index = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.ProcedureStep> ProcedureSteps
	  	{
			
			get { return _procedureSteps; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ScheduledStartTime
	  	{
			
			get { return _scheduledStartTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? StartTime
	  	{
			
			get { return _startTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? EndTime
	  	{
			
			get { return _endTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ProcedureStatusEnum Status
	  	{
			
			get { return _status; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility PerformingFacility
	  	{
			
			get { return _performingFacility; }
			
			
			 set { _performingFacility = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.LateralityEnum Laterality
	  	{
			
			get { return _laterality; }
			
			
			 set { _laterality = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool Portable
	  	{
			
			get { return _portable; }
			
			
			 set { _portable = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ProcedureCheckIn ProcedureCheckIn
	  	{
			
			get { return _procedureCheckIn; }
			
			
			 set { _procedureCheckIn = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ImageAvailabilityEnum ImageAvailability
	  	{
			
			get { return _imageAvailability; }
			
			
			 set { _imageAvailability = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.DiagnosticService PackageProcedure
	  	{
			
			get { return _packageProcedure; }
			
			
			 set { _packageProcedure = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool DowntimeRecoveryMode
	  	{
			
			get { return _downtimeRecoveryMode; }
			
			
			 set { _downtimeRecoveryMode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.Report> Reports
	  	{
			
			get { return _reports; }
			
			
			protected set { _reports = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.Protocol> Protocols
	  	{
			
			get { return _protocols; }
			
			
			protected set { _protocols = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal WaitingInsuranceAmount
	  	{
			
			get { return _waitingInsuranceAmount; }
			
			
			 set { _waitingInsuranceAmount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Decimal CollectedAmount
	  	{
			
			get { return _collectedAmount; }
			
			
			 set { _collectedAmount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsPendingInsurance
	  	{
			
			get { return _isPendingInsurance; }
			
			
			 set { _isPendingInsurance = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool IsPackageProcedure
	  	{
			
			get { return _isPackageProcedure; }
			
			
			 set { _isPackageProcedure = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual string PendingProcedureStatus
	  	{
			
			get { return _pendingProcedureStatus; }
			
			
			 set { _pendingProcedureStatus = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
