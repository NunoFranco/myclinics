// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using Iesi.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Workflow
{


    /// <summary>
    /// WorkQueueItem entity
    /// </summary>
	
	public partial class WorkQueueItem : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private DateTime _creationTime;
	  	
	  	private DateTime _scheduledTime;
	  	
	  	private DateTime? _expirationTime;
	  	
	  	private string _user;
	  	
	  	private string _type;
	  	
	  	private ClearCanvas.Workflow.WorkQueueStatusEnum _status;
	  	
	  	private DateTime? _processedTime;
	  	
	  	private int _failureCount;
	  	
	  	private string _failureDescription;
	  	
	  	private IDictionary<string, string> _extendedProperties;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public WorkQueueItem()
	  	{
		 	
		  	_creationTime = Platform.Time;
		  	
		  	_scheduledTime = Platform.Time;
		  	
		  	_extendedProperties = new Dictionary<string, string>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public WorkQueueItem(DateTime creationtime1, DateTime scheduledtime1, DateTime? expirationtime1, string user1, string type1, ClearCanvas.Workflow.WorkQueueStatusEnum status1, DateTime? processedtime1, int failurecount1, string failuredescription1, IDictionary<string, string> extendedproperties1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_creationTime = creationtime1;
		  	
		  	_scheduledTime = scheduledtime1;
		  	
		  	_expirationTime = expirationtime1;
		  	
		  	_user = user1;
		  	
		  	_type = type1;
		  	
		  	_status = status1;
		  	
		  	_processedTime = processedtime1;
		  	
		  	_failureCount = failurecount1;
		  	
		  	_failureDescription = failuredescription1;
		  	
		  	_extendedProperties = extendedproperties1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime CreationTime
	  	{
			
			get { return _creationTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime ScheduledTime
	  	{
			
			get { return _scheduledTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ExpirationTime
	  	{
			
			get { return _expirationTime; }
			
			
			 set { _expirationTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string User
	  	{
			
			get { return _user; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual string Type
	  	{
			
			get { return _type; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Workflow.WorkQueueStatusEnum Status
	  	{
			
			get { return _status; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ProcessedTime
	  	{
			
			get { return _processedTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual int FailureCount
	  	{
			
			get { return _failureCount; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(1024)]
	  	public virtual string FailureDescription
	  	{
			
			get { return _failureDescription; }
			
			
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
