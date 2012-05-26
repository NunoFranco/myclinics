using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Visit : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _visitNumberId = String.Empty;
		private System.DateTime? _admitTime = null;
		private System.DateTime? _dischargeTime = null;
		private string _dischargeDisposition = null;
		private bool _vipIndicator = default(Boolean);
		private string _preadmitNumber = null;
		
		private AdmissionTypeEnum _admissionTypeEnum = null;
		private Location _location = null;
		private Facility _facility = null;
		private PatientClassEnum _patientClassEnum = null;
		private Patient _patient = null;
		private PatientTypeEnum _patientTypeEnum = null;
		private VisitStatusEnum _visitStatusEnum = null;
		private InformationAuthorityEnum _informationAuthorityEnum = null;
		
		private IList<Order> _orders = new List<Order>();
		private IList<VisitLocation> _visitLocations = new List<VisitLocation>();
		private IList<VisitPractitioner> _visitPractitioners = new List<VisitPractitioner>();
		
		#endregion

        #region Constructors

        public Visit() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_visitNumberId);
			sb.Append(_admitTime);
			sb.Append(_dischargeTime);
			sb.Append(_dischargeDisposition);
			sb.Append(_vipIndicator);
			sb.Append(_preadmitNumber);

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
		
		public virtual string VisitNumberId
        {
            get { return _visitNumberId; }
			set
			{
				OnVisitNumberIdChanging();
				_visitNumberId = value;
				OnVisitNumberIdChanged();
			}
        }
		partial void OnVisitNumberIdChanging();
		partial void OnVisitNumberIdChanged();
		
		public virtual System.DateTime? AdmitTime
        {
            get { return _admitTime; }
			set
			{
				OnAdmitTimeChanging();
				_admitTime = value;
				OnAdmitTimeChanged();
			}
        }
		partial void OnAdmitTimeChanging();
		partial void OnAdmitTimeChanged();
		
		public virtual System.DateTime? DischargeTime
        {
            get { return _dischargeTime; }
			set
			{
				OnDischargeTimeChanging();
				_dischargeTime = value;
				OnDischargeTimeChanged();
			}
        }
		partial void OnDischargeTimeChanging();
		partial void OnDischargeTimeChanged();
		
		public virtual string DischargeDisposition
        {
            get { return _dischargeDisposition; }
			set
			{
				OnDischargeDispositionChanging();
				_dischargeDisposition = value;
				OnDischargeDispositionChanged();
			}
        }
		partial void OnDischargeDispositionChanging();
		partial void OnDischargeDispositionChanged();
		
		public virtual bool VipIndicator
        {
            get { return _vipIndicator; }
			set
			{
				OnVipIndicatorChanging();
				_vipIndicator = value;
				OnVipIndicatorChanged();
			}
        }
		partial void OnVipIndicatorChanging();
		partial void OnVipIndicatorChanged();
		
		public virtual string PreadmitNumber
        {
            get { return _preadmitNumber; }
			set
			{
				OnPreadmitNumberChanging();
				_preadmitNumber = value;
				OnPreadmitNumberChanged();
			}
        }
		partial void OnPreadmitNumberChanging();
		partial void OnPreadmitNumberChanged();
		
		public virtual AdmissionTypeEnum AdmissionTypeEnum
        {
            get { return _admissionTypeEnum; }
			set
			{
				OnAdmissionTypeEnumChanging();
				_admissionTypeEnum = value;
				OnAdmissionTypeEnumChanged();
			}
        }
		partial void OnAdmissionTypeEnumChanging();
		partial void OnAdmissionTypeEnumChanged();
		
		public virtual Location Location
        {
            get { return _location; }
			set
			{
				OnLocationChanging();
				_location = value;
				OnLocationChanged();
			}
        }
		partial void OnLocationChanging();
		partial void OnLocationChanged();
		
		public virtual Facility Facility
        {
            get { return _facility; }
			set
			{
				OnFacilityChanging();
				_facility = value;
				OnFacilityChanged();
			}
        }
		partial void OnFacilityChanging();
		partial void OnFacilityChanged();
		
		public virtual PatientClassEnum PatientClassEnum
        {
            get { return _patientClassEnum; }
			set
			{
				OnPatientClassEnumChanging();
				_patientClassEnum = value;
				OnPatientClassEnumChanged();
			}
        }
		partial void OnPatientClassEnumChanging();
		partial void OnPatientClassEnumChanged();
		
		public virtual Patient Patient
        {
            get { return _patient; }
			set
			{
				OnPatientChanging();
				_patient = value;
				OnPatientChanged();
			}
        }
		partial void OnPatientChanging();
		partial void OnPatientChanged();
		
		public virtual PatientTypeEnum PatientTypeEnum
        {
            get { return _patientTypeEnum; }
			set
			{
				OnPatientTypeEnumChanging();
				_patientTypeEnum = value;
				OnPatientTypeEnumChanged();
			}
        }
		partial void OnPatientTypeEnumChanging();
		partial void OnPatientTypeEnumChanged();
		
		public virtual VisitStatusEnum VisitStatusEnum
        {
            get { return _visitStatusEnum; }
			set
			{
				OnVisitStatusEnumChanging();
				_visitStatusEnum = value;
				OnVisitStatusEnumChanged();
			}
        }
		partial void OnVisitStatusEnumChanging();
		partial void OnVisitStatusEnumChanged();
		
		public virtual InformationAuthorityEnum InformationAuthorityEnum
        {
            get { return _informationAuthorityEnum; }
			set
			{
				OnInformationAuthorityEnumChanging();
				_informationAuthorityEnum = value;
				OnInformationAuthorityEnumChanged();
			}
        }
		partial void OnInformationAuthorityEnumChanging();
		partial void OnInformationAuthorityEnumChanged();
		
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
		
		public virtual IList<VisitLocation> VisitLocations
        {
            get { return _visitLocations; }
            set
			{
				OnVisitLocationsChanging();
				_visitLocations = value;
				OnVisitLocationsChanged();
			}
        }
		partial void OnVisitLocationsChanging();
		partial void OnVisitLocationsChanged();
		
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
		
        #endregion
    }
}
