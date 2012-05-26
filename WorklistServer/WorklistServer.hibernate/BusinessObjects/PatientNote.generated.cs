using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class PatientNote : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private System.DateTime _creationTime = new DateTime();
		private string _comment = null;
		private System.DateTime? _validFrom = null;
		private System.DateTime? _validUntil = null;
		
		private Staff _staff = null;
		private PatientNoteCategory _patientNoteCategory = null;
		private Patient _patient = null;
		
		
		#endregion

        #region Constructors

        public PatientNote() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_creationTime);
			sb.Append(_comment);
			sb.Append(_validFrom);
			sb.Append(_validUntil);

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
		
		public virtual System.DateTime CreationTime
        {
            get { return _creationTime; }
			set
			{
				OnCreationTimeChanging();
				_creationTime = value;
				OnCreationTimeChanged();
			}
        }
		partial void OnCreationTimeChanging();
		partial void OnCreationTimeChanged();
		
		public virtual string Comment
        {
            get { return _comment; }
			set
			{
				OnCommentChanging();
				_comment = value;
				OnCommentChanged();
			}
        }
		partial void OnCommentChanging();
		partial void OnCommentChanged();
		
		public virtual System.DateTime? ValidFrom
        {
            get { return _validFrom; }
			set
			{
				OnValidFromChanging();
				_validFrom = value;
				OnValidFromChanged();
			}
        }
		partial void OnValidFromChanging();
		partial void OnValidFromChanged();
		
		public virtual System.DateTime? ValidUntil
        {
            get { return _validUntil; }
			set
			{
				OnValidUntilChanging();
				_validUntil = value;
				OnValidUntilChanged();
			}
        }
		partial void OnValidUntilChanging();
		partial void OnValidUntilChanged();
		
		public virtual Staff Staff
        {
            get { return _staff; }
			set
			{
				OnStaffChanging();
				_staff = value;
				OnStaffChanged();
			}
        }
		partial void OnStaffChanging();
		partial void OnStaffChanged();
		
		public virtual PatientNoteCategory PatientNoteCategory
        {
            get { return _patientNoteCategory; }
			set
			{
				OnPatientNoteCategoryChanging();
				_patientNoteCategory = value;
				OnPatientNoteCategoryChanged();
			}
        }
		partial void OnPatientNoteCategoryChanging();
		partial void OnPatientNoteCategoryChanged();
		
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
		
        #endregion
    }
}
