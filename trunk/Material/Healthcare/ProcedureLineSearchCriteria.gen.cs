// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Material.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProcedureLine"/> class.
    /// </summary>
	public partial class ProcedureLineSearchCriteria : EntitySearchCriteria<ProcedureLine>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProcedureLineSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProcedureLineSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProcedureLineSearchCriteria(ProcedureLineSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProcedureLineSearchCriteria(this);
        }


		
	  	public ISearchCondition<ClearCanvas.Healthcare.Procedure> ParentProcedure
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ParentProcedure"))
	  			{
	  				this.SubCriteria["ParentProcedure"] = new SearchCondition<ClearCanvas.Healthcare.Procedure>("ParentProcedure");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.Procedure>)this.SubCriteria["ParentProcedure"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Material.Healthcare.StockTransactionLineSearchCriteria StockTransactionsDetails
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StockTransactionsDetails"))
	  			{
	  				this.SubCriteria["StockTransactionsDetails"] = new ClearCanvas.Material.Healthcare.StockTransactionLineSearchCriteria("StockTransactionsDetails");
	  			}
	  			return (ClearCanvas.Material.Healthcare.StockTransactionLineSearchCriteria)this.SubCriteria["StockTransactionsDetails"];
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
	  	
	  	public ISearchCondition<DateTime?> CreatedDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreatedDate"))
	  			{
	  				this.SubCriteria["CreatedDate"] = new SearchCondition<DateTime?>("CreatedDate");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["CreatedDate"];
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
	  	
	  	public ISearchCondition<bool> IsInsuranceSale
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsInsuranceSale"))
	  			{
	  				this.SubCriteria["IsInsuranceSale"] = new SearchCondition<bool>("IsInsuranceSale");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsInsuranceSale"];
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
	  	
	}
}
