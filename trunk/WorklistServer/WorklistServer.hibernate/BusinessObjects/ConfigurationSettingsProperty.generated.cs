using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ConfigurationSettingsProperty : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _name = String.Empty;
		private string _typeName = String.Empty;
		private string _scope = String.Empty;
		private string _description = null;
		private string _defaultValue = null;
		
		private ConfigurationSettingsGroup _configurationSettingsGroup = null;
		
		
		#endregion

        #region Constructors

        public ConfigurationSettingsProperty() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_name);
			sb.Append(_typeName);
			sb.Append(_scope);
			sb.Append(_description);
			sb.Append(_defaultValue);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

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
		
		public virtual string TypeName
        {
            get { return _typeName; }
			set
			{
				OnTypeNameChanging();
				_typeName = value;
				OnTypeNameChanged();
			}
        }
		partial void OnTypeNameChanging();
		partial void OnTypeNameChanged();
		
		public virtual string Scope
        {
            get { return _scope; }
			set
			{
				OnScopeChanging();
				_scope = value;
				OnScopeChanged();
			}
        }
		partial void OnScopeChanging();
		partial void OnScopeChanged();
		
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
		
		public virtual string DefaultValue
        {
            get { return _defaultValue; }
			set
			{
				OnDefaultValueChanging();
				_defaultValue = value;
				OnDefaultValueChanged();
			}
        }
		partial void OnDefaultValueChanging();
		partial void OnDefaultValueChanged();
		
		public virtual ConfigurationSettingsGroup ConfigurationSettingsGroup
        {
            get { return _configurationSettingsGroup; }
			set
			{
				OnConfigurationSettingsGroupChanging();
				_configurationSettingsGroup = value;
				OnConfigurationSettingsGroupChanged();
			}
        }
		partial void OnConfigurationSettingsGroupChanging();
		partial void OnConfigurationSettingsGroupChanged();
		
        #endregion
    }
}
