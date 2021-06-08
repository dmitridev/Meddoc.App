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
using MongoDB.Bson;
using Meddoc.App.Helper;
using Meddoc.App.Entity;

namespace Meddoc.App.Forms
{
    /// <summary>
    /// Логика взаимодействия для MyPatients.xaml
    /// </summary>
    public partial class MyPatients : Page
    {
        Main main;
        public MyPatients()
        {
            InitializeComponent();
            LoadPatients();
        }

        public MyPatients(Main main)
        {
            InitializeComponent();
            LoadPatients();
            this.main = main;
            DataContext = this;
        }

        private void LoadPatients()
        {
            
            var list = Collection<PatientEntity>.List(new BsonDocument());
            foreach(var item in list)
            {
                this.Table.Items.Add(item);
            }
            
        }

        public void Add_Patient(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Patient());
        }

        private void DataGridCell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PatientEntity patientEntity = (PatientEntity)this.Table.SelectedItem;
            main.MainFrame.Content = new PatientsTable(main,patientEntity);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientEntity patientEntity = (PatientEntity)this.Table.SelectedItem;
            main.MainFrame.Content = new PatientsTable(main,patientEntity);
        }

        private void DataGridTextColumn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PatientEntity patientEntity = (PatientEntity)this.Table.SelectedItem;
            main.MainFrame.Content = new PatientsTable(main,patientEntity);
        }
    }
}
