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
    /// StockTransactionLine entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class StockTransactionLine : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.ProcedureType _material;
	  	
	  	private double _amount;
	  	
	  	private double _inputPrice;
	  	
	  	private double _salePrice;
	  	
	  	private double _insurancePrice;
	  	
	  	private double _soldAmount;
	  	
	  	private ClearCanvas.Healthcare.UOMEnum _uOM;
	  	
	  	private ClearCanvas.Material.Healthcare.StockTransaction _transaction;
	  	
	  	private DateTime? _expireDate;
	  	
	  	private double _tax;
	  	
	  	private bool _deactivated;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public StockTransactionLine()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public StockTransactionLine(ClearCanvas.Healthcare.ProcedureType material1, double amount1, double inputprice1, double saleprice1, double insuranceprice1, double soldamount1, ClearCanvas.Healthcare.UOMEnum uom1, ClearCanvas.Material.Healthcare.StockTransaction transaction1, DateTime? expiredate1, double tax1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_material = material1;
		  	
		  	_amount = amount1;
		  	
		  	_inputPrice = inputprice1;
		  	
		  	_salePrice = saleprice1;
		  	
		  	_insurancePrice = insuranceprice1;
		  	
		  	_soldAmount = soldamount1;
		  	
		  	_uOM = uom1;
		  	
		  	_transaction = transaction1;
		  	
		  	_expireDate = expiredate1;
		  	
		  	_tax = tax1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ProcedureType Material
	  	{
			
			get { return _material; }
			
			
			 set { _material = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual double Amount
	  	{
			
			get { return _amount; }
			
			
			 set { _amount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual double InputPrice
	  	{
			
			get { return _inputPrice; }
			
			
			 set { _inputPrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual double SalePrice
	  	{
			
			get { return _salePrice; }
			
			
			 set { _salePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual double InsurancePrice
	  	{
			
			get { return _insurancePrice; }
			
			
			 set { _insurancePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual double SoldAmount
	  	{
			
			get { return _soldAmount; }
			
			
			 set { _soldAmount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.UOMEnum UOM
	  	{
			
			get { return _uOM; }
			
			
			 set { _uOM = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Material.Healthcare.StockTransaction Transaction
	  	{
			
			get { return _transaction; }
			
			
			 set { _transaction = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ExpireDate
	  	{
			
			get { return _expireDate; }
			
			
			 set { _expireDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual double Tax
	  	{
			
			get { return _tax; }
			
			
			 set { _tax = value; }
			
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
