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
    /// Логика взаимодействия для Patient.xaml
    /// </summary>
    public partial class Patient : Page
    {
        public Patient()
        {
            InitializeComponent();
        }

        public void Button_Add(object sender, RoutedEventArgs e)
        {
            PatientEntity entity = new PatientEntity
            {
                Id = ObjectId.GenerateNewId(),
                Name = this.FirstName.Text,
                MiddleName = this.MiddleName.Text,
                LastName = this.LastName.Text,
                DateBirth = DateTime.Parse(this.DateBirth.Text),
                History = this.PatientHistory.Text
            };
            Collection<PatientEntity>.Save(entity);
        }
    }
}
