// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Enterprise.Configuration
{

    /// <summary>
    /// Search criteria for <see cref="ConfigurationSettingsProperty"/> class.
    /// </summary>
	public partial class ConfigurationSettingsPropertySearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ConfigurationSettingsPropertySearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ConfigurationSettingsPropertySearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ConfigurationSettingsPropertySearchCriteria(ConfigurationSettingsPropertySearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ConfigurationSettingsPropertySearchCriteria(this);
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
	  	
	  	public ISearchCondition<string> TypeName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TypeName"))
	  			{
	  				this.SubCriteria["TypeName"] = new SearchCondition<string>("TypeName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["TypeName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Scope
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Scope"))
	  			{
	  				this.SubCriteria["Scope"] = new SearchCondition<string>("Scope");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Scope"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Description
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Description"))
	  			{
	  				this.SubCriteria["Description"] = new SearchCondition<string>("Description");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Description"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> DefaultValue
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DefaultValue"))
	  			{
	  				this.SubCriteria["DefaultValue"] = new SearchCondition<string>("DefaultValue");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["DefaultValue"];
	  		}
	  	}
	  	
	}
}
