﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tests {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class TestSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static TestSettings defaultInstance = ((TestSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new TestSettings())));
        
        public static TestSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int DbType {
            get {
                return ((int)(this["DbType"]));
            }
            set {
                this["DbType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1433")]
        public int DbPort {
            get {
                return ((int)(this["DbPort"]));
            }
            set {
                this["DbPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ServiceName {
            get {
                return ((string)(this["ServiceName"]));
            }
            set {
                this["ServiceName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("alex_cr_ver_db17")]
        public string DbSchemaName {
            get {
                return ((string)(this["DbSchemaName"]));
            }
            set {
                this["DbSchemaName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sa")]
        public string DbUsername {
            get {
                return ((string)(this["DbUsername"]));
            }
            set {
                this["DbUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mercurypw12")]
        public string DbPassword {
            get {
                return ((string)(this["DbPassword"]));
            }
            set {
                this["DbPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("myd-vm19717.hpeswlab.net")]
        public string AlmServer {
            get {
                return ((string)(this["AlmServer"]));
            }
            set {
                this["AlmServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("myd-vm04111")]
        public string DbServer {
            get {
                return ((string)(this["DbServer"]));
            }
            set {
                this["DbServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8080")]
        public int AlmPort {
            get {
                return ((int)(this["AlmPort"]));
            }
            set {
                this["AlmPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ALEX")]
        public string Domain {
            get {
                return ((string)(this["Domain"]));
            }
            set {
                this["Domain"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("cr_ver")]
        public string Project {
            get {
                return ((string)(this["Project"]));
            }
            set {
                this["Project"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sa")]
        public string AlmAdminName {
            get {
                return ((string)(this["AlmAdminName"]));
            }
            set {
                this["AlmAdminName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AlmAdminPassword {
            get {
                return ((string)(this["AlmAdminPassword"]));
            }
            set {
                this["AlmAdminPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsHttps {
            get {
                return ((bool)(this["IsHttps"]));
            }
            set {
                this["IsHttps"] = value;
            }
        }
    }
}