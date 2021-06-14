using System.Windows;
using System.Windows.Controls;
using Meddoc.App.Entity;
using Meddoc.App.Helper;
using System.Globalization;
using Meddoc.App.Components;

namespace Meddoc.App.Forms
{
    /// <summary>
    /// Логика взаимодействия для PatientsTable.xaml
    /// </summary>
    public partial class PatientsTable : Page
    {
        Main main;
        PatientEntity entity;
        public PatientsTable()
        {
            InitializeComponent();
        }

        public PatientsTable(Main main)
        {
            this.main = main;
            InitializeComponent();
        }

        public PatientsTable(Main main, PatientEntity patientEntity)
        {
            InitializeComponent();
            this.main = main;
            this.entity = patientEntity;
            this.PatientName.Text = this.entity.LastName + " " + this.entity.Name + " " + this.entity.MiddleName;
            this.Diagnoz.Text = "Диагноз: " + this.entity.Diagnoz;
            this.DateBirth.Text = "Дата рождения:" + this.entity.DateBirth.ToString("dd.MM.yyyy",CultureInfo.CurrentCulture);
            this.PatientHistory.Text = this.entity.History;
            if (entity.AvatarBase64 != null)
                this.Avatar.Source = Images.Load(this.entity.AvatarBase64);

            var collection = Collection<Entity.PatientNote>.List(new MongoDB.Bson.BsonDocument("PatientId", patientEntity.Id));
            foreach (var item in collection)
            {
                this.patientNotes.Children.Add(new Components.PatientNote(main, item, entity));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new Patient(main, entity, true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NoteWindow window = new NoteWindow(main, Dto.NoteType.PatientNoteWindow, null, entity.Id);
            if (window.ShowDialog().Value)
                main.MainFrame.Content = new PatientsTable(main, entity);
        }

        void Button_Back(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new MyPatients(main);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteObj deleteObj = new DeleteObj();
            if (deleteObj.ShowDialog().Value)
            {
                Collection<PatientEntity>.Del(entity);
                main.MainFrame.Content = new MyPatients(main);
            }
        }
    }
}
