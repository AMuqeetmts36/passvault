﻿#pragma checksum "E:\Documents\Visual Studio 2013\Projects\passvault\passvault\interBankDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3BDD732EA1E878C815009CC9454E9B7B"
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


namespace passvault {
    
    
    public partial class interBankDetails : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock page_name;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock tb_accountNumb;
        
        internal System.Windows.Controls.TextBlock tb_email;
        
        internal System.Windows.Controls.TextBlock tb_userName;
        
        internal System.Windows.Controls.TextBlock tb_password;
        
        internal System.Windows.Controls.TextBlock tb_cell;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/passvault;component/interBankDetails.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.page_name = ((System.Windows.Controls.TextBlock)(this.FindName("page_name")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.tb_accountNumb = ((System.Windows.Controls.TextBlock)(this.FindName("tb_accountNumb")));
            this.tb_email = ((System.Windows.Controls.TextBlock)(this.FindName("tb_email")));
            this.tb_userName = ((System.Windows.Controls.TextBlock)(this.FindName("tb_userName")));
            this.tb_password = ((System.Windows.Controls.TextBlock)(this.FindName("tb_password")));
            this.tb_cell = ((System.Windows.Controls.TextBlock)(this.FindName("tb_cell")));
        }
    }
}

