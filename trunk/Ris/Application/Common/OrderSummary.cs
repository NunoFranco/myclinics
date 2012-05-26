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
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Admin;

namespace ClearCanvas.Ris.Application.Common
{
    [DataContract]
    public class OrderSummary : DataContractBase
    {
        public EnumValueInfo CancelStatus { get { return new EnumValueInfo("CA", "",this.Clinic.OID ); } }

        public EnumValueInfo CancelReason { get { return new EnumValueInfo("PA", "", this.Clinic.OID); } }
        public OrderSummary()
        {
            Invoices = new List<ClearCanvas.Ris.Application.Common.Billing.OrderInvoicesSummary>();
            ProcedureTypes = new List<ProcedureTypeSummary>();

        }

        [DataMember]
        public EntityRef OrderRef;

        [DataMember]
        public string AccessionNumber;

        [DataMember]
        public string DiagnosticServiceName;

        [DataMember]
        public DateTime? EnteredTime;

        [DataMember]
        public DateTime? SchedulingRequestTime;

        [DataMember]
        public ExternalPractitionerSummary OrderingPractitioner;

        [DataMember]
        public string OrderingFacility;

        [DataMember]
        public string ReasonForStudy;

        [DataMember]
        public string OrderNumber;

        [DataMember]
        public string BillingStatus;

        [DataMember]
        public EnumValueInfo OrderPriority;

        [DataMember]
        public EnumValueInfo OrderStatus;

        [DataMember]
        public List<ClearCanvas.Ris.Application.Common.Billing.OrderInvoicesSummary> Invoices;

        [DataMember]
        public List<ClearCanvas.Ris.Application.Common.ProcedureTypeSummary> ProcedureTypes;

        [DataMember]
        public FacilitySummary Clinic;
    }
}