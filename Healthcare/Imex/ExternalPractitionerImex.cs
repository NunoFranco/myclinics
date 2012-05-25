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
using System.Text;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core.Imex;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Healthcare.Imex
{
    [ExtensionOf(typeof(XmlDataImexExtensionPoint))]
    [ImexDataClass("ExternalPractitioner")]
    public class ExternalPractitionerImex : XmlEntityImex<ExternalPractitioner, ExternalPractitionerImex.ExternalPractitionerData>
    {
        [DataContract]
		public class ExternalPractitionerData : ReferenceEntityDataBase
        {
            [DataMember]
            public string FamilyName;

            [DataMember]
            public string GivenName;

            [DataMember]
            public string MiddleName;

            [DataMember]
            public string LicenseNumber;

            [DataMember]
            public string BillingNumber;

            [DataMember]
            public List<ExternalPractitionerContactPointData> ContactPoints;

            [DataMember]
            public Dictionary<string, string> ExtendedProperties;

            [DataMember]
            public ClinicData Clinic;
        }

        [DataContract]
        public class ExternalPractitionerContactPointData
        {
            [DataMember]
            public string Name;

            [DataMember]
            public string Description;

            [DataMember]
            public string PreferredResultCommunicationMode;

            [DataMember]
            public bool IsDefaultContactPoint;

            [DataMember]
            public List<TelephoneNumberData> TelephoneNumbers;

            [DataMember]
            public List<AddressData> Addresses;

            [DataMember]
            public List<EmailAddressData> EmailAddresses;

            [DataMember]
            public object ClinicOID;
        }

        #region Overrides

        protected override IList<ExternalPractitioner> GetItemsForExport(IReadContext context, int firstRow, int maxRows)
        {
            ExternalPractitionerSearchCriteria where = new ExternalPractitionerSearchCriteria();
            where.Name.FamilyName.SortAsc(0);
            where.Name.GivenName.SortAsc(1);
            where.Name.MiddleName.SortAsc(2);
            where.LicenseNumber.SortAsc(3);
            where.BillingNumber.SortAsc(4);

            return context.GetBroker<IExternalPractitionerBroker>().Find(where, new SearchResultPage(firstRow, maxRows));
        }

        protected override ExternalPractitionerData Export(ExternalPractitioner entity, IReadContext context)
        {
            ExternalPractitionerData data = new ExternalPractitionerData();
			data.Deactivated = entity.Deactivated;
			data.FamilyName = entity.Name.FamilyName;
            data.GivenName = entity.Name.GivenName;
            data.MiddleName = entity.Name.MiddleName;
            data.LicenseNumber = entity.LicenseNumber;
            data.BillingNumber = entity.BillingNumber;
            data.Clinic = new ClinicData(entity.Clinic);
            data.ContactPoints =
                CollectionUtils.Map<ExternalPractitionerContactPoint, ExternalPractitionerContactPointData>(
                    entity.ContactPoints,
                    delegate(ExternalPractitionerContactPoint cp)
                    {
                        ExternalPractitionerContactPointData cpData = new ExternalPractitionerContactPointData();
                        cpData.Name = cp.Name;
                        cpData.IsDefaultContactPoint = cp.IsDefaultContactPoint;
                        cpData.PreferredResultCommunicationMode = cp.PreferredResultCommunicationMode.ToString();
                        cpData.Description = cp.Description;
                        cpData.Addresses = CollectionUtils.Map<Address, AddressData>(cp.Addresses,
                            delegate(Address a) { return new AddressData(a); });
                        cpData.TelephoneNumbers = CollectionUtils.Map<TelephoneNumber, TelephoneNumberData>(cp.TelephoneNumbers,
                            delegate(TelephoneNumber tn) { return new TelephoneNumberData(tn); });
                        cpData.EmailAddresses = CollectionUtils.Map<EmailAddress, EmailAddressData>(cp.EmailAddresses,
                            delegate(EmailAddress a) { return new EmailAddressData(a); });
                        cpData.ClinicOID = entity.Clinic.OID;
                        return cpData;
                    });

            data.ExtendedProperties = new Dictionary<string, string>(entity.ExtendedProperties);
            data.Clinic = new ClinicData(entity.Clinic);
            return data;
        }

        protected override void Import(ExternalPractitionerData data, string clinicCode, IUpdateContext context)
        {
            Facility CurrentClinic = Common.GetClinic(clinicCode, context );
            ExternalPractitioner prac = LoadOrCreateExternalPractitioner(
                data.LicenseNumber,
                data.BillingNumber,CurrentClinic ,
                new PersonName(data.FamilyName, data.GivenName, data.MiddleName, null, null, null),
                context);

			prac.Deactivated = data.Deactivated;
			if (data.ContactPoints != null)
            {
                foreach (ExternalPractitionerContactPointData cpData in data.ContactPoints)
                {
                    ExternalPractitionerContactPoint cp = CollectionUtils.SelectFirst(prac.ContactPoints,
                        delegate (ExternalPractitionerContactPoint p) { return p.Name == cpData.Name; });
                    if(cp == null)
                        cp = new ExternalPractitionerContactPoint(prac);

                    UpdateExternalPractitionerContactPoint(cpData, cp);
                }
            }

            if (data.ExtendedProperties != null)
            {
                foreach (KeyValuePair<string, string> kvp in data.ExtendedProperties)
                {
                    prac.ExtendedProperties[kvp.Key] = kvp.Value;
                }
            }
        }

        #endregion

        private void UpdateExternalPractitionerContactPoint(ExternalPractitionerContactPointData data, ExternalPractitionerContactPoint cp)
        {
            cp.Name = data.Name;
            cp.Description = data.Description;
            cp.IsDefaultContactPoint = data.IsDefaultContactPoint;
            cp.PreferredResultCommunicationMode = Common.ConvertSystemEnumTohbmEnum < ResultCommunicationModeEnum >(data.PreferredResultCommunicationMode, data.ClinicOID  );

            if (data.TelephoneNumbers != null)
            {
               cp.TelephoneNumbers.Clear();
               foreach (TelephoneNumberData phoneDetail in data.TelephoneNumbers)
               {
                   cp.TelephoneNumbers.Add(phoneDetail.CreateTelephoneNumber(data.ClinicOID));
               }
            }

            if (data.Addresses != null)
            {
               cp.Addresses.Clear();
               foreach (AddressData addressDetail in data.Addresses)
               {
                   cp.Addresses.Add(addressDetail.CreateAddress(data.ClinicOID));
               }
            }

            if (data.EmailAddresses != null)
            {
               cp.EmailAddresses.Clear();
               foreach (EmailAddressData addressDetail in data.EmailAddresses)
               {
                   cp.EmailAddresses.Add(addressDetail.CreateEmailAddress());
               }
            }
        }

        private ExternalPractitioner LoadOrCreateExternalPractitioner(string license, string billingNumber, Facility clinic, PersonName name, IPersistenceContext context)
        {
            ExternalPractitioner prac = null;

            // if either license or billing number are supplied, check for an existing practitioner
            if (!string.IsNullOrEmpty(license) || !string.IsNullOrEmpty(billingNumber))
            {
                ExternalPractitionerSearchCriteria criteria = new ExternalPractitionerSearchCriteria();
                if(!string.IsNullOrEmpty(license))
                    criteria.LicenseNumber.EqualTo(license);
                if (!string.IsNullOrEmpty(billingNumber))
                    criteria.BillingNumber.EqualTo(billingNumber);
                if (clinic != null)
                {
                    criteria.Clinic.EqualTo(clinic);
                }

                IExternalPractitionerBroker broker = context.GetBroker<IExternalPractitionerBroker>();
                prac = CollectionUtils.FirstElement(broker.Find(criteria));
            }

            if(prac == null)
            {
                // create it
                prac = new ExternalPractitioner();
                prac.Name = name;
                prac.LicenseNumber = license;
                prac.BillingNumber = billingNumber;
                prac.Clinic = clinic;
                context.Lock(prac, DirtyState.New);
            }

            return prac;
        }
    }
}
