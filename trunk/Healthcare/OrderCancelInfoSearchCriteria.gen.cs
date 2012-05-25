// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="OrderCancelInfo"/> class.
    /// </summary>
	public partial class OrderCancelInfoSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public OrderCancelInfoSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public OrderCancelInfoSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected OrderCancelInfoSearchCriteria(OrderCancelInfoSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new OrderCancelInfoSearchCriteria(this);
        }


		
	  	public ISearchCondition<ClearCanvas.Healthcare.OrderCancelReasonEnum> Reason
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Reason"))
	  			{
	  				this.SubCriteria["Reason"] = new SearchCondition<ClearCanvas.Healthcare.OrderCancelReasonEnum>("Reason");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.OrderCancelReasonEnum>)this.SubCriteria["Reason"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria CancelledBy
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CancelledBy"))
	  			{
	  				this.SubCriteria["CancelledBy"] = new ClearCanvas.Healthcare.StaffSearchCriteria("CancelledBy");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["CancelledBy"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Comment
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Comment"))
	  			{
	  				this.SubCriteria["Comment"] = new SearchCondition<string>("Comment");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Comment"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.OrderSearchCriteria ReplacementOrder
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ReplacementOrder"))
	  			{
	  				this.SubCriteria["ReplacementOrder"] = new ClearCanvas.Healthcare.OrderSearchCriteria("ReplacementOrder");
	  			}
	  			return (ClearCanvas.Healthcare.OrderSearchCriteria)this.SubCriteria["ReplacementOrder"];
	  		}
	  	}
	  	
	}
}
