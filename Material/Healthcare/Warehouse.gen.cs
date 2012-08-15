// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using Iesi.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Material.Healthcare
{


    /// <summary>
    /// Warehouse entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class Warehouse : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _code;
	  	
	  	private string _name;
	  	
	  	private ClearCanvas.Healthcare.Staff _pICName;
	  	
	  	private string _contactDetailInformation;
	  	
	  	private bool _deactivated;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Warehouse()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Warehouse(string code1, string name1, ClearCanvas.Healthcare.Staff picname1, string contactdetailinformation1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_code = code1;
		  	
		  	_name = name1;
		  	
		  	_pICName = picname1;
		  	
		  	_contactDetailInformation = contactdetailinformation1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(100)]
		[Unique]
	  	public virtual string Code
	  	{
			
			get { return _code; }
			
			
			 set { _code = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff PICName
	  	{
			
			get { return _pICName; }
			
			
			 set { _pICName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string ContactDetailInformation
	  	{
			
			get { return _contactDetailInformation; }
			
			
			 set { _contactDetailInformation = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
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
