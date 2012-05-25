// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Enterprise.Configuration
{

    /// <summary>
    /// Search criteria for <see cref="ConfigurationSettingsGroup"/> class.
    /// </summary>
	public partial class ConfigurationSettingsGroupSearchCriteria : EntitySearchCriteria<ConfigurationSettingsGroup>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ConfigurationSettingsGroupSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ConfigurationSettingsGroupSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ConfigurationSettingsGroupSearchCriteria(ConfigurationSettingsGroupSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ConfigurationSettingsGroupSearchCriteria(this);
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
	  	
	  	public ISearchCondition<string> VersionString
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("VersionString"))
	  			{
	  				this.SubCriteria["VersionString"] = new SearchCondition<string>("VersionString");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["VersionString"];
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
	  	
	  	public ISearchCondition<string> AssemblyQualifiedTypeName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AssemblyQualifiedTypeName"))
	  			{
	  				this.SubCriteria["AssemblyQualifiedTypeName"] = new SearchCondition<string>("AssemblyQualifiedTypeName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["AssemblyQualifiedTypeName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> HasUserScopedSettings
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("HasUserScopedSettings"))
	  			{
	  				this.SubCriteria["HasUserScopedSettings"] = new SearchCondition<bool>("HasUserScopedSettings");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["HasUserScopedSettings"];
	  		}
	  	}
	  	
	}
}
