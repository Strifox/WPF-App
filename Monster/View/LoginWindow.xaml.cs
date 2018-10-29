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
    public partial class LoginWindow : Window
    {
        private LoginViewModel LoginViewModel;
        private readonly AccountContext context = new AccountContext();

        public LoginWindow(LoginViewModel viewModel)
        {
            context.Database.CreateIfNotExists();
            InitializeComponent();
            DataContext = viewModel;
            LoginViewModel = viewModel;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel.AuthenticateUser();

            if (Globals.LoggedInUser == null)
            {
                txtblockinvalidusernameorpassword.Visibility = Visibility.Visible;
                return;
            }

            DetailsViewModel.ShowDetailsWindow();
            Close();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterViewModel.ShowRegisterWindow();
            Close();
        }

        private void Txtboxusername_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtblockinvalidusernameorpassword.Visibility = Visibility.Hidden;
        }

        private void Txtboxpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtblockinvalidusernameorpassword.Visibility = Visibility.Hidden;
            if (DataContext != null)
            { ((dynamic)DataContext).SecurePassword = ((PasswordBox)sender).SecurePassword; }
        }
    }
}
