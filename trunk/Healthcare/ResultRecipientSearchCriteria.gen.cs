// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ResultRecipient"/> class.
    /// </summary>
	public partial class ResultRecipientSearchCriteria : SearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ResultRecipientSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ResultRecipientSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ResultRecipientSearchCriteria(ResultRecipientSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ResultRecipientSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.ExternalPractitionerContactPointSearchCriteria PractitionerContactPoint
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PractitionerContactPoint"))
	  			{
	  				this.SubCriteria["PractitionerContactPoint"] = new ClearCanvas.Healthcare.ExternalPractitionerContactPointSearchCriteria("PractitionerContactPoint");
	  			}
	  			return (ClearCanvas.Healthcare.ExternalPractitionerContactPointSearchCriteria)this.SubCriteria["PractitionerContactPoint"];
	  		}
	  	}
	  	
	  	public ISearchCondition<ClearCanvas.Healthcare.ResultCommunicationModeEnum> PreferredCommunicationMode
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PreferredCommunicationMode"))
	  			{
	  				this.SubCriteria["PreferredCommunicationMode"] = new SearchCondition<ClearCanvas.Healthcare.ResultCommunicationModeEnum>("PreferredCommunicationMode");
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.ResultCommunicationModeEnum>)this.SubCriteria["PreferredCommunicationMode"];
	  		}
	  	}
	  	
	}
}
