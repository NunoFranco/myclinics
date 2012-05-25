// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="ProtocolResolutionStep"/> class.
    /// </summary>
	public partial class ProtocolResolutionStepSearchCriteria : ProtocolProcedureStepSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public ProtocolResolutionStepSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public ProtocolResolutionStepSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected ProtocolResolutionStepSearchCriteria(ProtocolResolutionStepSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new ProtocolResolutionStepSearchCriteria(this);
        }


		
	}
}
