using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Monster
{
    public class Account
    {
        private string accountName { get; set; }
        private string salt { get; set; }
        private string passwordHash { get; set; }
        
        public string AccountName { get => accountName;}
        public string PasswordHash { get => passwordHash; }
        public string Salt { get => salt; }

        public Account(string accountName, string password)
        {
            this.accountName = accountName;
            salt = RandomString(new Random().Next(15, 40));
            passwordHash = ComputeSha256Hash(string.Concat(Salt, password));
        }

        public Account(string accountName, string password, string salt)
        {
            this.accountName = accountName;
            this.salt = salt;
            passwordHash = password;
        }

        public Account()
        {

        }

        private static string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder builder = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    builder.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return builder.ToString();
        }
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
