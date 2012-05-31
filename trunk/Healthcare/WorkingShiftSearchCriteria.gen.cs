// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="WorkingShift"/> class.
    /// </summary>
	public partial class WorkingShiftSearchCriteria : EntitySearchCriteria<WorkingShift>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public WorkingShiftSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public WorkingShiftSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected WorkingShiftSearchCriteria(WorkingShiftSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new WorkingShiftSearchCriteria(this);
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
	  	
	  	public ISearchCondition<DateTime?> ValidFromDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ValidFromDate"))
	  			{
	  				this.SubCriteria["ValidFromDate"] = new SearchCondition<DateTime?>("ValidFromDate");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ValidFromDate"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Double> StartTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StartTime"))
	  			{
	  				this.SubCriteria["StartTime"] = new SearchCondition<Double>("StartTime");
	  			}
	  			return (ISearchCondition<Double>)this.SubCriteria["StartTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> ValidToDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ValidToDate"))
	  			{
	  				this.SubCriteria["ValidToDate"] = new SearchCondition<DateTime?>("ValidToDate");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ValidToDate"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Double> EndTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("EndTime"))
	  			{
	  				this.SubCriteria["EndTime"] = new SearchCondition<Double>("EndTime");
	  			}
	  			return (ISearchCondition<Double>)this.SubCriteria["EndTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> EndTimeType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("EndTimeType"))
	  			{
	  				this.SubCriteria["EndTimeType"] = new SearchCondition<string>("EndTimeType");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["EndTimeType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> StartTimeType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StartTimeType"))
	  			{
	  				this.SubCriteria["StartTimeType"] = new SearchCondition<string>("StartTimeType");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["StartTimeType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> WorkOnSunday
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WorkOnSunday"))
	  			{
	  				this.SubCriteria["WorkOnSunday"] = new SearchCondition<bool>("WorkOnSunday");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["WorkOnSunday"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> WorkOnMonday
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WorkOnMonday"))
	  			{
	  				this.SubCriteria["WorkOnMonday"] = new SearchCondition<bool>("WorkOnMonday");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["WorkOnMonday"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> WorkOnTuesday
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WorkOnTuesday"))
	  			{
	  				this.SubCriteria["WorkOnTuesday"] = new SearchCondition<bool>("WorkOnTuesday");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["WorkOnTuesday"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> WorkOnWednesday
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WorkOnWednesday"))
	  			{
	  				this.SubCriteria["WorkOnWednesday"] = new SearchCondition<bool>("WorkOnWednesday");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["WorkOnWednesday"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> WorkOnThursday
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WorkOnThursday"))
	  			{
	  				this.SubCriteria["WorkOnThursday"] = new SearchCondition<bool>("WorkOnThursday");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["WorkOnThursday"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> WorkOnFriday
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WorkOnFriday"))
	  			{
	  				this.SubCriteria["WorkOnFriday"] = new SearchCondition<bool>("WorkOnFriday");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["WorkOnFriday"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> WorkOnSaturday
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WorkOnSaturday"))
	  			{
	  				this.SubCriteria["WorkOnSaturday"] = new SearchCondition<bool>("WorkOnSaturday");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["WorkOnSaturday"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> ExactDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ExactDate"))
	  			{
	  				this.SubCriteria["ExactDate"] = new SearchCondition<DateTime?>("ExactDate");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ExactDate"];
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
