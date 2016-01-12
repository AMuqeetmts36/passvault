using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace passvault.Models
{
    class creditCards
    {
        public string accountNumber { get; set; }
        public string bankName { get; set; }
        public string cardNumber { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        private string _securityNumber;
        private string _pinCode;

        public void addSecurityNumber(string secNumb)
        {
            ((App)Application.Current).globalDictionary.addNode(cardNumber + bankName + "securityNumber", secNumb);
            this._securityNumber = generatehash(cardNumber + bankName + "securityNumber");
        }

        public void addPinCode(string pinCode)
        {
            ((App)Application.Current).globalDictionary.addNode(cardNumber + bankName + "pinCode", pinCode);
            this._pinCode = generatehash(cardNumber + bankName + "pinCode");
        }

        public string getSecurityNumber()
        {
            if (this._securityNumber != null)
            {
                return ((App)Application.Current).globalDictionary.getValue(this._securityNumber);
            }
            return null;
        }
        public string getPinCode()
        {
            if (this._pinCode != null)
            {
                return ((App)Application.Current).globalDictionary.getValue(this._pinCode);
            }
            else
                return null;
        }


        //
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
