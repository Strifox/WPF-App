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
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>A Tuple where Item1 is a boolean (true == valid password; false otherwise).
        /// And Item2 is the message validating the password.</returns>
        public Tuple<bool, MessageBoxResult> IsValidPassword(string password)
        {
            if (password.Contains(" "))
            {
                return new Tuple<bool, MessageBoxResult>(false, MessageBox.Show("Password cannot contain white spaces."));
            }

            if (!password.Any(char.IsNumber))
            {
                return new Tuple<bool, MessageBoxResult>(false, MessageBox.Show("Password must contain at least one numeric char."));
            }
            // perhaps the requirements meant to be 1 or more capital letters?
            // if( !password.Any( char.IsUpper ) )
            if (password.Count(char.IsUpper) != 1)
            {
                return new Tuple<bool, MessageBoxResult>(false, MessageBox.Show("Password must contain only 1 capital letter."));
            }
            if (password.Length < 8)
            {
                return new Tuple<bool, MessageBoxResult>(false, MessageBox.Show("Password is too short; must be at least 8 characters (15 max)."));
            }

            if (password.Length > 15)
            {
                return new Tuple<bool, MessageBoxResult>(false, MessageBox.Show("Password is too long; must be no more than 15 characters (8 min)."));
            }

            return new Tuple<bool, MessageBoxResult>(true, MessageBox.Show("Password is valid."));
        }


        public Account AuthenticateUser(string username, string password)
        {
            Account account = new Account();
            try
            {
                if (Queries.DoesPlayerExistWithName(context, username))
                {
                    account = Queries.GetAccountByName(context, username);

                    if (IsValidPassword(password).Item1)
                    {
                        string saltedPassword = string.Concat(account.Salt, password);
                        string hashedPassword = Hashing.ComputeSha256Hash(saltedPassword);

                        bool matchedPassword = string.Equals(account.PasswordHash, hashedPassword);

                        if (matchedPassword)
                        {
                            Globals.LoggedInUser = account;
                        }
                    }
                }
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
                    if(IsValidPassword(password).Item1)
                    {
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    Globals.LoggedInUser = account;
                    MessageBox.Show("Registration successful");
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

        public Account RegisterUserWithAge(string username, string password, string firstname, string lastname, int age)
        {
            Account account = new Account(username, password, firstname, lastname, age);
            try
            {
                if (!Queries.DoesPlayerExistWithName(context, account.Username))
                {
                    if (IsValidPassword(password).Item1)
                    {
                        context.Accounts.Add(account);
                        context.SaveChanges();

                        Globals.LoggedInUser = account;
                        MessageBox.Show("Registration successful");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return account;
        }

        public void CheckTextBox(TextBox textBox, TextBlock textBlock)
        {
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
