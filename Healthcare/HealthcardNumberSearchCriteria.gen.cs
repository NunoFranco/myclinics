// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="HealthcardNumber"/> class.
    /// </summary>
	public partial class HealthcardNumberSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public HealthcardNumberSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public HealthcardNumberSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected HealthcardNumberSearchCriteria(HealthcardNumberSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new HealthcardNumberSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Id
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Id"))
	  			{
	  				this.SubCriteria["Id"] = new SearchCondition<string>("Id");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Id"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.InsuranceAuthorityEnum> AssigningAuthority
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AssigningAuthority"))
	  			{
	  				this.SubCriteria["AssigningAuthority"] = new SearchCondition<ClearCanvas.Healthcare.InsuranceAuthorityEnum>("AssigningAuthority");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.InsuranceAuthorityEnum>)this.SubCriteria["AssigningAuthority"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> VersionCode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("VersionCode"))
	  			{
	  				this.SubCriteria["VersionCode"] = new SearchCondition<string>("VersionCode");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["VersionCode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> ExpiryDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ExpiryDate"))
	  			{
	  				this.SubCriteria["ExpiryDate"] = new SearchCondition<DateTime?>("ExpiryDate");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ExpiryDate"];
	  		}
	  	}
	  	
	}
}
