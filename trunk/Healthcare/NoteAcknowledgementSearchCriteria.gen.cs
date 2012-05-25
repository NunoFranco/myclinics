// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="NoteAcknowledgement"/> class.
    /// </summary>
	public partial class NoteAcknowledgementSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public NoteAcknowledgementSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public NoteAcknowledgementSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected NoteAcknowledgementSearchCriteria(NoteAcknowledgementSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new NoteAcknowledgementSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Staff
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Staff"))
	  			{
	  				this.SubCriteria["Staff"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Staff");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Staff"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime?> Time
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Time"))
	  			{
	  				this.SubCriteria["Time"] = new SearchCondition<DateTime?>("Time");
	  			}
	  			return (ISearchCondition<DateTime?>)this.SubCriteria["Time"];
	  		}
	  	}
	  	
	}
}
