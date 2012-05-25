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
    /// Protocol entity
    /// </summary>
	
	public partial class Protocol : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ISet<ClearCanvas.Healthcare.Procedure> _procedures;
	  	
	  	private ClearCanvas.Healthcare.Staff _author;
	  	
	  	private ClearCanvas.Healthcare.Staff _supervisor;
	  	
	  	private ClearCanvas.Healthcare.ProtocolStatusEnum _status;
	  	
	  	private ClearCanvas.Healthcare.ProtocolUrgencyEnum _urgency;
	  	
	  	private ClearCanvas.Healthcare.ProtocolRejectReasonEnum _rejectReason;
	  	
	  	private ISet<ClearCanvas.Healthcare.ProtocolCode> _codes;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Protocol()
	  	{
		 	
		  	_procedures = new HashedSet<ClearCanvas.Healthcare.Procedure>();
		  	
		  	_codes = new HashedSet<ClearCanvas.Healthcare.ProtocolCode>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Protocol(ISet<ClearCanvas.Healthcare.Procedure> procedures1, ClearCanvas.Healthcare.Staff author1, ClearCanvas.Healthcare.Staff supervisor1, ClearCanvas.Healthcare.ProtocolStatusEnum status1, ClearCanvas.Healthcare.ProtocolUrgencyEnum urgency1, ClearCanvas.Healthcare.ProtocolRejectReasonEnum rejectreason1, ISet<ClearCanvas.Healthcare.ProtocolCode> codes1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_procedures = procedures1;
		  	
		  	_author = author1;
		  	
		  	_supervisor = supervisor1;
		  	
		  	_status = status1;
		  	
		  	_urgency = urgency1;
		  	
		  	_rejectReason = rejectreason1;
		  	
		  	_codes = codes1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.Procedure> Procedures
	  	{
			
			get { return _procedures; }
			
			
			protected set { _procedures = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Author
	  	{
			
			get { return _author; }
			
			
			 set { _author = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Supervisor
	  	{
			
			get { return _supervisor; }
			
			
			 set { _supervisor = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ProtocolStatusEnum Status
	  	{
			
			get { return _status; }
			
			
			 set { _status = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ProtocolUrgencyEnum Urgency
	  	{
			
			get { return _urgency; }
			
			
			 set { _urgency = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ProtocolRejectReasonEnum RejectReason
	  	{
			
			get { return _rejectReason; }
			
			
			 set { _rejectReason = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.ProtocolCode> Codes
	  	{
			
			get { return _codes; }
			
			
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
