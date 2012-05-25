// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Visit"/> class.
    /// </summary>
	public partial class VisitSearchCriteria : EntitySearchCriteria<Visit>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public VisitSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public VisitSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected VisitSearchCriteria(VisitSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new VisitSearchCriteria(this);
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
	  	
	  	public ClearCanvas.Healthcare.VisitNumberSearchCriteria VisitNumber
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("VisitNumber"))
	  			{
	  				this.SubCriteria["VisitNumber"] = new ClearCanvas.Healthcare.VisitNumberSearchCriteria("VisitNumber");
	  			}
	  			return (ClearCanvas.Healthcare.VisitNumberSearchCriteria)this.SubCriteria["VisitNumber"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.VisitStatusEnum> Status
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Status"))
	  			{
	  				this.SubCriteria["Status"] = new SearchCondition<ClearCanvas.Healthcare.VisitStatusEnum>("Status");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.VisitStatusEnum>)this.SubCriteria["Status"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> AdmitTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AdmitTime"))
	  			{
	  				this.SubCriteria["AdmitTime"] = new SearchCondition<DateTime?>("AdmitTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["AdmitTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> DischargeTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DischargeTime"))
	  			{
	  				this.SubCriteria["DischargeTime"] = new SearchCondition<DateTime?>("DischargeTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["DischargeTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> DischargeDisposition
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DischargeDisposition"))
	  			{
	  				this.SubCriteria["DischargeDisposition"] = new SearchCondition<string>("DischargeDisposition");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["DischargeDisposition"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.PatientClassEnum> PatientClass
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PatientClass"))
	  			{
	  				this.SubCriteria["PatientClass"] = new SearchCondition<ClearCanvas.Healthcare.PatientClassEnum>("PatientClass");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.PatientClassEnum>)this.SubCriteria["PatientClass"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.PatientTypeEnum> PatientType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PatientType"))
	  			{
	  				this.SubCriteria["PatientType"] = new SearchCondition<ClearCanvas.Healthcare.PatientTypeEnum>("PatientType");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.PatientTypeEnum>)this.SubCriteria["PatientType"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.AdmissionTypeEnum> AdmissionType
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AdmissionType"))
	  			{
	  				this.SubCriteria["AdmissionType"] = new SearchCondition<ClearCanvas.Healthcare.AdmissionTypeEnum>("AdmissionType");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.AdmissionTypeEnum>)this.SubCriteria["AdmissionType"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.FacilitySearchCriteria Facility
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Facility"))
	  			{
	  				this.SubCriteria["Facility"] = new ClearCanvas.Healthcare.FacilitySearchCriteria("Facility");
	  			}
	  			return (ClearCanvas.Healthcare.FacilitySearchCriteria)this.SubCriteria["Facility"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.LocationSearchCriteria CurrentLocation
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CurrentLocation"))
	  			{
	  				this.SubCriteria["CurrentLocation"] = new ClearCanvas.Healthcare.LocationSearchCriteria("CurrentLocation");
	  			}
	  			return (ClearCanvas.Healthcare.LocationSearchCriteria)this.SubCriteria["CurrentLocation"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> VipIndicator
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("VipIndicator"))
	  			{
	  				this.SubCriteria["VipIndicator"] = new SearchCondition<bool>("VipIndicator");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["VipIndicator"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> PreadmitNumber
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PreadmitNumber"))
	  			{
	  				this.SubCriteria["PreadmitNumber"] = new SearchCondition<string>("PreadmitNumber");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["PreadmitNumber"];
	  		}
	  	}
	  	
	}
}
