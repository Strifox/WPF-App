using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Monster
{
    public class Account
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }


        public Account(string userName, string password, string firstname, string lastname)
        {
            Username = userName;
            Firstname = firstname;
            Lastname = lastname;
            if (!string.IsNullOrWhiteSpace(password))
                Salt = Salting.RandomString(new Random().Next(10, 25));
            else
                MessageBox.Show("Cannot use whitespace");
            PasswordHash = Hashing.ComputeSha256Hash(string.Concat(Salt, password));
        }

        public Account(string userName, string password, string firstname, string lastname, int age)
        {
            Username = userName;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            if (!string.IsNullOrWhiteSpace(password))
                Salt = Salting.RandomString(new Random().Next(10, 25));
            else
                MessageBox.Show("Cannot use whitespace");
            PasswordHash = Hashing.ComputeSha256Hash(string.Concat(Salt, password));
        }



        public Account()
        {

        }


    }
}
