using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{
    public class InsuranceRuleSearchCriteria : EntitySearchCriteria<InsuranceRule>
    {
         /// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public InsuranceRuleSearchCriteria ()
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
       
		
	  	public ISearchCondition<string> InsuranceRuleID
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InsuranceRuleID"))
	  			{
                    this.SubCriteria["InsuranceRuleID"] = new SearchCondition<string>("InsuranceRuleID");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["InsuranceRuleID"];
	  		}
	  	}
       
        public ISearchCondition<string> ClassID
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("ClassID"))
                {
                    this.SubCriteria["ClassID"] = new SearchCondition<string>("ClassID");
                }
                return (ISearchCondition<string>)this.SubCriteria["ClassID"];
            }
        }
	  	
	  	public ISearchCondition<string> ProcedureTypeID_
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("ProcedureTypeID_"))
	  			{
                    this.SubCriteria["ProcedureTypeID_"] = new SearchCondition<string>("ProcedureTypeID_");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["ProcedureTypeID_"];
	  		}
	  	}

        public ISearchCondition<string> RuleCode
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("RuleCode"))
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
                if (!this.SubCriteria.ContainsKey("RuleName"))
	  			{
                    this.SubCriteria["RuleName"] = new SearchCondition<string>("RuleName");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["RuleName"];
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
        

        public ISearchCondition<DateTime> StartDate
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("StartDate"))
                {
                    this.SubCriteria["StartDate"] = new SearchCondition<DateTime>("StartDate");
                }
                return (ISearchCondition<DateTime>)this.SubCriteria["StartDate"];
            }
        }

        public ISearchCondition<DateTime> ExpireDate
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("ExpireDate"))
                {
                    this.SubCriteria["ExpireDate"] = new SearchCondition<DateTime>("ExpireDate");
                }
                return (ISearchCondition<DateTime>)this.SubCriteria["ExpireDate"];
            }
        }


        public ISearchCondition<DateTime> CreatedTime
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("CreatedTime"))
                {
                    this.SubCriteria["CreatedTime"] = new SearchCondition<DateTime>("CreatedTime");
                }
                return (ISearchCondition<DateTime>)this.SubCriteria["CreatedTime"];
            }
        }

        public ISearchCondition<DateTime> LastUpdated
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("LastUpdated"))
                {
                    this.SubCriteria["LastUpdated"] = new SearchCondition<DateTime>("LastUpdated");
                }
                return (ISearchCondition<DateTime>)this.SubCriteria["LastUpdated"];
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
        public ISearchCondition<ProcedureType> ProcedureType
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("ProcedureType"))
                {
                    this.SubCriteria["ProcedureType"] = new SearchCondition<ProcedureType>("ProcedureType");
                }
                return (ISearchCondition<ProcedureType>)this.SubCriteria["ProcedureType"];
            }
        }

        public ISearchCondition<InsuranceTypeEnum> Insurance
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("ClassID"))
                {
                    this.SubCriteria["ClassID"] = new SearchCondition<InsuranceTypeEnum>("ClassID");
                }
                return (ISearchCondition<InsuranceTypeEnum>)this.SubCriteria["ClassID"];
            }
        }
    }
	  	
}
