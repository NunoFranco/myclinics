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
    /// ProcedureType entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class ProcedureType : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private string _name;
	  	
	  	private ClearCanvas.Healthcare.ProcedureType _baseType;
	  	
	  	private string _planXml;
	  	
	  	private bool _deactivated;
	  	
	  	private Decimal _basePrice;
	  	
	  	private Decimal _tax;
	  	
	  	private bool _isRequired;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private ClearCanvas.Healthcare.ProcedureTypeCategoryEnum _category;
	  	
	  	private ClearCanvas.Healthcare.UOMEnum _uOM;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ProcedureType()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ProcedureType(string id1, string name1, ClearCanvas.Healthcare.ProcedureType basetype1, string planxml1, Decimal baseprice1, Decimal tax1, bool isrequired1, ClearCanvas.Healthcare.Facility clinic1, ClearCanvas.Healthcare.ProcedureTypeCategoryEnum category1, ClearCanvas.Healthcare.UOMEnum uom1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_name = name1;
		  	
		  	_baseType = basetype1;
		  	
		  	_planXml = planxml1;
		  	
		  	_basePrice = baseprice1;
		  	
		  	_tax = tax1;
		  	
		  	_isRequired = isrequired1;
		  	
		  	_clinic = clinic1;
		  	
		  	_category = category1;
		  	
		  	_uOM = uom1;
		  	
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
		[Required]
		[Length(100)]
		[Unique]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ProcedureType BaseType
	  	{
			
			get { return _baseType; }
			
			
			 set { _baseType = value; }
			
	  	}
		
	  	
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal BasePrice
	  	{
			
			get { return _basePrice; }
			
			
			 set { _basePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal Tax
	  	{
			
			get { return _tax; }
			
			
			 set { _tax = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsRequired
	  	{
			
			get { return _isRequired; }
			
			
			 set { _isRequired = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ProcedureTypeCategoryEnum Category
	  	{
			
			get { return _category; }
			
			
			 set { _category = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.UOMEnum UOM
	  	{
			
			get { return _uOM; }
			
			
			 set { _uOM = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
