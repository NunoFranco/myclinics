using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Protocol : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		
		private Staff _staff1 = null;
		private ProtocolRejectReasonEnum _protocolRejectReasonEnum = null;
		private ProtocolStatusEnum _protocolStatusEnum = null;
		private Staff _staff2 = null;
		private ProtocolUrgencyEnum _protocolUrgencyEnum = null;
		
		private IList<ProcedureStep> _procedureSteps = new List<ProcedureStep>();
		
		#endregion

        #region Constructors

        public Protocol() { }

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
		
		public virtual Staff Staff1
        {
            get { return _staff1; }
			set
			{
				OnStaff1Changing();
				_staff1 = value;
				OnStaff1Changed();
			}
        }
		partial void OnStaff1Changing();
		partial void OnStaff1Changed();
		
		public virtual ProtocolRejectReasonEnum ProtocolRejectReasonEnum
        {
            get { return _protocolRejectReasonEnum; }
			set
			{
				OnProtocolRejectReasonEnumChanging();
				_protocolRejectReasonEnum = value;
				OnProtocolRejectReasonEnumChanged();
			}
        }
		partial void OnProtocolRejectReasonEnumChanging();
		partial void OnProtocolRejectReasonEnumChanged();
		
		public virtual ProtocolStatusEnum ProtocolStatusEnum
        {
            get { return _protocolStatusEnum; }
			set
			{
				OnProtocolStatusEnumChanging();
				_protocolStatusEnum = value;
				OnProtocolStatusEnumChanged();
			}
        }
		partial void OnProtocolStatusEnumChanging();
		partial void OnProtocolStatusEnumChanged();
		
		public virtual Staff Staff2
        {
            get { return _staff2; }
			set
			{
				OnStaff2Changing();
				_staff2 = value;
				OnStaff2Changed();
			}
        }
		partial void OnStaff2Changing();
		partial void OnStaff2Changed();
		
		public virtual ProtocolUrgencyEnum ProtocolUrgencyEnum
        {
            get { return _protocolUrgencyEnum; }
			set
			{
				OnProtocolUrgencyEnumChanging();
				_protocolUrgencyEnum = value;
				OnProtocolUrgencyEnumChanged();
			}
        }
		partial void OnProtocolUrgencyEnumChanging();
		partial void OnProtocolUrgencyEnumChanged();
		
		public virtual IList<ProcedureStep> ProcedureSteps
        {
            get { return _procedureSteps; }
            set
			{
				OnProcedureStepsChanging();
				_procedureSteps = value;
				OnProcedureStepsChanged();
			}
        }
		partial void OnProcedureStepsChanging();
		partial void OnProcedureStepsChanged();
		
        #endregion
    }
}
