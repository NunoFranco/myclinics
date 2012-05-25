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
    /// ReportPart entity
    /// </summary>
	
	public partial class ReportPart : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private int _index;
	  	
	  	private ClearCanvas.Healthcare.ReportPartStatusEnum _status;
	  	
	  	private DateTime _creationTime;
	  	
	  	private DateTime? _preliminaryTime;
	  	
	  	private DateTime? _completedTime;
	  	
	  	private DateTime? _cancelledTime;
	  	
	  	private ClearCanvas.Healthcare.Staff _supervisor;
	  	
	  	private ClearCanvas.Healthcare.Staff _interpreter;
	  	
	  	private ClearCanvas.Healthcare.Staff _transcriber;
	  	
	  	private ClearCanvas.Healthcare.Staff _transcriptionSupervisor;
	  	
	  	private ClearCanvas.Healthcare.Staff _verifier;
	  	
	  	private ClearCanvas.Healthcare.TranscriptionRejectReasonEnum _transcriptionRejectReason;
	  	
	  	private ClearCanvas.Healthcare.Report _report;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private IDictionary<string, string> _extendedProperties;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ReportPart()
	  	{
		 	
		  	_creationTime = Platform.Time;
		  	
		  	_extendedProperties = new Dictionary<string, string>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ReportPart(int index1, ClearCanvas.Healthcare.ReportPartStatusEnum status1, DateTime creationtime1, DateTime? preliminarytime1, DateTime? completedtime1, DateTime? cancelledtime1, ClearCanvas.Healthcare.Staff supervisor1, ClearCanvas.Healthcare.Staff interpreter1, ClearCanvas.Healthcare.Staff transcriber1, ClearCanvas.Healthcare.Staff transcriptionsupervisor1, ClearCanvas.Healthcare.Staff verifier1, ClearCanvas.Healthcare.TranscriptionRejectReasonEnum transcriptionrejectreason1, ClearCanvas.Healthcare.Report report1, ClearCanvas.Healthcare.Facility clinic1, IDictionary<string, string> extendedproperties1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_index = index1;
		  	
		  	_status = status1;
		  	
		  	_creationTime = creationtime1;
		  	
		  	_preliminaryTime = preliminarytime1;
		  	
		  	_completedTime = completedtime1;
		  	
		  	_cancelledTime = cancelledtime1;
		  	
		  	_supervisor = supervisor1;
		  	
		  	_interpreter = interpreter1;
		  	
		  	_transcriber = transcriber1;
		  	
		  	_transcriptionSupervisor = transcriptionsupervisor1;
		  	
		  	_verifier = verifier1;
		  	
		  	_transcriptionRejectReason = transcriptionrejectreason1;
		  	
		  	_report = report1;
		  	
		  	_clinic = clinic1;
		  	
		  	_extendedProperties = extendedproperties1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual int Index
	  	{
			
			get { return _index; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ReportPartStatusEnum Status
	  	{
			
			get { return _status; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime CreationTime
	  	{
			
			get { return _creationTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? PreliminaryTime
	  	{
			
			get { return _preliminaryTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? CompletedTime
	  	{
			
			get { return _completedTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? CancelledTime
	  	{
			
			get { return _cancelledTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Supervisor
	  	{
			
			get { return _supervisor; }
			
			
			 set { _supervisor = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Interpreter
	  	{
			
			get { return _interpreter; }
			
			
			 set { _interpreter = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Transcriber
	  	{
			
			get { return _transcriber; }
			
			
			 set { _transcriber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff TranscriptionSupervisor
	  	{
			
			get { return _transcriptionSupervisor; }
			
			
			 set { _transcriptionSupervisor = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Verifier
	  	{
			
			get { return _verifier; }
			
			
			 set { _verifier = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.TranscriptionRejectReasonEnum TranscriptionRejectReason
	  	{
			
			get { return _transcriptionRejectReason; }
			
			
			 set { _transcriptionRejectReason = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Report Report
	  	{
			
			get { return _report; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[ExtendedPropertiesCollection]
	  	public virtual IDictionary<string, string> ExtendedProperties
	  	{
			
			get { return _extendedProperties; }
			
			
			protected set { _extendedProperties = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
