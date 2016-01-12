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
    public partial class website : PhoneApplicationPage
    {
        // Global Variables
        ObservableCollection<websites> webcollection = new ObservableCollection<websites>();
        string FilePath = "webInfo";
        
         
        
        public website()
        {
            InitializeComponent();
            weblist.ItemsSource = webcollection;
            websites t1 = new websites();
            t1.webAddress = "gsarena.com";
            t1.username = "teranova";
            t1.addPassword("wetgdfre");
            t1.secQuestion = "What is Williams GPE?";
            t1.addSecAnswer("F1 Racing Team");
            webcollection.Add(t1);
        }

        private void ab_cancel_Click(object sender, EventArgs e)
        {
            websiteAddress_txtBox.Text = "";
            username_txtBox.Text = "";
            emailAddress_txtBox.Text = "";
            password_pswdBox.Password = "";
            secQuestion_txtBox.Text = "";
            secAnswer_txtBox.Text = "";
        }

        private void ab_add_Click(object sender, EventArgs e)
        {
            if (websiteAddress_txtBox.Text != null && username_txtBox.Text != null && password_pswdBox.Password != null)
            {
                websites temp = new websites();
                temp.webAddress = websiteAddress_txtBox.Text;
                temp.emailAddress = emailAddress_txtBox.Text;
                temp.username = username_txtBox.Text;
                //temp.password = password_pswdBox.Password;
                temp.addPassword(password_pswdBox.Password);
                temp.secQuestion = secQuestion_txtBox.Text;
                //temp.secAnswer = secAnswer_txtBox.Text;
                temp.addSecAnswer(secAnswer_txtBox.Text);

                webcollection.Add(temp);
                weblist.ItemsSource = webcollection;
                tb_clear();
            }
            else
            {
                MessageBox.Show("Please Enter Required Values", "Error", MessageBoxButton.OK);
            }
            
            
        }

        private void tb_clear()
        {
            websiteAddress_txtBox.Text = "";
            emailAddress_txtBox.Text = "";
            username_txtBox.Text = "";
            password_pswdBox.Password = "";
            secQuestion_txtBox.Text = "";
            secAnswer_txtBox.Text = "";
        }

        // Protected Override Methods

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
            string toProtect = JsonConvert.SerializeObject(webcollection);
            byte[] pinByte = Encoding.UTF8.GetBytes(toProtect);
            byte[] protectedPinByte = ProtectedData.Protect(pinByte, null);
            this.WritePinToFile(protectedPinByte, FilePath);
        }

        public void unProtect(string FilePath)
        {
            byte[] protectedPinByte = this.ReadPinFromFile(FilePath);
            byte[] pinByte = ProtectedData.Unprotect(protectedPinByte, null);
            webcollection = JsonConvert.DeserializeObject<ObservableCollection<websites>>(Encoding.UTF8.GetString(pinByte, 0, pinByte.Length));
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

        private void weblist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            websites slectedItem = weblist.SelectedItem as websites;
            PhoneApplicationService.Current.State["param"] = slectedItem;
            NavigationService.Navigate(new Uri("/webDetails.xaml", UriKind.Relative));
        }
    }
}