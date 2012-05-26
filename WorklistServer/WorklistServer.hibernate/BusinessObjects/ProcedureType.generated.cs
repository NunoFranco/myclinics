using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ProcedureType : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _id = String.Empty;
		private string _name = String.Empty;
		private string _planXml = null;
		private bool _deactivated = default(Boolean);
		
		private ProcedureType _procedureTypeMember = null;
		
		private IList<Procedure> _procedures = new List<Procedure>();
		
		#endregion

        #region Constructors

        public ProcedureType() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_id);
			sb.Append(_name);
			sb.Append(_planXml);
			sb.Append(_deactivated);

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
		
		public virtual string Id
        {
            get { return _id; }
			set
			{
				OnIdChanging();
				_id = value;
				OnIdChanged();
			}
        }
		partial void OnIdChanging();
		partial void OnIdChanged();
		
		public virtual string Name
        {
            get { return _name; }
			set
			{
				OnNameChanging();
				_name = value;
				OnNameChanged();
			}
        }
		partial void OnNameChanging();
		partial void OnNameChanged();
		
		public virtual string PlanXml
        {
            get { return _planXml; }
			set
			{
				OnPlanXmlChanging();
				_planXml = value;
				OnPlanXmlChanged();
			}
        }
		partial void OnPlanXmlChanging();
		partial void OnPlanXmlChanged();
		
		public virtual bool Deactivated
        {
            get { return _deactivated; }
			set
			{
				OnDeactivatedChanging();
				_deactivated = value;
				OnDeactivatedChanged();
			}
        }
		partial void OnDeactivatedChanging();
		partial void OnDeactivatedChanged();
		
		public virtual ProcedureType ProcedureTypeMember
        {
            get { return _procedureTypeMember; }
			set
			{
				OnProcedureTypeMemberChanging();
				_procedureTypeMember = value;
				OnProcedureTypeMemberChanged();
			}
        }
		partial void OnProcedureTypeMemberChanging();
		partial void OnProcedureTypeMemberChanged();
		
		public virtual IList<Procedure> Procedures
        {
            get { return _procedures; }
            set
			{
				OnProceduresChanging();
				_procedures = value;
				OnProceduresChanged();
			}
        }
		partial void OnProceduresChanging();
		partial void OnProceduresChanged();
		
        #endregion
    }
}
