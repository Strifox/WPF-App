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

            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                string checkDatabaseQuery = $"SELECT COUNT(1) FROM tblUser WHERE Username={account.AccountName}";
                SqlCommand sqlComm = new SqlCommand(checkDatabaseQuery, sqlCon);
                sqlComm.CommandType = CommandType.Text;
                int count = Convert.ToInt32(sqlComm.ExecuteScalar());
                if (count == 0)
                {
                    string query = $"INSERT INTO tblUser [(Username, PasswordHash, Salt)] VALUES [({account.AccountName}, {account.PasswordHash}, {account.Salt})]";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.CommandType = CommandType.Text;

                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Username already exists");
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
    }
}
