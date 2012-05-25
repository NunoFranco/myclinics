// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProcedureCheckIn"/> class.
    /// </summary>
	public partial class ProcedureCheckInSearchCriteria : EntitySearchCriteria<ProcedureCheckIn>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProcedureCheckInSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProcedureCheckInSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProcedureCheckInSearchCriteria(ProcedureCheckInSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProcedureCheckInSearchCriteria(this);
        }


		
	  	public ISearchCondition<DateTime?> CheckInTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CheckInTime"))
	  			{
	  				this.SubCriteria["CheckInTime"] = new SearchCondition<DateTime?>("CheckInTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["CheckInTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> CheckOutTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CheckOutTime"))
	  			{
	  				this.SubCriteria["CheckOutTime"] = new SearchCondition<DateTime?>("CheckOutTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["CheckOutTime"];
	  		}
	  	}
	  	
	}
}
