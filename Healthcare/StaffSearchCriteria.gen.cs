// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Staff"/> class.
    /// </summary>
	public partial class StaffSearchCriteria : EntitySearchCriteria<Staff>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public StaffSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public StaffSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected StaffSearchCriteria(StaffSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new StaffSearchCriteria(this);
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
	  	
	  	public ClearCanvas.Healthcare.PersonNameSearchCriteria Name
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Name"))
	  			{
	  				this.SubCriteria["Name"] = new ClearCanvas.Healthcare.PersonNameSearchCriteria("Name");
	  			}
	  			return (ClearCanvas.Healthcare.PersonNameSearchCriteria)this.SubCriteria["Name"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.SexEnum> Sex
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Sex"))
	  			{
	  				this.SubCriteria["Sex"] = new SearchCondition<ClearCanvas.Healthcare.SexEnum>("Sex");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.SexEnum>)this.SubCriteria["Sex"];
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
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.StaffTypeEnum> Type
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Type"))
	  			{
	  				this.SubCriteria["Type"] = new SearchCondition<ClearCanvas.Healthcare.StaffTypeEnum>("Type");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.StaffTypeEnum>)this.SubCriteria["Type"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.FacilitySearchCriteria MainClinic
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("MainClinic"))
	  			{
	  				this.SubCriteria["MainClinic"] = new ClearCanvas.Healthcare.FacilitySearchCriteria("MainClinic");
	  			}
	  			return (ClearCanvas.Healthcare.FacilitySearchCriteria)this.SubCriteria["MainClinic"];
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
