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

using System;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Healthcare;

namespace ClearCanvas.Ris.Application.Common
{
    [DataContract]
    public class FacilitySummary : DataContractBase, IEquatable<FacilitySummary>
    {
       
        public FacilitySummary(EntityRef facilityRef, string code, string name, EnumValueInfo informationAuthority, bool deactivated)
        {
            this.FacilityRef = facilityRef;
            
            this.Code = code;
            this.Name = name;
            this.InformationAuthority = informationAuthority;
        	this.Deactivated = deactivated;
            this.OID = (System.Guid )facilityRef.EntityOID;
        }

        public FacilitySummary()
        {
        }

        [DataMember]
        public EntityRef FacilityRef;

        [DataMember]
        public string Code;

        [DataMember]
        public string Name;

        [DataMember]
        public EnumValueInfo InformationAuthority;

		[DataMember]
		public bool Deactivated;

        [DataMember]
        public Guid OID;

		public bool Equals(FacilitySummary facilitySummary)
        {
            if (facilitySummary == null) return false;
            return Equals(FacilityRef, facilitySummary.FacilityRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as FacilitySummary);
        }

        public override int GetHashCode()
        {
            return FacilityRef == null ? 0 : FacilityRef.GetHashCode();
        }
    }
}