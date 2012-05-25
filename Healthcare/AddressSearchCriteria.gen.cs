// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Address"/> class.
    /// </summary>
	public partial class AddressSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public AddressSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public AddressSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected AddressSearchCriteria(AddressSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new AddressSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Street
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Street"))
	  			{
	  				this.SubCriteria["Street"] = new SearchCondition<string>("Street");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Street"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Unit
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Unit"))
	  			{
	  				this.SubCriteria["Unit"] = new SearchCondition<string>("Unit");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Unit"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> City
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("City"))
	  			{
	  				this.SubCriteria["City"] = new SearchCondition<string>("City");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["City"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Province
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Province"))
	  			{
	  				this.SubCriteria["Province"] = new SearchCondition<string>("Province");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Province"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> PostalCode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PostalCode"))
	  			{
	  				this.SubCriteria["PostalCode"] = new SearchCondition<string>("PostalCode");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["PostalCode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Country
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Country"))
	  			{
	  				this.SubCriteria["Country"] = new SearchCondition<string>("Country");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Country"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.AddressTypeEnum> Type
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Type"))
	  			{
	  				this.SubCriteria["Type"] = new SearchCondition<ClearCanvas.Healthcare.AddressTypeEnum>("Type");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.AddressTypeEnum>)this.SubCriteria["Type"];
	  		}
	  	}
	  	
	}
}
