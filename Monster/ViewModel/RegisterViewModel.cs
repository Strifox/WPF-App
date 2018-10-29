using Autofac;
using Monster.DataAccess;
using Monster.Model.Models;
using Monster.UI.Data;
using Monster.UI.Startup;
using Monster.UI.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Monster.UI.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private AccountContext context = new AccountContext();

        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Age { get; set; }


        public bool IsValidRegistration(TextBlock textBlock)
        {
            Account account = new Account(Username.ToLower(), Password, Firstname, Lastname);

            if (string.IsNullOrEmpty(Age) || string.IsNullOrWhiteSpace(Age))
            {
                if (IsValidPassword(textBlock).Item1)
                {
                    if (!AccountDataService.DoesPlayerExistWithName(context, account.Username))
                    {
                        textBlock.Text = "Successfully created account";
                        textBlock.Visibility = Visibility.Visible;
                        context.Accounts.Add(account);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        textBlock.Text = "Username already exists";
                        textBlock.Visibility = Visibility.Visible;
                        return false;
                    }
                }
                else
                    return false;
            }
            else
            {
                account = new Account(Username.ToLower(), Password, Firstname, Lastname, int.Parse(Age));

                if (IsValidPassword(textBlock).Item1)
                {
                    if (!AccountDataService.DoesPlayerExistWithName(context, account.Username))
                    {
                        textBlock.Text = "Creating Account";
                        textBlock.Visibility = Visibility.Visible;
                        context.Accounts.Add(account);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        textBlock.Text = "Username already exists";
                        textBlock.Visibility = Visibility.Visible;
                        return false;
                    }
                }
                else
                    return false;
            }
        }

        public Tuple<bool, string> IsValidPassword(TextBlock textBlock)
        {
            textBlock.Visibility = Visibility.Visible;

            if (Password.Contains(" "))
                return new Tuple<bool, string>(false, textBlock.Text = "Password cannot contain white spaces.");

            if (!Password.Any(char.IsNumber))
                return new Tuple<bool, string>(false, textBlock.Text = "Password must contain at least one numeric char.");

            // perhaps the requirements meant to be 1 capital letter?
            //if (password.Count(char.IsUpper) != 1)
            if (!Password.Any(char.IsUpper))
                return new Tuple<bool, string>(false, textBlock.Text = "Password must contain at least 1 capital letter.");

            if (Password.Length < 8)
                return new Tuple<bool, string>(false, textBlock.Text = "Password is too short, must be\n at least 8 characters.");

            return new Tuple<bool, string>(true, textBlock.Text = string.Empty);
        }
    }
}
