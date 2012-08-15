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
using ClearCanvas.Material.Healthcare;
using ClearCanvas.Material.Application.Common.Contacts;
using System.Xml;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Healthcare;


namespace ClearCanvas.Material.Application.Services.Contacts
{

    public partial class ContactAssembler
    {
        public ContactSummary CreateSummary(Contact obj)
        {
            FacilityAssembler assembler = new FacilityAssembler();
            return new ContactSummary(obj.GetRef(), obj.Code,
                obj.Name,
                obj.Address,
                obj.ContactDetailInformation,
                obj.Deactivated,
                assembler.CreateFacilitySummary(obj.Clinic));

        }

        public ContactDetail CreateDetail(Contact obj, IPersistenceContext context)
        {
            FacilityAssembler assembler = new FacilityAssembler();
            // write plan to string
            return new ContactDetail(
                obj.GetRef(), obj.Code,
                obj.Name,
                obj.Address,
                obj.ContactDetailInformation,
                obj.Deactivated,
                assembler.CreateFacilitySummary(obj.Clinic));

        }

        public void UpdateContact(Contact obj, ContactDetail detail, IPersistenceContext context)
        {
            //loop through property and set value
            obj.Code = detail.Code;
            obj.Name = detail.Name;
            obj.Address = detail.Address;
            obj.ContactDetailInformation = detail.ContactDetailInformation;
            obj.Deactivated = detail.Deactivated;
            obj.Clinic = context.Load<Facility>(detail.Clinic.FacilityRef);

        }
    }
}
