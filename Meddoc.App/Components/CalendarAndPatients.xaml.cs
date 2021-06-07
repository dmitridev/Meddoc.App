using Meddoc.App.Components;
using Meddoc.App.Entity;
using Meddoc.App.Helper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
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

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для CalendarAndPatients.xaml
    /// </summary>
    public partial class CalendarAndPatients : Page
    {
        Main main;

        public CalendarAndPatients(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NoteWindow note = new NoteWindow(new long());
            note.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new AddNewReception();
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            this.CurrentDate.Text = String.Format("{0:dd MMMM yyyy}", calendar.SelectedDate);
            DateTime selectedDate = calendar.SelectedDate.Value;

            this.Receptions.Children.Clear();


            var collection = Collection<ReceptionEntity>.List(new BsonDocument());
            foreach (var item in collection)
            {
                this.Receptions.Children.Add(new Reception(main, item));
            }

        }
    }
}
