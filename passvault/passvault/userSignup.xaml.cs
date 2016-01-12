using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows;
using System.Security.Cryptography;
using System.IO.IsolatedStorage;
namespace passvault
{
    public partial class userSignup : PhoneApplicationPage
    {
        public userSignup()
        {
            InitializeComponent();
        }

        private void ab_signup_Click(object sender, EventArgs e)
        {
            if (tb_username != null && tb_password.Password == tb_password2.Password != null && !IsolatedStorageSettings.ApplicationSettings.Contains("usercreated"))
            {
                ((App)Application.Current).m.username = tb_username.Text;
                ((App)Application.Current).m.password = tb_password.Password;
                ((App)Application.Current).userCreated = true;
                ((App)Application.Current).settings.Add("userName", tb_username.Text);
                ((App)Application.Current).settings.Add("password", generatehash(tb_password2.Password));
                ((App)Application.Current).settings.Add("usercreated","true");

                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private string generatehash(string key)
        {
            string has; //= Crypter.MD5.Crypt("poi");
            SHA256Managed sha256 = new SHA256Managed();
            sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key + "kjuhyykjasdbvfhy"));
            has = Convert.ToBase64String(sha256.Hash);
            return has;
        }
    }
}