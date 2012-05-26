using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class VisitExtendedProperty : BusinessBase<string>
    {
        #region Declarations

		private System.Guid _visitOID = Guid.Empty;
		private string _name = String.Empty;
		private string _value = null;
		
		
		
		#endregion

        #region Constructors

        public VisitExtendedProperty() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_visitOID);
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
				uniqueId.Append(_visitOID.ToString());
				uniqueId.Append("^");
				uniqueId.Append(_name.ToString());
				return uniqueId.ToString();
			}
		}
		
		public virtual System.Guid VisitOID
        {
            get { return _visitOID; }
			set
			{
				OnVisitOIDChanging();
				_visitOID = value;
				OnVisitOIDChanged();
			}
        }
		partial void OnVisitOIDChanging();
		partial void OnVisitOIDChanged();
		
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
