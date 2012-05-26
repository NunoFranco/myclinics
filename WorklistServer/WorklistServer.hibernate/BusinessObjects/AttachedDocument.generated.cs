using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class AttachedDocument : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _mimeType = String.Empty;
		private string _fileExtension = String.Empty;
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime _receivedTime = new DateTime();
		private string _contentUrl = String.Empty;
		
		
		private IList<PatientAttachment> _patientAttachments = new List<PatientAttachment>();
		private IList<OrderAttachment> _orderAttachments = new List<OrderAttachment>();
		
		#endregion

        #region Constructors

        public AttachedDocument() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_mimeType);
			sb.Append(_fileExtension);
			sb.Append(_creationTime);
			sb.Append(_receivedTime);
			sb.Append(_contentUrl);

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
		
		public virtual string MimeType
        {
            get { return _mimeType; }
			set
			{
				OnMimeTypeChanging();
				_mimeType = value;
				OnMimeTypeChanged();
			}
        }
		partial void OnMimeTypeChanging();
		partial void OnMimeTypeChanged();
		
		public virtual string FileExtension
        {
            get { return _fileExtension; }
			set
			{
				OnFileExtensionChanging();
				_fileExtension = value;
				OnFileExtensionChanged();
			}
        }
		partial void OnFileExtensionChanging();
		partial void OnFileExtensionChanged();
		
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
		
		public virtual System.DateTime ReceivedTime
        {
            get { return _receivedTime; }
			set
			{
				OnReceivedTimeChanging();
				_receivedTime = value;
				OnReceivedTimeChanged();
			}
        }
		partial void OnReceivedTimeChanging();
		partial void OnReceivedTimeChanged();
		
		public virtual string ContentUrl
        {
            get { return _contentUrl; }
			set
			{
				OnContentUrlChanging();
				_contentUrl = value;
				OnContentUrlChanged();
			}
        }
		partial void OnContentUrlChanging();
		partial void OnContentUrlChanged();
		
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
		
		public virtual IList<OrderAttachment> OrderAttachments
        {
            get { return _orderAttachments; }
            set
			{
				OnOrderAttachmentsChanging();
				_orderAttachments = value;
				OnOrderAttachmentsChanged();
			}
        }
		partial void OnOrderAttachmentsChanging();
		partial void OnOrderAttachmentsChanged();
		
        #endregion
    }
}
