using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace passvault.Models
{
    class interb
    {
        public string accountNumbber { get; set; }
        public string bankName { get; set; }
        public string emailAddress { get; set; }
        public string userName { get; set; }
        public string phoneNumber { get; set; }

        private string _passwrod;

        public void addPassword(string pass)
        {
            _passwrod = generatehash(this.accountNumbber + userName + "bankPassword");
            ((App)Application.Current).globalDictionary.addNode(this.accountNumbber + userName + "bankPassword", pass);
        }
        public string getPassword()
        {
            if (this._passwrod != null)
            {
                return ((App)Application.Current).globalDictionary.getValue(this._passwrod);
            }
            return null;
        }



        private string generatehash(string key)
        {
            string has; //= Crypter.MD5.Crypt("poi");
            SHA1Managed sha1 = new SHA1Managed();
            sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));
            has = Convert.ToBase64String(sha1.Hash);
            return has;
        }
    }
}
