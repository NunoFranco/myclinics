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
    /// ConfigurationSettingsProperty component
    /// </summary>
	public sealed partial class ConfigurationSettingsProperty : ValueObject, IEquatable<ConfigurationSettingsProperty>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private string _name;
	  	
	  	private string _typeName;
	  	
	  	private string _scope;
	  	
	  	private string _description;
	  	
	  	private string _defaultValue;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ConfigurationSettingsProperty()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ConfigurationSettingsProperty(string name1, string typename1, string scope1, string description1, string defaultvalue1)
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_typeName = typename1;
		  	
		  	_scope = scope1;
		  	
		  	_description = description1;
		  	
		  	_defaultValue = defaultvalue1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public string Name
	  	{
			
			get { return _name; }
			
			
			set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public string TypeName
	  	{
			
			get { return _typeName; }
			
			
			set { _typeName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public string Scope
	  	{
			
			get { return _scope; }
			
			
			set { _scope = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(1000)]
	  	public string Description
	  	{
			
			get { return _description; }
			
			
			set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(1000000)]
	  	public string DefaultValue
	  	{
			
			get { return _defaultValue; }
			
			
			set { _defaultValue = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(ConfigurationSettingsProperty that)
		{
			return (that != null) &&
	  	
			((this._name == default(string)) ? (that._name == default(string)) : this._name.Equals(that._name)) &&
	  	
			((this._typeName == default(string)) ? (that._typeName == default(string)) : this._typeName.Equals(that._typeName)) &&
	  	
			((this._scope == default(string)) ? (that._scope == default(string)) : this._scope.Equals(that._scope)) &&
	  	
			((this._description == default(string)) ? (that._description == default(string)) : this._description.Equals(that._description)) &&
	  	
			((this._defaultValue == default(string)) ? (that._defaultValue == default(string)) : this._defaultValue.Equals(that._defaultValue)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as ConfigurationSettingsProperty);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_name == default(string) ? 0 : _name.GetHashCode()) ^
	  	
				(_typeName == default(string) ? 0 : _typeName.GetHashCode()) ^
	  	
				(_scope == default(string) ? 0 : _scope.GetHashCode()) ^
	  	
				(_description == default(string) ? 0 : _description.GetHashCode()) ^
	  	
				(_defaultValue == default(string) ? 0 : _defaultValue.GetHashCode()) ^
	  	
				0;
		}
				
	  	#endregion
	  	
	  	/// <summary>
	  	/// Returns a clone of this object.  A deep-copy is performed, so the clone will not share
	  	/// any mutable data with this object.
	  	/// NB. Note that collections are not currently supported.  If this object contains collections
	  	/// they will not be cloned.  It should be relatively easy to add collection support when the need arises.
	  	/// </summary>
        public override object Clone()
        {
			ConfigurationSettingsProperty clone = new ConfigurationSettingsProperty();
		
		
	  		clone._name = this._name;
		
	  		clone._typeName = this._typeName;
		
	  		clone._scope = this._scope;
		
	  		clone._description = this._description;
		
	  		clone._defaultValue = this._defaultValue;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Name", _name);
		  	
		  	writer.WriteProperty("TypeName", _typeName);
		  	
		  	writer.WriteProperty("Scope", _scope);
		  	
		  	writer.WriteProperty("Description", _description);
		  	
		  	writer.WriteProperty("DefaultValue", _defaultValue);
		  	
		}

		#endregion
	}
}
