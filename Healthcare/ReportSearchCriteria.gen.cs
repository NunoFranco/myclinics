// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Report"/> class.
    /// </summary>
	public partial class ReportSearchCriteria : EntitySearchCriteria<Report>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ReportSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ReportSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ReportSearchCriteria(ReportSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ReportSearchCriteria(this);
        }


		
	  	public ISearchCondition<ClearCanvas.Healthcare.ReportStatusEnum> Status
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Status"))
	  			{
	  				this.SubCriteria["Status"] = new SearchCondition<ClearCanvas.Healthcare.ReportStatusEnum>("Status");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ReportStatusEnum>)this.SubCriteria["Status"];
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
