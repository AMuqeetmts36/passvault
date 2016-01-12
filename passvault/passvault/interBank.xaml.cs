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
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using System.IO.IsolatedStorage;
using System.IO;

namespace passvault
{
    public partial class interBank : PhoneApplicationPage
    {
        ObservableCollection<interb> iBankCollection = new ObservableCollection<interb>();
        string FilePath = "interbInfo";
        public interBank()
        {
            InitializeComponent();
            

            interb t1 = new interb();
            t1.bankName = "Standard Chartered";
            t1.emailAddress = "temp@gnothing.com";
            t1.accountNumbber = "3265987549879";
            t1.userName = "teranova";
            t1.addPassword("hhgsfets");
            t1.phoneNumber = "3336958547";
            iBankCollection.Add(t1);
            iBankList.ItemsSource = iBankCollection;
            iBankList.DataContext = iBankCollection;
        }

        private void tb_clear()
        {
            bankName_txtBox.Text = "";
            acctNumber_txtBox.Text = "";
            emailAddress_txtBox.Text = "";
            userName_txtBox.Text = "";
            password_pswdBox.Password = "";
            mobileNumber_txtBox.Text = "";
        }

        private void ab_add_Click(object sender, EventArgs e)
        {
            if (bankName_txtBox.Text != null && acctNumber_txtBox.Text != null && emailAddress_txtBox.Text != null
                && userName_txtBox != null && password_pswdBox.Password != null && mobileNumber_txtBox != null)
            {
                interb temp = new interb();
                temp.bankName = bankName_txtBox.Text;
                temp.accountNumbber = acctNumber_txtBox.Text;
                temp.emailAddress = emailAddress_txtBox.Text;
                temp.userName = userName_txtBox.Text;
                temp.addPassword(password_pswdBox.Password);
                temp.phoneNumber = mobileNumber_txtBox.Text;
                iBankCollection.Add(temp);
                iBankList.ItemsSource = iBankCollection;
                tb_clear();

            }
            else
            {
                MessageBox.Show("Please Enter Required Values", "Error", MessageBoxButton.OK);
            }

        }

        private void ab_cancel_Click(object sender, EventArgs e)
        {
            tb_clear();
        }

        ///Protected Override methods
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IsolatedStorageFile fs = IsolatedStorageFile.GetUserStoreForApplication();
            if (fs.FileExists(FilePath))
            {
                this.unProtect(FilePath);
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            this.protect(FilePath);
        }


        /////
        public void protect(string FilePath)
        {
            string toProtect = JsonConvert.SerializeObject(iBankCollection);
            byte[] pinByte = Encoding.UTF8.GetBytes(toProtect);
            byte[] protectedPinByte = ProtectedData.Protect(pinByte, null);
            this.WritePinToFile(protectedPinByte, FilePath);
        }

        public void unProtect(string FilePath)
        {
            byte[] protectedPinByte = this.ReadPinFromFile(FilePath);
            byte[] pinByte = ProtectedData.Unprotect(protectedPinByte, null);
            iBankCollection = JsonConvert.DeserializeObject<ObservableCollection<interb>>(Encoding.UTF8.GetString(pinByte, 0, pinByte.Length));
        }



        // Internal Functions
        private void WritePinToFile(byte[] pinData, String FilePath)
        {
            // Create a file in the application's isolated storage.
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream writestream = new IsolatedStorageFileStream(FilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, file);

            // Write pinData to the file.
            Stream writer = new StreamWriter(writestream).BaseStream;
            writer.Write(pinData, 0, pinData.Length);
            writer.Close();
            writestream.Close();
        }

        private byte[] ReadPinFromFile(string FilePath)
        {
            // Access the file in the application's isolated storage.
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream readstream = new IsolatedStorageFileStream(FilePath, System.IO.FileMode.Open, FileAccess.Read, file);

            // Read the PIN from the file.
            Stream reader = new StreamReader(readstream).BaseStream;
            byte[] pinArray = new byte[reader.Length];

            reader.Read(pinArray, 0, pinArray.Length);
            reader.Close();
            readstream.Close();

            return pinArray;
        }

        private void iBankList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            interb slectedItem = iBankList.SelectedItem as interb;
            PhoneApplicationService.Current.State["param"] = slectedItem;
            NavigationService.Navigate(new Uri("/interBankDetails.xaml", UriKind.Relative));
        }
    }
}