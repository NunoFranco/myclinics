using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ExternalPractitioner : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _familyName = String.Empty;
		private string _givenName = String.Empty;
		private string _middleName = null;
		private string _prefix = null;
		private string _suffix = null;
		private string _degree = null;
		private string _licenseNumber = null;
		private string _billingNumber = null;
		private bool _deactivated = default(Boolean);
		
		
		private IList<Order> _orders = new List<Order>();
		private IList<VisitPractitioner> _visitPractitioners = new List<VisitPractitioner>();
		private IList<ExternalPractitionerContactPoint> _externalPractitionerContactPoints = new List<ExternalPractitionerContactPoint>();
		
		#endregion

        #region Constructors

        public ExternalPractitioner() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_familyName);
			sb.Append(_givenName);
			sb.Append(_middleName);
			sb.Append(_prefix);
			sb.Append(_suffix);
			sb.Append(_degree);
			sb.Append(_licenseNumber);
			sb.Append(_billingNumber);
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
		
		public virtual string FamilyName
        {
            get { return _familyName; }
			set
			{
				OnFamilyNameChanging();
				_familyName = value;
				OnFamilyNameChanged();
			}
        }
		partial void OnFamilyNameChanging();
		partial void OnFamilyNameChanged();
		
		public virtual string GivenName
        {
            get { return _givenName; }
			set
			{
				OnGivenNameChanging();
				_givenName = value;
				OnGivenNameChanged();
			}
        }
		partial void OnGivenNameChanging();
		partial void OnGivenNameChanged();
		
		public virtual string MiddleName
        {
            get { return _middleName; }
			set
			{
				OnMiddleNameChanging();
				_middleName = value;
				OnMiddleNameChanged();
			}
        }
		partial void OnMiddleNameChanging();
		partial void OnMiddleNameChanged();
		
		public virtual string Prefix
        {
            get { return _prefix; }
			set
			{
				OnPrefixChanging();
				_prefix = value;
				OnPrefixChanged();
			}
        }
		partial void OnPrefixChanging();
		partial void OnPrefixChanged();
		
		public virtual string Suffix
        {
            get { return _suffix; }
			set
			{
				OnSuffixChanging();
				_suffix = value;
				OnSuffixChanged();
			}
        }
		partial void OnSuffixChanging();
		partial void OnSuffixChanged();
		
		public virtual string Degree
        {
            get { return _degree; }
			set
			{
				OnDegreeChanging();
				_degree = value;
				OnDegreeChanged();
			}
        }
		partial void OnDegreeChanging();
		partial void OnDegreeChanged();
		
		public virtual string LicenseNumber
        {
            get { return _licenseNumber; }
			set
			{
				OnLicenseNumberChanging();
				_licenseNumber = value;
				OnLicenseNumberChanged();
			}
        }
		partial void OnLicenseNumberChanging();
		partial void OnLicenseNumberChanged();
		
		public virtual string BillingNumber
        {
            get { return _billingNumber; }
			set
			{
				OnBillingNumberChanging();
				_billingNumber = value;
				OnBillingNumberChanged();
			}
        }
		partial void OnBillingNumberChanging();
		partial void OnBillingNumberChanged();
		
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
		
		public virtual IList<Order> Orders
        {
            get { return _orders; }
            set
			{
				OnOrdersChanging();
				_orders = value;
				OnOrdersChanged();
			}
        }
		partial void OnOrdersChanging();
		partial void OnOrdersChanged();
		
		public virtual IList<VisitPractitioner> VisitPractitioners
        {
            get { return _visitPractitioners; }
            set
			{
				OnVisitPractitionersChanging();
				_visitPractitioners = value;
				OnVisitPractitionersChanged();
			}
        }
		partial void OnVisitPractitionersChanging();
		partial void OnVisitPractitionersChanged();
		
		public virtual IList<ExternalPractitionerContactPoint> ExternalPractitionerContactPoints
        {
            get { return _externalPractitionerContactPoints; }
            set
			{
				OnExternalPractitionerContactPointsChanging();
				_externalPractitionerContactPoints = value;
				OnExternalPractitionerContactPointsChanged();
			}
        }
		partial void OnExternalPractitionerContactPointsChanging();
		partial void OnExternalPractitionerContactPointsChanged();
		
        #endregion
    }
}
