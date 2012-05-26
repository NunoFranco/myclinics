using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class User : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _userName = String.Empty;
		private string _passwordSalt = String.Empty;
		private string _passwordSaltedHash = String.Empty;
		private System.DateTime? _passwordExpiryDate = null;
		private string _displayName = null;
		private System.DateTime? _validFrom = null;
		private System.DateTime? _validUntil = null;
		private bool _enabled = default(Boolean);
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime? _lastLoginTime = null;
		
		
		private IList<UserSession> _userSessions = new List<UserSession>();
		
		#endregion

        #region Constructors

        public User() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_userName);
			sb.Append(_passwordSalt);
			sb.Append(_passwordSaltedHash);
			sb.Append(_passwordExpiryDate);
			sb.Append(_displayName);
			sb.Append(_validFrom);
			sb.Append(_validUntil);
			sb.Append(_enabled);
			sb.Append(_creationTime);
			sb.Append(_lastLoginTime);

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
		
		public virtual string UserName
        {
            get { return _userName; }
			set
			{
				OnUserNameChanging();
				_userName = value;
				OnUserNameChanged();
			}
        }
		partial void OnUserNameChanging();
		partial void OnUserNameChanged();
		
		public virtual string PasswordSalt
        {
            get { return _passwordSalt; }
			set
			{
				OnPasswordSaltChanging();
				_passwordSalt = value;
				OnPasswordSaltChanged();
			}
        }
		partial void OnPasswordSaltChanging();
		partial void OnPasswordSaltChanged();
		
		public virtual string PasswordSaltedHash
        {
            get { return _passwordSaltedHash; }
			set
			{
				OnPasswordSaltedHashChanging();
				_passwordSaltedHash = value;
				OnPasswordSaltedHashChanged();
			}
        }
		partial void OnPasswordSaltedHashChanging();
		partial void OnPasswordSaltedHashChanged();
		
		public virtual System.DateTime? PasswordExpiryDate
        {
            get { return _passwordExpiryDate; }
			set
			{
				OnPasswordExpiryDateChanging();
				_passwordExpiryDate = value;
				OnPasswordExpiryDateChanged();
			}
        }
		partial void OnPasswordExpiryDateChanging();
		partial void OnPasswordExpiryDateChanged();
		
		public virtual string DisplayName
        {
            get { return _displayName; }
			set
			{
				OnDisplayNameChanging();
				_displayName = value;
				OnDisplayNameChanged();
			}
        }
		partial void OnDisplayNameChanging();
		partial void OnDisplayNameChanged();
		
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
		
		public virtual bool Enabled
        {
            get { return _enabled; }
			set
			{
				OnEnabledChanging();
				_enabled = value;
				OnEnabledChanged();
			}
        }
		partial void OnEnabledChanging();
		partial void OnEnabledChanged();
		
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
		
		public virtual System.DateTime? LastLoginTime
        {
            get { return _lastLoginTime; }
			set
			{
				OnLastLoginTimeChanging();
				_lastLoginTime = value;
				OnLastLoginTimeChanged();
			}
        }
		partial void OnLastLoginTimeChanging();
		partial void OnLastLoginTimeChanged();
		
		public virtual IList<UserSession> UserSessions
        {
            get { return _userSessions; }
            set
			{
				OnUserSessionsChanging();
				_userSessions = value;
				OnUserSessionsChanged();
			}
        }
		partial void OnUserSessionsChanging();
		partial void OnUserSessionsChanged();
		
        #endregion
    }
}
