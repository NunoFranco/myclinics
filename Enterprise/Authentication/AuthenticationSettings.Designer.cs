﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Enterprise.Authentication {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class AuthenticationSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static AuthenticationSettings defaultInstance = ((AuthenticationSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AuthenticationSettings())));
        
        public static AuthenticationSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Number of days until a password expires
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Number of days until a password expires")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60")]
        public int PasswordExpiryDays {
            get {
                return ((int)(this["PasswordExpiryDays"]));
            }
        }
        
        /// <summary>
        /// Temporary password assigned to new users
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Temporary password assigned to new users")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("clearcanvas")]
        public string DefaultTemporaryPassword {
            get {
                return ((string)(this["DefaultTemporaryPassword"]));
            }
        }
        
        /// <summary>
        /// User session inactivity timeout in minutes
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("User session inactivity timeout in minutes")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int UserSessionTimeoutMinutes {
            get {
                return ((int)(this["UserSessionTimeoutMinutes"]));
            }
        }
        
        /// <summary>
        /// Specify true to enable user session inactivity timeout, otherwise user sessions never time out
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specify true to enable user session inactivity timeout, otherwise user sessions n" +
            "ever time out")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UserSessionTimeoutEnabled {
            get {
                return ((bool)(this["UserSessionTimeoutEnabled"]));
            }
        }
        
        /// <summary>
        /// Regular expression used to validate new password candidates
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Regular expression used to validate new password candidates")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("^\\w{8,16}$")]
        public string ValidPasswordRegex {
            get {
                return ((string)(this["ValidPasswordRegex"]));
            }
        }
        
        /// <summary>
        /// User friendly description of a valid password
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("User friendly description of a valid password")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password must contain only letters and numbers, and be 8-16 characters long")]
        public string ValidPasswordMessage {
            get {
                return ((string)(this["ValidPasswordMessage"]));
            }
        }
        
        /// <summary>
        /// Comma delimited list of valid application names.  If blank, all application names are valid.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Comma delimited list of valid application names.  If blank, all application names" +
            " are valid.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ApplicationWhiteList {
            get {
                return ((string)(this["ApplicationWhiteList"]));
            }
        }
        
        /// <summary>
        /// Comma delimited list of valid host names.  If blank, all host names are valid.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Comma delimited list of valid host names.  If blank, all host names are valid.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string HostNameWhiteList {
            get {
                return ((string)(this["HostNameWhiteList"]));
            }
        }
        
        /// <summary>
        /// Specifies whether session token cache is enabled.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies whether session token cache is enabled.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SessionTokenCachingEnabled {
            get {
                return ((bool)(this["SessionTokenCachingEnabled"]));
            }
        }
        
        /// <summary>
        /// Specifies session token cache TTL in seconds - max recommended value is 60
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies session token cache TTL in seconds - max recommended value is 60")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60")]
        public int SessionTokenCachingTimeToLiveSeconds {
            get {
                return ((int)(this["SessionTokenCachingTimeToLiveSeconds"]));
            }
        }
        
        /// <summary>
        /// Specifies whether authority token cache is enabled.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies whether authority token cache is enabled.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AuthorityTokenCachingEnabled {
            get {
                return ((bool)(this["AuthorityTokenCachingEnabled"]));
            }
        }
        
        /// <summary>
        /// Specifies authority token cache TTL in seconds.  Authority token changes may not take effect until this time elapses.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies authority token cache TTL in seconds.  Authority token changes may not " +
            "take effect until this time elapses.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("180")]
        public int AuthorityTokenCachingTimeToLiveSeconds {
            get {
                return ((int)(this["AuthorityTokenCachingTimeToLiveSeconds"]));
            }
        }
    }
}
