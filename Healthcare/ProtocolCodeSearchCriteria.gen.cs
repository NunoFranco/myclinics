// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProtocolCode"/> class.
    /// </summary>
	public partial class ProtocolCodeSearchCriteria : EntitySearchCriteria<ProtocolCode>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProtocolCodeSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProtocolCodeSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProtocolCodeSearchCriteria(ProtocolCodeSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProtocolCodeSearchCriteria(this);
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
	  	
	  	public ISearchCondition<string> Description
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Description"))
	  			{
	  				this.SubCriteria["Description"] = new SearchCondition<string>("Description");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Description"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> Deactivated
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Deactivated"))
	  			{
	  				this.SubCriteria["Deactivated"] = new SearchCondition<bool>("Deactivated");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Deactivated"];
	  		}
	  	}
	  	
	}
}
