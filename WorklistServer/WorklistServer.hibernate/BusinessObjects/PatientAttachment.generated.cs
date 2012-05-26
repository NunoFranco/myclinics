using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class PatientAttachment : BusinessBase<System.Guid>
    {
        #region Declarations

		private System.DateTime _attachedTime = new DateTime();
		
		private Staff _staff = null;
		private AttachedDocument _attachedDocument = null;
		private PatientAttachmentCategoryEnum _patientAttachmentCategoryEnum = null;
		private Patient _patient = null;
		
		
		#endregion

        #region Constructors

        public PatientAttachment() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_attachedTime);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual System.DateTime AttachedTime
        {
            get { return _attachedTime; }
			set
			{
				OnAttachedTimeChanging();
				_attachedTime = value;
				OnAttachedTimeChanged();
			}
        }
		partial void OnAttachedTimeChanging();
		partial void OnAttachedTimeChanged();
		
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
		
		public virtual AttachedDocument AttachedDocument
        {
            get { return _attachedDocument; }
			set
			{
				OnAttachedDocumentChanging();
				_attachedDocument = value;
				OnAttachedDocumentChanged();
			}
        }
		partial void OnAttachedDocumentChanging();
		partial void OnAttachedDocumentChanged();
		
		public virtual PatientAttachmentCategoryEnum PatientAttachmentCategoryEnum
        {
            get { return _patientAttachmentCategoryEnum; }
			set
			{
				OnPatientAttachmentCategoryEnumChanging();
				_patientAttachmentCategoryEnum = value;
				OnPatientAttachmentCategoryEnumChanged();
			}
        }
		partial void OnPatientAttachmentCategoryEnumChanging();
		partial void OnPatientAttachmentCategoryEnumChanged();
		
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
