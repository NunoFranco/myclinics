#region License

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

using System.Collections;
using ClearCanvas.Common;
using ClearCanvas.Healthcare.Brokers;

namespace ClearCanvas.Healthcare
{
    [WorklistProcedureTypeGroupClass(typeof(PerformingGroup))]
    [WorklistCategory("WorklistCategoryRegistration")]
    public abstract class RegistrationWorklist : Worklist
    { 
        public RegistrationWorklist()
        { }
        public RegistrationWorklist(Facility f)
            : base(f)
        { }
        public override IList GetWorklistItems(IWorklistQueryContext wqc)
        {
            return (IList)wqc.GetBroker<IRegistrationWorklistItemBroker>().GetWorklistItems(this, wqc);
        }

        public override int GetWorklistItemCount(IWorklistQueryContext wqc)
        {
            return wqc.GetBroker<IRegistrationWorklistItemBroker>().CountWorklistItems(this, wqc);
        }
    }

    /// <summary>
    /// RegistrationToBeScheduledWorklist entity
    /// </summary>
    [ExtensionOf(typeof(WorklistExtensionPoint))]
    [WorklistSupportsTimeFilter(true)]
    [WorklistCategory("WorklistCategoryBooking")]
    [WorklistClassDescription("RegistrationToBeScheduledWorklistDescription")]
    public class RegistrationToBeScheduledWorklist : RegistrationWorklist
    { 
        public RegistrationToBeScheduledWorklist()
        { }
        public RegistrationToBeScheduledWorklist(Facility f)
            : base(f)
        { }
        protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
        {
            RegistrationWorklistItemSearchCriteria criteria = new RegistrationWorklistItemSearchCriteria();
            //criteria.Order.Status.In(new OrderStatus[] { OrderStatus.SC });
            criteria.Procedure.Status.EqualTo(Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum >(ProcedureStatus.SC .ToString(), Clinic.OID ));

            // only unscheduled items should appear in this list
            criteria.Procedure.ScheduledStartTime.IsNull();

            ApplyTimeCriteria(criteria, WorklistTimeField.OrderSchedulingRequestTime, null, WorklistOrdering.PrioritizeOldestItems, wqc);
            return new WorklistItemSearchCriteria[] { criteria };
        }
    }

    /// <summary>
    /// RegistrationScheduledWorklist entity
    /// </summary>
    [ExtensionOf(typeof(WorklistExtensionPoint))]
    [WorklistSupportsTimeFilter(true)]
    [WorklistClassDescription("RegistrationScheduledWorklistDescription")]
    public class RegistrationScheduledWorklist : RegistrationWorklist
    { 
        public RegistrationScheduledWorklist()
        { }
        public RegistrationScheduledWorklist(Facility f)
            : base(f)
        { }
        protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
        {
            RegistrationWorklistItemSearchCriteria criteria = new RegistrationWorklistItemSearchCriteria();
            //criteria.Order.Status.EqualTo(OrderStatus.SC);
            criteria.Procedure.Status.EqualTo(Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.SC.ToString(), Clinic.OID));
            criteria.ProcedureCheckIn.CheckInTime.IsNull();     // exclude anything already checked-in
            ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureScheduledStartTime, WorklistTimeRange.Today, WorklistOrdering.PrioritizeOldestItems, wqc);
            return new WorklistItemSearchCriteria[] { criteria };
        }
    }

    /// <summary>
    /// RegistrationCheckedInWorklist entity
    /// </summary>
    [ExtensionOf(typeof(WorklistExtensionPoint))]
    [WorklistSupportsTimeFilter(true)]
    [WorklistClassDescription("RegistrationCheckedInWorklistDescription")]
    public class RegistrationCheckedInWorklist : RegistrationWorklist
    { 
        public RegistrationCheckedInWorklist()
        { }
        public RegistrationCheckedInWorklist(Facility f)
            : base(f)
        { }
        protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
        {
            RegistrationWorklistItemSearchCriteria criteria = new RegistrationWorklistItemSearchCriteria();
            //criteria.Order.Status.EqualTo(OrderStatus.SC);
            criteria.Procedure.Status.EqualTo(Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.SC.ToString(), Clinic.OID));
            criteria.ProcedureCheckIn.CheckInTime.IsNotNull();  // include only items that have been checked-in
            criteria.ProcedureCheckIn.CheckOutTime.IsNull();
            ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureCheckInTime, WorklistTimeRange.Today, WorklistOrdering.PrioritizeOldestItems, wqc);
            return new WorklistItemSearchCriteria[] { criteria };
        }
    }

    /// <summary>
    /// RegistrationInProgessWorklist entity
    /// </summary>
    [ExtensionOf(typeof(WorklistExtensionPoint))]
    [WorklistSupportsTimeFilter(true)]
    [WorklistClassDescription("RegistrationInProgressWorklistDescription")]
    public class RegistrationInProgressWorklist : RegistrationWorklist
    { 
        public RegistrationInProgressWorklist()
        { }
        public RegistrationInProgressWorklist(Facility f)
            : base(f)
        { }
        protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
        {
            RegistrationWorklistItemSearchCriteria criteria = new RegistrationWorklistItemSearchCriteria();
            //criteria.Order.Status.EqualTo(OrderStatus.IP);
            criteria.Procedure.Status.EqualTo(Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.IP .ToString(), Clinic.OID));
            criteria.ProcedureCheckIn.CheckOutTime.IsNull();    // exclude any item already checked-out
            ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureStartTime, WorklistTimeRange.Today, WorklistOrdering.PrioritizeOldestItems, wqc);
            return new WorklistItemSearchCriteria[] { criteria };
        }
    }

    /// <summary>
	/// RegistrationPerformedWorklist entity
    /// </summary>
    [ExtensionOf(typeof(WorklistExtensionPoint))]
    [WorklistSupportsTimeFilter(true)]
    [WorklistClassDescription("RegistrationPerformedWorklistDescription")]
    public class RegistrationPerformedWorklist : RegistrationWorklist
    { 
        public RegistrationPerformedWorklist()
        { }
        public RegistrationPerformedWorklist(Facility f)
            : base(f)
        { }
        protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
        {
            // "completed" in this context just means the patient has checked-out
            // the order may still be in progress
            RegistrationWorklistItemSearchCriteria criteria = new RegistrationWorklistItemSearchCriteria();
            //criteria.Order.Status.In(new OrderStatus[] { OrderStatus.IP, OrderStatus.CM });
            criteria.Procedure.Status.In(new ProcedureStatusEnum[] { Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.IP.ToString(), Clinic.OID), Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.CM.ToString(), Clinic.OID) });
            criteria.ProcedureCheckIn.CheckOutTime.IsNotNull();
            ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureCheckOutTime, WorklistTimeRange.Today, WorklistOrdering.PrioritizeNewestItems, wqc);
            return new WorklistItemSearchCriteria[] { criteria };
        }
    }

    /// <summary>
    /// RegistrationCancelledWorklist entity
    /// </summary>
    [ExtensionOf(typeof(WorklistExtensionPoint))]
    [WorklistSupportsTimeFilter(true)]
    [WorklistClassDescription("RegistrationCancelledWorklistDescription")]
    public class RegistrationCancelledWorklist : RegistrationWorklist
    { 
        public RegistrationCancelledWorklist()
        { }
        public RegistrationCancelledWorklist(Facility f)
            : base(f)
        { }
        protected override WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc)
        {
            RegistrationWorklistItemSearchCriteria criteria = new RegistrationWorklistItemSearchCriteria();
            //criteria.Order.Status.In(new OrderStatus[] { OrderStatus.DC, OrderStatus.CA, OrderStatus.RP });
            criteria.Procedure.Status.In(new ProcedureStatusEnum[] { Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.DC.ToString(), Clinic.OID), Healthcare.Common.ConvertSystemEnumTohbmEnum<ProcedureStatusEnum>(ProcedureStatus.CA.ToString(), Clinic.OID) });

            // apply filter to the end-time (time procedure was was cancelled)
            ApplyTimeCriteria(criteria, WorklistTimeField.ProcedureEndTime, WorklistTimeRange.Today, WorklistOrdering.PrioritizeNewestItems, wqc);
            return new WorklistItemSearchCriteria[] { criteria };
        }
    }
}