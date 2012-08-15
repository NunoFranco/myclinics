// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Material.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="StockTransactionLine"/> class.
    /// </summary>
	public partial class StockTransactionLineSearchCriteria : EntitySearchCriteria<StockTransactionLine>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public StockTransactionLineSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public StockTransactionLineSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected StockTransactionLineSearchCriteria(StockTransactionLineSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new StockTransactionLineSearchCriteria(this);
        }


		
	  	public ISearchCondition<ClearCanvas.Healthcare.ProcedureType> Material
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Material"))
	  			{
	  				this.SubCriteria["Material"] = new SearchCondition<ClearCanvas.Healthcare.ProcedureType>("Material");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ProcedureType>)this.SubCriteria["Material"];
	  		}
	  	}
	  	
	  	public ISearchCondition<double> Amount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Amount"))
	  			{
	  				this.SubCriteria["Amount"] = new SearchCondition<double>("Amount");
	  			}
	  			return (ISearchCondition<double>)this.SubCriteria["Amount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<double> InputPrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InputPrice"))
	  			{
	  				this.SubCriteria["InputPrice"] = new SearchCondition<double>("InputPrice");
	  			}
	  			return (ISearchCondition<double>)this.SubCriteria["InputPrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<double> SalePrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SalePrice"))
	  			{
	  				this.SubCriteria["SalePrice"] = new SearchCondition<double>("SalePrice");
	  			}
	  			return (ISearchCondition<double>)this.SubCriteria["SalePrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<double> InsurancePrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InsurancePrice"))
	  			{
	  				this.SubCriteria["InsurancePrice"] = new SearchCondition<double>("InsurancePrice");
	  			}
	  			return (ISearchCondition<double>)this.SubCriteria["InsurancePrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<double> SoldAmount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SoldAmount"))
	  			{
	  				this.SubCriteria["SoldAmount"] = new SearchCondition<double>("SoldAmount");
	  			}
	  			return (ISearchCondition<double>)this.SubCriteria["SoldAmount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.UOMEnum> UOM
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("UOM"))
	  			{
	  				this.SubCriteria["UOM"] = new SearchCondition<ClearCanvas.Healthcare.UOMEnum>("UOM");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.UOMEnum>)this.SubCriteria["UOM"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Material.Healthcare.StockTransactionSearchCriteria Transaction
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Transaction"))
	  			{
	  				this.SubCriteria["Transaction"] = new ClearCanvas.Material.Healthcare.StockTransactionSearchCriteria("Transaction");
	  			}
	  			return (ClearCanvas.Material.Healthcare.StockTransactionSearchCriteria)this.SubCriteria["Transaction"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> ExpireDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ExpireDate"))
	  			{
	  				this.SubCriteria["ExpireDate"] = new SearchCondition<DateTime?>("ExpireDate");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ExpireDate"];
	  		}
	  	}
	  	
	  	public ISearchCondition<double> Tax
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Tax"))
	  			{
	  				this.SubCriteria["Tax"] = new SearchCondition<double>("Tax");
	  			}
	  			return (ISearchCondition<double>)this.SubCriteria["Tax"];
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
