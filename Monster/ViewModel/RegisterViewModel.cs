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

        public static void ShowRegisterWindow()
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var detailswindow = container.Resolve<DetailsWindow>();
            detailswindow.Show();
        }

        public Account RegisterUserWithoutAge(string username, string password, string firstname, string lastname, TextBlock textBlock)
        {
            Account account = new Account(username.ToLower(), password, firstname, lastname);

            if (!AccountDataService.DoesPlayerExistWithName(context, account.Username))
            {
                textBlock.Text = "Successfully created account";
                textBlock.Visibility = Visibility.Visible;
                context.Accounts.Add(account);
                context.SaveChanges();
                return account;
            }
            else
            {
                textBlock.Text = "Username already exists";
                textBlock.Visibility = Visibility.Visible;
                return account = null;
            }
        }

        public Account RegisterUserWithAge(string username, string password, string firstname, string lastname, int age, TextBlock textBlock)
        {
            Account account = new Account(username.ToLower(), password, firstname, lastname, age);

            if (!AccountDataService.DoesPlayerExistWithName(context, account.Username))
            {
                textBlock.Text = "Creating Account";
                textBlock.Visibility = Visibility.Visible;
                context.Accounts.Add(account);
                context.SaveChanges();
                return account;
            }
            else
            {
                textBlock.Text = "Username already exists";
                textBlock.Visibility = Visibility.Visible;
                return account = null;
            }

        }

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

            return new Tuple<bool, string>(true, textBlock.Text = string.Empty);
        }
    }
}
