using System.Windows;
using System.Windows.Controls;
using Meddoc.App.Forms;
using MongoDB.Bson;

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
            this.Date.Text = note.dateCreate.ToString("dd.MM.yyyy");
            this.Text.Text = note.Text;
            this.Width = 374;
            this.Height = 210;
            this.Margin = new Thickness(0, 0, 5, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NoteWindow window = new NoteWindow(main, Dto.NoteType.PatientNoteWindow, note, patientEntity.Id);
            if (window.ShowDialog().Value == true)
            {
                main.MainFrame.Content = new PatientsTable(main, patientEntity);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
