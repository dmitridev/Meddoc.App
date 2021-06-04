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
        public PatientsTable()
        {
            InitializeComponent();
        }

        public PatientsTable(PatientEntity patientEntity)
        {
            InitializeComponent();
        }
    }
}
