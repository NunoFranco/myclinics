using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Patient : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		
		
		private IList<Order> _orders = new List<Order>();
		private IList<PatientProfile> _patientProfiles = new List<PatientProfile>();
		private IList<PatientNote> _patientNotes = new List<PatientNote>();
		private IList<PatientAttachment> _patientAttachments = new List<PatientAttachment>();
		private IList<Visit> _visits = new List<Visit>();
		
		#endregion

        #region Constructors

        public Patient() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);

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
		
		public virtual IList<PatientNote> PatientNotes
        {
            get { return _patientNotes; }
            set
			{
				OnPatientNotesChanging();
				_patientNotes = value;
				OnPatientNotesChanged();
			}
        }
		partial void OnPatientNotesChanging();
		partial void OnPatientNotesChanged();
		
		public virtual IList<PatientAttachment> PatientAttachments
        {
            get { return _patientAttachments; }
            set
			{
				OnPatientAttachmentsChanging();
				_patientAttachments = value;
				OnPatientAttachmentsChanged();
			}
        }
		partial void OnPatientAttachmentsChanging();
		partial void OnPatientAttachmentsChanged();
		
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
