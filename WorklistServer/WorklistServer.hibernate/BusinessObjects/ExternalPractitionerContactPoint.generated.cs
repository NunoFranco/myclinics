using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ExternalPractitionerContactPoint : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _name = String.Empty;
		private string _description = null;
		private bool _isDefaultContactPoint = default(Boolean);
		private bool _deactivated = default(Boolean);
		
		private ExternalPractitioner _externalPractitioner = null;
		private ResultCommunicationModeEnum _resultCommunicationModeEnum = null;
		
		private IList<ExternalPractitionerContactPointEmailAddress> _externalPractitionerContactPointEmailAddresses = new List<ExternalPractitionerContactPointEmailAddress>();
		private IList<ExternalPractitionerContactPointTelephoneNumber> _externalPractitionerContactPointTelephoneNumbers = new List<ExternalPractitionerContactPointTelephoneNumber>();
		private IList<ExternalPractitionerContactPointAddress> _externalPractitionerContactPointAddresses = new List<ExternalPractitionerContactPointAddress>();
		private IList<OrderResultRecipient> _orderResultRecipients = new List<OrderResultRecipient>();
		
		#endregion

        #region Constructors

        public ExternalPractitionerContactPoint() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_name);
			sb.Append(_description);
			sb.Append(_isDefaultContactPoint);
			sb.Append(_deactivated);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual int Version
        {
            get { return _version; }
			set
			{
				OnVersionChanging();
				_version = value;
				OnVersionChanged();
			}
        }
		partial void OnVersionChanging();
		partial void OnVersionChanged();
		
		public virtual string Name
        {
            get { return _name; }
			set
			{
				OnNameChanging();
				_name = value;
				OnNameChanged();
			}
        }
		partial void OnNameChanging();
		partial void OnNameChanged();
		
		public virtual string Description
        {
            get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				OnDescriptionChanged();
			}
        }
		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		
		public virtual bool IsDefaultContactPoint
        {
            get { return _isDefaultContactPoint; }
			set
			{
				OnIsDefaultContactPointChanging();
				_isDefaultContactPoint = value;
				OnIsDefaultContactPointChanged();
			}
        }
		partial void OnIsDefaultContactPointChanging();
		partial void OnIsDefaultContactPointChanged();
		
		public virtual bool Deactivated
        {
            get { return _deactivated; }
			set
			{
				OnDeactivatedChanging();
				_deactivated = value;
				OnDeactivatedChanged();
			}
        }
		partial void OnDeactivatedChanging();
		partial void OnDeactivatedChanged();
		
		public virtual ExternalPractitioner ExternalPractitioner
        {
            get { return _externalPractitioner; }
			set
			{
				OnExternalPractitionerChanging();
				_externalPractitioner = value;
				OnExternalPractitionerChanged();
			}
        }
		partial void OnExternalPractitionerChanging();
		partial void OnExternalPractitionerChanged();
		
		public virtual ResultCommunicationModeEnum ResultCommunicationModeEnum
        {
            get { return _resultCommunicationModeEnum; }
			set
			{
				OnResultCommunicationModeEnumChanging();
				_resultCommunicationModeEnum = value;
				OnResultCommunicationModeEnumChanged();
			}
        }
		partial void OnResultCommunicationModeEnumChanging();
		partial void OnResultCommunicationModeEnumChanged();
		
		public virtual IList<ExternalPractitionerContactPointEmailAddress> ExternalPractitionerContactPointEmailAddresses
        {
            get { return _externalPractitionerContactPointEmailAddresses; }
            set
			{
				OnExternalPractitionerContactPointEmailAddressesChanging();
				_externalPractitionerContactPointEmailAddresses = value;
				OnExternalPractitionerContactPointEmailAddressesChanged();
			}
        }
		partial void OnExternalPractitionerContactPointEmailAddressesChanging();
		partial void OnExternalPractitionerContactPointEmailAddressesChanged();
		
		public virtual IList<ExternalPractitionerContactPointTelephoneNumber> ExternalPractitionerContactPointTelephoneNumbers
        {
            get { return _externalPractitionerContactPointTelephoneNumbers; }
            set
			{
				OnExternalPractitionerContactPointTelephoneNumbersChanging();
				_externalPractitionerContactPointTelephoneNumbers = value;
				OnExternalPractitionerContactPointTelephoneNumbersChanged();
			}
        }
		partial void OnExternalPractitionerContactPointTelephoneNumbersChanging();
		partial void OnExternalPractitionerContactPointTelephoneNumbersChanged();
		
		public virtual IList<ExternalPractitionerContactPointAddress> ExternalPractitionerContactPointAddresses
        {
            get { return _externalPractitionerContactPointAddresses; }
            set
			{
				OnExternalPractitionerContactPointAddressesChanging();
				_externalPractitionerContactPointAddresses = value;
				OnExternalPractitionerContactPointAddressesChanged();
			}
        }
		partial void OnExternalPractitionerContactPointAddressesChanging();
		partial void OnExternalPractitionerContactPointAddressesChanged();
		
		public virtual IList<OrderResultRecipient> OrderResultRecipients
        {
            get { return _orderResultRecipients; }
            set
			{
				OnOrderResultRecipientsChanging();
				_orderResultRecipients = value;
				OnOrderResultRecipientsChanged();
			}
        }
		partial void OnOrderResultRecipientsChanging();
		partial void OnOrderResultRecipientsChanged();
		
        #endregion
    }
}
