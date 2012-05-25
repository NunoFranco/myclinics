// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="VisitLocation"/> class.
    /// </summary>
	public partial class VisitLocationSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public VisitLocationSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public VisitLocationSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected VisitLocationSearchCriteria(VisitLocationSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new VisitLocationSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.LocationSearchCriteria Location
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Location"))
	  			{
	  				this.SubCriteria["Location"] = new ClearCanvas.Healthcare.LocationSearchCriteria("Location");
	  			}
	  			return (ClearCanvas.Healthcare.LocationSearchCriteria)this.SubCriteria["Location"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.VisitLocationRoleEnum> Role
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Role"))
	  			{
	  				this.SubCriteria["Role"] = new SearchCondition<ClearCanvas.Healthcare.VisitLocationRoleEnum>("Role");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.VisitLocationRoleEnum>)this.SubCriteria["Role"];
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
