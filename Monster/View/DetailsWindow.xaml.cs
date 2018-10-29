﻿using Monster.Model.Models;
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

namespace Monster.View
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