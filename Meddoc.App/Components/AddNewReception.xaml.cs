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
        ReceptionEntity entity;
        public AddNewReception()
        {
            InitializeComponent();
            var list = Collection<PatientEntity>.List(new BsonDocument());
            this.Patient.Items.Add(list[0]);
        }

        public AddNewReception(ReceptionEntity entity)
        {
            InitializeComponent();
            this.entity = entity;
            this.MainText.Text = "Редактировать приём";
            this.MainButton.Content = "Сохранить";
            this.Patient.Items.Add(this.entity.PatientEntity);
            this.Patient.SelectedItem = this.entity.PatientEntity;
            this.Date.Textbox.Text = this.entity.Date.ToString();
            this.Time.Textbox.Text = this.entity.Time.ToString();
            this.Description.Textbox.Text = this.entity.Info;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReceptionEntity receptionEntity;
            if (entity == null)
            {
                receptionEntity = new ReceptionEntity
                {
                    Id = ObjectId.GenerateNewId(),
                    PatientEntity = ((PatientEntity)this.Patient.SelectedItem).Id,
                    Date = DateTime.Parse(this.Date.Textbox.Text),
                    Time = DateTime.Parse(this.Time.Textbox.Text),
                    Info = this.Description.Textbox.Text
                };
            }
            else
            {
                receptionEntity = entity;
            }

            Collection<ReceptionEntity>.Save(receptionEntity);
            
        }
    }
}
