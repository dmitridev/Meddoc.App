using Meddoc.App.Entity;
using Meddoc.App.Forms;
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
using Meddoc.App.Components;

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
            this.MainFrame.Content = new UserInfo();
        }
    }
}
