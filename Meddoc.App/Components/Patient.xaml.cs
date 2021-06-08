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
        Main main;
        PatientEntity entity;
        public Patient()
        {
            InitializeComponent();
        }

        public Patient(Main main,PatientEntity entity)
        {
            InitializeComponent();
            this.main = main;
            this.entity = entity;
        }

        public void Button_Add(object sender, RoutedEventArgs e)
        {
            PatientEntity entity = new PatientEntity
            {
                Id = ObjectId.GenerateNewId(),
                Name = this.FirstName.Textbox.Text,
                MiddleName = this.MiddleName.Textbox.Text,
                LastName = this.LastName.Textbox.Text,
                DateBirth = DateTime.Parse(this.DateBirth.Textbox.Text),
                History = this.History.Textbox.Text
            };
            Collection<PatientEntity>.Save(entity);
        }
    }
}
