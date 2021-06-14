using System.Windows;
using System.Windows.Controls;
using Meddoc.App.Forms;
using MongoDB.Bson;
using Meddoc.App.Helper;
using System.Globalization;

namespace Meddoc.App.Components
{
    /// <summary>
    /// Логика взаимодействия для PatientNote.xaml
    /// </summary>
    public partial class PatientNote : UserControl
    {
        Main main;
        Entity.PatientNote note;
        Entity.PatientEntity patientEntity;
        public PatientNote()
        {
            InitializeComponent();
        }

        public PatientNote(Main main, Entity.PatientNote note, Entity.PatientEntity patientEntity)
        {
            this.main = main;
            this.note = note;
            this.patientEntity = patientEntity;
            InitializeComponent();
            this.Date.Text = note.dateCreate.ToString("dd.MM.yyyy", CultureInfo.CurrentCulture);
            this.Text.Text = note.Text;
            this.Width = 374;
            this.Height = 210;
            this.Margin = new Thickness(0, 0, 5, 0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NoteWindow noteWindow = new NoteWindow(main, note);
            if (noteWindow.ShowDialog().Value)
            {
                main.MainFrame.Content = new PatientsTable(main, this.patientEntity);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DeleteObj deleteObj = new DeleteObj();
            if (deleteObj.ShowDialog().Value)
            {
                Collection<Entity.PatientNote>.Del(this.note);
                main.MainFrame.Content = new PatientsTable(main, this.patientEntity);
            }
        }
    }
}
