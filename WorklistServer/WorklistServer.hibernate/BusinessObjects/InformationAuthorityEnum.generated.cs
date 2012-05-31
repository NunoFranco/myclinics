using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class InformationAuthorityEnum : BusinessBase<string>
    {
        #region Declarations

		private string _value = null;
		private string _description = null;
		private float? _displayOrder = null;
		private bool _deactivated = default(Boolean);
		
		
		private IList<Facility> _facilities = new List<Facility>();
		private IList<PatientProfileExpiredMrn> _patientProfileExpiredMrns = new List<PatientProfileExpiredMrn>();
		private IList<PatientProfile> _patientProfiles = new List<PatientProfile>();
		private IList<Visit> _visits = new List<Visit>();
		
		#endregion

        #region Constructors

        public InformationAuthorityEnum() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_value);
			sb.Append(_description);
			sb.Append(_displayOrder);
			sb.Append(_deactivated);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string Value
        {
            get { return _value; }
			set
			{
				OnValueChanging();
				_value = value;
				OnValueChanged();
			}
        }
		partial void OnValueChanging();
		partial void OnValueChanged();
		
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
		
		public virtual float? DisplayOrder
        {
            get { return _displayOrder; }
			set
			{
				OnDisplayOrderChanging();
				_displayOrder = value;
				OnDisplayOrderChanged();
			}
        }
		partial void OnDisplayOrderChanging();
		partial void OnDisplayOrderChanged();
		
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
		
		public virtual IList<Facility> Facilities
        {
            get { return _facilities; }
            set
			{
				OnFacilitiesChanging();
				_facilities = value;
				OnFacilitiesChanged();
			}
        }
		partial void OnFacilitiesChanging();
		partial void OnFacilitiesChanged();
		
		public virtual IList<PatientProfileExpiredMrn> PatientProfileExpiredMrns
        {
            get { return _patientProfileExpiredMrns; }
            set
			{
				OnPatientProfileExpiredMrnsChanging();
				_patientProfileExpiredMrns = value;
				OnPatientProfileExpiredMrnsChanged();
			}
        }
		partial void OnPatientProfileExpiredMrnsChanging();
		partial void OnPatientProfileExpiredMrnsChanged();
		
		public virtual IList<PatientProfile> PatientProfiles
        {
            get { return _patientProfiles; }
            set
			{
				OnPatientProfilesChanging();
				_patientProfiles = value;
				OnPatientProfilesChanged();
			}
        }
		partial void OnPatientProfilesChanging();
		partial void OnPatientProfilesChanged();
		
		public virtual IList<Visit> Visits
        {
            get { return _visits; }
            set
			{
				OnVisitsChanging();
				_visits = value;
				OnVisitsChanged();
			}
        }
		partial void OnVisitsChanging();
		partial void OnVisitsChanged();
		
        #endregion
    }
}