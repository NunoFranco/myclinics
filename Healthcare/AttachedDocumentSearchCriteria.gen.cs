// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="AttachedDocument"/> class.
    /// </summary>
	public partial class AttachedDocumentSearchCriteria : EntitySearchCriteria<AttachedDocument>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public AttachedDocumentSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public AttachedDocumentSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected AttachedDocumentSearchCriteria(AttachedDocumentSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new AttachedDocumentSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> MimeType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("MimeType"))
	  			{
	  				this.SubCriteria["MimeType"] = new SearchCondition<string>("MimeType");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["MimeType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> FileExtension
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("FileExtension"))
	  			{
	  				this.SubCriteria["FileExtension"] = new SearchCondition<string>("FileExtension");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["FileExtension"];
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
	  	
	  	public ISearchCondition<DateTime> ReceivedTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ReceivedTime"))
	  			{
	  				this.SubCriteria["ReceivedTime"] = new SearchCondition<DateTime>("ReceivedTime");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["ReceivedTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> ContentUrl
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ContentUrl"))
	  			{
	  				this.SubCriteria["ContentUrl"] = new SearchCondition<string>("ContentUrl");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["ContentUrl"];
	  		}
	  	}
	  	
	}
}
