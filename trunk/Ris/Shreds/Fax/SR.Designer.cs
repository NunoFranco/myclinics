﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Ris.Shreds.Fax {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SR {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SR() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ClearCanvas.Ris.Shreds.Fax.SR", typeof(SR).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to create or write to the following directory: {0}.
        /// </summary>
        internal static string ExceptionFailedToCreateOrWriteToDirectory {
            get {
                return ResourceManager.GetString("ExceptionFailedToCreateOrWriteToDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to parse meta data file..
        /// </summary>
        internal static string ExceptionFailedToParseMetaDataFile {
            get {
                return ResourceManager.GetString("ExceptionFailedToParseMetaDataFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An active FaxMachine with the phone number {0} cannot be found..
        /// </summary>
        internal static string MessageErrorFaxMachineNotFound {
            get {
                return ResourceManager.GetString("MessageErrorFaxMachineNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fax metadata file is empty..
        /// </summary>
        internal static string MessageMetaDataFileEmpty {
            get {
                return ResourceManager.GetString("MessageMetaDataFileEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fax metadata does not contain required fields..
        /// </summary>
        internal static string MessageRequiredFieldsMissing {
            get {
                return ResourceManager.GetString("MessageRequiredFieldsMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This shred hosts the IncomingFaxProcessor and FaxStorageWorkQueueProcessor, which are responsible for turning incoming faxes into ReceivedFax entities..
        /// </summary>
        internal static string ReceivedFaxShredDescription {
            get {
                return ResourceManager.GetString("ReceivedFaxShredDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Received Fax.
        /// </summary>
        internal static string ReceivedFaxShredName {
            get {
                return ResourceManager.GetString("ReceivedFaxShredName", resourceCulture);
            }
        }
    }
}