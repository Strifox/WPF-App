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
        private ApiOperations operations = new ApiOperations();

        public RegisterPage()
        {
            InitializeComponent();
        }
   
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            operations.RegisterUser(txtboxusername.Text, txtboxpassword.Password);
        }
    }
}
