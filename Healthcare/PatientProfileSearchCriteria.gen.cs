// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="PatientProfile"/> class.
    /// </summary>
	public partial class PatientProfileSearchCriteria : EntitySearchCriteria<PatientProfile>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public PatientProfileSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public PatientProfileSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected PatientProfileSearchCriteria(PatientProfileSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new PatientProfileSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.PatientIdentifierSearchCriteria Mrn
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Mrn"))
	  			{
	  				this.SubCriteria["Mrn"] = new ClearCanvas.Healthcare.PatientIdentifierSearchCriteria("Mrn");
	  			}
	  			return (ClearCanvas.Healthcare.PatientIdentifierSearchCriteria)this.SubCriteria["Mrn"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.HealthcardNumberSearchCriteria Healthcard
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Healthcard"))
	  			{
	  				this.SubCriteria["Healthcard"] = new ClearCanvas.Healthcare.HealthcardNumberSearchCriteria("Healthcard");
	  			}
	  			return (ClearCanvas.Healthcare.HealthcardNumberSearchCriteria)this.SubCriteria["Healthcard"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.PersonNameSearchCriteria Name
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Name"))
	  			{
	  				this.SubCriteria["Name"] = new ClearCanvas.Healthcare.PersonNameSearchCriteria("Name");
	  			}
	  			return (ClearCanvas.Healthcare.PersonNameSearchCriteria)this.SubCriteria["Name"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> DateOfBirth
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DateOfBirth"))
	  			{
	  				this.SubCriteria["DateOfBirth"] = new SearchCondition<DateTime?>("DateOfBirth");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["DateOfBirth"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.SexEnum> Sex
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Sex"))
	  			{
	  				this.SubCriteria["Sex"] = new SearchCondition<ClearCanvas.Healthcare.SexEnum>("Sex");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.SexEnum>)this.SubCriteria["Sex"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.SpokenLanguageEnum> PrimaryLanguage
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PrimaryLanguage"))
	  			{
	  				this.SubCriteria["PrimaryLanguage"] = new SearchCondition<ClearCanvas.Healthcare.SpokenLanguageEnum>("PrimaryLanguage");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.SpokenLanguageEnum>)this.SubCriteria["PrimaryLanguage"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ReligionEnum> Religion
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Religion"))
	  			{
	  				this.SubCriteria["Religion"] = new SearchCondition<ClearCanvas.Healthcare.ReligionEnum>("Religion");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ReligionEnum>)this.SubCriteria["Religion"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> DeathIndicator
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DeathIndicator"))
	  			{
	  				this.SubCriteria["DeathIndicator"] = new SearchCondition<bool>("DeathIndicator");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["DeathIndicator"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> TimeOfDeath
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TimeOfDeath"))
	  			{
	  				this.SubCriteria["TimeOfDeath"] = new SearchCondition<DateTime?>("TimeOfDeath");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["TimeOfDeath"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.PatientSearchCriteria Patient
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Patient"))
	  			{
	  				this.SubCriteria["Patient"] = new ClearCanvas.Healthcare.PatientSearchCriteria("Patient");
	  			}
	  			return (ClearCanvas.Healthcare.PatientSearchCriteria)this.SubCriteria["Patient"];
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
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.InsuranceTypeEnum> InsuranceType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InsuranceType"))
	  			{
	  				this.SubCriteria["InsuranceType"] = new SearchCondition<ClearCanvas.Healthcare.InsuranceTypeEnum>("InsuranceType");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.InsuranceTypeEnum>)this.SubCriteria["InsuranceType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.DiscountTypeEnum> DiscountType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DiscountType"))
	  			{
	  				this.SubCriteria["DiscountType"] = new SearchCondition<ClearCanvas.Healthcare.DiscountTypeEnum>("DiscountType");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.DiscountTypeEnum>)this.SubCriteria["DiscountType"];
	  		}
	  	}
	  	
	}
}
