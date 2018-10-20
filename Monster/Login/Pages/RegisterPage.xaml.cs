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
            operations.CheckTextBox(txtboxusername, txtblockusernameisrequired);
            operations.CheckPasswordBox(txtboxpassword, txtblockpasswordisrequired);
            operations.CheckTextBox(txtboxfirstname, txtblockfirstnameisrequired);
            operations.CheckTextBox(txtboxlastname, txtblocklastnameisrequired);

            if (string.IsNullOrEmpty(txtboxage.Text) || string.IsNullOrWhiteSpace(txtboxage.Text))
            {
                if (string.IsNullOrEmpty(txtboxusername.Text) || string.IsNullOrWhiteSpace(txtboxusername.Text) || string.IsNullOrEmpty(txtboxpassword.Password) || string.IsNullOrWhiteSpace(txtboxpassword.Password) || string.IsNullOrEmpty(txtboxfirstname.Text) || string.IsNullOrWhiteSpace(txtboxfirstname.Text) || string.IsNullOrEmpty(txtboxlastname.Text) || string.IsNullOrWhiteSpace(txtboxlastname.Text))
                {
                    txtblockisrequired.Visibility = Visibility.Visible;
                    return;
                }
                else
                {
                    Account user = operations.RegisterUserWithoutAge(txtboxusername.Text, txtboxpassword.Password, txtboxfirstname.Text, txtboxlastname.Text);
                    Globals.LoggedInUser = user;
                    NavigationService.Navigate(new LoginPage());
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtboxusername.Text) || string.IsNullOrWhiteSpace(txtboxusername.Text) || string.IsNullOrEmpty(txtboxpassword.Password) || string.IsNullOrWhiteSpace(txtboxpassword.Password) || string.IsNullOrEmpty(txtboxfirstname.Text) || string.IsNullOrWhiteSpace(txtboxfirstname.Text) || string.IsNullOrEmpty(txtboxlastname.Text) || string.IsNullOrWhiteSpace(txtboxlastname.Text))
                {
                    txtblockisrequired.Visibility = Visibility.Visible;
                    return;
                }
                else
                {

                    Account user = operations.RegisterUserWithAge(txtboxusername.Text, txtboxpassword.Password, txtboxfirstname.Text, txtboxlastname.Text, int.Parse(txtboxage.Text));
                    Globals.LoggedInUser = user;
                    NavigationService.Navigate(new LoginPage());
                }
            }

        }

        private void Txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxusername.Text.Length > 0 && txtboxpassword.Password.Length > 0 && txtboxfirstname.Text.Length > 0 && txtboxlastname.Text.Length > 0)
                BtnRegister.IsEnabled = true;
            else
            {
                BtnRegister.IsEnabled = false;
            }

            if (string.IsNullOrEmpty(txtboxusername.Text) || string.IsNullOrWhiteSpace(txtboxusername.Text))
                txtblockusernameisrequired.Text = "*";

        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtboxusername.Text.Length > 0 && txtboxpassword.Password.Length > 0 && txtboxfirstname.Text.Length > 0 && txtboxlastname.Text.Length > 0)
                BtnRegister.IsEnabled = true;
            else
            {
                BtnRegister.IsEnabled = false;
            }
        }
    }

}

