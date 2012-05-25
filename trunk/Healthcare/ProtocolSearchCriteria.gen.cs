// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="Protocol"/> class.
    /// </summary>
	public partial class ProtocolSearchCriteria : EntitySearchCriteria<Protocol>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProtocolSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProtocolSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProtocolSearchCriteria(ProtocolSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProtocolSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Author
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Author"))
	  			{
	  				this.SubCriteria["Author"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Author");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Author"];
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
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ProtocolStatusEnum> Status
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Status"))
	  			{
	  				this.SubCriteria["Status"] = new SearchCondition<ClearCanvas.Healthcare.ProtocolStatusEnum>("Status");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ProtocolStatusEnum>)this.SubCriteria["Status"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ProtocolUrgencyEnum> Urgency
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Urgency"))
	  			{
	  				this.SubCriteria["Urgency"] = new SearchCondition<ClearCanvas.Healthcare.ProtocolUrgencyEnum>("Urgency");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ProtocolUrgencyEnum>)this.SubCriteria["Urgency"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ProtocolRejectReasonEnum> RejectReason
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("RejectReason"))
	  			{
	  				this.SubCriteria["RejectReason"] = new SearchCondition<ClearCanvas.Healthcare.ProtocolRejectReasonEnum>("RejectReason");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ProtocolRejectReasonEnum>)this.SubCriteria["RejectReason"];
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
