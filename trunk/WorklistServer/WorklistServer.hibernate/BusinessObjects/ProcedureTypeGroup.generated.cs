using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ProcedureTypeGroup : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _discriminator = String.Empty;
		private int _version = default(Int32);
		private string _name = String.Empty;
		private string _description = null;
		
		
		
		#endregion

        #region Constructors

        public ProcedureTypeGroup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_discriminator);
			sb.Append(_version);
			sb.Append(_name);
			sb.Append(_description);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string Discriminator
        {
            get { return _discriminator; }
			set
			{
				OnDiscriminatorChanging();
				_discriminator = value;
				OnDiscriminatorChanged();
			}
        }
		partial void OnDiscriminatorChanging();
		partial void OnDiscriminatorChanged();
		
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
		
        #endregion
    }
}
