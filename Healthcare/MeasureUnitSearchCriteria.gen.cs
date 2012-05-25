// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="MeasureUnit"/> class.
    /// </summary>
	public partial class MeasureUnitSearchCriteria : EntitySearchCriteria<MeasureUnit>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public MeasureUnitSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public MeasureUnitSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected MeasureUnitSearchCriteria(MeasureUnitSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new MeasureUnitSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.MeasureUnitSearchCriteria CompareUnit
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CompareUnit"))
	  			{
	  				this.SubCriteria["CompareUnit"] = new ClearCanvas.Healthcare.MeasureUnitSearchCriteria("CompareUnit");
	  			}
	  			return (ClearCanvas.Healthcare.MeasureUnitSearchCriteria)this.SubCriteria["CompareUnit"];
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
	  	
	  	public ISearchCondition<Decimal> DeviationValue
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DeviationValue"))
	  			{
	  				this.SubCriteria["DeviationValue"] = new SearchCondition<Decimal>("DeviationValue");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["DeviationValue"];
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
