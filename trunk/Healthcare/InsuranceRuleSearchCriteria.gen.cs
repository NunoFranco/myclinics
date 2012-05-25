// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="InsuranceRule"/> class.
    /// </summary>
	public partial class InsuranceRuleSearchCriteria : EntitySearchCriteria<InsuranceRule>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public InsuranceRuleSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public InsuranceRuleSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected InsuranceRuleSearchCriteria(InsuranceRuleSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new InsuranceRuleSearchCriteria(this);
        }


		
	  	public ISearchCondition<ClearCanvas.Healthcare.InsuranceTypeEnum> ClassID
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ClassID"))
	  			{
	  				this.SubCriteria["ClassID"] = new SearchCondition<ClearCanvas.Healthcare.InsuranceTypeEnum>("ClassID");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.InsuranceTypeEnum>)this.SubCriteria["ClassID"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.ProcedureTypeSearchCriteria ProcedureType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ProcedureType"))
	  			{
	  				this.SubCriteria["ProcedureType"] = new ClearCanvas.Healthcare.ProcedureTypeSearchCriteria("ProcedureType");
	  			}
	  			return (ClearCanvas.Healthcare.ProcedureTypeSearchCriteria)this.SubCriteria["ProcedureType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> RuleCode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("RuleCode"))
	  			{
	  				this.SubCriteria["RuleCode"] = new SearchCondition<string>("RuleCode");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["RuleCode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> RuleName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("RuleName"))
	  			{
	  				this.SubCriteria["RuleName"] = new SearchCondition<string>("RuleName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["RuleName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DisCountInsuranceAmountType> AmountType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AmountType"))
	  			{
	  				this.SubCriteria["AmountType"] = new SearchCondition<DisCountInsuranceAmountType>("AmountType");
	  			}
	  			return (ISearchCondition<DisCountInsuranceAmountType>)this.SubCriteria["AmountType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> Amount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Amount"))
	  			{
	  				this.SubCriteria["Amount"] = new SearchCondition<Decimal>("Amount");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["Amount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> StartDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StartDate"))
	  			{
	  				this.SubCriteria["StartDate"] = new SearchCondition<DateTime?>("StartDate");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["StartDate"];
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
	  	
	  	public ISearchCondition<string> CreatedUser
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreatedUser"))
	  			{
	  				this.SubCriteria["CreatedUser"] = new SearchCondition<string>("CreatedUser");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["CreatedUser"];
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
	  	
	  	public ISearchCondition<DateTime?> LastUpdated
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("LastUpdated"))
	  			{
	  				this.SubCriteria["LastUpdated"] = new SearchCondition<DateTime?>("LastUpdated");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["LastUpdated"];
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
