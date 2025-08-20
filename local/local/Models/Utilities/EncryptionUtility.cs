using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace local.Models.Utilities
{
    internal class EncryptionUtility
    {

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("0123456789ABCDEF");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("FEDCBA9876543210");

        public static string Encrypt(string text)
        {
            using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                using MemoryStream ms = new();
                using CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(text);


                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                byte[] buffer = Convert.FromBase64String(cipherText);
                using MemoryStream ms = new MemoryStream(buffer);
                using CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
                using StreamReader sr = new(cs);
                return sr.ReadToEnd();
            }
        }
    }
}
