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
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            InitializeComponent();
        }
        /**
        * Details Page Loaded
        * @param  object  sender
        * @param  RoutedEventArgs e
        */
        private void DetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            ShowUserInfo();
        }


        /**
         * Show User Info on the Screen
         */
        private void ShowUserInfo()
        {
            txtboxWelcome.Text += " " + Globals.LoggedInUser.Firstname;
        }

        /**
         * Logout Method to be called on the logout Button
         * @param  object sender
         * @param  RoutedEventArgs e
         */
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Globals.LoggedInUser = null;
            NavigationService.Navigate(new LoginPage());
        }
    }
}
 
