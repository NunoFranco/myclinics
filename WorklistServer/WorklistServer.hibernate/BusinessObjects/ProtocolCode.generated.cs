using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ProtocolCode : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _name = String.Empty;
		private string _description = null;
		private bool _deactivated = default(Boolean);
		
		
		private IList<ProtocolGroup> _protocolGroups = new List<ProtocolGroup>();
		
		#endregion

        #region Constructors

        public ProtocolCode() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_name);
			sb.Append(_description);
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
		
		public virtual string Description
        {
            get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				OnDescriptionChanged();
			}
        }
		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		
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
		
		public virtual IList<ProtocolGroup> ProtocolGroups
        {
            get { return _protocolGroups; }
            set
			{
				OnProtocolGroupsChanging();
				_protocolGroups = value;
				OnProtocolGroupsChanged();
			}
        }
		partial void OnProtocolGroupsChanging();
		partial void OnProtocolGroupsChanged();
		
        #endregion
    }
}
