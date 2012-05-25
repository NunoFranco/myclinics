// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProcedureTypeGroup"/> class.
    /// </summary>
	public partial class ProcedureTypeGroupSearchCriteria : EntitySearchCriteria<ProcedureTypeGroup>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProcedureTypeGroupSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProcedureTypeGroupSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProcedureTypeGroupSearchCriteria(ProcedureTypeGroupSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProcedureTypeGroupSearchCriteria(this);
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
	  	
	  	public ClearCanvas.Healthcare.ProcedureTypeGroupSearchCriteria Parent
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Parent"))
	  			{
	  				this.SubCriteria["Parent"] = new ClearCanvas.Healthcare.ProcedureTypeGroupSearchCriteria("Parent");
	  			}
	  			return (ClearCanvas.Healthcare.ProcedureTypeGroupSearchCriteria)this.SubCriteria["Parent"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsAutoUpdatePrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsAutoUpdatePrice"))
	  			{
	  				this.SubCriteria["IsAutoUpdatePrice"] = new SearchCondition<bool>("IsAutoUpdatePrice");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsAutoUpdatePrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> PackagePrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PackagePrice"))
	  			{
	  				this.SubCriteria["PackagePrice"] = new SearchCondition<Decimal>("PackagePrice");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["PackagePrice"];
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
	  	
	}
}
