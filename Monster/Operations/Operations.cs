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
                else
                    MessageBox.Show("Username already exists");
            }
            catch (Exception)
            {
                throw;
            }
            return account;
        }


        public Account RegisterUserWithoutAge(string username, string password, string firstname, string lastname)
        {
            Account account = new Account(username, password, firstname, lastname);
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

        public Account RegisterUserAge(string username, string password, string firstname, string lastname, int age)
        {
            Account account = new Account(username, password, firstname, lastname, age);
            try
            {
                if (!Queries.DoesPlayerExistWithName(context, account.Username))
                {
                    context.Accounts.Add(account);
                    context.SaveChanges();

                    Globals.LoggedInUser = account;
                    MessageBox.Show("Registration successful");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return account;
        }

        public void CheckTextBox(TextBox textBox,TextBlock textBlock )
        {
            RegisterPage page = new RegisterPage();
            if (string.IsNullOrEmpty(textBox.Text) || string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBlock.Text = "required";
                textBlock.Margin = new Thickness(Convert.ToDouble(1), Convert.ToDouble(5), Convert.ToDouble(0), Convert.ToDouble(0));
            }
            else
            {
                textBlock.Text = "*";
                textBlock.Margin = new Thickness(Convert.ToDouble(1), Convert.ToDouble(-5), Convert.ToDouble(0), Convert.ToDouble(0));
            }
        }

        public void CheckPasswordBox(PasswordBox passwordBox, TextBlock textBlock)
        {
            RegisterPage page = new RegisterPage();
            if (string.IsNullOrEmpty(passwordBox.Password) || string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                textBlock.Text = "required";
                textBlock.Margin = new Thickness(Convert.ToDouble(1), Convert.ToDouble(5), Convert.ToDouble(0), Convert.ToDouble(0));
            }
            else
            {
                textBlock.Text = "*";
                textBlock.Margin = new Thickness(Convert.ToDouble(1), Convert.ToDouble(-5), Convert.ToDouble(0), Convert.ToDouble(0));
            }
        }

    }
}
