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

using System;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;
using System.Collections.Generic;

namespace ClearCanvas.Ris.Application.Common
{
    [DataContract]
    public class WorkingShiftDetail : DataContractBase, IEquatable<WorkingShiftDetail>
    {
		public WorkingShiftDetail()
		{

		}

        public WorkingShiftDetail(EntityRef entityRef, 
            string name, 
            string description,
            DateTime validfrom, 
            DateTime validto, 
            DateTime starttime, 
            DateTime endtime, 
            List<DoctorWorkingPlanSummary> doctors,
            FacilitySummary fSummary,
            bool deactivated)
        {
            WorkingShiftRef = entityRef;
            Name = name;
            Description = description;
        	Deactivated = deactivated;
            this.ValidFromDate = validfrom;
            this.ValidToDate = validto;
            this.StartTime = starttime;
            this.EndTime = endtime;
            this.Doctors = doctors;
            Clinic = fSummary;
        }

        [DataMember]
        public EntityRef WorkingShiftRef;

        [DataMember]
        public string Name;

        [DataMember]
        public string Description;

        [DataMember]
        public DateTime  PlanDate;


        [DataMember]
        public DateTime ValidFromDate;

        [DataMember]
        public DateTime ValidToDate;

        [DataMember]
        public DateTime StartTime;

        [DataMember]
        public DateTime EndTime;
[DataMember]
        public FacilitySummary  Clinic;
        [DataMember]
        public List<DoctorWorkingPlanSummary> Doctors;
		[DataMember]
		public bool Deactivated;

        public bool Equals(WorkingShiftDetail WorkingShiftDetail)
        {
            if (WorkingShiftDetail == null) return false;
            return Equals(this.WorkingShiftRef, WorkingShiftDetail.WorkingShiftRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as WorkingShiftDetail);
        }

        public override int GetHashCode()
        {
			return WorkingShiftRef.GetHashCode();
        }
    }
}