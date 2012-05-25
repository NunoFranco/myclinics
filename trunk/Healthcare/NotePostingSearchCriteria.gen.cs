// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="NotePosting"/> class.
    /// </summary>
	public partial class NotePostingSearchCriteria : EntitySearchCriteria<NotePosting>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public NotePostingSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public NotePostingSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected NotePostingSearchCriteria(NotePostingSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new NotePostingSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.NoteSearchCriteria Note
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Note"))
	  			{
	  				this.SubCriteria["Note"] = new ClearCanvas.Healthcare.NoteSearchCriteria("Note");
	  			}
	  			return (ClearCanvas.Healthcare.NoteSearchCriteria)this.SubCriteria["Note"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsAcknowledged
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsAcknowledged"))
	  			{
	  				this.SubCriteria["IsAcknowledged"] = new SearchCondition<bool>("IsAcknowledged");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsAcknowledged"];
	  		}
	  	}
	  	
	  	public ClearCanvas.Healthcare.NoteAcknowledgementSearchCriteria AcknowledgedBy
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("AcknowledgedBy"))
	  			{
	  				this.SubCriteria["AcknowledgedBy"] = new ClearCanvas.Healthcare.NoteAcknowledgementSearchCriteria("AcknowledgedBy");
	  			}
	  			return (ClearCanvas.Healthcare.NoteAcknowledgementSearchCriteria)this.SubCriteria["AcknowledgedBy"];
	  		}
	  	}
	  	
	}
}
