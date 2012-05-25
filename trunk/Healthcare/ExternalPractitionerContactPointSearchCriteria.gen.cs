// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ExternalPractitionerContactPoint"/> class.
    /// </summary>
	public partial class ExternalPractitionerContactPointSearchCriteria : EntitySearchCriteria<ExternalPractitionerContactPoint>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ExternalPractitionerContactPointSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ExternalPractitionerContactPointSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ExternalPractitionerContactPointSearchCriteria(ExternalPractitionerContactPointSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ExternalPractitionerContactPointSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.ExternalPractitionerSearchCriteria Practitioner
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Practitioner"))
	  			{
	  				this.SubCriteria["Practitioner"] = new ClearCanvas.Healthcare.ExternalPractitionerSearchCriteria("Practitioner");
	  			}
	  			return (ClearCanvas.Healthcare.ExternalPractitionerSearchCriteria)this.SubCriteria["Practitioner"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Name
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Name"))
	  			{
	  				this.SubCriteria["Name"] = new SearchCondition<string>("Name");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Name"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> Description
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Description"))
	  			{
	  				this.SubCriteria["Description"] = new SearchCondition<string>("Description");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["Description"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ResultCommunicationModeEnum> PreferredResultCommunicationMode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PreferredResultCommunicationMode"))
	  			{
	  				this.SubCriteria["PreferredResultCommunicationMode"] = new SearchCondition<ClearCanvas.Healthcare.ResultCommunicationModeEnum>("PreferredResultCommunicationMode");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ResultCommunicationModeEnum>)this.SubCriteria["PreferredResultCommunicationMode"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsDefaultContactPoint
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsDefaultContactPoint"))
	  			{
	  				this.SubCriteria["IsDefaultContactPoint"] = new SearchCondition<bool>("IsDefaultContactPoint");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsDefaultContactPoint"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> Deactivated
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Deactivated"))
	  			{
	  				this.SubCriteria["Deactivated"] = new SearchCondition<bool>("Deactivated");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Deactivated"];
	  		}
	  	}
	  	
	}
}
