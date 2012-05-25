// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="DiagnosticService"/> class.
    /// </summary>
	public partial class DiagnosticServiceSearchCriteria : EntitySearchCriteria<DiagnosticService>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public DiagnosticServiceSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public DiagnosticServiceSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected DiagnosticServiceSearchCriteria(DiagnosticServiceSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new DiagnosticServiceSearchCriteria(this);
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
	  	
	  	public ISearchCondition<bool> IsPackageProcedure
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsPackageProcedure"))
	  			{
	  				this.SubCriteria["IsPackageProcedure"] = new SearchCondition<bool>("IsPackageProcedure");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsPackageProcedure"];
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
