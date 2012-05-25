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
    /// Employee entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class Employee : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private string _title;
	  	
	  	private string _licenseNumber;
	  	
	  	private string _billingNumber;
	  	
	  	private string _userName;
	  	
	  	private ISet<ClearCanvas.Enterprise.Authentication.Clinic> _clinics;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Employee()
	  	{
		 	
		  	_clinics = new HashedSet<ClearCanvas.Enterprise.Authentication.Clinic>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Employee(string id1, string title1, string licensenumber1, string billingnumber1, string username1, ISet<ClearCanvas.Enterprise.Authentication.Clinic> clinics1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_title = title1;
		  	
		  	_licenseNumber = licensenumber1;
		  	
		  	_billingNumber = billingnumber1;
		  	
		  	_userName = username1;
		  	
		  	_clinics = clinics1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(30)]
		[Unique]
	  	public virtual string Id
	  	{
			
			get { return _id; }
			
			
			 set { _id = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string Title
	  	{
			
			get { return _title; }
			
			
			 set { _title = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string LicenseNumber
	  	{
			
			get { return _licenseNumber; }
			
			
			 set { _licenseNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string BillingNumber
	  	{
			
			get { return _billingNumber; }
			
			
			 set { _billingNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string UserName
	  	{
			
			get { return _userName; }
			
			
			 set { _userName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Enterprise.Authentication.Clinic> Clinics
	  	{
			
			get { return _clinics; }
			
			
			protected set { _clinics = value; }
			
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
