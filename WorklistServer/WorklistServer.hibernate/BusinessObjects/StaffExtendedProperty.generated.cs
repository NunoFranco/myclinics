using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class StaffExtendedProperty : BusinessBase<string>
    {
        #region Declarations

		private System.Guid _staffOID = Guid.Empty;
		private string _name = String.Empty;
		private string _value = null;
		
		
		
		#endregion

        #region Constructors

        public StaffExtendedProperty() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_staffOID);
			sb.Append(_name);
			sb.Append(_value);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public override string Id
		{
			get
			{
				System.Text.StringBuilder uniqueId = new System.Text.StringBuilder();
				uniqueId.Append(_staffOID.ToString());
				uniqueId.Append("^");
				uniqueId.Append(_name.ToString());
				return uniqueId.ToString();
			}
		}
		
		public virtual System.Guid StaffOID
        {
            get { return _staffOID; }
			set
			{
				OnStaffOIDChanging();
				_staffOID = value;
				OnStaffOIDChanged();
			}
        }
		partial void OnStaffOIDChanging();
		partial void OnStaffOIDChanged();
		
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
		
		public virtual string Value
        {
            get { return _value; }
			set
			{
				OnValueChanging();
				_value = value;
				OnValueChanged();
			}
        }
		partial void OnValueChanging();
		partial void OnValueChanged();
		
        #endregion
    }
}
