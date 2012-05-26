using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ImageAvailabilityEnum : BusinessBase<string>
    {
        #region Declarations

		private string _value = null;
		private string _description = null;
		private float? _displayOrder = null;
		private bool _deactivated = default(Boolean);
		
		
		private IList<Procedure> _procedures = new List<Procedure>();
		
		#endregion

        #region Constructors

        public ImageAvailabilityEnum() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_value);
			sb.Append(_description);
			sb.Append(_displayOrder);
			sb.Append(_deactivated);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

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
		
		public virtual float? DisplayOrder
        {
            get { return _displayOrder; }
			set
			{
				OnDisplayOrderChanging();
				_displayOrder = value;
				OnDisplayOrderChanged();
			}
        }
		partial void OnDisplayOrderChanging();
		partial void OnDisplayOrderChanged();
		
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
