using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using passvault.Models;

namespace passvault
{
    public partial class interBankDetails : PhoneApplicationPage
    {
        interb b = new interb();
        public interBankDetails()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            b = PhoneApplicationService.Current.State["param"] as interb;
            page_name.Text = b.bankName;
            tb_accountNumb.Text = b.accountNumbber;
            tb_email.Text = b.emailAddress;
            tb_userName.Text = b.userName;
            tb_password.Text = b.getPassword();
            tb_cell.Text = b.phoneNumber;
        }
    }
}