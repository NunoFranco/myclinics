﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Ris.Client {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class FormatSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static FormatSettings defaultInstance = ((FormatSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new FormatSettings())));
        
        public static FormatSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Mask used on healthcard number input fields
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on healthcard number input fields")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0000 000 000")]
        public string HealthcardNumberMask {
            get {
                return ((string)(this["HealthcardNumberMask"]));
            }
        }
        
        /// <summary>
        /// Mask used on healthcard version code input field
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on healthcard version code input field")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LL")]
        public string HealthcardVersionCodeMask {
            get {
                return ((string)(this["HealthcardVersionCodeMask"]));
            }
        }
        
        /// <summary>
        /// Mask used on local telephone number input fields
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on local telephone number input fields")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("000-0000")]
        public string TelephoneNumberLocalMask {
            get {
                return ((string)(this["TelephoneNumberLocalMask"]));
            }
        }
        
        /// <summary>
        /// Mask used on full telephone number input fields
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask used on full telephone number input fields")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("(000) 000-0000")]
        public string TelephoneNumberFullMask {
            get {
                return ((string)(this["TelephoneNumberFullMask"]));
            }
        }
        
        /// <summary>
        /// Default display format for person names
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for person names")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%F, %G %M")]
        public string PersonNameDefaultFormat {
            get {
                return ((string)(this["PersonNameDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for healthcard numbers
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for healthcard numbers")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%A %N %V")]
        public string HealthcardDefaultFormat {
            get {
                return ((string)(this["HealthcardDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for addresses
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for addresses")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%S, %V %P %Z")]
        public string AddressDefaultFormat {
            get {
                return ((string)(this["AddressDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Country-code to suppress in display (all other country codes will be shown)
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Country-code to suppress in display (all other country codes will be shown)")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public string TelephoneNumberSuppressCountryCode {
            get {
                return ((string)(this["TelephoneNumberSuppressCountryCode"]));
            }
        }
        
        /// <summary>
        /// Default display format for telephone numbers
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for telephone numbers")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%c (%A) %N %X")]
        public string TelephoneNumberDefaultFormat {
            get {
                return ((string)(this["TelephoneNumberDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for MRN
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for MRN")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%A %N")]
        public string MrnDefaultFormat {
            get {
                return ((string)(this["MrnDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for Visit Number
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for Visit Number")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%A %N")]
        public string VisitNumberDefaultFormat {
            get {
                return ((string)(this["VisitNumberDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for external practitioner contact point
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for external practitioner contact point")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%N (%A ph:%T fx:%F Em:%E)")]
        public string ExternalPractitionerContactPointDefaultFormat {
            get {
                return ((string)(this["ExternalPractitionerContactPointDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Default display format for accession numbers.  Eligible placeholders are:  &apos;%N&apos; number (masked);  &apos;%n&apos; number (unmasked);  &apos;%L&apos; label
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for accession numbers.  Eligible placeholders are:  \'%N\' n" +
            "umber (masked);  \'%n\' number (unmasked);  \'%L\' label")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%L %N")]
        public string AccessionNumberDefaultFormat {
            get {
                return ((string)(this["AccessionNumberDefaultFormat"]));
            }
        }
        
        /// <summary>
        /// Text substited for the &apos;%L&apos; placeholder in an Accession number format string
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Text substited for the \'%L\' placeholder in an Accession number format string")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("A#")]
        public string AccessionNumberLabel {
            get {
                return ((string)(this["AccessionNumberLabel"]));
            }
        }
        
        /// <summary>
        /// Mask applied to the &apos;%N&apos; placeholder in an Accession number format string
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Mask applied to the \'%N\' placeholder in an Accession number format string")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("000000000 ")]
        public string AccessionNumberMask {
            get {
                return ((string)(this["AccessionNumberMask"]));
            }
        }
        
        /// <summary>
        /// Default display format for procedures
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Default display format for procedures")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%P/%L")]
        public string ProcedurePortableLateralityDefaultFormat {
            get {
                return ((string)(this["ProcedurePortableLateralityDefaultFormat"]));
            }
        }
    }
}