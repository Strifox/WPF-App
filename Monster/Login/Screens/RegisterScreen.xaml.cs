using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Monster
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        private AccountContext context = new AccountContext();
        private ApiOperations operations = new ApiOperations();

        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            operations.RegisterUser(txtboxusername.Text, txtboxpassword.Password);
            Close();
        }
    }
}
