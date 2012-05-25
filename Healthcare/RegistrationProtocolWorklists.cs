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
using ClearCanvas.Workflow;

namespace ClearCanvas.Healthcare
{
	[WorklistProcedureTypeGroupClass(typeof(PerformingGroup))]
	[WorklistCategory("WorklistCategoryBooking")]
	public abstract class RegistrationProtocolWorklist : RegistrationWorklist
	{ 
        public RegistrationProtocolWorklist()
        { }
        public RegistrationProtocolWorklist(Facility f)
            : base(f)
        { }
	}

	/// <summary>
	/// RegistrationPendingProtocolWorklist entity
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(true)]
	[WorklistClassDescription("RegistrationPendingProtocolWorklistDescription")]
	public class RegistrationPendingProtocolWorklist : RegistrationProtocolWorklist
	{ 
        public RegistrationPendingProtocolWorklist()
        { }
         public RegistrationPendingProtocolWorklist(Facility f)
            : base(f)
        { }
		protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
		{
			var criteria = new RegistrationWorklistItemSearchCriteria();
			criteria.ProcedureStep.State.In(new[] { ActivityStatus.SC, ActivityStatus.IP });
			criteria.ProcedureStepClass = typeof(ProtocolAssignmentStep);

            criteria.Procedure.Status.EqualTo(Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.SC.ToString(), Clinic.OID));	//bug #3498: exclude procedures that are no longer in SC status 
			ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureStepCreationTime, null, WorklistOrdering.PrioritizeOldestItems, wqc);
			return new WorklistItemSearchCriteria[] { criteria };
		}
	}

	/// <summary>
	/// RegistrationAsapPendingProtocolWorklist entity 
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(true)]
	[WorklistClassDescription("RegistrationAsapPendingProtocolWorklistDescription")]
	public class RegistrationAsapPendingProtocolWorklist : RegistrationProtocolWorklist
	{ 
        public RegistrationAsapPendingProtocolWorklist()
        { }
         public RegistrationAsapPendingProtocolWorklist(Facility f)
            : base(f)
        { }
		protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
		{
			var criteria = new RegistrationWorklistItemSearchCriteria();
			criteria.ProcedureStep.State.In(new[] { ActivityStatus.SC, ActivityStatus.IP });
			criteria.ProcedureStepClass = typeof(ProtocolAssignmentStep);
			criteria.Procedure.Status.EqualTo(Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum >( ProcedureStatus.SC.ToString(),Clinic.OID ));	//bug #3498: exclude procedures that are no longer in SC status 

			// any procedures with pending protocol assignment, where the procedure scheduled start time is filtered
			ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureScheduledStartTime, WorklistTimeRange.Today, WorklistOrdering.PrioritizeOldestItems, wqc);
			return new WorklistItemSearchCriteria[] { criteria };
		}
	}

	/// <summary>
	/// RegistrationRejectedProtocolWorklist entity
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(false)]
	[WorklistClassDescription("RegistrationRejectedProtocolWorklistDescription")]
	public class RegistrationRejectedProtocolWorklist : RegistrationProtocolWorklist
	{ 
        public RegistrationRejectedProtocolWorklist()
        { }
         public RegistrationRejectedProtocolWorklist(Facility f)
            : base(f)
        { }
		protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
		{
			var criteria = new RegistrationWorklistItemSearchCriteria();
			criteria.ProcedureStepClass = typeof(ProtocolResolutionStep);
			criteria.ProcedureStep.State.EqualTo(ActivityStatus.SC);
			ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureStepCreationTime, null, WorklistOrdering.PrioritizeOldestItems, wqc);
			return new WorklistItemSearchCriteria[] { criteria };
		}
	}

	/// <summary>
	/// RegistrationCompletedProtocolWorklist entity
	/// </summary>
	[ExtensionOf(typeof(WorklistExtensionPoint))]
	[WorklistSupportsTimeFilter(false)]
	[WorklistClassDescription("RegistrationCompletedProtocolWorklistDescription")]
	public class RegistrationCompletedProtocolWorklist : RegistrationProtocolWorklist
	{ 
        public RegistrationCompletedProtocolWorklist()
        { }
         public RegistrationCompletedProtocolWorklist(Facility f)
            : base(f)
        { }
		protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
		{
			var criteria = new RegistrationWorklistItemSearchCriteria();
			criteria.ProcedureStepClass = typeof(ProtocolAssignmentStep);
			criteria.ProcedureStep.State.EqualTo(ActivityStatus.CM);

			// only unscheduled procedures should be in this list
			// unscheduled procedures are in the scheduled status but have no scheduled start time
			criteria.Procedure.ScheduledStartTime.IsNull();
			criteria.Procedure.Status.EqualTo(Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.SC,Clinic.OID));

			// checked in procedures are also in the scheduled status and may or may not have no scheduled start time
			// but they should be excluded since there is no reason to schedule a patient who is already here
			criteria.Procedure.ProcedureCheckIn.CheckInTime.IsNull();

			ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureStepEndTime, null, WorklistOrdering.PrioritizeNewestItems, wqc);
			return new WorklistItemSearchCriteria[] { criteria };
		}
	}
}
