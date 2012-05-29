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

using System.Collections.Generic;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Healthcare.Brokers;
using System;

namespace ClearCanvas.Ris.Application.Services
{
    public class WorkingShiftAssembler
    {
        public WorkingShiftDetail CreateWorkingShiftDetail(WorkingShift Shift)
        {
            var detail = new WorkingShiftDetail();
            var staffAssembler = new StaffAssembler();
            var fassemble = new FacilityAssembler();
            detail.WorkingShiftRef = Shift.GetRef();
            detail.Name = Shift.Name;
            detail.Description = Shift.Description;
            detail.Deactivated = Shift.Deactivated;
            detail.Clinic = fassemble.CreateFacilitySummary(Shift.Clinic);
            detail.WorkingOnMonday  = Shift.WorkOnMonday ;
            detail.WorkingOnTuesday = Shift.WorkOnTuesday;
            detail.WorkingOnWednesday = Shift.WorkOnWednesday;
            detail.WorkingOnThursday = Shift.WorkOnThursday;
            detail.WorkingOnFriday = Shift.WorkOnFriday;
            detail.WorkingOnSaturday = Shift.WorkOnSaturday;
            detail.WorkingOnSunday = Shift.WorkOnSunday;
            detail.Doctors = CollectionUtils.Map<Staff, StaffSummary>(
                    Shift.Doctors,
                    d => staffAssembler.CreateStaffSummary(d));

            return detail;
        }
        public WorkingShiftSummary CreateWorkingShiftSummary(WorkingShift ws)
        {
            FacilityAssembler assembler = new FacilityAssembler();

            return new WorkingShiftSummary(
                ws.GetRef(),
                ws.Name,
                ws.Description,
                ws.ValidFromDate,
                ws.ValidToDate,
                ws.StartTime,
                ws.EndTime,
                assembler.
                CreateFacilitySummary(ws.Clinic),
                ws.WorkOnMonday,
                ws.WorkOnTuesday,
                ws.WorkOnWednesday,
                ws.WorkOnThursday,
                ws.WorkOnFriday,
                ws.WorkOnSaturday,
                ws.WorkOnSunday,
                ws.Deactivated);
        }

        public void UpdateWorkingShift(WorkingShift ws, WorkingShiftDetail detail, IPersistenceContext context)
        {
            ws.Clinic = context.GetBroker<IFacilityBroker>().Load(detail.Clinic.FacilityRef);
            ws.Deactivated = detail.Deactivated;
            ws.Description = detail.Description;
            ws.Name = detail.Name;
            ws.StartTime = detail.StartTime;
            ws.EndTime = detail.EndTime;
            ws.ValidFromDate = detail.ValidFromDate;
            ws.ValidToDate = detail.ValidToDate;

            ws.WorkOnMonday = detail.WorkingOnMonday;
            ws.WorkOnTuesday = detail.WorkingOnTuesday;
            ws.WorkOnWednesday = detail.WorkingOnWednesday;
            ws.WorkOnThursday = detail.WorkingOnThursday;
            ws.WorkOnFriday = detail.WorkingOnFriday;
            ws.WorkOnSaturday = detail.WorkingOnSaturday;
            ws.WorkOnSunday = detail.WorkingOnSunday;

            ws.Doctors.Clear(); //= CollectionUtils.Map<StaffSummary, Staff>(detail.Doctors, s => context.Load<Staff>(s.StaffRef));

            CollectionUtils.ForEach(detail.Doctors,
                 delegate(StaffSummary summary)
                 {
                     ws.Doctors.Add(context.Load<Staff>(summary.StaffRef, EntityLoadFlags.Proxy));
                 });
            //foreach (var item in detail.Doctors)
            //{
            //    DoctorWorkingPlan d = new DoctorWorkingPlan();
            //    d.Clinic = context.Load<Facility>(detail.Clinic.FacilityRef);
            //    d.Doctor = context.Load<Staff>(item.DoctorSummary.StaffRef);
            //    d.PlanDate = item.PlanDate;
            //    ws.Doctors.Add(d);
            //}


        }


    }
}