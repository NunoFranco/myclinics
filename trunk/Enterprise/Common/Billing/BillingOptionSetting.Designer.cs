﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4952
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Enterprise.Common.Billing {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class BillingOptionSetting : global::System.Configuration.ApplicationSettingsBase {
        
        private static BillingOptionSetting defaultInstance = ((BillingOptionSetting)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new BillingOptionSetting())));
        
        public static BillingOptionSetting Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("USD")]
        public string PrimaryCurrency {
            get {
                return ((string)(this["PrimaryCurrency"]));
            }
            set {
                this["PrimaryCurrency"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("EN")]
        public string SystemLanguague {
            get {
                return ((string)(this["SystemLanguague"]));
            }
            set {
                this["SystemLanguague"] = value;
            }
        }
    }
}
