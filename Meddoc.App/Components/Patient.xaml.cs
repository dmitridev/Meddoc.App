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
using Microsoft.Win32;
using System.IO;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для Patient.xaml
    /// </summary>
    public partial class Patient : Page
    {

        Main main;
        PatientEntity entity;
        bool addToReception = false;
        public Patient()
        {
            InitializeComponent();
        }

        public Patient(Main main, PatientEntity entity, bool edit = false)
        {
            InitializeComponent();
            this.main = main;
            this.entity = entity;
            this.FirstName.Textbox.Text = entity.Name;
            this.LastName.Textbox.Text = entity.LastName;
            this.MiddleName.Textbox.Text = entity.MiddleName;
            this.DateBirth.Textbox.Text = entity.DateBirth.ToString("dd.MM.yyyy");
            this.History.Textbox.Text = entity.History;
            this.Diagnoz.Textbox.Text = entity.Diagnoz;
            if (entity.AvatarBase64 != null)
                this.Image.Source = Images.Load(entity.AvatarBase64);

            if (edit)
            {
                this.Logo.Text = "Редактирование";
                this.ButtonAdd.Content = "Сохранить";
            }
        }

        public Patient(Main main, bool addToReception)
        {
            InitializeComponent();
            this.main = main;
            this.addToReception = addToReception;
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
                History = this.History.Textbox.Text,
                AvatarBase64 = this.entity.AvatarBase64,
                Diagnoz = this.Diagnoz.Textbox.Text
            };
            if (addToReception)
            {
                Collection<PatientEntity>.Save(entity);
                ReceptionEntity receptionEntity = new ReceptionEntity();
                receptionEntity.PatientEntity = entity.Id;
                main.MainFrame.Content = new AddNewReception(main, receptionEntity);
            }
            Collection<PatientEntity>.Save(entity);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog().Value)
            {
                byte[] bytes = File.ReadAllBytes(ofd.FileName);

                BitmapSource image = Images.Load(bytes);
                string base64 = Images.ToBase64String(bytes);
                if (entity == null)
                    entity = new PatientEntity();
                this.entity.AvatarBase64 = base64;
                this.Image.Source = image;
                this.Image.Width = 250;
            }
        }
    }
}
