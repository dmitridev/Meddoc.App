using Meddoc.App.Entity;
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
