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
    public partial class webDetails : PhoneApplicationPage
    {
        websites w = new websites();
        public webDetails()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            w = PhoneApplicationService.Current.State["param"] as websites;
            base.OnNavigatedTo(e);
            page_name.Text = w.webAddress;
            tb_email.Text = w.emailAddress;
            tb_userName.Text = w.username;
            tb_password.Text = w.getPassword();
            tb_secQuestion.Text = w.secQuestion;
            tb_secAnswer.Text = w.getSecAnswer();
        }
    }
}