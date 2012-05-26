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

namespace ClearCanvas.Ris.Application.Common
{
    [DataContract]
    public class ProcedureTypeSummary : DataContractBase, IEquatable<ProcedureTypeSummary>
    {
        public ProcedureTypeSummary(EntityRef entityRef, string name, string id, bool deactivated,decimal baseprice, decimal tax,decimal afterdiscount, decimal afterinsurace,string proceduretypeid, bool required)
        {
            this.ProcedureTypeRef = entityRef;
            this.Name = name;
            this.Id = id;
        	this.Deactivated = deactivated;
            this.BasePrice = baseprice;
            this.Tax = tax;
            this.AfterDiscountPrice=afterdiscount;
            this.AfterInsurancePrice = afterinsurace;
            ProcedureTypeID = proceduretypeid;
            this.IsRequired = required;
        }

		public ProcedureTypeSummary()
		{
		}

        [DataMember]
        public EntityRef ProcedureTypeRef;

        [DataMember]
        public string ProcedureTypeID;

        [DataMember]
        public string Name;

        [DataMember]
        public string Id;

        [DataMember]
        public decimal BasePrice;

        [DataMember]
        public bool  IsRequired;

        public decimal AfterDiscountPrice
        {
            get;
            set;

        }
        public decimal AfterInsurancePrice
        {
            get;
            set;
        }
        //public Billing.Common.DisCountInsuranceAmountType AmountType { get; set; }
        [DataMember]
        public decimal Tax;
		[DataMember]
		public bool Deactivated;

		public bool Equals(ProcedureTypeSummary that)
        {
            if (that == null) return false;
            return Equals(this.ProcedureTypeRef, that.ProcedureTypeRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ProcedureTypeSummary);
        }

        public override int GetHashCode()
        {
            return ProcedureTypeRef.GetHashCode();
        }
    }
}