﻿#pragma checksum "E:\Documents\Visual Studio 2013\Projects\passvault\passvault\userSignup.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "993CB2C8245A64CB7FE30C1A029472C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using Telerik.Windows.Controls;


namespace passvault {
    
    
    public partial class userSignup : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton ab_signup;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Telerik.Windows.Controls.RadTextBox tb_username;
        
        internal Telerik.Windows.Controls.RadPasswordBox tb_password;
        
        internal Telerik.Windows.Controls.RadPasswordBox tb_password2;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/passvault;component/userSignup.xaml", System.UriKind.Relative));
            this.ab_signup = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("ab_signup")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.tb_username = ((Telerik.Windows.Controls.RadTextBox)(this.FindName("tb_username")));
            this.tb_password = ((Telerik.Windows.Controls.RadPasswordBox)(this.FindName("tb_password")));
            this.tb_password2 = ((Telerik.Windows.Controls.RadPasswordBox)(this.FindName("tb_password2")));
        }
    }
}
