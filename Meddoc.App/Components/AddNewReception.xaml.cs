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
        Main main;
        ReceptionEntity entity;
        PatientEntity patientEntity;
        public AddNewReception()
        {
            InitializeComponent();
            var list = Collection<PatientEntity>.List(new BsonDocument());

            foreach (var item in list)
            {
                this.Patient.Items.Add(item);
            }
        }

        public AddNewReception(Main main)
        {
            InitializeComponent();
            this.main = main;
            var list = Collection<PatientEntity>.List(new BsonDocument());

            foreach (var item in list)
            {
                this.Patient.Items.Add(item);
            }
        }

        public AddNewReception(Main main,ReceptionEntity entity)
        {
            InitializeComponent();
            this.main = main;
            this.entity = entity;
            this.MainText.Text = "Редактировать приём";
            this.MainButton.Content = "Сохранить";
            this.Date.Textbox.Text = this.entity.Date.ToString();
            this.Time.Textbox.Text = this.entity.Time.ToString();
            this.Description.Textbox.Text = this.entity.Info;

            var list = Collection<PatientEntity>.List(new BsonDocument());
            foreach (var item in list)
            {
                this.Patient.Items.Add(item);
            }

            this.Patient.SelectedItem = list.Find(obj => obj.Id.Equals(this.entity.PatientEntity));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReceptionEntity receptionEntity = new ReceptionEntity
            {
                PatientEntity = ((PatientEntity)this.Patient.SelectedItem).Id,
                Date = DateTime.Parse(this.Date.Textbox.Text),
                Time = DateTime.Parse(this.Time.Textbox.Text),
                Info = this.Description.Textbox.Text
            };

            if (entity == null)
                receptionEntity.Id = ObjectId.GenerateNewId();
            else
                receptionEntity.Id = this.entity.Id;

            Collection<ReceptionEntity>.Save(receptionEntity);
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            main.MainFrame.Content = new Patient(main,true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new CalendarAndPatients(main);
        }
    }
}
