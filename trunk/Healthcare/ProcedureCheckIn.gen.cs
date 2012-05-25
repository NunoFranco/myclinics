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
    /// ProcedureCheckIn entity
    /// </summary>
	
	public partial class ProcedureCheckIn : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private DateTime? _checkInTime;
	  	
	  	private DateTime? _checkOutTime;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ProcedureCheckIn()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ProcedureCheckIn(DateTime? checkintime1, DateTime? checkouttime1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_checkInTime = checkintime1;
		  	
		  	_checkOutTime = checkouttime1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? CheckInTime
	  	{
			
			get { return _checkInTime; }
			
			
			 set { _checkInTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? CheckOutTime
	  	{
			
			get { return _checkOutTime; }
			
			
			 set { _checkOutTime = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
