// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="VisitNumber"/> class.
    /// </summary>
	public partial class VisitNumberSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public VisitNumberSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public VisitNumberSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected VisitNumberSearchCriteria(VisitNumberSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new VisitNumberSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Id
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Id"))
	  			{
	  				this.SubCriteria["Id"] = new SearchCondition<string>("Id");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Id"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum> AssigningAuthority
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AssigningAuthority"))
	  			{
	  				this.SubCriteria["AssigningAuthority"] = new SearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum>("AssigningAuthority");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum>)this.SubCriteria["AssigningAuthority"];
	  		}
	  	}
	  	
	}
}
