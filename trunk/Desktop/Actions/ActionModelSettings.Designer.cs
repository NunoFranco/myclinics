﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Desktop.Actions {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class ActionModelSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ActionModelSettings defaultInstance = ((ActionModelSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ActionModelSettings())));
        
        public static ActionModelSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Action model XML document.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Action model XML document.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<action-models />")]
        public global::System.Xml.XmlDocument ActionModelsXml {
            get {
                return ((global::System.Xml.XmlDocument)(this["ActionModelsXml"]));
            }
            set {
                this["ActionModelsXml"] = value;
            }
        }
    }
}
