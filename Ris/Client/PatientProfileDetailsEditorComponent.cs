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
using System.Globalization;

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Client
{
    [ExtensionPoint]
    public class PatientEditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    [AssociateView(typeof(PatientEditorComponentViewExtensionPoint))]
    public class PatientProfileDetailsEditorComponent : ApplicationComponent
    {
        private PatientProfileDetail _profile;
        private readonly List<EnumValueInfo> _sexChoices;

        private string _dateOfBirth;
        private readonly List<EnumValueInfo> _mrnAuthorityChoices;
        private readonly List<EnumValueInfo> _healthcardAuthorityChoices;

        public PatientProfileDetailsEditorComponent(List<EnumValueInfo> sexChoices, List<EnumValueInfo> mrnAuthorityChoices, List<EnumValueInfo> healthcardAuthorityChoices, List<EnumValueInfo> discountchoices, List<EnumValueInfo> insurancechoices)
        {
            _sexChoices = sexChoices;
            _mrnAuthorityChoices = mrnAuthorityChoices;
            _healthcardAuthorityChoices = healthcardAuthorityChoices;

            ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType none = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE;
            DiscountChoices = discountchoices;
            InsunranceChoices = insurancechoices;
            InsunranceChoices.Insert(0, new EnumValueInfo(none.ToString(), "", LoginSession.Current.WorkingFacility.OID ));
            DiscountChoices.Insert(0, new EnumValueInfo(none.ToString(), "", LoginSession.Current.WorkingFacility.OID ));
        }

        /// <summary>
        /// Gets or sets the subject (e.g PatientProfileDetail) that this editor operates on.  This property
        /// should never be used by the view.
        /// </summary>
        public PatientProfileDetail Subject
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
                _dateOfBirth = _profile.DateOfBirth == null ? null : _profile.DateOfBirth.Value.ToString(this.DateOfBirthFormat);
            }
        }
        public ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType SelectedDiscountInsuranceType { get; set; }
        public void SetModified(bool value)
        {
            this.Modified = value;
        }
        public override void Start()
        {
            this.Validation.Add(new ValidationRule("TimeOfDeath",
                delegate
                {
                    // only need to validate the if Date of Birth and Time of Death are specified
                    if (!_profile.DateOfBirth.HasValue || !_profile.TimeOfDeath.HasValue)
                        return new ValidationResult(true, "");

                    var ok = DateTime.Compare(_profile.TimeOfDeath.Value, _profile.DateOfBirth.Value) >= 0;
                    return new ValidationResult(ok, SR.MessageDateOfDeathMustBeLaterThanOrEqualToDateOfBirth);
                }));
            if (string.IsNullOrEmpty(MrnID ))
            {
                MrnID = CommonFunctions.GetUniqueMrnID();
            }
            //if (_profile.DiscountType != null)
            //{
            //SelectedDiscountInsuranceType = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.DISCOUNT;
            //}
            //else if (_profile.InsuranceType != null)
            //{
            //SelectedDiscountInsuranceType = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.INSURANCE;
            //}
            //else
            //{
            //    SelectedDiscountInsuranceType = ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE;               
            //}
            base.Start();
        }

        #region Presentation Model

        [ValidateNotNull]
        public string MrnID
        {
            get { return _profile.Mrn.Id; }
            set
            {
                _profile.Mrn.Id = value;
                this.Modified = true;
            }
        }

        [ValidateNotNull]
        public EnumValueInfo MrnAuthority
        {
            get { return _profile.Mrn.AssigningAuthority; }
            set
            {
                _profile.Mrn.AssigningAuthority = value;
                this.Modified = true;
            }
        }

        [ValidateNotNull]
        public string FamilyName
        {
            get { return _profile.Name.FamilyName; }
            set
            {
                _profile.Name.FamilyName = value;
                this.Modified = true;
            }
        }

        [ValidateNotNull]
        public string GivenName
        {
            get { return _profile.Name.GivenName; }
            set
            {
                _profile.Name.GivenName = value;
                this.Modified = true;
            }
        }

        public string MiddleName
        {
            get { return _profile.Name.MiddleName; }
            set
            {
                _profile.Name.MiddleName = value;
                this.Modified = true;
            }
        }

        [ValidateNotNull]
        public EnumValueInfo Sex
        {
            get { return _profile.Sex; }
            set
            {
                _profile.Sex = value;
                this.Modified = true;
            }
        }

        public IList SexChoices
        {
            get { return _sexChoices; }
        }

        public string DateOfBirthMask
        {
            get { return "0000-00-00"; }
        }

        public string DateOfBirthFormat
        {
            get { return "yyyyMMdd"; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                this.Modified = true;

                if (string.IsNullOrEmpty(_dateOfBirth) || _dateOfBirth == this.DateOfBirthMask)
                    _profile.DateOfBirth = null;
                else
                {
                    DateTime dt;
                    if (!DateTime.TryParseExact(_dateOfBirth, this.DateOfBirthFormat, null, DateTimeStyles.None, out dt))
                        throw new Exception(SR.MessageInvalidDateFormat);
                    _profile.DateOfBirth = dt;
                }
            }
        }

        public bool DeathIndicator
        {
            get { return _profile.DeathIndicator; }
            set
            {
                _profile.DeathIndicator = value;
                this.Modified = true;
            }
        }

        public DateTime? TimeOfDeath
        {
            get { return _profile.TimeOfDeath; }
            set
            {
                _profile.TimeOfDeath = value;
                _profile.DeathIndicator = (_profile.TimeOfDeath == null ? false : true);
                this.Modified = true;
            }
        }

        public IList MrnAuthorityChoices
        {
            get { return _mrnAuthorityChoices; }
        }
        public IList DiscountChoices { get; set; }
        public IList InsunranceChoices { get; set; }
        EnumValueInfo nullDiscountInsurance = new EnumValueInfo(ClearCanvas.Ris.Application.Common.Billing.DiscountInsuranceClassType.NONE.ToString(), "", LoginSession.Current.WorkingFacility.OID );

        public object SelectedDiscount
        {
            get
            {
                if (_profile.DiscountType == null)
                    return nullDiscountInsurance;
                return _profile.DiscountType;
            }
            set
            {
                _profile.DiscountType = value as EnumValueInfo;
                if (_profile.DiscountType.Value == "")
                    _profile.DiscountType = null;
                this.Modified = true;
            }
        }
        public object SelectedInsurnce
        {
            get
            {
                if (_profile.InsuranceType == null)
                    return nullDiscountInsurance;
                return _profile.InsuranceType;
            }
            set
            {
                _profile.InsuranceType = value as EnumValueInfo;
                if (_profile.InsuranceType.Value == "")
                    _profile.InsuranceType = null;
                this.Modified = true;
            }
        }


        public string HealthcardID
        {
            get { return _profile.Healthcard.Id; }
            set
            {
                _profile.Healthcard.Id = value;
                this.Modified = true;
            }
        }

        public string HealthcardMask
        {
            get { return TextFieldMasks.HealthcardNumberMask; }
        }

        public EnumValueInfo HealthcardAuthority
        {
            get { return _profile.Healthcard.AssigningAuthority; }
            set
            {
                _profile.Healthcard.AssigningAuthority = value;
                this.Modified = true;
            }
        }

        public IList HealthcardAuthorityChoices
        {
            get { return _healthcardAuthorityChoices; }
        }

        public string HealthcardVersionCode
        {
            get { return _profile.Healthcard.VersionCode; }
            set
            {
                _profile.Healthcard.VersionCode = value;
                this.Modified = true;
            }
        }

        public string HealthcardVersionCodeMask
        {
            get { return TextFieldMasks.HealthcardVersionCodeMask; }
        }

        public DateTime? HealthcardExpiryDate
        {
            get { return _profile.Healthcard.ExpiryDate; }
            set
            {
                _profile.Healthcard.ExpiryDate = value;
                this.Modified = true;
            }
        }

        #endregion
    }
}