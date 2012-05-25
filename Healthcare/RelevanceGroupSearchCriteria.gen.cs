// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="RelevanceGroup"/> class.
    /// </summary>
	public partial class RelevanceGroupSearchCriteria : ProcedureTypeGroupSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public RelevanceGroupSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public RelevanceGroupSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected RelevanceGroupSearchCriteria(RelevanceGroupSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new RelevanceGroupSearchCriteria(this);
        }


		
	}
}
