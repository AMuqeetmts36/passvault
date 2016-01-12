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
    public partial class testPage : PhoneApplicationPage
    {
        public myDict ter = new myDict();
        public testPage()
        {
            InitializeComponent();
        }

        private void insertBut_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).globalDictionary.addNode(tb_key.Text, tb_value.Password);
            tb_key.Text = "";
            tb_value.Password = "";
        }

        private void removeBut_Click(object sender, RoutedEventArgs e)
        {
            ter.removeNode(tb_key.Text);
            tb_key.Text = "";
        }

        private void getBut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Value is :"+((App)Application.Current).globalDictionary.getValue(tb_key.Text));
        }
    }
}