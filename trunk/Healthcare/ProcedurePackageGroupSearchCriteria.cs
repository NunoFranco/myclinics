using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{
    public class ProcedurePackageGroupSearchCriteria : EntitySearchCriteria<DiscountInsuranceClass>
    {
        /// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProcedurePackageGroupSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProcedurePackageGroupSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
        protected ProcedurePackageGroupSearchCriteria(ProcedurePackageGroupSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProcedurePackageGroupSearchCriteria(this);
        }


	  	
	  	
	  	
    }
}
