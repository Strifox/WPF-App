using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;

namespace Monster
{
    public class Account
    {
        private int id { get; set; }
        private string username { get; set; }
        private string salt { get; set; }
        private string passwordHash { get; set; }
        
        public int Id { get => id; set => value = id; }
        public string Username { get => username; set => value = username; }
        public string PasswordHash { get => passwordHash; set => value = passwordHash; }
        public string Salt { get => salt; set => value = salt; }

        public Account(string userName, string password)
        {
            username = userName;
            salt = Salting.RandomString(new Random().Next(10, 25));
            passwordHash = Hashing.ComputeSha256Hash(string.Concat(salt, password));
        }

        public Account(string userName, string password, string salt)
        {
            username = userName;
            this.salt = salt;
            passwordHash = password;
        }

        public Account()
        {

        }

      
    }
}
