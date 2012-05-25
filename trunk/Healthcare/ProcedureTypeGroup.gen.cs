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
    /// ProcedureTypeGroup entity
    /// </summary>
	
	public partial class ProcedureTypeGroup : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _name;
	  	
	  	private string _description;
	  	
	  	private ClearCanvas.Healthcare.ProcedureTypeGroup _parent;
	  	
	  	private bool _isAutoUpdatePrice;
	  	
	  	private Decimal _packagePrice;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private ISet<ClearCanvas.Healthcare.ProcedureType> _procedureTypes;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ProcedureTypeGroup()
	  	{
		 	
		  	_procedureTypes = new HashedSet<ClearCanvas.Healthcare.ProcedureType>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ProcedureTypeGroup(string name1, string description1, ClearCanvas.Healthcare.ProcedureTypeGroup parent1, bool isautoupdateprice1, Decimal packageprice1, ClearCanvas.Healthcare.Facility clinic1, ISet<ClearCanvas.Healthcare.ProcedureType> proceduretypes1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_description = description1;
		  	
		  	_parent = parent1;
		  	
		  	_isAutoUpdatePrice = isautoupdateprice1;
		  	
		  	_packagePrice = packageprice1;
		  	
		  	_clinic = clinic1;
		  	
		  	_procedureTypes = proceduretypes1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(100)]
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
	  	public virtual ClearCanvas.Healthcare.ProcedureTypeGroup Parent
	  	{
			
			get { return _parent; }
			
			
			 set { _parent = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool IsAutoUpdatePrice
	  	{
			
			get { return _isAutoUpdatePrice; }
			
			
			 set { _isAutoUpdatePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Decimal PackagePrice
	  	{
			
			get { return _packagePrice; }
			
			
			 set { _packagePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.ProcedureType> ProcedureTypes
	  	{
			
			get { return _procedureTypes; }
			
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
