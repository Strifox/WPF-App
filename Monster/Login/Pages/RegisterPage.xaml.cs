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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monster.Login.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private AccountContext context = new AccountContext();
        private Operations operations = new Operations();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Account user = operations.RegisterUser(txtboxusername.Text, txtboxpassword.Password);
            if (user == null)
            {
                MessageBox.Show("Username already exists");
                return;
            }

            Globals.LoggedInUser = user;
            NavigationService.Navigate(new LoginPage());
        }
    }
}

