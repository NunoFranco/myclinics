using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Facility : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _code = String.Empty;
		private string _name = String.Empty;
		private bool _deactivated = default(Boolean);
		
		private InformationAuthorityEnum _informationAuthorityEnum = null;
		
		private IList<Visit> _visits = new List<Visit>();
		private IList<Location> _locations = new List<Location>();
		private IList<Order> _orders = new List<Order>();
		private IList<Procedure> _procedures = new List<Procedure>();
		
		#endregion

        #region Constructors

        public Facility() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_code);
			sb.Append(_name);
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
		
		public virtual string Code
        {
            get { return _code; }
			set
			{
				OnCodeChanging();
				_code = value;
				OnCodeChanged();
			}
        }
		partial void OnCodeChanging();
		partial void OnCodeChanged();
		
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
		
		public virtual InformationAuthorityEnum InformationAuthorityEnum
        {
            get { return _informationAuthorityEnum; }
			set
			{
				OnInformationAuthorityEnumChanging();
				_informationAuthorityEnum = value;
				OnInformationAuthorityEnumChanged();
			}
        }
		partial void OnInformationAuthorityEnumChanging();
		partial void OnInformationAuthorityEnumChanged();
		
		public virtual IList<Visit> Visits
        {
            get { return _visits; }
            set
			{
				OnVisitsChanging();
				_visits = value;
				OnVisitsChanged();
			}
        }
		partial void OnVisitsChanging();
		partial void OnVisitsChanged();
		
		public virtual IList<Location> Locations
        {
            get { return _locations; }
            set
			{
				OnLocationsChanging();
				_locations = value;
				OnLocationsChanged();
			}
        }
		partial void OnLocationsChanging();
		partial void OnLocationsChanged();
		
		public virtual IList<Order> Orders
        {
            get { return _orders; }
            set
			{
				OnOrdersChanging();
				_orders = value;
				OnOrdersChanged();
			}
        }
		partial void OnOrdersChanging();
		partial void OnOrdersChanged();
		
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
