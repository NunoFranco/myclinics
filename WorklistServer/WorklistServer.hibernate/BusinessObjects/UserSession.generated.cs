using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class UserSession : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _hostName = null;
		private string _application = null;
		private string _sessionId = String.Empty;
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime _expiryTime = new DateTime();
		
		private User _user = null;
		
		
		#endregion

        #region Constructors

        public UserSession() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_hostName);
			sb.Append(_application);
			sb.Append(_sessionId);
			sb.Append(_creationTime);
			sb.Append(_expiryTime);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

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
		
		public virtual string SessionId
        {
            get { return _sessionId; }
			set
			{
				OnSessionIdChanging();
				_sessionId = value;
				OnSessionIdChanged();
			}
        }
		partial void OnSessionIdChanging();
		partial void OnSessionIdChanged();
		
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
		
		public virtual System.DateTime ExpiryTime
        {
            get { return _expiryTime; }
			set
			{
				OnExpiryTimeChanging();
				_expiryTime = value;
				OnExpiryTimeChanged();
			}
        }
		partial void OnExpiryTimeChanging();
		partial void OnExpiryTimeChanged();
		
		public virtual User User
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
		
        #endregion
    }
}
