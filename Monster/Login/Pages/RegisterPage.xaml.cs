using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (string.IsNullOrEmpty(txtboxage.Text) || string.IsNullOrWhiteSpace(txtboxage.Text))
            {
                if (Operations.IsValidPassword(txtboxpassword.Password, txtblockinvalidpassword).Item1)
                {
                    Account user = operations.RegisterUserWithoutAge(txtboxusername.Text, txtboxpassword.Password, txtboxfirstname.Text, txtboxlastname.Text, txtblockstatus);
                    if (user != null)
                        NavigationService.Navigate(new LoginPage());
                }
                else
                    return;
            }
            else
            {
                if (Operations.IsValidPassword(txtboxpassword.Password, txtblockinvalidpassword).Item1)
                {
                    Account user = operations.RegisterUserWithAge(txtboxusername.Text, txtboxpassword.Password, txtboxfirstname.Text, txtboxlastname.Text, int.Parse(txtboxage.Text), txtblockstatus);

                    if (user != null)
                        NavigationService.Navigate(new LoginPage());
                }
                else
                    return;
            }
        }

        private void Txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxusername.Text.Length > 0 && txtboxpassword.Password.Length > 0 && txtboxfirstname.Text.Length > 0 && txtboxlastname.Text.Length > 0)
            {
                BtnRegister.IsEnabled = true;
                txtblockisrequired.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnRegister.IsEnabled = false;
                txtblockisrequired.Visibility = Visibility.Visible;
            }

        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtboxusername.Text.Length > 0 && txtboxpassword.Password.Length > 0 && txtboxfirstname.Text.Length > 0 && txtboxlastname.Text.Length > 0)
            {
                BtnRegister.IsEnabled = true;
                txtblockisrequired.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnRegister.IsEnabled = false;
                txtblockisrequired.Visibility = Visibility.Visible;
            }
        }
    }

}

