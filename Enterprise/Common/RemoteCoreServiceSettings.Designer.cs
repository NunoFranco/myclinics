﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5456
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Enterprise.Common {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class RemoteCoreServiceSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static RemoteCoreServiceSettings defaultInstance = ((RemoteCoreServiceSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new RemoteCoreServiceSettings())));
        
        public static RemoteCoreServiceSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ClearCanvas.Enterprise.Common.ServiceConfiguration.Client.NetTcpConfiguration, Cl" +
            "earCanvas.Enterprise.Common")]
        public string ConfigurationClass {
            get {
                return ((string)(this["ConfigurationClass"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4000000")]
        public int MaxReceivedMessageSize {
            get {
                return ((int)(this["MaxReceivedMessageSize"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("PeerOrChainTrust")]
        public global::System.ServiceModel.Security.X509CertificateValidationMode CertificateValidationMode {
            get {
                return ((global::System.ServiceModel.Security.X509CertificateValidationMode)(this["CertificateValidationMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("NoCheck")]
        public global::System.Security.Cryptography.X509Certificates.X509RevocationMode RevocationMode {
            get {
                return ((global::System.Security.Cryptography.X509Certificates.X509RevocationMode)(this["RevocationMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserCredentialsProviderClass {
            get {
                return ((string)(this["UserCredentialsProviderClass"]));
            }
        }
        
        /// <summary>
        /// Optional failover base URL (see BaseURL property)
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Optional failover base URL (see BaseURL property)")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string FailoverBaseUrl {
            get {
                return ((string)(this["FailoverBaseUrl"]));
            }
        }
        
        /// <summary>
        /// Base URL that hosts the remote core services
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Base URL that hosts the remote core services")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("net.tcp://longca-PC:8000/")]
        public string BaseUrl {
            get {
                return ((string)(this["BaseUrl"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100000")]
        public int MaxItemsInObjectGraph {
            get {
                return ((int)(this["MaxItemsInObjectGraph"]));
            }
        }
    }
}
