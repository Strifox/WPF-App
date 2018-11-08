using MahApps.Metro.Controls;
using Monster.Model.Models;
using Monster.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Monster.UI.View
{
    public partial class NoteWindow : MetroWindow
    {
        private NoteViewModel ViewModel;

        public NoteWindow(NoteViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadNoteAsync();
            ViewModel.Window = this;
            ShowUserInfo();
        }

        private void ShowUserInfo()
        {
            txtboxWelcome.Text += " " + Globals.LoggedInUser.Firstname;
        }

        private void TxtboxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext != null)
                ((dynamic)DataContext).Title = ((TextBox)sender).Text;
        }

        private void TxtboxContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext != null)
                ((dynamic)DataContext).Content = ((TextBox)sender).Text;
        }
    }
}
