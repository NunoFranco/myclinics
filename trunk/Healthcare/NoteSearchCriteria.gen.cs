// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Note"/> class.
    /// </summary>
	public partial class NoteSearchCriteria : EntitySearchCriteria<Note>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public NoteSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public NoteSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected NoteSearchCriteria(NoteSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new NoteSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Category
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Category"))
	  			{
	  				this.SubCriteria["Category"] = new SearchCondition<string>("Category");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Category"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Body
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Body"))
	  			{
	  				this.SubCriteria["Body"] = new SearchCondition<string>("Body");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Body"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> Urgent
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Urgent"))
	  			{
	  				this.SubCriteria["Urgent"] = new SearchCondition<bool>("Urgent");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Urgent"];
	  		}
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
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Author
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Author"))
	  			{
	  				this.SubCriteria["Author"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Author");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Author"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffGroupSearchCriteria OnBehalfOfGroup
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("OnBehalfOfGroup"))
	  			{
	  				this.SubCriteria["OnBehalfOfGroup"] = new ClearCanvas.Healthcare.StaffGroupSearchCriteria("OnBehalfOfGroup");
	  			}
	  			return (ClearCanvas.Healthcare.StaffGroupSearchCriteria)this.SubCriteria["OnBehalfOfGroup"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> PostTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PostTime"))
	  			{
	  				this.SubCriteria["PostTime"] = new SearchCondition<DateTime?>("PostTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["PostTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsFullyAcknowledged
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsFullyAcknowledged"))
	  			{
	  				this.SubCriteria["IsFullyAcknowledged"] = new SearchCondition<bool>("IsFullyAcknowledged");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsFullyAcknowledged"];
	  		}
	  	}
	  	
	}
}
