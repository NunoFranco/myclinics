// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Facility"/> class.
    /// </summary>
	public partial class FacilitySearchCriteria : EntitySearchCriteria<Facility>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public FacilitySearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public FacilitySearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected FacilitySearchCriteria(FacilitySearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new FacilitySearchCriteria(this);
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
	  	
	  	public ISearchCondition<string> Name
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Name"))
	  			{
	  				this.SubCriteria["Name"] = new SearchCondition<string>("Name");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Name"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Address
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Address"))
	  			{
	  				this.SubCriteria["Address"] = new SearchCondition<string>("Address");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Address"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum> InformationAuthority
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InformationAuthority"))
	  			{
	  				this.SubCriteria["InformationAuthority"] = new SearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum>("InformationAuthority");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum>)this.SubCriteria["InformationAuthority"];
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
