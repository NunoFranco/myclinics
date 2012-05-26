using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ExceptionLog : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private System.DateTime _timeStamp = new DateTime();
		private string _hostName = null;
		private string _application = null;
		private string _user = null;
		private string _operation = null;
		private string _exceptionClass = null;
		private string _message = null;
		private string _details = null;
		private string _assemblyName = null;
		private string _assemblyLocation = null;
		
		
		
		#endregion

        #region Constructors

        public ExceptionLog() { }

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
			sb.Append(_user);
			sb.Append(_operation);
			sb.Append(_exceptionClass);
			sb.Append(_message);
			sb.Append(_details);
			sb.Append(_assemblyName);
			sb.Append(_assemblyLocation);

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
		
		public virtual string ExceptionClass
        {
            get { return _exceptionClass; }
			set
			{
				OnExceptionClassChanging();
				_exceptionClass = value;
				OnExceptionClassChanged();
			}
        }
		partial void OnExceptionClassChanging();
		partial void OnExceptionClassChanged();
		
		public virtual string Message
        {
            get { return _message; }
			set
			{
				OnMessageChanging();
				_message = value;
				OnMessageChanged();
			}
        }
		partial void OnMessageChanging();
		partial void OnMessageChanged();
		
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
		
		public virtual string AssemblyName
        {
            get { return _assemblyName; }
			set
			{
				OnAssemblyNameChanging();
				_assemblyName = value;
				OnAssemblyNameChanged();
			}
        }
		partial void OnAssemblyNameChanging();
		partial void OnAssemblyNameChanged();
		
		public virtual string AssemblyLocation
        {
            get { return _assemblyLocation; }
			set
			{
				OnAssemblyLocationChanging();
				_assemblyLocation = value;
				OnAssemblyLocationChanged();
			}
        }
		partial void OnAssemblyLocationChanging();
		partial void OnAssemblyLocationChanged();
		
        #endregion
    }
}
