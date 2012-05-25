// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// <see cref="WorklistQueryBaseCriteria"/> class
    /// </summary>
	public partial class WorklistQueryBaseCriteria : ClearCanvas.Enterprise.Core.SearchCriteria
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public WorklistQueryBaseCriteria()
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected WorklistQueryBaseCriteria(WorklistQueryBaseCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new WorklistQueryBaseCriteria(this);
        }
	
		
	  	public ISearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum> PatientProfileAssigningAuthority
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("PatientProfileAssigningAuthority"))
	  			{
	  				this.SubCriteria["PatientProfileAssigningAuthority"] = new SearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum>();
	  			}
	  			return (ISearchCondition<ClearCanvas.Healthcare.InformationAuthorityEnum>)this.SubCriteria["PatientProfileAssigningAuthority"];
	  		}
	  	}
	  	
	}
}
