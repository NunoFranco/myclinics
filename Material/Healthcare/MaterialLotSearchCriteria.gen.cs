// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Material.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="MaterialLot"/> class.
    /// </summary>
	public partial class MaterialLotSearchCriteria : EntitySearchCriteria<MaterialLot>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public MaterialLotSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public MaterialLotSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected MaterialLotSearchCriteria(MaterialLotSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new MaterialLotSearchCriteria(this);
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
	  	
	  	public ClearCanvas.Material.Healthcare.ContactSearchCriteria Supplier
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Supplier"))
	  			{
	  				this.SubCriteria["Supplier"] = new ClearCanvas.Material.Healthcare.ContactSearchCriteria("Supplier");
	  			}
	  			return (ClearCanvas.Material.Healthcare.ContactSearchCriteria)this.SubCriteria["Supplier"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> InputDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InputDate"))
	  			{
	  				this.SubCriteria["InputDate"] = new SearchCondition<DateTime>("InputDate");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["InputDate"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.Facility> Clinic
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Clinic"))
	  			{
	  				this.SubCriteria["Clinic"] = new SearchCondition<ClearCanvas.Healthcare.Facility>("Clinic");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.Facility>)this.SubCriteria["Clinic"];
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
