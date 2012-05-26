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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare {


    /// <summary>
    /// ExternalPractitionerContactPoint entity
    /// </summary>
	public partial class ExternalPractitionerContactPoint : ClearCanvas.Enterprise.Core.Entity
	{

        public ExternalPractitionerContactPoint(ExternalPractitioner practitioner)
        {
            _practitioner = practitioner;
            _practitioner.ContactPoints.Add(this);

            _telephoneNumbers = new List<ClearCanvas.Healthcare.TelephoneNumber>();
            _addresses = new List<ClearCanvas.Healthcare.Address>();
            _emailAddresses = new List<ClearCanvas.Healthcare.EmailAddress>();
        }

        public virtual Address CurrentAddress
        {
            get
            {
                return CollectionUtils.SelectFirst(this.Addresses,
                    delegate(Address address) { return Common.IsEqual(address.Type,AddressType.B) && address.IsCurrent; });
            }
        }

        public virtual TelephoneNumber CurrentFaxNumber
        {
            get
            {
                return CollectionUtils.SelectFirst(this.TelephoneNumbers,
                  delegate(TelephoneNumber phone) { return Common.IsEqual(phone.Use,TelephoneUse.WPN) && Common.IsEqual(phone.Equipment,TelephoneEquipment.FX)&& phone.IsCurrent; });
            }
        }

        public virtual TelephoneNumber CurrentPhoneNumber
        {
            get
            {
                return CollectionUtils.SelectFirst(this.TelephoneNumbers,
                  delegate(TelephoneNumber phone) { return Common.IsEqual(phone.Use,TelephoneUse.WPN )&& Common.IsEqual(phone.Equipment, TelephoneEquipment.PH )&& phone.IsCurrent; });
            }
        }

		public virtual EmailAddress CurrentEmailAddress
		{
			get
			{
				return CollectionUtils.SelectFirst(this.EmailAddresses,
				  delegate(EmailAddress emailAddress) { return emailAddress.IsCurrent; });
			}
		}

		/// <summary>
		/// This method is called from the constructor.  Use this method to implement any custom
		/// object initialization.
		/// </summary>
		private void CustomInitialize()
		{
		}
	}
}