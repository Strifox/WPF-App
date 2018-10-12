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
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                string getUserQuery = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username";
                SqlCommand sqlCmd = new SqlCommand(getUserQuery, sqlCon);
                var reader = sqlCmd.ExecuteReader();

                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtboxusername.Text);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Account account = new Account();

                    while (reader.Read())
                    {
                        account = new Account(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }

                    string password = account.Salt + txtboxpassword.Password;
                    string hashedPassword = Account.ComputeSha256Hash(password);
                    string getUser = $"SELECT COUNT(1) FROM tblUser WHERE Username={account.AccountName} AND PasswordHash={hashedPassword}";
                    SqlCommand sqlLogin = new SqlCommand(getUser, sqlCon);
                    int isUserValid = Convert.ToInt32(sqlLogin.ExecuteScalar());
                    if (isUserValid == 1)
                    {
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlCon.Close();
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
