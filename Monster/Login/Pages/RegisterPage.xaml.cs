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
            if (string.IsNullOrEmpty(txtboxfirstname.Text) || string.IsNullOrWhiteSpace(txtboxfirstname.Text))
                txtblockfirstnameisrequired.Visibility = Visibility.Visible;
            else
                txtblockfirstnameisrequired.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(txtboxlastname.Text) || string.IsNullOrWhiteSpace(txtboxlastname.Text))
                txtblocklastnameisrequired.Visibility = Visibility.Visible;
            else
                txtblocklastnameisrequired.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(txtboxusername.Text) || string.IsNullOrWhiteSpace(txtboxusername.Text))
                txtblockusernameisrequired.Visibility = Visibility.Visible;
            else
                txtblockusernameisrequired.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(txtboxpassword.Password) || string.IsNullOrWhiteSpace(txtboxpassword.Password))
                txtblockpasswordisrequired.Visibility = Visibility.Visible;
            else
                txtblockpasswordisrequired.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(txtboxage.Text) || string.IsNullOrWhiteSpace(txtboxage.Text))
            {
                if (string.IsNullOrEmpty(txtboxusername.Text) || string.IsNullOrWhiteSpace(txtboxusername.Text) || string.IsNullOrEmpty(txtboxpassword.Password) || string.IsNullOrWhiteSpace(txtboxpassword.Password) || string.IsNullOrEmpty(txtboxfirstname.Text) || string.IsNullOrWhiteSpace(txtboxfirstname.Text) || string.IsNullOrEmpty(txtboxlastname.Text) || string.IsNullOrWhiteSpace(txtboxlastname.Text))
                {
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
                    return;
                }
                else
                {
                    Account user = operations.RegisterUserAge(txtboxusername.Text, txtboxpassword.Password, txtboxfirstname.Text, txtboxlastname.Text, int.Parse(txtboxage.Text));
                    Globals.LoggedInUser = user;
                    NavigationService.Navigate(new LoginPage());
                }
            }

        }
    }
}

