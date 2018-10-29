using Monster.Model.Models;
using Monster.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Monster.UI.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterViewModel registerViewModel = new RegisterViewModel();


        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel.ShowLoginWindow();
            Close();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxage.Text) || string.IsNullOrWhiteSpace(txtboxage.Text))
            {
                if (RegisterViewModel.IsValidPassword(txtboxpassword.Password, txtblockstatus).Item1)
                {
                    Account user = registerViewModel.RegisterUserWithoutAge(txtboxusername.Text, txtboxpassword.Password, txtboxfirstname.Text, txtboxlastname.Text, txtblockstatus);

                    if (user != null)
                    {
                        LoginViewModel.ShowLoginWindow();
                        Close();
                    }
                }
                else
                {
                    txtblockstatus.Visibility = Visibility.Visible;
                    return;
                }
            }
            else
            {
                if (RegisterViewModel.IsValidPassword(txtboxpassword.Password, txtblockstatus).Item1)
                {
                    Account user = registerViewModel.RegisterUserWithAge(txtboxusername.Text, txtboxpassword.Password, txtboxfirstname.Text, txtboxlastname.Text, int.Parse(txtboxage.Text), txtblockstatus);

                    if (user != null)
                    {
                        LoginViewModel.ShowLoginWindow();
                        Close();
                    }
                }
                else
                {
                    txtblockstatus.Visibility = Visibility.Visible;
                    return;
                }
            }
        }

        private void Txtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtboxusername.Text.Length > 0 && txtboxpassword.Password.Length > 0 && txtboxfirstname.Text.Length > 0 && txtboxlastname.Text.Length > 0)
            {
                BtnRegister.IsEnabled = true;
                txtblockstatus.Text = "* is required";
                txtblockstatus.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnRegister.IsEnabled = false;
                txtblockstatus.Text = "* is required";
                txtblockstatus.Visibility = Visibility.Visible;
            }

        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtboxusername.Text.Length > 0 && txtboxpassword.Password.Length > 0 && txtboxfirstname.Text.Length > 0 && txtboxlastname.Text.Length > 0)
            {
                BtnRegister.IsEnabled = true;
                txtblockstatus.Text = "* is required";
                txtblockstatus.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnRegister.IsEnabled = false;
                txtblockstatus.Text = "* is required";
                txtblockstatus.Visibility = Visibility.Visible;
            }
        }
    }
}
