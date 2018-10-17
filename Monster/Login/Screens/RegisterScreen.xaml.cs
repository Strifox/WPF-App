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
        private AccountContext accountContext = new AccountContext();

        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account(txtboxusername.Text, txtboxpassword.Password);

            try
            {
                if (!Queries.DoesPlayerExistWithName(accountContext, account.Username))
                    accountContext.Accounts.Add(account);
               
                accountContext.SaveChanges();
                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();
                Close();

            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
