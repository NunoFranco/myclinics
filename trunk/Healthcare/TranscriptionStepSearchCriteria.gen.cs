// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="TranscriptionStep"/> class.
    /// </summary>
	public partial class TranscriptionStepSearchCriteria : ReportingProcedureStepSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public TranscriptionStepSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public TranscriptionStepSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected TranscriptionStepSearchCriteria(TranscriptionStepSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new TranscriptionStepSearchCriteria(this);
        }


		
	}
}
