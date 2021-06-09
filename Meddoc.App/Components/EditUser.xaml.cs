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
using Microsoft.Win32;
using System.IO;
using Meddoc.App.Helper;
using Meddoc.App.Entity;

namespace Meddoc.App.Components
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        byte[] image;
        public EditUser()
        {
            InitializeComponent();
            User user = Configuration.currentUser;
            this.FirstName.Textbox.Text = user.FirstName;
            this.LastName.Textbox.Text = user.LastName;
            this.MiddleName.Textbox.Text = user.MiddleName;
            this.Email.Textbox.Text = user.Email;
            this.Work.Textbox.Text = user.Work;
            this.DateBirth.Textbox.Text = user.DateBirth.ToString("dd.MM.yyyy");
            if (user.ImageBase64 != null)
                this.Logo.Source = Images.Load(user.ImageBase64);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);
                // this.Logo load image; 
                this.image = bytes;
                this.Logo.Source = LoadImage(bytes);
                this.Logo.Width = 100;
                this.Logo.Height = 100;
                string base64 = Convert.ToBase64String(bytes);
            }
        }

        private BitmapSource LoadImage(byte[] bytes)
        {
            MemoryStream byteStream = new MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User user = Configuration.currentUser;
            user.Email = this.Email.Textbox.Text;
            user.FirstName = this.FirstName.Textbox.Text;
            user.LastName = this.LastName.Textbox.Text;
            user.MiddleName = this.MiddleName.Textbox.Text;
            user.Work = this.Work.Textbox.Text;
            user.DateBirth = DateTime.Parse(this.DateBirth.Textbox.Text);
            if (image != null)
                user.ImageBase64 = Convert.ToBase64String(image);
            Collection<User>.Save(user);
        }
    }
}
