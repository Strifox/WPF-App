using Monster.Login.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Monster
{
    class Operations
    {
        private AccountContext context = new AccountContext();

        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>A Tuple where Item1 is a boolean (true == valid password; false otherwise).
        /// And Item2 is the message validating the password.</returns>
        public static Tuple<bool, string> IsValidPassword(string password, TextBlock textBlock)
        {
            if (password.Contains(" "))
                return new Tuple<bool, string>(false, textBlock.Text = "Password cannot contain white spaces.");

            if (!password.Any(char.IsNumber))
                return new Tuple<bool, string>(false, textBlock.Text = "Password must contain at least one numeric char.");
            
            // perhaps the requirements meant to be 1 capital letter?
            //if (password.Count(char.IsUpper) != 1)
            if (!password.Any(char.IsUpper))
                return new Tuple<bool, string>(false, textBlock.Text = "Password must contain at least 1 capital letter.");

            if (password.Length < 8)
                return new Tuple<bool, string>(false, textBlock.Text = "Password is too short, must be\n at least 8 characters.");
            
            //if (password.Length > 15)
            //{
            //    return new Tuple<bool, string>(false, textBlock.Text = "Password is too long; must be no more than 15 characters (8 min).");
            //}
            return new Tuple<bool, string>(true, textBlock.Text = string.Empty);
        }

        public Account AuthenticateUser(string username, string password)
        {
            Account account = new Account();
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                    return account = null;

                if (Queries.DoesPlayerExistWithName(context, username.ToLower()))
                {
                    account = Queries.GetAccountByName(context, username.ToLower());

                    string saltedPassword = string.Concat(account.Salt, password);
                    string hashedPassword = Hashing.ComputeSha256Hash(saltedPassword);

                    bool matchedPassword = string.Equals(account.PasswordHash, hashedPassword);

                    if (matchedPassword)
                    {
                        account.PasswordHash = hashedPassword;
                        Globals.LoggedInUser = account;
                        return account;
                    }
                    else
                    {
                        return account = null;
                    }
                }
                return account = null;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Account RegisterUserWithoutAge(string username, string password, string firstname, string lastname, TextBlock textBlock)
        {
            Account account = new Account(username.ToLower(), password, firstname, lastname);
            try
            {
                if (!Queries.DoesPlayerExistWithName(context, account.Username))
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    textBlock.Text = "Account successfully created";
                    return account;
                }
                else
                {
                    textBlock.Text = "Username already exists";
                    return account = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Account RegisterUserWithAge(string username, string password, string firstname, string lastname, int age, TextBlock textBlock)
        {
            Account account = new Account(username.ToLower(), password, firstname, lastname, age);
            try
            {
                if (!Queries.DoesPlayerExistWithName(context, account.Username))
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    textBlock.Text = "Account successfully created";
                    return account;
                }
                else
                {
                    textBlock.Text = "Username already exists";
                    return account = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
