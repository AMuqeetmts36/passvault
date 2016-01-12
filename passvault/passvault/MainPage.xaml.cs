using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using passvault.Resources;
using passvault.Models;
using Windows.Security.Credentials;
using System.IO.IsolatedStorage;

namespace passvault
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            InitializeComponent();
            if (!((App)Application.Current).userCreated)
            {
                NavigationService.Navigate(new Uri("/userSignup.xaml", UriKind.Relative));
            }
        }
        private void ab_login_click(object sender, EventArgs e)
        {
            //MessageBox.Show("Works");

            bool check = ((App)Application.Current).m.login(tb_username.Text, tb_password.Password);

            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            NavigationService.Navigate(new Uri("/types.xaml", UriKind.Relative));
            if (((App)Application.Current).isLoggedIn == false && store.FileExists(((App)Application.Current).FilePath))
            {

                ((App)Application.Current).globalDictionary.unProtect(((App)Application.Current).FilePath);
            }
                
        }

        private void del_test_Click(object sender, EventArgs e)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            if (store.FileExists(((App)Application.Current).FilePath))
            {
                store.DeleteFile(((App)Application.Current).FilePath);
            }
        }
    }
}