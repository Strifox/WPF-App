using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Monster
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private AccountContext context = new AccountContext();

        public LoginScreen()
        {
            context.Database.CreateIfNotExists();

            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account account = new Account();

                if (Queries.DoesPlayerExistWithName(context, txtboxusername.Text))
                {
                    account = Queries.GetAccountByName(context, txtboxusername.Text);

                    string saltedPassword = string.Concat(account.Salt, txtboxpassword.Password);
                    string hashedPassword = Hashing.ComputeSha256Hash(saltedPassword);

                    bool matchedPassword = string.Equals(account.PasswordHash, hashedPassword);

                    if (matchedPassword)
                    {
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        Close();
                    }
                    else
                        MessageBox.Show("Username or password is incorrect");
                }
                else
                    MessageBox.Show("Username or password is incorrect");

            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();
            registerScreen.Show();
            Close();
        }
    }
}
