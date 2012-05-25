// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="PerformingGroup"/> class.
    /// </summary>
	public partial class PerformingGroupSearchCriteria : ProcedureTypeGroupSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public PerformingGroupSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public PerformingGroupSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected PerformingGroupSearchCriteria(PerformingGroupSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new PerformingGroupSearchCriteria(this);
        }


		
	}
}
