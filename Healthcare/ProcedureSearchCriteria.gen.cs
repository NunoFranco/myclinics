// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Procedure"/> class.
    /// </summary>
	public partial class ProcedureSearchCriteria : EntitySearchCriteria<Procedure>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProcedureSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProcedureSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProcedureSearchCriteria(ProcedureSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProcedureSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.OrderSearchCriteria Order
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Order"))
	  			{
	  				this.SubCriteria["Order"] = new ClearCanvas.Healthcare.OrderSearchCriteria("Order");
	  			}
	  			return (ClearCanvas.Healthcare.OrderSearchCriteria)this.SubCriteria["Order"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.ProcedureTypeSearchCriteria Type
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Type"))
	  			{
	  				this.SubCriteria["Type"] = new ClearCanvas.Healthcare.ProcedureTypeSearchCriteria("Type");
	  			}
	  			return (ClearCanvas.Healthcare.ProcedureTypeSearchCriteria)this.SubCriteria["Type"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Index
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Index"))
	  			{
	  				this.SubCriteria["Index"] = new SearchCondition<string>("Index");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Index"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> ScheduledStartTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ScheduledStartTime"))
	  			{
	  				this.SubCriteria["ScheduledStartTime"] = new SearchCondition<DateTime?>("ScheduledStartTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["ScheduledStartTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> StartTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StartTime"))
	  			{
	  				this.SubCriteria["StartTime"] = new SearchCondition<DateTime?>("StartTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["StartTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> EndTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("EndTime"))
	  			{
	  				this.SubCriteria["EndTime"] = new SearchCondition<DateTime?>("EndTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["EndTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ProcedureStatusEnum> Status
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Status"))
	  			{
	  				this.SubCriteria["Status"] = new SearchCondition<ClearCanvas.Healthcare.ProcedureStatusEnum>("Status");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ProcedureStatusEnum>)this.SubCriteria["Status"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.FacilitySearchCriteria PerformingFacility
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PerformingFacility"))
	  			{
	  				this.SubCriteria["PerformingFacility"] = new ClearCanvas.Healthcare.FacilitySearchCriteria("PerformingFacility");
	  			}
	  			return (ClearCanvas.Healthcare.FacilitySearchCriteria)this.SubCriteria["PerformingFacility"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.LateralityEnum> Laterality
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Laterality"))
	  			{
	  				this.SubCriteria["Laterality"] = new SearchCondition<ClearCanvas.Healthcare.LateralityEnum>("Laterality");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.LateralityEnum>)this.SubCriteria["Laterality"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> Portable
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Portable"))
	  			{
	  				this.SubCriteria["Portable"] = new SearchCondition<bool>("Portable");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Portable"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.ProcedureCheckInSearchCriteria ProcedureCheckIn
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ProcedureCheckIn"))
	  			{
	  				this.SubCriteria["ProcedureCheckIn"] = new ClearCanvas.Healthcare.ProcedureCheckInSearchCriteria("ProcedureCheckIn");
	  			}
	  			return (ClearCanvas.Healthcare.ProcedureCheckInSearchCriteria)this.SubCriteria["ProcedureCheckIn"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ImageAvailabilityEnum> ImageAvailability
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ImageAvailability"))
	  			{
	  				this.SubCriteria["ImageAvailability"] = new SearchCondition<ClearCanvas.Healthcare.ImageAvailabilityEnum>("ImageAvailability");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ImageAvailabilityEnum>)this.SubCriteria["ImageAvailability"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.DiagnosticServiceSearchCriteria PackageProcedure
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PackageProcedure"))
	  			{
	  				this.SubCriteria["PackageProcedure"] = new ClearCanvas.Healthcare.DiagnosticServiceSearchCriteria("PackageProcedure");
	  			}
	  			return (ClearCanvas.Healthcare.DiagnosticServiceSearchCriteria)this.SubCriteria["PackageProcedure"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> DowntimeRecoveryMode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("DowntimeRecoveryMode"))
	  			{
	  				this.SubCriteria["DowntimeRecoveryMode"] = new SearchCondition<bool>("DowntimeRecoveryMode");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["DowntimeRecoveryMode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> WaitingInsuranceAmount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("WaitingInsuranceAmount"))
	  			{
	  				this.SubCriteria["WaitingInsuranceAmount"] = new SearchCondition<Decimal>("WaitingInsuranceAmount");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["WaitingInsuranceAmount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> CollectedAmount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CollectedAmount"))
	  			{
	  				this.SubCriteria["CollectedAmount"] = new SearchCondition<Decimal>("CollectedAmount");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["CollectedAmount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsPendingInsurance
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsPendingInsurance"))
	  			{
	  				this.SubCriteria["IsPendingInsurance"] = new SearchCondition<bool>("IsPendingInsurance");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsPendingInsurance"];
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
	  	
	  	public ISearchCondition<string> PendingProcedureStatus
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PendingProcedureStatus"))
	  			{
	  				this.SubCriteria["PendingProcedureStatus"] = new SearchCondition<string>("PendingProcedureStatus");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["PendingProcedureStatus"];
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
