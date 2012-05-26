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
using System;

namespace ClearCanvas.Ris.Application.Services
{
    public class ProcedureAssembler
    {
        /// <summary>
        /// Creates the most verbose possible procedure detail.
        /// </summary>
        /// <param name="rp"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public ProcedureDetail CreateProcedureDetail(Procedure rp, IPersistenceContext context)
        {
            return CreateProcedureDetail(rp, delegate { return true; }, true, context);
        }

        /// <summary>
        /// Creates procedure detail optionally including specified data.
        /// </summary>
        /// <param name="rp"></param>
        /// <param name="procedureStepFilter"></param>
        /// <param name="includeProtocol"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public ProcedureDetail CreateProcedureDetail(
            Procedure rp,
            Predicate<ProcedureStep> procedureStepFilter,
            bool includeProtocol,
            IPersistenceContext context)
        {
            ProcedureDetail detail = new ProcedureDetail();
            Facility CurrentClinic = rp.Clinic;
            DiagnosticServiceAssembler diaAssembler = new DiagnosticServiceAssembler();
            detail.ProcedureRef = rp.GetRef();
            detail.Status = EnumUtils.GetEnumValueInfo(rp.Status);
            detail.Type = new ProcedureTypeAssembler().CreateSummary(rp.Type, context);
            detail.ScheduledStartTime = rp.ScheduledStartTime;
            detail.StartTime = rp.StartTime;
            detail.EndTime = rp.EndTime;
            detail.CheckInTime = rp.ProcedureCheckIn.CheckInTime;
            detail.CheckOutTime = rp.ProcedureCheckIn.CheckOutTime;
            detail.PerformingFacility = new FacilityAssembler().CreateFacilitySummary(rp.PerformingFacility);
            detail.Laterality = EnumUtils.GetEnumValueInfo(rp.Laterality);
            detail.ImageAvailability = EnumUtils.GetEnumValueInfo(rp.ImageAvailability);
            detail.Portable = rp.Portable;
            #region Longchang added
            detail.IsPackageProcedure = rp.IsPackageProcedure;
            detail.CollectedAmount = rp.CollectedAmount;
            detail.WaitingInsuranceAmount = rp.WaitingInsuranceAmount;
            //detail.IsPendingProcedure = rp.IsPendingInsurance;
            detail.PendingProcedureStatus = rp.PendingProcedureStatus;
            if (rp.IsPackageProcedure && rp.PackageProcedure != null)
                detail.PackageProcedure = diaAssembler.CreateSummary(rp.PackageProcedure);
            #endregion Longchang added

            List<ProcedureStep> includedSteps = CollectionUtils.Select(rp.GetWorkflowHistory(), procedureStepFilter);
            if (includedSteps.Count > 0)
            {
                ProcedureStepAssembler procedureStepAssembler = new ProcedureStepAssembler();
                detail.ProcedureSteps = CollectionUtils.Map<ProcedureStep, ProcedureStepDetail>(
                    includedSteps,
                    delegate(ProcedureStep ps)
                    {
                        return procedureStepAssembler.CreateProcedureStepDetail(ps, CurrentClinic, context);
                    });
            }

            // the Protocol may be null, if this procedure has not been protocolled
            if (includeProtocol && rp.ActiveProtocol != null)
            {
                ProtocolAssembler protocolAssembler = new ProtocolAssembler();
                detail.Protocol = protocolAssembler.CreateProtocolDetail(rp.ActiveProtocol, context);
            }

            return detail;
        }

        public ProcedureSummary CreateProcedureSummary(Procedure rp, IPersistenceContext context)
        {
            ProcedureTypeAssembler rptAssembler = new ProcedureTypeAssembler();
            ProcedureSummary summary = new ProcedureSummary();

            summary.OrderRef = rp.Order.GetRef();
            summary.ProcedureRef = rp.GetRef();
            summary.Index = rp.Index;
            summary.ScheduledStartTime = rp.ScheduledStartTime;
            summary.PerformingFacility = new FacilityAssembler().CreateFacilitySummary(rp.PerformingFacility);
            summary.Type = rptAssembler.CreateSummary(rp.Type, context);
            summary.Laterality = EnumUtils.GetEnumValueInfo(rp.Laterality);
            summary.Portable = rp.Portable;
            summary.IsPackageProcedure = rp.IsPackageProcedure;
            summary.WaitingInsuranceAmount = rp.WaitingInsuranceAmount;
            summary.CollectedAmount = rp.CollectedAmount;
            //summary.IsPendingProcedure = rp.IsPendingInsurance;
            summary.ProcedureTypeID = rp.Type.OID.ToString();
            return summary;
        }
    }
}
