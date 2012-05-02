// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using Iesi.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Enterprise.Configuration
{


    /// <summary>
    /// ConfigurationSettingsGroup entity
    /// </summary>
	
	public partial class ConfigurationSettingsGroup : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _name;
	  	
	  	private string _versionString;
	  	
	  	private string _description;
	  	
	  	private string _assemblyQualifiedTypeName;
	  	
	  	private bool _hasUserScopedSettings;
	  	
	  	private IList<ClearCanvas.Enterprise.Configuration.ConfigurationSettingsProperty> _settingsProperties;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ConfigurationSettingsGroup()
	  	{
		 	
		  	_settingsProperties = new List<ClearCanvas.Enterprise.Configuration.ConfigurationSettingsProperty>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ConfigurationSettingsGroup(string name1, string versionstring1, string description1, string assemblyqualifiedtypename1, bool hasuserscopedsettings1, IList<ClearCanvas.Enterprise.Configuration.ConfigurationSettingsProperty> settingsproperties1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_versionString = versionstring1;
		  	
		  	_description = description1;
		  	
		  	_assemblyQualifiedTypeName = assemblyqualifiedtypename1;
		  	
		  	_hasUserScopedSettings = hasuserscopedsettings1;
		  	
		  	_settingsProperties = settingsproperties1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(30)]
	  	public virtual string VersionString
	  	{
			
			get { return _versionString; }
			
			
			 set { _versionString = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(1000)]
	  	public virtual string Description
	  	{
			
			get { return _description; }
			
			
			 set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(500)]
	  	public virtual string AssemblyQualifiedTypeName
	  	{
			
			get { return _assemblyQualifiedTypeName; }
			
			
			 set { _assemblyQualifiedTypeName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool HasUserScopedSettings
	  	{
			
			get { return _hasUserScopedSettings; }
			
			
			 set { _hasUserScopedSettings = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Enterprise.Configuration.ConfigurationSettingsProperty))]
	  	public virtual IList<ClearCanvas.Enterprise.Configuration.ConfigurationSettingsProperty> SettingsProperties
	  	{
			
			get { return _settingsProperties; }
			
			
			protected set { _settingsProperties = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
