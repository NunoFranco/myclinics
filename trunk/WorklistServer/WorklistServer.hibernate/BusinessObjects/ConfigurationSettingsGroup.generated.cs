using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ConfigurationSettingsGroup : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _name = String.Empty;
		private string _versionString = String.Empty;
		private string _description = null;
		private string _assemblyQualifiedTypeName = null;
		private bool _hasUserScopedSettings = default(Boolean);
		
		
		private IList<ConfigurationSettingsProperty> _configurationSettingsProperties = new List<ConfigurationSettingsProperty>();
		
		#endregion

        #region Constructors

        public ConfigurationSettingsGroup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_name);
			sb.Append(_versionString);
			sb.Append(_description);
			sb.Append(_assemblyQualifiedTypeName);
			sb.Append(_hasUserScopedSettings);

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
		
		public virtual string VersionString
        {
            get { return _versionString; }
			set
			{
				OnVersionStringChanging();
				_versionString = value;
				OnVersionStringChanged();
			}
        }
		partial void OnVersionStringChanging();
		partial void OnVersionStringChanged();
		
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
		
		public virtual string AssemblyQualifiedTypeName
        {
            get { return _assemblyQualifiedTypeName; }
			set
			{
				OnAssemblyQualifiedTypeNameChanging();
				_assemblyQualifiedTypeName = value;
				OnAssemblyQualifiedTypeNameChanged();
			}
        }
		partial void OnAssemblyQualifiedTypeNameChanging();
		partial void OnAssemblyQualifiedTypeNameChanged();
		
		public virtual bool HasUserScopedSettings
        {
            get { return _hasUserScopedSettings; }
			set
			{
				OnHasUserScopedSettingsChanging();
				_hasUserScopedSettings = value;
				OnHasUserScopedSettingsChanged();
			}
        }
		partial void OnHasUserScopedSettingsChanging();
		partial void OnHasUserScopedSettingsChanged();
		
		public virtual IList<ConfigurationSettingsProperty> ConfigurationSettingsProperties
        {
            get { return _configurationSettingsProperties; }
            set
			{
				OnConfigurationSettingsPropertiesChanging();
				_configurationSettingsProperties = value;
				OnConfigurationSettingsPropertiesChanged();
			}
        }
		partial void OnConfigurationSettingsPropertiesChanging();
		partial void OnConfigurationSettingsPropertiesChanged();
		
        #endregion
    }
}
