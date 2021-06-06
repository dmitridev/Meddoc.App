﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Meddoc.App.Helper;
using Meddoc.App.Entity;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }


        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Register());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = Users.Login(this.LoginField.Textbox.Text, this.PasswordField.Textbox.Text);
            Configuration.currentUser = user;
            this.NavigationService.Navigate(new Main());
        }
    }
}
