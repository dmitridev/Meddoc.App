using Meddoc.App.Entity;
using Meddoc.App.Forms;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Meddoc.App.Helper;
using Meddoc.App.Components;
using System.IO;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            List<Note> notes = Collection<Note>.List(new MongoDB.Bson.BsonDocument());
            notes.ForEach(note => this.Notes.Children.Add(new Memo(note)));
            if (Configuration.currentUser.FirstName == null && Configuration.currentUser.LastName == null)
                this.Login.Text = Configuration.currentUser?.Login;
            else
            {
                this.Login.Text = Configuration.currentUser.FirstName + " " + Configuration.currentUser.MiddleName + " " + Configuration.currentUser.LastName + " ";
            }
            if (Configuration.currentUser != null)
                this.Logo.Source = LoadImage(Convert.FromBase64String(Configuration.currentUser.ImageBase64));

            this.MainFrame.Content = new CalendarAndPatients(this);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new CalendarAndPatients(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new MyPatients(this);
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new AddNewReception();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new Patient();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Content = new UserInfo(this);
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

        void Button_Important_Click(object sender, RoutedEventArgs e)
        {
            Visibility visibility;

            if (this.NotesScroll.Visibility == Visibility.Visible)
            {
                visibility = Visibility.Hidden;

                this.Notes.Visibility = visibility;
                this.NotesScroll.Visibility = visibility;
                //this.importantArrow.Source = new BitmapImage(new Uri(@"/Assets/ArrowDown.png"));
            }
            else
            {
                visibility = Visibility.Visible;
                this.Notes.Visibility = visibility;
                this.NotesScroll.Visibility = visibility;
                //this.importantArrow.Source = new BitmapImage(new Uri(@"/Assets/ArrowUp.png"));
            }
        }
    }
}
