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
	  	
	  	public ISearchCondition<string> MainIngredient
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("MainIngredient"))
	  			{
	  				this.SubCriteria["MainIngredient"] = new SearchCondition<string>("MainIngredient");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["MainIngredient"];
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
	  	
	  	public ISearchCondition<string> UseDirection
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("UseDirection"))
	  			{
	  				this.SubCriteria["UseDirection"] = new SearchCondition<string>("UseDirection");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["UseDirection"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> MedicineDose
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("MedicineDose"))
	  			{
	  				this.SubCriteria["MedicineDose"] = new SearchCondition<string>("MedicineDose");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["MedicineDose"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> InputPrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InputPrice"))
	  			{
	  				this.SubCriteria["InputPrice"] = new SearchCondition<Decimal>("InputPrice");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["InputPrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> ManualPrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ManualPrice"))
	  			{
	  				this.SubCriteria["ManualPrice"] = new SearchCondition<Decimal>("ManualPrice");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["ManualPrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsAutomaticPrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsAutomaticPrice"))
	  			{
	  				this.SubCriteria["IsAutomaticPrice"] = new SearchCondition<bool>("IsAutomaticPrice");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsAutomaticPrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> Saleable
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Saleable"))
	  			{
	  				this.SubCriteria["Saleable"] = new SearchCondition<bool>("Saleable");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Saleable"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> InsurancePrice
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InsurancePrice"))
	  			{
	  				this.SubCriteria["InsurancePrice"] = new SearchCondition<Decimal>("InsurancePrice");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["InsurancePrice"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Double> MininumAllow
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("MininumAllow"))
	  			{
	  				this.SubCriteria["MininumAllow"] = new SearchCondition<Double>("MininumAllow");
	  			}
	  			return (ISearchCondition<Double>)this.SubCriteria["MininumAllow"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Double> CurrentQuantity
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CurrentQuantity"))
	  			{
	  				this.SubCriteria["CurrentQuantity"] = new SearchCondition<Double>("CurrentQuantity");
	  			}
	  			return (ISearchCondition<Double>)this.SubCriteria["CurrentQuantity"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Barcode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Barcode"))
	  			{
	  				this.SubCriteria["Barcode"] = new SearchCondition<string>("Barcode");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Barcode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsPoisonA
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsPoisonA"))
	  			{
	  				this.SubCriteria["IsPoisonA"] = new SearchCondition<bool>("IsPoisonA");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsPoisonA"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsPoisonB
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsPoisonB"))
	  			{
	  				this.SubCriteria["IsPoisonB"] = new SearchCondition<bool>("IsPoisonB");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsPoisonB"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsSaleWithOrder
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsSaleWithOrder"))
	  			{
	  				this.SubCriteria["IsSaleWithOrder"] = new SearchCondition<bool>("IsSaleWithOrder");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsSaleWithOrder"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> SideEffective
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SideEffective"))
	  			{
	  				this.SubCriteria["SideEffective"] = new SearchCondition<string>("SideEffective");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["SideEffective"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> PackingMethod
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PackingMethod"))
	  			{
	  				this.SubCriteria["PackingMethod"] = new SearchCondition<string>("PackingMethod");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["PackingMethod"];
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
