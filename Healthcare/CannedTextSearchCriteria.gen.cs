// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="CannedText"/> class.
    /// </summary>
	public partial class CannedTextSearchCriteria : EntitySearchCriteria<CannedText>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public CannedTextSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public CannedTextSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected CannedTextSearchCriteria(CannedTextSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new CannedTextSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Name
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Name"))
	  			{
	  				this.SubCriteria["Name"] = new SearchCondition<string>("Name");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Name"];
	  		}
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
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Staff
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Staff"))
	  			{
	  				this.SubCriteria["Staff"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Staff");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Staff"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffGroupSearchCriteria StaffGroup
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StaffGroup"))
	  			{
	  				this.SubCriteria["StaffGroup"] = new ClearCanvas.Healthcare.StaffGroupSearchCriteria("StaffGroup");
	  			}
	  			return (ClearCanvas.Healthcare.StaffGroupSearchCriteria)this.SubCriteria["StaffGroup"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Text
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Text"))
	  			{
	  				this.SubCriteria["Text"] = new SearchCondition<string>("Text");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Text"];
	  		}
	  	}
	  	
	}
}
