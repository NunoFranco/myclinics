// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ReportPart"/> class.
    /// </summary>
	public partial class ReportPartSearchCriteria : EntitySearchCriteria<ReportPart>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ReportPartSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ReportPartSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ReportPartSearchCriteria(ReportPartSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ReportPartSearchCriteria(this);
        }


		
	  	public ISearchCondition<int> Index
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Index"))
	  			{
	  				this.SubCriteria["Index"] = new SearchCondition<int>("Index");
	  			}
	  			return (ISearchCondition<int>)this.SubCriteria["Index"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ReportPartStatusEnum> Status
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Status"))
	  			{
	  				this.SubCriteria["Status"] = new SearchCondition<ClearCanvas.Healthcare.ReportPartStatusEnum>("Status");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ReportPartStatusEnum>)this.SubCriteria["Status"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> CreationTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreationTime"))
	  			{
	  				this.SubCriteria["CreationTime"] = new SearchCondition<DateTime>("CreationTime");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["CreationTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> PreliminaryTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PreliminaryTime"))
	  			{
	  				this.SubCriteria["PreliminaryTime"] = new SearchCondition<DateTime?>("PreliminaryTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["PreliminaryTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> CompletedTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CompletedTime"))
	  			{
	  				this.SubCriteria["CompletedTime"] = new SearchCondition<DateTime?>("CompletedTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["CompletedTime"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> CancelledTime
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CancelledTime"))
	  			{
	  				this.SubCriteria["CancelledTime"] = new SearchCondition<DateTime?>("CancelledTime");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["CancelledTime"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Supervisor
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Supervisor"))
	  			{
	  				this.SubCriteria["Supervisor"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Supervisor");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Supervisor"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Interpreter
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Interpreter"))
	  			{
	  				this.SubCriteria["Interpreter"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Interpreter");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Interpreter"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Transcriber
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Transcriber"))
	  			{
	  				this.SubCriteria["Transcriber"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Transcriber");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Transcriber"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria TranscriptionSupervisor
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TranscriptionSupervisor"))
	  			{
	  				this.SubCriteria["TranscriptionSupervisor"] = new ClearCanvas.Healthcare.StaffSearchCriteria("TranscriptionSupervisor");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["TranscriptionSupervisor"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Verifier
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Verifier"))
	  			{
	  				this.SubCriteria["Verifier"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Verifier");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Verifier"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.TranscriptionRejectReasonEnum> TranscriptionRejectReason
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TranscriptionRejectReason"))
	  			{
	  				this.SubCriteria["TranscriptionRejectReason"] = new SearchCondition<ClearCanvas.Healthcare.TranscriptionRejectReasonEnum>("TranscriptionRejectReason");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.TranscriptionRejectReasonEnum>)this.SubCriteria["TranscriptionRejectReason"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.ReportSearchCriteria Report
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Report"))
	  			{
	  				this.SubCriteria["Report"] = new ClearCanvas.Healthcare.ReportSearchCriteria("Report");
	  			}
	  			return (ClearCanvas.Healthcare.ReportSearchCriteria)this.SubCriteria["Report"];
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
