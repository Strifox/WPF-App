using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monster.Login.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private AccountContext context = new AccountContext();
        private Operations operations = new Operations();

        public LoginPage()
        {
            context.Database.CreateIfNotExists();
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            operations.AuthenticateUser(txtboxusername.Text, txtboxpassword.Password);

            if (Globals.LoggedInUser == null)
            {
                txtblockinvalidusernameorpassword.Text = "Invalid username or password";
                return;
            }
            txtblockinvalidusernameorpassword.Text = "Login successful";
            NavigationService.Navigate(new DetailsPage());
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
