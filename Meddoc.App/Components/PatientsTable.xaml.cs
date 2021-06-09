using System.Windows;
using System.Windows.Controls;
using Meddoc.App.Entity;
using Meddoc.App.Helper;

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
            this.DateBirth.Text = "Дата рождения:" + this.entity.DateBirth.ToString();
            this.PatientHistory.Text = this.entity.History;
            if (entity.AvatarBase64 != null)
                this.Avatar.Source = Images.Load(this.entity.AvatarBase64);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new Patient(main, entity,true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
