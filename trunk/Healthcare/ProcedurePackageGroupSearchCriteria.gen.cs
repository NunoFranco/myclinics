// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProcedurePackageGroup"/> class.
    /// </summary>
	public partial class ProcedurePackageGroupSearchCriteria : ProcedureTypeGroupSearchCriteria
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
