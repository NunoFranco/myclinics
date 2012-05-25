// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="StaffGroup"/> class.
    /// </summary>
	public partial class StaffGroupSearchCriteria : EntitySearchCriteria<StaffGroup>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public StaffGroupSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public StaffGroupSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected StaffGroupSearchCriteria(StaffGroupSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new StaffGroupSearchCriteria(this);
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
	  	
	  	public ISearchCondition<bool> Elective
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Elective"))
	  			{
	  				this.SubCriteria["Elective"] = new SearchCondition<bool>("Elective");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Elective"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.FacilitySearchCriteria Clinic
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Clinic"))
	  			{
	  				this.SubCriteria["Clinic"] = new ClearCanvas.Healthcare.FacilitySearchCriteria("Clinic");
	  			}
	  			return (ClearCanvas.Healthcare.FacilitySearchCriteria)this.SubCriteria["Clinic"];
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
