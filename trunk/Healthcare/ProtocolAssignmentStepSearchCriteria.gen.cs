// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProtocolAssignmentStep"/> class.
    /// </summary>
	public partial class ProtocolAssignmentStepSearchCriteria : ProtocolProcedureStepSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProtocolAssignmentStepSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProtocolAssignmentStepSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProtocolAssignmentStepSearchCriteria(ProtocolAssignmentStepSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProtocolAssignmentStepSearchCriteria(this);
        }


		
	}
}
