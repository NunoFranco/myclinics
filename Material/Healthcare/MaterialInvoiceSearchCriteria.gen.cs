// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Material.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="MaterialInvoice"/> class.
    /// </summary>
	public partial class MaterialInvoiceSearchCriteria : EntitySearchCriteria<MaterialInvoice>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public MaterialInvoiceSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public MaterialInvoiceSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected MaterialInvoiceSearchCriteria(MaterialInvoiceSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new MaterialInvoiceSearchCriteria(this);
        }


		
	  	public ISearchCondition<string> Code
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Code"))
	  			{
	  				this.SubCriteria["Code"] = new SearchCondition<string>("Code");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Code"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.Patient> Patient
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Patient"))
	  			{
	  				this.SubCriteria["Patient"] = new SearchCondition<ClearCanvas.Healthcare.Patient>("Patient");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.Patient>)this.SubCriteria["Patient"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ProcedureType> Material
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Material"))
	  			{
	  				this.SubCriteria["Material"] = new SearchCondition<ClearCanvas.Healthcare.ProcedureType>("Material");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ProcedureType>)this.SubCriteria["Material"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Material.Healthcare.MaterialLotSearchCriteria Lot
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Lot"))
	  			{
	  				this.SubCriteria["Lot"] = new ClearCanvas.Material.Healthcare.MaterialLotSearchCriteria("Lot");
	  			}
	  			return (ClearCanvas.Material.Healthcare.MaterialLotSearchCriteria)this.SubCriteria["Lot"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> SoldDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SoldDate"))
	  			{
	  				this.SubCriteria["SoldDate"] = new SearchCondition<DateTime>("SoldDate");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["SoldDate"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> SoldAmount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SoldAmount"))
	  			{
	  				this.SubCriteria["SoldAmount"] = new SearchCondition<Decimal>("SoldAmount");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["SoldAmount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> Price
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Price"))
	  			{
	  				this.SubCriteria["Price"] = new SearchCondition<Decimal>("Price");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["Price"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Comment
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Comment"))
	  			{
	  				this.SubCriteria["Comment"] = new SearchCondition<string>("Comment");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Comment"];
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
	  	
	}
}
