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
    /// Clinic entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class Clinic : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _code;
	  	
	  	private string _name;
	  	
	  	private string _address;
	  	
	  	private bool _deactivated;
	  	
	  	private ISet<ClearCanvas.Enterprise.Authentication.User> _members;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Clinic()
	  	{
		 	
		  	_members = new HashedSet<ClearCanvas.Enterprise.Authentication.User>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Clinic(string code1, string name1, string address1, ISet<ClearCanvas.Enterprise.Authentication.User> members1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_code = code1;
		  	
		  	_name = name1;
		  	
		  	_address = address1;
		  	
		  	_members = members1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(30)]
		[Unique]
	  	public virtual string Code
	  	{
			
			get { return _code; }
			
			
			 set { _code = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(200)]
		[Unique]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(500)]
	  	public virtual string Address
	  	{
			
			get { return _address; }
			
			
			 set { _address = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Enterprise.Authentication.User> Members
	  	{
			
			get { return _members; }
			
			
			protected set { _members = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
