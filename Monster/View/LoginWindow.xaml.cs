using MahApps.Metro.Controls;
using Monster.DataAccess;
using Monster.Model.Models;
using Monster.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Monster.UI.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        private LoginViewModel LoginViewModel = new LoginViewModel();
        private readonly AccountContext context = new AccountContext();

        public LoginWindow()
        {
            context.Database.CreateIfNotExists();
            InitializeComponent();
            DataContext = LoginViewModel;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel.AuthenticateUser();

            if (Globals.LoggedInUser == null)
            {
                txtblockinvalidusernameorpassword.Visibility = Visibility.Visible;
                return;
            }

            NoteViewModel.ShowDetailsWindow();
            Close();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            ViewModelBase.OpenAndCloseWindow(new RegisterWindow(), this);
        }

        private void Txtboxusername_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtblockinvalidusernameorpassword.Visibility = Visibility.Hidden;
        }

        private void Txtboxpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtblockinvalidusernameorpassword.Visibility = Visibility.Hidden;
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
