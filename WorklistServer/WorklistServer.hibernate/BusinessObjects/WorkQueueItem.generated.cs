using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class WorkQueueItem : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime _scheduledTime = new DateTime();
		private System.DateTime? _expirationTime = null;
		private string _user = null;
		private string _type = String.Empty;
		private System.DateTime? _processedTime = null;
		private int _failureCount = default(Int32);
		private string _failureDescription = null;
		
		private WorkQueueStatusEnum _workQueueStatusEnum = null;
		
		
		#endregion

        #region Constructors

        public WorkQueueItem() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_creationTime);
			sb.Append(_scheduledTime);
			sb.Append(_expirationTime);
			sb.Append(_user);
			sb.Append(_type);
			sb.Append(_processedTime);
			sb.Append(_failureCount);
			sb.Append(_failureDescription);

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
		
		public virtual System.DateTime ScheduledTime
        {
            get { return _scheduledTime; }
			set
			{
				OnScheduledTimeChanging();
				_scheduledTime = value;
				OnScheduledTimeChanged();
			}
        }
		partial void OnScheduledTimeChanging();
		partial void OnScheduledTimeChanged();
		
		public virtual System.DateTime? ExpirationTime
        {
            get { return _expirationTime; }
			set
			{
				OnExpirationTimeChanging();
				_expirationTime = value;
				OnExpirationTimeChanged();
			}
        }
		partial void OnExpirationTimeChanging();
		partial void OnExpirationTimeChanged();
		
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
		
		public virtual string Type
        {
            get { return _type; }
			set
			{
				OnTypeChanging();
				_type = value;
				OnTypeChanged();
			}
        }
		partial void OnTypeChanging();
		partial void OnTypeChanged();
		
		public virtual System.DateTime? ProcessedTime
        {
            get { return _processedTime; }
			set
			{
				OnProcessedTimeChanging();
				_processedTime = value;
				OnProcessedTimeChanged();
			}
        }
		partial void OnProcessedTimeChanging();
		partial void OnProcessedTimeChanged();
		
		public virtual int FailureCount
        {
            get { return _failureCount; }
			set
			{
				OnFailureCountChanging();
				_failureCount = value;
				OnFailureCountChanged();
			}
        }
		partial void OnFailureCountChanging();
		partial void OnFailureCountChanged();
		
		public virtual string FailureDescription
        {
            get { return _failureDescription; }
			set
			{
				OnFailureDescriptionChanging();
				_failureDescription = value;
				OnFailureDescriptionChanged();
			}
        }
		partial void OnFailureDescriptionChanging();
		partial void OnFailureDescriptionChanged();
		
		public virtual WorkQueueStatusEnum WorkQueueStatusEnum
        {
            get { return _workQueueStatusEnum; }
			set
			{
				OnWorkQueueStatusEnumChanging();
				_workQueueStatusEnum = value;
				OnWorkQueueStatusEnumChanged();
			}
        }
		partial void OnWorkQueueStatusEnumChanging();
		partial void OnWorkQueueStatusEnumChanged();
		
        #endregion
    }
}
