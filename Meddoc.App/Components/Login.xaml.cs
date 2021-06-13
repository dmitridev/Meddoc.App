using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Meddoc.App.Helper;
using Meddoc.App.Entity;
using System;

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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Error.Text = "";
                spinner.Visibility = Visibility.Visible;
                LoginButton.IsEnabled = false;
                User user = await Users.Login(this.LoginField.Textbox.Text, this.PasswordField.Textbox.Text);
                Configuration.currentUser = user;
                spinner.Visibility = Visibility.Hidden;
                LoginButton.IsEnabled = true;
                this.NavigationService.Navigate(new Main());
            }
            catch (Exception exception)
            {
                spinner.Visibility = Visibility.Hidden;
                LoginButton.IsEnabled = true;
                this.Error.Text = exception.Message;
            }
        }
    }
}
