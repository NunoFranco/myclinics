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
    /// DoctorPrescription entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class DoctorPrescription : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _name;
	  	
	  	private string _description;
	  	
	  	private ISet<ClearCanvas.Healthcare.ProcedureType> _medicines;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public DoctorPrescription()
	  	{
		 	
		  	_medicines = new HashedSet<ClearCanvas.Healthcare.ProcedureType>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public DoctorPrescription(string name1, string description1, ISet<ClearCanvas.Healthcare.ProcedureType> medicines1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_description = description1;
		  	
		  	_medicines = medicines1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Unique]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(1024)]
	  	public virtual string Description
	  	{
			
			get { return _description; }
			
			
			 set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.ProcedureType> Medicines
	  	{
			
			get { return _medicines; }
			
			
			protected set { _medicines = value; }
			
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
