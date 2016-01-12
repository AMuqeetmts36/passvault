using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CryptSharp;
using passvault.Models;
using Newtonsoft.Json;
using Windows.Security.Cryptography;
using System.IO.IsolatedStorage;
using System.IO;
namespace passvault.Models
{
    class dictNode
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class myDict
    {
        private List<dictNode> hashTab = new List<dictNode>();

        public void addNode(string key, string Value)
        {

            dictNode temp = new dictNode();
            if (!hashTab.Exists(x => x.key == generatehash(key)))
            {
                temp.key = generatehash(key);
                temp.value = Value;
                hashTab.Add(temp);
            }
            
        }

        public void removeNode(string key)
        {
            hashTab.RemoveAll(x => x.key == generatehash(key));
        }


        public string getValue(string key)
        {
            if (hashTab.Count > 0)
            {
                return hashTab.Find(x => x.key == key).value;
            }
            else
                return null;
        }

        public void protect(string FilePath)
        {
            string toProtect = JsonConvert.SerializeObject(hashTab);
            byte[] pinByte = Encoding.UTF8.GetBytes(toProtect);
            byte[] protectedPinByte = ProtectedData.Protect(pinByte,null);
            this.WritePinToFile(protectedPinByte, FilePath);
        }

        public void unProtect(string FilePath)
        {
            byte[] protectedPinByte = this.ReadPinFromFile(FilePath);
            byte[] pinByte = ProtectedData.Unprotect(protectedPinByte, null);
            hashTab = JsonConvert.DeserializeObject<List<dictNode>>(Encoding.UTF8.GetString(pinByte, 0, pinByte.Length));
        }



        // Internal Functions
        private string generatehash(string key)
        {
            string has; //= Crypter.MD5.Crypt("poi");
            SHA1Managed sha1 = new SHA1Managed();
            sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(key));
            has = Convert.ToBase64String(sha1.Hash);
            return has;
        }
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

    }
}
