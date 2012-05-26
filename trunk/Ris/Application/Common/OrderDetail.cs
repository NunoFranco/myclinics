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
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common
{
    [DataContract]
    public class OrderDetail : DataContractBase
    {
        public OrderDetail()
        {
            this.Procedures = new List<ProcedureDetail>();
            Invoices = new List<OrderInvoicesDetail>();
        }

        [DataMember] 
        public EntityRef OrderRef;

        [DataMember]
        public EntityRef PatientRef;

        [DataMember]
        public List<PatientProfileDetail> PatinentProfiles;
        
        [DataMember]
        public VisitDetail Visit;

        [DataMember]
        public string PlacerNumber;

        [DataMember]
        public string AccessionNumber;

        [DataMember]
        public DiagnosticServiceSummary DiagnosticService;

        [DataMember]
        public DateTime? EnteredTime;

		[DataMember]
		public StaffSummary EnteredBy;

		[DataMember]
		public string EnteredComment;

		[DataMember]
        public DateTime? SchedulingRequestTime;

        [DataMember]
        public ExternalPractitionerSummary OrderingPractitioner;

        [DataMember]
        public FacilitySummary OrderingFacility;

        [DataMember]
        public string ReasonForStudy;

        [DataMember]
        public string OrderNumber;

        [DataMember]
        public string BillingStatus;

        [DataMember]
        public EnumValueInfo OrderPriority;

        [DataMember]
        public EnumValueInfo CancelReason;

		[DataMember]
		public StaffSummary CancelledBy;

		[DataMember]
		public string CancelComment;

		[DataMember]
        public List<ProcedureDetail> Procedures;

        [DataMember]
        public List<OrderNoteSummary> Notes;

		[DataMember]
		public List<OrderAttachmentSummary> Attachments;

		[DataMember]
		public List<ResultRecipientDetail> ResultRecipients;

		[DataMember]
		public Dictionary<string, string> ExtendedProperties;

        [DataMember]
        public List<OrderInvoicesDetail> Invoices;
	}
}
