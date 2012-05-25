// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="PatientNote"/> class.
    /// </summary>
	public partial class PatientNoteSearchCriteria : EntitySearchCriteria<PatientNote>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public PatientNoteSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public PatientNoteSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected PatientNoteSearchCriteria(PatientNoteSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new PatientNoteSearchCriteria(this);
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
	  	
	  	public ClearCanvas.Healthcare.PatientNoteCategorySearchCriteria Category
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Category"))
	  			{
	  				this.SubCriteria["Category"] = new ClearCanvas.Healthcare.PatientNoteCategorySearchCriteria("Category");
	  			}
	  			return (ClearCanvas.Healthcare.PatientNoteCategorySearchCriteria)this.SubCriteria["Category"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Comment
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Comment"))
	  			{
	  				this.SubCriteria["Comment"] = new SearchCondition<string>("Comment");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Comment"];
	  		}
	  	}
	  	
	}
}
