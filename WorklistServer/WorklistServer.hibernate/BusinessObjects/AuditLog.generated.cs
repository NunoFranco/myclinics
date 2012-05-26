using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class AuditLog : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private System.DateTime _timeStamp = new DateTime();
		private string _hostName = null;
		private string _application = null;
		private string _category = String.Empty;
		private string _user = null;
		private string _userSessionId = null;
		private string _operation = null;
		private string _details = null;
		
		
		
		#endregion

        #region Constructors

        public AuditLog() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_timeStamp);
			sb.Append(_hostName);
			sb.Append(_application);
			sb.Append(_category);
			sb.Append(_user);
			sb.Append(_userSessionId);
			sb.Append(_operation);
			sb.Append(_details);

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
		
		public virtual System.DateTime TimeStamp
        {
            get { return _timeStamp; }
			set
			{
				OnTimeStampChanging();
				_timeStamp = value;
				OnTimeStampChanged();
			}
        }
		partial void OnTimeStampChanging();
		partial void OnTimeStampChanged();
		
		public virtual string HostName
        {
            get { return _hostName; }
			set
			{
				OnHostNameChanging();
				_hostName = value;
				OnHostNameChanged();
			}
        }
		partial void OnHostNameChanging();
		partial void OnHostNameChanged();
		
		public virtual string Application
        {
            get { return _application; }
			set
			{
				OnApplicationChanging();
				_application = value;
				OnApplicationChanged();
			}
        }
		partial void OnApplicationChanging();
		partial void OnApplicationChanged();
		
		public virtual string Category
        {
            get { return _category; }
			set
			{
				OnCategoryChanging();
				_category = value;
				OnCategoryChanged();
			}
        }
		partial void OnCategoryChanging();
		partial void OnCategoryChanged();
		
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
		
		public virtual string UserSessionId
        {
            get { return _userSessionId; }
			set
			{
				OnUserSessionIdChanging();
				_userSessionId = value;
				OnUserSessionIdChanged();
			}
        }
		partial void OnUserSessionIdChanging();
		partial void OnUserSessionIdChanged();
		
		public virtual string Operation
        {
            get { return _operation; }
			set
			{
				OnOperationChanging();
				_operation = value;
				OnOperationChanged();
			}
        }
		partial void OnOperationChanging();
		partial void OnOperationChanged();
		
		public virtual string Details
        {
            get { return _details; }
			set
			{
				OnDetailsChanging();
				_details = value;
				OnDetailsChanged();
			}
        }
		partial void OnDetailsChanging();
		partial void OnDetailsChanged();
		
        #endregion
    }
}
