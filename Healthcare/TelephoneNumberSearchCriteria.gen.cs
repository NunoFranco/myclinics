// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="TelephoneNumber"/> class.
    /// </summary>
	public partial class TelephoneNumberSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public TelephoneNumberSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public TelephoneNumberSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected TelephoneNumberSearchCriteria(TelephoneNumberSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new TelephoneNumberSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> CountryCode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CountryCode"))
	  			{
	  				this.SubCriteria["CountryCode"] = new SearchCondition<string>("CountryCode");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["CountryCode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> AreaCode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AreaCode"))
	  			{
	  				this.SubCriteria["AreaCode"] = new SearchCondition<string>("AreaCode");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["AreaCode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Number
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Number"))
	  			{
	  				this.SubCriteria["Number"] = new SearchCondition<string>("Number");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Number"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Extension
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Extension"))
	  			{
	  				this.SubCriteria["Extension"] = new SearchCondition<string>("Extension");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Extension"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.TelephoneUseEnum> Use
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Use"))
	  			{
	  				this.SubCriteria["Use"] = new SearchCondition<ClearCanvas.Healthcare.TelephoneUseEnum>("Use");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.TelephoneUseEnum>)this.SubCriteria["Use"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.TelephoneEquipmentEnum> Equipment
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Equipment"))
	  			{
	  				this.SubCriteria["Equipment"] = new SearchCondition<ClearCanvas.Healthcare.TelephoneEquipmentEnum>("Equipment");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.TelephoneEquipmentEnum>)this.SubCriteria["Equipment"];
	  		}
	  	}
	  	
	}
}
