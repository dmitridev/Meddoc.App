using System;
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

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        Main main;
        public Register()
        {
            InitializeComponent();
        }

        public Register(Main main)
        {
            InitializeComponent();
            this.main = main;
        }


        void CustomTextField_Loaded(object sender, RoutedEventArgs e)
        {

        }

        void Button_Register(object sender, RoutedEventArgs e)
        {
            Users.Register(this.Login.Textbox.Text, this.Email.Textbox.Text, this.Password.Textbox.Text, this.PasswordConfirm.Textbox.Text);
            this.NavigationService.Navigate(new Login());
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Register());
        }
    }
}
