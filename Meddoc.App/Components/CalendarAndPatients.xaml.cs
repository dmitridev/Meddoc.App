using Meddoc.App.Components;
using Meddoc.App.Entity;
using Meddoc.App.Helper;
using MongoDB.Bson;
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
            List<ReceptionEntity> receptions = Collection<ReceptionEntity>.List(new BsonDocument());
            receptions.ForEach(r => this.Receptions.Children.Add(new Reception(main,r)));
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
    }
}
