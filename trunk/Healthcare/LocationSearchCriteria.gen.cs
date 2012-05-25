// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Location"/> class.
    /// </summary>
	public partial class LocationSearchCriteria : EntitySearchCriteria<Location>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public LocationSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public LocationSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected LocationSearchCriteria(LocationSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new LocationSearchCriteria(this);
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
	  	
	  	public ClearCanvas.Healthcare.FacilitySearchCriteria Facility
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Facility"))
	  			{
	  				this.SubCriteria["Facility"] = new ClearCanvas.Healthcare.FacilitySearchCriteria("Facility");
	  			}
	  			return (ClearCanvas.Healthcare.FacilitySearchCriteria)this.SubCriteria["Facility"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Building
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Building"))
	  			{
	  				this.SubCriteria["Building"] = new SearchCondition<string>("Building");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Building"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Floor
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Floor"))
	  			{
	  				this.SubCriteria["Floor"] = new SearchCondition<string>("Floor");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Floor"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> PointOfCare
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PointOfCare"))
	  			{
	  				this.SubCriteria["PointOfCare"] = new SearchCondition<string>("PointOfCare");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["PointOfCare"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Room
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Room"))
	  			{
	  				this.SubCriteria["Room"] = new SearchCondition<string>("Room");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Room"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Bed
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Bed"))
	  			{
	  				this.SubCriteria["Bed"] = new SearchCondition<string>("Bed");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Bed"];
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
