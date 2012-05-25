// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ReadingGroup"/> class.
    /// </summary>
	public partial class ReadingGroupSearchCriteria : ProcedureTypeGroupSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ReadingGroupSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ReadingGroupSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ReadingGroupSearchCriteria(ReadingGroupSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ReadingGroupSearchCriteria(this);
        }


		
	}
}
