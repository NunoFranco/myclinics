// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="GroupNotePosting"/> class.
    /// </summary>
	public partial class GroupNotePostingSearchCriteria : NotePostingSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public GroupNotePostingSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public GroupNotePostingSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected GroupNotePostingSearchCriteria(GroupNotePostingSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new GroupNotePostingSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.StaffGroupSearchCriteria Recipient
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Recipient"))
	  			{
	  				this.SubCriteria["Recipient"] = new ClearCanvas.Healthcare.StaffGroupSearchCriteria("Recipient");
	  			}
	  			return (ClearCanvas.Healthcare.StaffGroupSearchCriteria)this.SubCriteria["Recipient"];
	  		}
	  	}
	  	
	}
}
