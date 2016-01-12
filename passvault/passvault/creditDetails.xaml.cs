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
    public partial class creditDetails : PhoneApplicationPage
    {
        creditCards c = new creditCards();
        public creditDetails()
        {
            InitializeComponent();
            

        }


        ////portected override methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            c = PhoneApplicationService.Current.State["param"] as creditCards;
            page_name.Text = c.bankName;
            tb_accountNumb.Text = c.accountNumber;
            tb_cardNumb.Text = c.cardNumber;
            tb_cvvCode.Text = c.getSecurityNumber();
            tb_pincode.Text = c.getPinCode();
            tb_startDate.Text = c.endDate;
            tb_endDate.Text = c.endDate;
        }
    }
}