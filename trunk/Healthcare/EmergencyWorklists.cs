﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using ClearCanvas.Common;

namespace ClearCanvas.Healthcare
{
	/// <summary>
	/// EmergencyScheduledWorklist entity
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(true)]
	[WorklistCategory("WorklistCategoryEmergency")]
	[WorklistClassDescription("EmergencyScheduledWorklistDescription")]
	public class EmergencyScheduledWorklist : RegistrationWorklist
    {
        public EmergencyScheduledWorklist()
        { }
        public EmergencyScheduledWorklist(Facility f)
            : base(f)
        { }
		protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
		{
			// this is slightly different than the registration scheduled worklist, because we include
			// 'checked in' items here, rather than having a separate 'checked in' worklist
			RegistrationWorklistItemSearchCriteria criteria = new RegistrationWorklistItemSearchCriteria();
            
			criteria.Procedure.Status.EqualTo( Common.ConvertSystemEnumTohbmEnum <ProcedureStatusEnum >( ProcedureStatus.SC.ToString(),Clinic.OID ));
			//criteria.Order.Status.EqualTo(OrderStatus.SC);
			ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureScheduledStartTime, WorklistTimeRange.Today, WorklistOrdering.PrioritizeOldestItems, wqc);
			return new WorklistItemSearchCriteria[] { criteria };
		}
	}

	/// <summary>
	/// EmergencyInProgressWorklist entity
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(true)]
	[WorklistCategory("WorklistCategoryEmergency")]
	[WorklistClassDescription("EmergencyInProgressWorklistDescription")]
	public class EmergencyInProgressWorklist : RegistrationInProgressWorklist
	{
        public EmergencyInProgressWorklist()
        { }
         public EmergencyInProgressWorklist(Facility f)
            : base(f)
        { }
	}

	/// <summary>
	/// EmergencyPerformedWorklist entity
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(true)]
	[WorklistCategory("WorklistCategoryEmergency")]
	[WorklistClassDescription("EmergencyPerformedWorklistDescription")]
	public class EmergencyPerformedWorklist : RegistrationPerformedWorklist
	{
        public EmergencyPerformedWorklist()
        { }
         public EmergencyPerformedWorklist(Facility f)
            : base(f)
        { }
	}

	/// <summary>
	/// EmergencyCancelledWorklist entity
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(true)]
	[WorklistCategory("WorklistCategoryEmergency")]
	[WorklistClassDescription("EmergencyCancelledWorklistDescription")]
	public class EmergencyCancelledWorklist : RegistrationCancelledWorklist
	{
        public EmergencyCancelledWorklist()
        { }
         public EmergencyCancelledWorklist(Facility f)
            : base(f)
        { }
	}
}