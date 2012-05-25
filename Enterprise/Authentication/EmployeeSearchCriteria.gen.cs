// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Enterprise.Authentication
{

    /// <summary>
    /// Search criteria for <see cref="Employee"/> class.
    /// </summary>
	public partial class EmployeeSearchCriteria : EntitySearchCriteria<Employee>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public EmployeeSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public EmployeeSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected EmployeeSearchCriteria(EmployeeSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new EmployeeSearchCriteria(this);
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
	  	
	  	public ISearchCondition<string> Title
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Title"))
	  			{
	  				this.SubCriteria["Title"] = new SearchCondition<string>("Title");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Title"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> LicenseNumber
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("LicenseNumber"))
	  			{
	  				this.SubCriteria["LicenseNumber"] = new SearchCondition<string>("LicenseNumber");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["LicenseNumber"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> BillingNumber
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("BillingNumber"))
	  			{
	  				this.SubCriteria["BillingNumber"] = new SearchCondition<string>("BillingNumber");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["BillingNumber"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> UserName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("UserName"))
	  			{
	  				this.SubCriteria["UserName"] = new SearchCondition<string>("UserName");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["UserName"];
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
