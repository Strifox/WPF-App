using MahApps.Metro.Controls;
using Monster.UI.ViewModel;
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
using System.Windows.Shapes;

namespace Monster.UI.View
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : MetroWindow
    {
        private AccountViewModel ViewModel;

        public AccountWindow(AccountViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = viewModel;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Window = this;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }

        private void Txtboxusername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Txtboxusername.Text.Length > 0 && Txtboxfirstname.Text.Length > 0 && Txtboxlastname.Text.Length > 0)
            {
                BtnSave.IsEnabled = true;
            }
            else
            {
                BtnSave.IsEnabled = false;
            }
        }
    }
}
