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
    /// StockTransaction entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class StockTransaction : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _code;
	  	
	  	private ClearCanvas.Material.Healthcare.Contact _supplier;
	  	
	  	private ClearCanvas.Material.Healthcare.Warehouse _inWarehouse;
	  	
	  	private ClearCanvas.Material.Healthcare.Warehouse _outWarehouse;
	  	
	  	private ClearCanvas.Material.Healthcare.MaterialLot _equipmentLot;
	  	
	  	private ClearCanvas.Healthcare.Order _order;
	  	
	  	private string _description;
	  	
	  	private DateTime _transactionDate;
	  	
	  	private ClearCanvas.Enterprise.Authentication.User _user;
	  	
	  	private ClearCanvas.Material.Healthcare.StockTransactionTypeEnum _transactionType;
	  	
	  	private ISet<ClearCanvas.Material.Healthcare.StockTransactionLine> _details;
	  	
	  	private bool _deactivated;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public StockTransaction()
	  	{
		 	
		  	_transactionDate = Platform.Time;
		  	
		  	_details = new HashedSet<ClearCanvas.Material.Healthcare.StockTransactionLine>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public StockTransaction(string code1, ClearCanvas.Material.Healthcare.Contact supplier1, ClearCanvas.Material.Healthcare.Warehouse inwarehouse1, ClearCanvas.Material.Healthcare.Warehouse outwarehouse1, ClearCanvas.Material.Healthcare.MaterialLot equipmentlot1, ClearCanvas.Healthcare.Order order1, string description1, DateTime transactiondate1, ClearCanvas.Enterprise.Authentication.User user1, ClearCanvas.Material.Healthcare.StockTransactionTypeEnum transactiontype1, ISet<ClearCanvas.Material.Healthcare.StockTransactionLine> details1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_code = code1;
		  	
		  	_supplier = supplier1;
		  	
		  	_inWarehouse = inwarehouse1;
		  	
		  	_outWarehouse = outwarehouse1;
		  	
		  	_equipmentLot = equipmentlot1;
		  	
		  	_order = order1;
		  	
		  	_description = description1;
		  	
		  	_transactionDate = transactiondate1;
		  	
		  	_user = user1;
		  	
		  	_transactionType = transactiontype1;
		  	
		  	_details = details1;
		  	
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
	  	public virtual ClearCanvas.Material.Healthcare.Contact Supplier
	  	{
			
			get { return _supplier; }
			
			
			 set { _supplier = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Material.Healthcare.Warehouse InWarehouse
	  	{
			
			get { return _inWarehouse; }
			
			
			 set { _inWarehouse = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Material.Healthcare.Warehouse OutWarehouse
	  	{
			
			get { return _outWarehouse; }
			
			
			 set { _outWarehouse = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Material.Healthcare.MaterialLot EquipmentLot
	  	{
			
			get { return _equipmentLot; }
			
			
			 set { _equipmentLot = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Order Order
	  	{
			
			get { return _order; }
			
			
			 set { _order = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string Description
	  	{
			
			get { return _description; }
			
			
			 set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime TransactionDate
	  	{
			
			get { return _transactionDate; }
			
			
			 set { _transactionDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Enterprise.Authentication.User User
	  	{
			
			get { return _user; }
			
			
			 set { _user = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Material.Healthcare.StockTransactionTypeEnum TransactionType
	  	{
			
			get { return _transactionType; }
			
			
			 set { _transactionType = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Material.Healthcare.StockTransactionLine> Details
	  	{
			
			get { return _details; }
			
			
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
