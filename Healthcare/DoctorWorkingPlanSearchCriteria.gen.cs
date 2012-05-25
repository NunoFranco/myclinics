// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="DoctorWorkingPlan"/> class.
    /// </summary>
	public partial class DoctorWorkingPlanSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public DoctorWorkingPlanSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public DoctorWorkingPlanSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected DoctorWorkingPlanSearchCriteria(DoctorWorkingPlanSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new DoctorWorkingPlanSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Doctor
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Doctor"))
	  			{
	  				this.SubCriteria["Doctor"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Doctor");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Doctor"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> PlanDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PlanDate"))
	  			{
	  				this.SubCriteria["PlanDate"] = new SearchCondition<DateTime>("PlanDate");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["PlanDate"];
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
	  	
	}
}
