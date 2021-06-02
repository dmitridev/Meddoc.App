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
using Meddoc.App.Entity;
using Meddoc.App.Helper;
using MongoDB.Bson;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для AddNewReception.xaml
    /// </summary>
    public partial class AddNewReception : Page
    {
        public AddNewReception()
        {
            InitializeComponent();
            var list = Collection<PatientEntity>.List(new MongoDB.Bson.BsonDocument());
            this.Patient.Items.Add(list[0]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReceptionEntity patientEntity = new ReceptionEntity
            {
                Id = ObjectId.GenerateNewId(),
                PatientEntity = ((PatientEntity)this.Patient.SelectedItem).Id,
                Date = DateTime.Parse(this.Date.Text),
                Time = DateTime.Parse(this.Time.Text),
                Info = this.Description.Text
            };
            Collection<ReceptionEntity>.Save(patientEntity);
        }
    }
}
