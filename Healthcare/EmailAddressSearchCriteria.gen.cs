// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="EmailAddress"/> class.
    /// </summary>
	public partial class EmailAddressSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public EmailAddressSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public EmailAddressSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected EmailAddressSearchCriteria(EmailAddressSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new EmailAddressSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Address
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Address"))
	  			{
	  				this.SubCriteria["Address"] = new SearchCondition<string>("Address");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Address"];
	  		}
	  	}
	  	
	}
}
