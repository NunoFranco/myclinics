using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class StaffEmailAddress : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _address = String.Empty;
		private System.DateTime? _validFrom = null;
		private System.DateTime? _validUntil = null;
		
		private Staff _staff = null;
		
		
		#endregion

        #region Constructors

        public StaffEmailAddress() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_address);
			sb.Append(_validFrom);
			sb.Append(_validUntil);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string Address
        {
            get { return _address; }
			set
			{
				OnAddressChanging();
				_address = value;
				OnAddressChanged();
			}
        }
		partial void OnAddressChanging();
		partial void OnAddressChanged();
		
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
		
		public virtual Staff Staff
        {
            get { return _staff; }
			set
			{
				OnStaffChanging();
				_staff = value;
				OnStaffChanged();
			}
        }
		partial void OnStaffChanging();
		partial void OnStaffChanged();
		
        #endregion
    }
}
