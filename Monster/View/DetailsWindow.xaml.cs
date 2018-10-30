using Monster.Model.Models;
using Monster.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Monster.UI.View
{
    public partial class DetailsWindow : Window
    {
        private DetailsViewModel ViewModel;

        public DetailsWindow(DetailsViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadAsync();
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
            ViewModelBase.OpenAndCloseWindow(new LoginWindow(), this);
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.SaveNoteAsync();
            ViewModel.LoadAsync();
        }

        private void TxtboxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Title = ((TextBox)sender).Text; }
        }

        private void TxtboxContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Content = ((TextBox)sender).Text; }
        }
    }
}
