using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace passvault.Models
{
    public class masteruser
    {
        private string masterSalt = "kjuhyykjasdbvfhy";
        public string username { get; set; }
        private string _pass;
        public string password
        {
            get {
                return _pass; 
            }
            set
            {
                this._pass = generatehash(value);
            }
        }

        public void addPass(string hash)
        {
            _pass = hash;
        }

        public bool login(string user, string passkey)
        {
            if (user == username && password == generatehash(passkey))
            {
                return true;
            }
            return false;
        }



        private string generatehash(string key)
        {
            string has; //= Crypter.MD5.Crypt("poi");
            SHA256Managed sha256 = new SHA256Managed();
            sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key+this.masterSalt));
            has = Convert.ToBase64String(sha256.Hash);
            return has;
        }
    }
}
