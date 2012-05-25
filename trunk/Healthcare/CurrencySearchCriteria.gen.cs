// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Currency"/> class.
    /// </summary>
	public partial class CurrencySearchCriteria : EntitySearchCriteria<Currency>
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
	  			if(!this.SubCriteria.ContainsKey("CurrencyCode"))
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
	  			if(!this.SubCriteria.ContainsKey("CurrencyName"))
	  			{
	  				this.SubCriteria["CurrencyName"] = new SearchCondition<string>("CurrencyName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["CurrencyName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> RateToPrimaryExRate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("RateToPrimaryExRate"))
	  			{
	  				this.SubCriteria["RateToPrimaryExRate"] = new SearchCondition<Decimal>("RateToPrimaryExRate");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["RateToPrimaryExRate"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> DisplayLocale
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DisplayLocale"))
	  			{
	  				this.SubCriteria["DisplayLocale"] = new SearchCondition<string>("DisplayLocale");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["DisplayLocale"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> CustomDisplayFormat
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CustomDisplayFormat"))
	  			{
	  				this.SubCriteria["CustomDisplayFormat"] = new SearchCondition<string>("CustomDisplayFormat");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["CustomDisplayFormat"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsPrimaryExRateCurrency
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsPrimaryExRateCurrency"))
	  			{
	  				this.SubCriteria["IsPrimaryExRateCurrency"] = new SearchCondition<bool>("IsPrimaryExRateCurrency");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsPrimaryExRateCurrency"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsPrimaryCurrency
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsPrimaryCurrency"))
	  			{
	  				this.SubCriteria["IsPrimaryCurrency"] = new SearchCondition<bool>("IsPrimaryCurrency");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsPrimaryCurrency"];
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
	  	
	  	public ISearchCondition<DateTime> CreatedOn
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreatedOn"))
	  			{
	  				this.SubCriteria["CreatedOn"] = new SearchCondition<DateTime>("CreatedOn");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["CreatedOn"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> LastUpdated
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("LastUpdated"))
	  			{
	  				this.SubCriteria["LastUpdated"] = new SearchCondition<DateTime>("LastUpdated");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["LastUpdated"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.FacilitySearchCriteria Clinic
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Clinic"))
	  			{
	  				this.SubCriteria["Clinic"] = new ClearCanvas.Healthcare.FacilitySearchCriteria("Clinic");
	  			}
	  			return (ClearCanvas.Healthcare.FacilitySearchCriteria)this.SubCriteria["Clinic"];
	  		}
	  	}
	  	
	}
}
