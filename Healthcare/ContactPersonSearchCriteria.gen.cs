// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ContactPerson"/> class.
    /// </summary>
	public partial class ContactPersonSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ContactPersonSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ContactPersonSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ContactPersonSearchCriteria(ContactPersonSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ContactPersonSearchCriteria(this);
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
	  	
	  	public ISearchCondition<string> HomePhone
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("HomePhone"))
	  			{
	  				this.SubCriteria["HomePhone"] = new SearchCondition<string>("HomePhone");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["HomePhone"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> BusinessPhone
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("BusinessPhone"))
	  			{
	  				this.SubCriteria["BusinessPhone"] = new SearchCondition<string>("BusinessPhone");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["BusinessPhone"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ContactPersonTypeEnum> Type
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Type"))
	  			{
	  				this.SubCriteria["Type"] = new SearchCondition<ClearCanvas.Healthcare.ContactPersonTypeEnum>("Type");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ContactPersonTypeEnum>)this.SubCriteria["Type"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ContactPersonRelationshipEnum> Relationship
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Relationship"))
	  			{
	  				this.SubCriteria["Relationship"] = new SearchCondition<ClearCanvas.Healthcare.ContactPersonRelationshipEnum>("Relationship");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ContactPersonRelationshipEnum>)this.SubCriteria["Relationship"];
	  		}
	  	}
	  	
	}
}
