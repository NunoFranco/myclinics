using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{
    public class CurrencySearchCriteria : EntitySearchCriteria<OrderInvoices>
    {
        /// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public CurrencySearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public CurrencySearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
        protected CurrencySearchCriteria(CurrencySearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new CurrencySearchCriteria(this);
        }



        public ISearchCondition<string> CurrencyCode
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("CurrencyCode"))
                {
                    this.SubCriteria["CurrencyCode"] = new SearchCondition<string>("CurrencyCode");
                }
                return (ISearchCondition<string>)this.SubCriteria["CurrencyCode"];
            }
        }
	  	
	  	public ISearchCondition<string> CurrencyName
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("CurrencyName"))
	  			{
                    this.SubCriteria["CurrencyName"] = new SearchCondition<string>("CurrencyName");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["CurrencyName"];
	  		}
	  	}

        public ISearchCondition<bool> IsPrimaryCurrency
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("IsPrimaryCurrency"))
                {
                    this.SubCriteria["IsPrimaryCurrency"] = new SearchCondition<bool>("IsPrimaryCurrency");
                }
                return (ISearchCondition<bool>)this.SubCriteria["IsPrimaryCurrency"];
            }
        }

        public ISearchCondition<bool> IsPrimaryExRateCurrency
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("IsPrimaryExRateCurrency"))
                {
                    this.SubCriteria["IsPrimaryExRateCurrency"] = new SearchCondition<bool>("IsPrimaryExRateCurrency");
                }
                return (ISearchCondition<bool>)this.SubCriteria["IsPrimaryExRateCurrency"];
            }
        }
      
        public ISearchCondition<bool> Deactivated
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("Deactivated"))
                {
                    this.SubCriteria["Deactivated"] = new SearchCondition<bool>("Deactivated");
                }
                return (ISearchCondition<bool>)this.SubCriteria["Deactivated"];
            }
        }
	  	
    }
}
