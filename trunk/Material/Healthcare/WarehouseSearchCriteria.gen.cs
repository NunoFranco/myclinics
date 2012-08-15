// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Material.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Warehouse"/> class.
    /// </summary>
	public partial class WarehouseSearchCriteria : EntitySearchCriteria<Warehouse>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public WarehouseSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public WarehouseSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected WarehouseSearchCriteria(WarehouseSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new WarehouseSearchCriteria(this);
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
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.Staff> PICName
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PICName"))
	  			{
	  				this.SubCriteria["PICName"] = new SearchCondition<ClearCanvas.Healthcare.Staff>("PICName");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.Staff>)this.SubCriteria["PICName"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> ContactDetailInformation
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ContactDetailInformation"))
	  			{
	  				this.SubCriteria["ContactDetailInformation"] = new SearchCondition<string>("ContactDetailInformation");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["ContactDetailInformation"];
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
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.Facility> Clinic
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Clinic"))
	  			{
	  				this.SubCriteria["Clinic"] = new SearchCondition<ClearCanvas.Healthcare.Facility>("Clinic");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.Facility>)this.SubCriteria["Clinic"];
	  		}
	  	}
	  	
	}
}
