using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace passvault.Models
{
    class websites
    {
        public string webAddress { get; set; }
        public string emailAddress { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string secQuestion { get; set; }
        public string secAnswer { get; set; }

        private string _password;
        private string _secAnswer;

        public void addPassword(string pass)
        {
            this._password = generatehash(username + webAddress + "password");
            ((App)Application.Current).globalDictionary.addNode(username + webAddress + "password", pass);
        }

        public void addSecAnswer(string secAns)
        {
            this._secAnswer = generatehash(username + webAddress + "secAnswer");
            ((App)Application.Current).globalDictionary.addNode(username + webAddress + "secAnswer", secAns);
        }

        public string getPassword()
        {
            if (this._password != null)
            {
                return ((App)Application.Current).globalDictionary.getValue(this._password);
            }
            return null;
        }

        public string getSecAnswer()
        {
            if (this._secAnswer != null)
            {
                return ((App)Application.Current).globalDictionary.getValue(this._secAnswer);
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
