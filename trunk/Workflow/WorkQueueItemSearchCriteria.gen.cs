// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Workflow
{

    /// <summary>
    /// Search criteria for <see cref="WorkQueueItem"/> class.
    /// </summary>
	public partial class WorkQueueItemSearchCriteria : EntitySearchCriteria<WorkQueueItem>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public WorkQueueItemSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public WorkQueueItemSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected WorkQueueItemSearchCriteria(WorkQueueItemSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new WorkQueueItemSearchCriteria(this);
        }


		
	  	public ISearchCondition<DateTime> CreationTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreationTime"))
	  			{
	  				this.SubCriteria["CreationTime"] = new SearchCondition<DateTime>("CreationTime");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["CreationTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> ScheduledTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ScheduledTime"))
	  			{
	  				this.SubCriteria["ScheduledTime"] = new SearchCondition<DateTime>("ScheduledTime");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["ScheduledTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> ExpirationTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ExpirationTime"))
	  			{
	  				this.SubCriteria["ExpirationTime"] = new SearchCondition<DateTime?>("ExpirationTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ExpirationTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> User
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("User"))
	  			{
	  				this.SubCriteria["User"] = new SearchCondition<string>("User");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["User"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Type
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Type"))
	  			{
	  				this.SubCriteria["Type"] = new SearchCondition<string>("Type");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Type"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Workflow.WorkQueueStatusEnum> Status
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Status"))
	  			{
	  				this.SubCriteria["Status"] = new SearchCondition<ClearCanvas.Workflow.WorkQueueStatusEnum>("Status");
	  			}
	  			return (ISearchCondition<ClearCanvas.Workflow.WorkQueueStatusEnum>)this.SubCriteria["Status"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> ProcessedTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ProcessedTime"))
	  			{
	  				this.SubCriteria["ProcessedTime"] = new SearchCondition<DateTime?>("ProcessedTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ProcessedTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<int> FailureCount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("FailureCount"))
	  			{
	  				this.SubCriteria["FailureCount"] = new SearchCondition<int>("FailureCount");
	  			}
	  			return (ISearchCondition<int>)this.SubCriteria["FailureCount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> FailureDescription
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("FailureDescription"))
	  			{
	  				this.SubCriteria["FailureDescription"] = new SearchCondition<string>("FailureDescription");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["FailureDescription"];
	  		}
	  	}
	  	
	}
}
