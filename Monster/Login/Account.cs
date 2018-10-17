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
        
        private string id { get; set; }
        private string accountName { get; set; }
        private string salt { get; set; }
        private string passwordHash { get; set; }
        
        public string Id { get => id; set => value = id; }
        public string AccountName { get => accountName;}
        public string PasswordHash { get => passwordHash; }
        public string Salt { get => salt; }

        public Account(string accountName, string password)
        {
            this.accountName = accountName;
            salt = Salting.RandomString(new Random().Next(15, 40));
            passwordHash = Hashing.ComputeSha256Hash(string.Concat(Salt, password));
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

      
    }
}
