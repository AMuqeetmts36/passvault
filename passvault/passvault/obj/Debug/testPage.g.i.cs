﻿#pragma checksum "E:\Documents\Visual Studio 2013\Projects\passvault\passvault\testPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D7E53724CF1F84C8DE7FB4CBA71AF23"
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
    
    
    public partial class testPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Telerik.Windows.Controls.RadTextBox tb_key;
        
        internal Telerik.Windows.Controls.RadPasswordBox tb_value;
        
        internal System.Windows.Controls.Button insertBut;
        
        internal System.Windows.Controls.Button removeBut;
        
        internal System.Windows.Controls.Button getBut;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/passvault;component/testPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.tb_key = ((Telerik.Windows.Controls.RadTextBox)(this.FindName("tb_key")));
            this.tb_value = ((Telerik.Windows.Controls.RadPasswordBox)(this.FindName("tb_value")));
            this.insertBut = ((System.Windows.Controls.Button)(this.FindName("insertBut")));
            this.removeBut = ((System.Windows.Controls.Button)(this.FindName("removeBut")));
            this.getBut = ((System.Windows.Controls.Button)(this.FindName("getBut")));
        }
    }
}

