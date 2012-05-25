// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="VerificationStep"/> class.
    /// </summary>
	public partial class VerificationStepSearchCriteria : ReportingProcedureStepSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public VerificationStepSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public VerificationStepSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected VerificationStepSearchCriteria(VerificationStepSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new VerificationStepSearchCriteria(this);
        }


		
	}
}
