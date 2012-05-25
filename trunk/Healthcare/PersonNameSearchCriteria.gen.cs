// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="PersonName"/> class.
    /// </summary>
	public partial class PersonNameSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public PersonNameSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public PersonNameSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected PersonNameSearchCriteria(PersonNameSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new PersonNameSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> FamilyName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("FamilyName"))
	  			{
	  				this.SubCriteria["FamilyName"] = new SearchCondition<string>("FamilyName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["FamilyName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> GivenName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("GivenName"))
	  			{
	  				this.SubCriteria["GivenName"] = new SearchCondition<string>("GivenName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["GivenName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> MiddleName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("MiddleName"))
	  			{
	  				this.SubCriteria["MiddleName"] = new SearchCondition<string>("MiddleName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["MiddleName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Prefix
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Prefix"))
	  			{
	  				this.SubCriteria["Prefix"] = new SearchCondition<string>("Prefix");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Prefix"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Suffix
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Suffix"))
	  			{
	  				this.SubCriteria["Suffix"] = new SearchCondition<string>("Suffix");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Suffix"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Degree
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Degree"))
	  			{
	  				this.SubCriteria["Degree"] = new SearchCondition<string>("Degree");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Degree"];
	  		}
	  	}
	  	
	}
}
