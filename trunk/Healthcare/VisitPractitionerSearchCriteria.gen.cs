// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="VisitPractitioner"/> class.
    /// </summary>
	public partial class VisitPractitionerSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public VisitPractitionerSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public VisitPractitionerSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected VisitPractitionerSearchCriteria(VisitPractitionerSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new VisitPractitionerSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.ExternalPractitionerSearchCriteria Practitioner
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Practitioner"))
	  			{
	  				this.SubCriteria["Practitioner"] = new ClearCanvas.Healthcare.ExternalPractitionerSearchCriteria("Practitioner");
	  			}
	  			return (ClearCanvas.Healthcare.ExternalPractitionerSearchCriteria)this.SubCriteria["Practitioner"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.VisitPractitionerRoleEnum > Role
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Role"))
	  			{
	  				this.SubCriteria["Role"] = new SearchCondition<ClearCanvas.Healthcare.VisitPractitionerRoleEnum >("Role");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.VisitPractitionerRoleEnum >)this.SubCriteria["Role"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> StartTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StartTime"))
	  			{
	  				this.SubCriteria["StartTime"] = new SearchCondition<DateTime?>("StartTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["StartTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> EndTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("EndTime"))
	  			{
	  				this.SubCriteria["EndTime"] = new SearchCondition<DateTime?>("EndTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["EndTime"];
	  		}
	  	}
	  	
	}
}
