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
    /// MaterialInvoice entity
    /// </summary>
	
	public partial class MaterialInvoice : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _code;
	  	
	  	private ClearCanvas.Healthcare.Patient _patient;
	  	
	  	private ClearCanvas.Healthcare.ProcedureType _material;
	  	
	  	private ClearCanvas.Material.Healthcare.MaterialLot _lot;
	  	
	  	private DateTime _soldDate;
	  	
	  	private Decimal _soldAmount;
	  	
	  	private Decimal _price;
	  	
	  	private string _comment;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public MaterialInvoice()
	  	{
		 	
		  	_soldDate = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public MaterialInvoice(string code1, ClearCanvas.Healthcare.Patient patient1, ClearCanvas.Healthcare.ProcedureType material1, ClearCanvas.Material.Healthcare.MaterialLot lot1, DateTime solddate1, Decimal soldamount1, Decimal price1, string comment1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_code = code1;
		  	
		  	_patient = patient1;
		  	
		  	_material = material1;
		  	
		  	_lot = lot1;
		  	
		  	_soldDate = solddate1;
		  	
		  	_soldAmount = soldamount1;
		  	
		  	_price = price1;
		  	
		  	_comment = comment1;
		  	
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
		[Required]
	  	public virtual ClearCanvas.Healthcare.Patient Patient
	  	{
			
			get { return _patient; }
			
			
			 set { _patient = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ProcedureType Material
	  	{
			
			get { return _material; }
			
			
			 set { _material = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Material.Healthcare.MaterialLot Lot
	  	{
			
			get { return _lot; }
			
			
			 set { _lot = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime SoldDate
	  	{
			
			get { return _soldDate; }
			
			
			 set { _soldDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal SoldAmount
	  	{
			
			get { return _soldAmount; }
			
			
			 set { _soldAmount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal Price
	  	{
			
			get { return _price; }
			
			
			 set { _price = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string Comment
	  	{
			
			get { return _comment; }
			
			
			 set { _comment = value; }
			
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
