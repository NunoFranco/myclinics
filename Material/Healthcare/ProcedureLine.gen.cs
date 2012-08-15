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
    /// ProcedureLine entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class ProcedureLine : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Procedure _parentProcedure;
	  	
	  	private ClearCanvas.Material.Healthcare.StockTransactionLine _stockTransactionsDetails;
	  	
	  	private double _amount;
	  	
	  	private double _salePrice;
	  	
	  	private ClearCanvas.Healthcare.UOMEnum _uOM;
	  	
	  	private DateTime? _createdDate;
	  	
	  	private double _tax;
	  	
	  	private bool _isInsuranceSale;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ProcedureLine()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ProcedureLine(ClearCanvas.Healthcare.Procedure parentprocedure1, ClearCanvas.Material.Healthcare.StockTransactionLine stocktransactionsdetails1, double amount1, double saleprice1, ClearCanvas.Healthcare.UOMEnum uom1, DateTime? createddate1, double tax1, bool isinsurancesale1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_parentProcedure = parentprocedure1;
		  	
		  	_stockTransactionsDetails = stocktransactionsdetails1;
		  	
		  	_amount = amount1;
		  	
		  	_salePrice = saleprice1;
		  	
		  	_uOM = uom1;
		  	
		  	_createdDate = createddate1;
		  	
		  	_tax = tax1;
		  	
		  	_isInsuranceSale = isinsurancesale1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Procedure ParentProcedure
	  	{
			
			get { return _parentProcedure; }
			
			
			 set { _parentProcedure = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Material.Healthcare.StockTransactionLine StockTransactionsDetails
	  	{
			
			get { return _stockTransactionsDetails; }
			
			
			 set { _stockTransactionsDetails = value; }
			
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
	  	public virtual double SalePrice
	  	{
			
			get { return _salePrice; }
			
			
			 set { _salePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.UOMEnum UOM
	  	{
			
			get { return _uOM; }
			
			
			 set { _uOM = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? CreatedDate
	  	{
			
			get { return _createdDate; }
			
			
			 set { _createdDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual double Tax
	  	{
			
			get { return _tax; }
			
			
			 set { _tax = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsInsuranceSale
	  	{
			
			get { return _isInsuranceSale; }
			
			
			 set { _isInsuranceSale = value; }
			
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
