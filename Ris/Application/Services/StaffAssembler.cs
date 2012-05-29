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
using System.Collections.Generic;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Ris.Application.Common;
using System.Collections;

namespace ClearCanvas.Ris.Application.Services
{
	public class StaffAssembler
	{
        public List<Staff> FilterStaffOfClinic(IEnumerable StaffList, Facility Clinic)
        {
            List<Staff> lst=new List<Staff>();
            foreach (Staff s in StaffList)
            {
                foreach (var c in s.Clinics )
                {
                    if (c.Code == Clinic.Code)
                    {
                        lst.Add(s);
                        break;
                    }
                }
            }
            return lst;
        }
		public StaffSummary CreateStaffSummary(Staff staff)
		{
			if (staff == null)
				return null;

			return new StaffSummary(staff.GetRef(), staff.Id,
				EnumUtils.GetEnumValueInfo(staff.Type),
				new PersonNameAssembler().CreatePersonNameDetail(staff.Name),
				staff.Deactivated);
		}

		public StaffDetail CreateStaffDetail(Staff staff, Facility CurrentClinic, IPersistenceContext context)
		{
			PersonNameAssembler assembler = new PersonNameAssembler();
			StaffGroupAssembler groupAssembler = new StaffGroupAssembler();
            FacilityAssembler facilityAssembler = new FacilityAssembler();
			EmailAddressAssembler emailAssembler = new EmailAddressAssembler();
			TelephoneNumberAssembler telephoneAssembler = new TelephoneNumberAssembler();
			AddressAssembler addressAssembler = new AddressAssembler();

			return new StaffDetail(
				staff.GetRef(),
				staff.Id,
				EnumUtils.GetEnumValueInfo(staff.Type ),
				assembler.CreatePersonNameDetail(staff.Name ),
				EnumUtils.GetEnumValueInfo(staff.Sex),
				staff.Title,
				staff.LicenseNumber,
				staff.BillingNumber,
				CollectionUtils.Map<TelephoneNumber, TelephoneDetail>(
					staff.TelephoneNumbers,
					delegate(TelephoneNumber tn) { return telephoneAssembler.CreateTelephoneDetail(tn, context); }),
				CollectionUtils.Map<Address, AddressDetail>(
					staff.Addresses,
					delegate(Address a) { return addressAssembler.CreateAddressDetail(a, context); }),
				CollectionUtils.Map<EmailAddress, EmailAddressDetail>(
					staff.EmailAddresses,
					delegate(EmailAddress ea) { return emailAssembler.CreateEmailAddressDetail(ea, context); }),
				CollectionUtils.Map<StaffGroup, StaffGroupSummary>(
					staff.Groups,
					delegate(StaffGroup group) { return groupAssembler.CreateSummary(group); }),
                CollectionUtils.Map<Facility , FacilitySummary>(
                    staff.Clinics ,
                    delegate(Facility f) { return facilityAssembler.CreateFacilitySummary (f); }),
				new Dictionary<string, string>(staff.ExtendedProperties),
				staff.Deactivated,
                staff.UserName, facilityAssembler.CreateFacilitySummary(CurrentClinic));
		}

		public void UpdateStaff(StaffDetail detail, Staff staff, bool updateElectiveGroups, bool updateNonElectiveGroups, IPersistenceContext context)
		{
			PersonNameAssembler assembler = new PersonNameAssembler();
			EmailAddressAssembler emailAssembler = new EmailAddressAssembler();
			TelephoneNumberAssembler telephoneAssembler = new TelephoneNumberAssembler();
			AddressAssembler addressAssembler = new AddressAssembler();

			staff.Id = detail.StaffId;
			staff.Type = EnumUtils.GetEnumValue<StaffTypeEnum>(detail.StaffType, context);
			assembler.UpdatePersonName(detail.Name, staff.Name);
            staff.Sex = EnumUtils.GetEnumValue<SexEnum>(detail.Sex, context );
			staff.Title = detail.Title;
			staff.LicenseNumber = detail.LicenseNumber;
			staff.BillingNumber = detail.BillingNumber;
			staff.Deactivated = detail.Deactivated;
			staff.UserName = detail.UserName;
            staff.MainClinic = context.Load<Facility>(detail.MainClinic.FacilityRef);
			staff.TelephoneNumbers.Clear();
			if (detail.TelephoneNumbers != null)
			{
				foreach (TelephoneDetail phoneDetail in detail.TelephoneNumbers)
				{
					staff.TelephoneNumbers.Add(telephoneAssembler.CreateTelephoneNumber(phoneDetail,context));
				}
			}

			staff.Addresses.Clear();
			if (detail.Addresses != null)
			{
				foreach (AddressDetail addressDetail in detail.Addresses)
				{
					staff.Addresses.Add(addressAssembler.CreateAddress(addressDetail,context ));
				}
			}

			staff.EmailAddresses.Clear();
			if (detail.EmailAddresses != null)
			{
				foreach (EmailAddressDetail emailAddressDetail in detail.EmailAddresses)
				{
					staff.EmailAddresses.Add(emailAssembler.CreateEmailAddress(emailAddressDetail));
				}
			}

			// explicitly copy each pair, so that we don't remove any properties that the client may have removed
			foreach (KeyValuePair<string, string> pair in detail.ExtendedProperties)
			{
				staff.ExtendedProperties[pair.Key] = pair.Value;
			}

			if (updateElectiveGroups)
			{
				// update elective groups
				UpdateStaffGroups(detail, staff,
					delegate(StaffGroupSummary summary) { return summary.IsElective; },
					delegate(StaffGroup group) { return group.Elective; },
					context);
			}

			if (updateNonElectiveGroups)
			{
				// update non-elective groups
				UpdateStaffGroups(detail, staff,
					delegate(StaffGroupSummary summary) { return !summary.IsElective; },
					delegate(StaffGroup group) { return !group.Elective; },
					context);
			}

            UpdateStaffClinics(detail, staff, delegate(FacilitySummary summary) { return true; }, delegate(Facility f) { return true; }, context);
		}

		private static void UpdateStaffGroups(StaffDetail detail, Staff staff, Predicate<StaffGroupSummary> p1, Predicate<StaffGroup> p2,
			IPersistenceContext context)
		{
			// create a helper to sync staff group membership
			CollectionSynchronizeHelper<StaffGroup, StaffGroupSummary> helper =
				new CollectionSynchronizeHelper<StaffGroup, StaffGroupSummary>(
					delegate(StaffGroup group, StaffGroupSummary summary)
					{
						return group.GetRef().Equals(summary.StaffGroupRef, true);
					},
					delegate(StaffGroupSummary groupSummary, ICollection<StaffGroup> groups)
					{
						StaffGroup group = context.Load<StaffGroup>(groupSummary.StaffGroupRef, EntityLoadFlags.Proxy);
						group.AddMember(staff);
					},
					delegate
					{
						// do nothing
					},
					delegate(StaffGroup group, ICollection<StaffGroup> groups)
					{
						group.RemoveMember(staff);
					}
				);

			helper.Synchronize(
				CollectionUtils.Select(staff.Groups, p2),
				CollectionUtils.Select(detail.Groups, p1));
		}

        private static void UpdateStaffClinics(StaffDetail detail, Staff staff, Predicate<FacilitySummary > p1, Predicate<Facility > p2,
            IPersistenceContext context)
        {
            // create a helper to sync staff group membership
            CollectionSynchronizeHelper<Facility, FacilitySummary> helper =
                new CollectionSynchronizeHelper<Facility, FacilitySummary>(
                    delegate(Facility  f, FacilitySummary fsummary)
                    {
                        return f.GetRef().Equals(fsummary.FacilityRef , true);
                    },
                    delegate(FacilitySummary fSummary, ICollection<Facility > Facilities)
                    {
                        Facility f= context.Load<Facility >(fSummary.FacilityRef , EntityLoadFlags.Proxy);
                        f.AddMember (staff);
                    },
                    delegate
                    {
                        // do nothing
                    },
                    delegate(Facility  f, ICollection<Facility> Facilitiess)
                    {
                        f.RemoveMember(staff);
                    }
                );

            helper.Synchronize(
                CollectionUtils.Select(staff.Clinics , p2),
                CollectionUtils.Select(detail.Clinics , p1));
        }
	}
}
