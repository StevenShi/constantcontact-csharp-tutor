﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSharpTutor.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CSharpTutor.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Please check the response section for more information!.
        /// </summary>
        internal static string CheckResponseMessage {
            get {
                return ResourceManager.GetString("CheckResponseMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter all the needed credentials!.
        /// </summary>
        internal static string LoginNoCredentials {
            get {
                return ResourceManager.GetString("LoginNoCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C# Tutor.
        /// </summary>
        internal static string MessageBoxTitle {
            get {
                return ResourceManager.GetString("MessageBoxTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a contact..
        /// </summary>
        internal static string SelectContactMessage {
            get {
                return ResourceManager.GetString("SelectContactMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a email list..
        /// </summary>
        internal static string SelectListMessage {
            get {
                return ResourceManager.GetString("SelectListMessage", resourceCulture);
            }
        }
    }
}
