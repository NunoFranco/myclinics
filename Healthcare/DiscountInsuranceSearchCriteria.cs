using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{
    public class DiscountInsuranceRuleSearchCriteria : EntitySearchCriteria<DiscountInsuranceClass>
    {
        /// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public DiscountInsuranceRuleSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public DiscountInsuranceRuleSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
        protected DiscountInsuranceRuleSearchCriteria(DiscountInsuranceRuleSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new DiscountInsuranceRuleSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> ClassCode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ClassCode"))
	  			{
                    this.SubCriteria["ClassCode"] = new SearchCondition<string>("ClassCode");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["ClassCode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> ClassName
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("ClassName"))
	  			{
                    this.SubCriteria["ClassName"] = new SearchCondition<string>("ClassName");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["ClassName"];
	  		}
	  	}

        public ISearchCondition<string> ClassType
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("ClassType"))
	  			{
                    this.SubCriteria["ClassType"] = new SearchCondition<string>("ClassType");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["ClassType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> AmountType
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("AmountType"))
	  			{
                    this.SubCriteria["AmountType"] = new SearchCondition<string>("AmountType");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["AmountType"];
	  		}
	  	}
        public ISearchCondition<decimal> Amount
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("Amount"))
                {
                    this.SubCriteria["Amount"] = new SearchCondition<decimal>("Amount");
                }
                return (ISearchCondition<decimal>)this.SubCriteria["Amount"];
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
