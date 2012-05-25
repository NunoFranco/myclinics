// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using Iesi.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Enterprise.Authentication
{


    /// <summary>
    /// UserSession entity
    /// </summary>
	
	public partial class UserSession : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Enterprise.Authentication.User _user;
	  	
	  	private string _hostName;
	  	
	  	private string _application;
	  	
	  	private string _sessionId;
	  	
	  	private DateTime _creationTime;
	  	
	  	private DateTime _expiryTime;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public UserSession()
	  	{
		 	
		  	_creationTime = Platform.Time;
		  	
		  	_expiryTime = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public UserSession(ClearCanvas.Enterprise.Authentication.User user1, string hostname1, string application1, string sessionid1, DateTime creationtime1, DateTime expirytime1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_user = user1;
		  	
		  	_hostName = hostname1;
		  	
		  	_application = application1;
		  	
		  	_sessionId = sessionid1;
		  	
		  	_creationTime = creationtime1;
		  	
		  	_expiryTime = expirytime1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Enterprise.Authentication.User User
	  	{
			
			get { return _user; }
			
			
			 set { _user = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string HostName
	  	{
			
			get { return _hostName; }
			
			
			 set { _hostName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string Application
	  	{
			
			get { return _application; }
			
			
			 set { _application = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Unique]
	  	public virtual string SessionId
	  	{
			
			get { return _sessionId; }
			
			
			 set { _sessionId = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime CreationTime
	  	{
			
			get { return _creationTime; }
			
			
			 set { _creationTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime ExpiryTime
	  	{
			
			get { return _expiryTime; }
			
			
			 set { _expiryTime = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
