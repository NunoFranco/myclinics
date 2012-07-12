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


namespace ClearCanvas.Ris.Application.Common
{
    [DataContract]
    public class PatientProfileDetail : DataContractBase
    {
        public PatientProfileDetail()
        {
            this.Mrn = new CompositeIdentifierDetail();
            this.Healthcard = new HealthcardDetail();
            this.Addresses = new List<AddressDetail>();
            this.ContactPersons = new List<ContactPersonDetail>();
            this.EmailAddresses = new List<EmailAddressDetail>();
            this.TelephoneNumbers = new List<TelephoneDetail>();
            this.Notes = new List<PatientNoteDetail>();
            this.Attachments = new List<PatientAttachmentSummary>();
            this.Name = new PersonNameDetail();
            
        }

        [DataMember]
        public EntityRef PatientRef;

        [DataMember]
        public EntityRef PatientProfileRef;

        [DataMember]
        public CompositeIdentifierDetail Mrn;

        [DataMember]
        public HealthcardDetail Healthcard;

        [DataMember]
        public PersonNameDetail Name;

        [DataMember]
        public DateTime? DateOfBirth;

        [DataMember]
        public EnumValueInfo Sex;

        [DataMember]
        public EnumValueInfo PrimaryLanguage;

        [DataMember]
        public EnumValueInfo Religion;

        [DataMember]
        public bool DeathIndicator;

        [DataMember]
        public DateTime? TimeOfDeath;

        [DataMember]
        public AddressDetail CurrentHomeAddress;

        [DataMember]
        public AddressDetail CurrentWorkAddress;

        [DataMember]
        public TelephoneDetail CurrentHomePhone;

        [DataMember]
        public TelephoneDetail CurrentWorkPhone;

        [DataMember]
        public List<AddressDetail> Addresses;

        [DataMember]
        public List<TelephoneDetail> TelephoneNumbers;

        [DataMember]
        public List<EmailAddressDetail> EmailAddresses;

        [DataMember]
        public List<ContactPersonDetail> ContactPersons;

        [DataMember]
        public List<PatientNoteDetail> Notes;

        [DataMember]
        public List<PatientAttachmentSummary> Attachments;

        [DataMember]
        public EnumValueInfo DiscountType { get; set; }

        [DataMember]
        public EnumValueInfo InsuranceType { get; set; }
    }
}