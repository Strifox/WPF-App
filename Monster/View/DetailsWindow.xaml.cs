using Monster.Model.Models;
using Monster.UI.ViewModel;
using System.Windows;

namespace Monster.UI.View
{
    public partial class DetailsWindow : Window
    {
        private DetailsViewModel ViewModel;

        public DetailsWindow(DetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            ViewModel = viewModel;
        }
    
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           await ViewModel.LoadAsync();
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
        }

    }
}
