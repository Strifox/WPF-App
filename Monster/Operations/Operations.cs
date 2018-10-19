using Monster.Login.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Monster
{
    class Operations
    {
        private AccountContext context = new AccountContext();

        public Operations()
        {

        }

        public Account AuthenticateUser(string username, string password)
        {
            Account account = new Account();
            try
            {
                if (Queries.DoesPlayerExistWithName(context, username))
                {
                    account = Queries.GetAccountByName(context, username);

                    string saltedPassword = string.Concat(account.Salt, password);
                    string hashedPassword = Hashing.ComputeSha256Hash(saltedPassword);

                    bool matchedPassword = string.Equals(account.PasswordHash, hashedPassword);

                    if (matchedPassword)
                    {
                        Globals.LoggedInUser = account;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return account;
        }


        public Account RegisterUser(string username, string password)
        {
            Account account = new Account(username, password);
            try
            {
                if (!Queries.DoesPlayerExistWithName(context, account.Username))
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();

                    Globals.LoggedInUser = account;
                    MessageBox.Show("Registration successful");

                }
                else
                    MessageBox.Show("Username already exists");
            }
            catch (Exception)
            {
                throw;
            }
            return account;
        }

    }
}
