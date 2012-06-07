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
using System.IO;
using System.Text;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Healthcare;
using ClearCanvas.Ris.Application.Common;
using System.Xml;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Ris.Application.Services
{
    public class DoctorPrescriptionAssembler
    {
        public DoctorPrescriptionSummary CreateSummary(Healthcare.DoctorPrescription rpt)
        {

            FacilityAssembler assembler = new FacilityAssembler();
            return new DoctorPrescriptionSummary(rpt.GetRef(), rpt.Name, rpt.Description, assembler.CreateFacilitySummary(rpt.Clinic));
        }

        public DoctorPrescriptionDetail CreateDetail(Healthcare.DoctorPrescription DoctorPrescription, IPersistenceContext context)
        {
            // write plan to string
            ProcedureTypeAssembler assembler = new ProcedureTypeAssembler();
            FacilityAssembler fassembler = new FacilityAssembler();
            return new DoctorPrescriptionDetail(
                DoctorPrescription.GetRef(),
                DoctorPrescription.Name,
                DoctorPrescription.Description,
                CollectionUtils.Map<ProcedureType, ProcedureTypeSummary>(DoctorPrescription.Medicines, dp => assembler.CreateSummary(dp, null )),
                fassembler.CreateFacilitySummary(DoctorPrescription.Clinic),
                DoctorPrescription.Deactivated 
                );
        }

        public void UpdateDoctorPrescription(Healthcare.DoctorPrescription dp, DoctorPrescriptionDetail detail, IPersistenceContext context)
        {
            dp.Name = detail.Name;
            dp.Description = detail.Description;
            dp.Deactivated = detail.Deactivated;
            dp.Clinic = context.Load<Facility>(detail.Clinic.FacilityRef);
            dp.Medicines.Clear();

            CollectionUtils.ForEach(detail.Medicines,
                delegate(ProcedureTypeSummary summary)
                {
                    dp.Medicines.Add(context.Load<ProcedureType>(summary.ProcedureTypeRef, EntityLoadFlags.Proxy));
                });
        }
    }
}
