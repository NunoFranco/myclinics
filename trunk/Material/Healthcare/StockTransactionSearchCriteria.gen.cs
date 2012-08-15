// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Material.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="StockTransaction"/> class.
    /// </summary>
	public partial class StockTransactionSearchCriteria : EntitySearchCriteria<StockTransaction>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public StockTransactionSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public StockTransactionSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected StockTransactionSearchCriteria(StockTransactionSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new StockTransactionSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Code
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Code"))
	  			{
	  				this.SubCriteria["Code"] = new SearchCondition<string>("Code");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Code"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Material.Healthcare.ContactSearchCriteria Supplier
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Supplier"))
	  			{
	  				this.SubCriteria["Supplier"] = new ClearCanvas.Material.Healthcare.ContactSearchCriteria("Supplier");
	  			}
	  			return (ClearCanvas.Material.Healthcare.ContactSearchCriteria)this.SubCriteria["Supplier"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Material.Healthcare.WarehouseSearchCriteria InWarehouse
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InWarehouse"))
	  			{
	  				this.SubCriteria["InWarehouse"] = new ClearCanvas.Material.Healthcare.WarehouseSearchCriteria("InWarehouse");
	  			}
	  			return (ClearCanvas.Material.Healthcare.WarehouseSearchCriteria)this.SubCriteria["InWarehouse"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Material.Healthcare.WarehouseSearchCriteria OutWarehouse
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("OutWarehouse"))
	  			{
	  				this.SubCriteria["OutWarehouse"] = new ClearCanvas.Material.Healthcare.WarehouseSearchCriteria("OutWarehouse");
	  			}
	  			return (ClearCanvas.Material.Healthcare.WarehouseSearchCriteria)this.SubCriteria["OutWarehouse"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Material.Healthcare.MaterialLotSearchCriteria EquipmentLot
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("EquipmentLot"))
	  			{
	  				this.SubCriteria["EquipmentLot"] = new ClearCanvas.Material.Healthcare.MaterialLotSearchCriteria("EquipmentLot");
	  			}
	  			return (ClearCanvas.Material.Healthcare.MaterialLotSearchCriteria)this.SubCriteria["EquipmentLot"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.Order> Order
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Order"))
	  			{
	  				this.SubCriteria["Order"] = new SearchCondition<ClearCanvas.Healthcare.Order>("Order");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.Order>)this.SubCriteria["Order"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Description
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Description"))
	  			{
	  				this.SubCriteria["Description"] = new SearchCondition<string>("Description");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Description"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> TransactionDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TransactionDate"))
	  			{
	  				this.SubCriteria["TransactionDate"] = new SearchCondition<DateTime>("TransactionDate");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["TransactionDate"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Enterprise.Authentication.User> User
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("User"))
	  			{
	  				this.SubCriteria["User"] = new SearchCondition<ClearCanvas.Enterprise.Authentication.User>("User");
	  			}
	  			return (ISearchCondition<ClearCanvas.Enterprise.Authentication.User>)this.SubCriteria["User"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Material.Healthcare.StockTransactionTypeEnum> TransactionType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TransactionType"))
	  			{
	  				this.SubCriteria["TransactionType"] = new SearchCondition<ClearCanvas.Material.Healthcare.StockTransactionTypeEnum>("TransactionType");
	  			}
	  			return (ISearchCondition<ClearCanvas.Material.Healthcare.StockTransactionTypeEnum>)this.SubCriteria["TransactionType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> Deactivated
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Deactivated"))
	  			{
	  				this.SubCriteria["Deactivated"] = new SearchCondition<bool>("Deactivated");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Deactivated"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.Facility> Clinic
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Clinic"))
	  			{
	  				this.SubCriteria["Clinic"] = new SearchCondition<ClearCanvas.Healthcare.Facility>("Clinic");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.Facility>)this.SubCriteria["Clinic"];
	  		}
	  	}
	  	
	}
}
