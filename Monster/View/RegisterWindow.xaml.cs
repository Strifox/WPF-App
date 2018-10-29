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
        private RegisterViewModel model = new RegisterViewModel();

        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ViewModelBase.OpenAndCloseWindow(new LoginWindow(), this);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!model.IsValidRegistration(txtblockstatus))
                return;

            ViewModelBase.OpenAndCloseWindow(new LoginWindow(), this);
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

            if (DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
