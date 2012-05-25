// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="OrderAttachment"/> class.
    /// </summary>
	public partial class OrderAttachmentSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public OrderAttachmentSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public OrderAttachmentSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected OrderAttachmentSearchCriteria(OrderAttachmentSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new OrderAttachmentSearchCriteria(this);
        }


		
	  	public ISearchCondition<ClearCanvas.Healthcare.OrderAttachmentCategoryEnum> Category
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Category"))
	  			{
	  				this.SubCriteria["Category"] = new SearchCondition<ClearCanvas.Healthcare.OrderAttachmentCategoryEnum>("Category");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.OrderAttachmentCategoryEnum>)this.SubCriteria["Category"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria AttachedBy
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AttachedBy"))
	  			{
	  				this.SubCriteria["AttachedBy"] = new ClearCanvas.Healthcare.StaffSearchCriteria("AttachedBy");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["AttachedBy"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> AttachedTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AttachedTime"))
	  			{
	  				this.SubCriteria["AttachedTime"] = new SearchCondition<DateTime>("AttachedTime");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["AttachedTime"];
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
	  	
	  	public ClearCanvas.Healthcare.AttachedDocumentSearchCriteria Document
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Document"))
	  			{
	  				this.SubCriteria["Document"] = new ClearCanvas.Healthcare.AttachedDocumentSearchCriteria("Document");
	  			}
	  			return (ClearCanvas.Healthcare.AttachedDocumentSearchCriteria)this.SubCriteria["Document"];
	  		}
	  	}
	  	
	}
}
