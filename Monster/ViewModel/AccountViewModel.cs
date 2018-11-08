using Autofac;
using Monster.Model.Models;
using Monster.UI.Data;
using Monster.UI.Startup;
using Monster.UI.View;
using Monster.UI.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Monster.UI.ViewModel
{
   public class AccountViewModel : ViewModelBase
    {
        private readonly IAccountDataService _accountDataService;
        public Window Window;

        #region Commands

        public ICommand SaveUserCommand => new CommandHandler(() => { UpdateUser(); });
        public ICommand NoteCommand => new CommandHandler(() => { ShowNotes(); });
        public ICommand LogoutCommand => new CommandHandler(() => { Logout(); });

        #endregion

        #region Properties

        public string Username { get { return Globals.LoggedInUser.Username; } set { Globals.LoggedInUser.Username = value; } }
        public string Password { get; set; }
        public string Firstname { get { return Globals.LoggedInUser.Firstname; } set { Globals.LoggedInUser.Firstname = value; } }
        public string Lastname { get { return Globals.LoggedInUser.Lastname; } set { Globals.LoggedInUser.Lastname = value; } } 
        public int? Age { get { return Globals.LoggedInUser.Age; } set { Globals.LoggedInUser.Age = value; } }
        public TextBlock TextBlock { get; set; }

        #endregion

        public static void ShowAccountWindow()
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var accountWindow = container.Resolve<AccountWindow>();
            accountWindow.Show();
        }

        public void ShowNotes()
        {
            NoteViewModel.ShowDetailsWindow();
            Window.Close();
        }

        public void Logout()
        {
            Globals.LoggedInUser = null;
            OpenAndCloseWindow(new LoginWindow(), Window);
        }

        public void UpdateUser()
        {
            _accountDataService.UpdateAccount(Globals.LoggedInUser);
        }

        public AccountViewModel(IAccountDataService accountDataService)
        {
            _accountDataService = accountDataService;
        }

        public Tuple<bool, string> IsValidPassword()
        {
            TextBlock.Visibility = Visibility.Visible;

            if (Password.Contains(" "))
                return new Tuple<bool, string>(false, TextBlock.Text = "Password cannot contain white spaces.");

            if (!Password.Any(char.IsNumber))
                return new Tuple<bool, string>(false, TextBlock.Text = "Password must contain at least one numeric char.");

            // perhaps the requirements meant to be 1 capital letter?
            //if (password.Count(char.IsUpper) != 1)
            if (!Password.Any(char.IsUpper))
                return new Tuple<bool, string>(false, TextBlock.Text = "Password must contain at least 1 capital letter.");

            if (Password.Length < 8)
                return new Tuple<bool, string>(false, TextBlock.Text = "Password is too short, must be\n at least 8 characters.");

            return new Tuple<bool, string>(true, TextBlock.Text = string.Empty);
        }
    }
}
