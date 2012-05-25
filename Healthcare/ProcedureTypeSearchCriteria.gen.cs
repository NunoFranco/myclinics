// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProcedureType"/> class.
    /// </summary>
	public partial class ProcedureTypeSearchCriteria : EntitySearchCriteria<ProcedureType>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProcedureTypeSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProcedureTypeSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProcedureTypeSearchCriteria(ProcedureTypeSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProcedureTypeSearchCriteria(this);
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
	  	
	  	public ClearCanvas.Healthcare.ProcedureTypeSearchCriteria BaseType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("BaseType"))
	  			{
	  				this.SubCriteria["BaseType"] = new ClearCanvas.Healthcare.ProcedureTypeSearchCriteria("BaseType");
	  			}
	  			return (ClearCanvas.Healthcare.ProcedureTypeSearchCriteria)this.SubCriteria["BaseType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> PlanXml
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PlanXml"))
	  			{
	  				this.SubCriteria["PlanXml"] = new SearchCondition<string>("PlanXml");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["PlanXml"];
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
	  	
	  	public ISearchCondition<Decimal> BasePrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("BasePrice"))
	  			{
	  				this.SubCriteria["BasePrice"] = new SearchCondition<Decimal>("BasePrice");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["BasePrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> Tax
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Tax"))
	  			{
	  				this.SubCriteria["Tax"] = new SearchCondition<Decimal>("Tax");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["Tax"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsRequired
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsRequired"))
	  			{
	  				this.SubCriteria["IsRequired"] = new SearchCondition<bool>("IsRequired");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsRequired"];
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
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ProcedureTypeCategoryEnum> Category
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Category"))
	  			{
	  				this.SubCriteria["Category"] = new SearchCondition<ClearCanvas.Healthcare.ProcedureTypeCategoryEnum>("Category");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ProcedureTypeCategoryEnum>)this.SubCriteria["Category"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.UOMEnum> UOM
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("UOM"))
	  			{
	  				this.SubCriteria["UOM"] = new SearchCondition<ClearCanvas.Healthcare.UOMEnum>("UOM");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.UOMEnum>)this.SubCriteria["UOM"];
	  		}
	  	}
	  	
	}
}
