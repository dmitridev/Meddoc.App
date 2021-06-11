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
using DB = Meddoc.App.Helper;
using Meddoc.App.Entity;
using Meddoc.App.Components;
using System.Collections.ObjectModel;

namespace Meddoc.App.Forms
{
    /// <summary>
    /// Логика взаимодействия для MyPatients.xaml
    /// </summary>
    public partial class MyPatients : Page
    {
        Main main;

        ObservableCollection<PatientEntity> collection = new ObservableCollection<PatientEntity>();

        public MyPatients()
        {
            InitializeComponent();
            collection = LoadPatients();
        }

        public MyPatients(Main main)
        {
            InitializeComponent();
            collection = LoadPatients();
            this.Table.ItemsSource = collection;
            this.main = main;
            DataContext = this;
        }

        ObservableCollection<PatientEntity> LoadPatients()
        {
            ObservableCollection<PatientEntity> ret = new ObservableCollection<PatientEntity>();

            var list = DB.Collection<PatientEntity>.List(new BsonDocument());
            foreach (var item in list)
                ret.Add(item);

            return ret;
        }

        public void Add_Patient(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Patient());
        }

        private void DataGridCell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PatientEntity patientEntity = (PatientEntity)this.Table.SelectedItem;
            main.MainFrame.Content = new PatientsTable(main, patientEntity);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientEntity patientEntity = (PatientEntity)this.Table.SelectedItem;
            main.MainFrame.Content = new PatientsTable(main, patientEntity);
        }

        private void DataGridTextColumn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PatientEntity patientEntity = (PatientEntity)this.Table.SelectedItem;
            main.MainFrame.Content = new PatientsTable(main, patientEntity);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteObj deleteObj = new DeleteObj();
            bool? result = deleteObj.ShowDialog();
            if (result.Value)
            {
                PatientEntity patientEntity = (PatientEntity)this.Table.SelectedItem;
                DB.Collection<PatientEntity>.Del(patientEntity);
            }
            main.MainFrame.Content = new MyPatients(main);
        }
    }
}
