using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ConfigurationDocument : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _documentName = String.Empty;
		private string _documentVersionString = String.Empty;
		private string _user = null;
		private string _instanceKey = null;
		
		
		
		#endregion

        #region Constructors

        public ConfigurationDocument() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_documentName);
			sb.Append(_documentVersionString);
			sb.Append(_user);
			sb.Append(_instanceKey);

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
		
		public virtual string DocumentName
        {
            get { return _documentName; }
			set
			{
				OnDocumentNameChanging();
				_documentName = value;
				OnDocumentNameChanged();
			}
        }
		partial void OnDocumentNameChanging();
		partial void OnDocumentNameChanged();
		
		public virtual string DocumentVersionString
        {
            get { return _documentVersionString; }
			set
			{
				OnDocumentVersionStringChanging();
				_documentVersionString = value;
				OnDocumentVersionStringChanged();
			}
        }
		partial void OnDocumentVersionStringChanging();
		partial void OnDocumentVersionStringChanged();
		
		public virtual string User
        {
            get { return _user; }
			set
			{
				OnUserChanging();
				_user = value;
				OnUserChanged();
			}
        }
		partial void OnUserChanging();
		partial void OnUserChanged();
		
		public virtual string InstanceKey
        {
            get { return _instanceKey; }
			set
			{
				OnInstanceKeyChanging();
				_instanceKey = value;
				OnInstanceKeyChanged();
			}
        }
		partial void OnInstanceKeyChanging();
		partial void OnInstanceKeyChanged();
		
        #endregion
    }
}
