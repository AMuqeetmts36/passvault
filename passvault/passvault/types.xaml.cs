using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace passvault
{
    public partial class types : PhoneApplicationPage
    {
        public types()
        {
            InitializeComponent();
        }

        private void hubTile_website_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/website.xaml", UriKind.Relative));
        }

        private void hubTile_credit_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/credit.xaml",UriKind.Relative));
        }

        private void hubTile_ibanking_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/interBank.xaml", UriKind.Relative));
        }
    }
}