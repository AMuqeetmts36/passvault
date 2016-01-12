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
    public partial class credit : PhoneApplicationPage
    {
        ObservableCollection<creditCards> cardsCollection = new ObservableCollection<creditCards>();
        string FilePath = "cardInfo";
        public credit()
        {
            InitializeComponent();
            creditlist.ItemsSource = cardsCollection;

            creditCards t1 = new creditCards();
            t1.bankName = "Allied Bank";
            t1.cardNumber = "22365895";
            t1.addPinCode("1147");
            t1.addSecurityNumber("123");
            cardsCollection.Add(t1);
            creditlist.DataContext = cardsCollection;
        }

        private void ab_add_Click(object sender, EventArgs e)
        {
            if (bankName_txtBox.Text != null && cardNumber_txtBox.Text != null && secNumber_txtBox.Text != null
                && pinCode_pswdBox.Password != null && startDate_dtPicker1.Value.HasValue && endDate_dtPicker.Value.HasValue)
            {
                creditCards temp = new creditCards();
                temp.bankName = bankName_txtBox.Text;
                temp.cardNumber = cardNumber_txtBox.Text;
                temp.accountNumber = acctNumber_txtBox.Text;
                temp.addSecurityNumber(secNumber_txtBox.Text);
                temp.addPinCode(pinCode_pswdBox.Password);
                temp.startDate = startDate_dtPicker1.ValueString;
                temp.endDate = endDate_dtPicker.ValueString;

                cardsCollection.Add(temp);
                creditlist.ItemsSource = cardsCollection;
                tb_clear();
            }
            else
            {
                MessageBox.Show("Please Enter Required Values", "Error", MessageBoxButton.OK);
            }
            
        }

        private void tb_clear()
        {
            bankName_txtBox.Text = "";
            cardNumber_txtBox.Text = "";
            acctNumber_txtBox.Text = "";
            secNumber_txtBox.Text = "";
            pinCode_pswdBox.Password = "";
            startDate_dtPicker1.ValueString = "Start Date";
            endDate_dtPicker.ValueString = "End date";
        }

        /////overloaded deafult functions of the page
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IsolatedStorageFile fs = IsolatedStorageFile.GetUserStoreForApplication();
            if(fs.FileExists(FilePath))
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
            string toProtect = JsonConvert.SerializeObject(cardsCollection);
            byte[] pinByte = Encoding.UTF8.GetBytes(toProtect);
            byte[] protectedPinByte = ProtectedData.Protect(pinByte, null);
            this.WritePinToFile(protectedPinByte, FilePath);
        }

        public void unProtect(string FilePath)
        {
            byte[] protectedPinByte = this.ReadPinFromFile(FilePath);
            byte[] pinByte = ProtectedData.Unprotect(protectedPinByte, null);
            cardsCollection = JsonConvert.DeserializeObject<ObservableCollection<creditCards>>(Encoding.UTF8.GetString(pinByte, 0, pinByte.Length));
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

        private void creditlist_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

        private void creditlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //creditCards tapItem = ((FrameworkElement)e.OriginalSource).DataContext as creditCards;
            creditCards slectedItem = creditlist.SelectedItem as creditCards;
            PhoneApplicationService.Current.State["param"] = slectedItem;
            NavigationService.Navigate(new Uri("/creditDetails.xaml", UriKind.Relative));
        }
    }
}