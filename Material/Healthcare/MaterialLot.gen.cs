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
    /// MaterialLot entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class MaterialLot : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private string _description;
	  	
	  	private ClearCanvas.Material.Healthcare.Contact _supplier;
	  	
	  	private DateTime _inputDate;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public MaterialLot()
	  	{
		 	
		  	_inputDate = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public MaterialLot(string id1, string description1, ClearCanvas.Material.Healthcare.Contact supplier1, DateTime inputdate1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_description = description1;
		  	
		  	_supplier = supplier1;
		  	
		  	_inputDate = inputdate1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(100)]
		[Unique]
	  	public virtual string Id
	  	{
			
			get { return _id; }
			
			
			 set { _id = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string Description
	  	{
			
			get { return _description; }
			
			
			 set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Material.Healthcare.Contact Supplier
	  	{
			
			get { return _supplier; }
			
			
			 set { _supplier = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime InputDate
	  	{
			
			get { return _inputDate; }
			
			
			 set { _inputDate = value; }
			
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
