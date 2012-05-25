// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="StaffNotePosting"/> class.
    /// </summary>
	public partial class StaffNotePostingSearchCriteria : NotePostingSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public StaffNotePostingSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public StaffNotePostingSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected StaffNotePostingSearchCriteria(StaffNotePostingSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new StaffNotePostingSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.StaffSearchCriteria Recipient
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Recipient"))
	  			{
	  				this.SubCriteria["Recipient"] = new ClearCanvas.Healthcare.StaffSearchCriteria("Recipient");
	  			}
	  			return (ClearCanvas.Healthcare.StaffSearchCriteria)this.SubCriteria["Recipient"];
	  		}
	  	}
	  	
	}
}
