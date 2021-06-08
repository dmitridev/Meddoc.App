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

        public PatientsTable(Main main,PatientEntity patientEntity)
        {
            InitializeComponent();
            this.entity = patientEntity;
            this.PatientName.Text = this.entity.LastName + " " + this.entity.Name + " " + this.entity.MiddleName;
            this.Diagnoz.Text = "Диагноз: " + this.entity.Diagnoz;
            this.DateBirth.Text = "Дата рождения:" + this.entity.DateBirth.ToString();
            this.PatientHistory.Text = this.entity.History;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new Patient();
        }
    }
}
