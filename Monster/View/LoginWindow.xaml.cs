using Autofac;
using Monster.DataAccess;
using Monster.Model.Models;
using Monster.UI.Data;
using Monster.UI.Startup;
using Monster.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Monster.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel LoginViewModel = new LoginViewModel();
        private AccountContext context = new AccountContext();

        public LoginWindow()
        {
            context.Database.CreateIfNotExists();
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel.AuthenticateUser(txtboxusername.Text, txtboxpassword.Password);

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
            ViewModelBase.OpenAndCloseWindow(new RegisterWindow(), this);
        }

        private void Txtboxusername_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtblockinvalidusernameorpassword.Visibility = Visibility.Hidden;
        }

        private void Txtboxpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtblockinvalidusernameorpassword.Visibility = Visibility.Hidden;
        }
    }
}
