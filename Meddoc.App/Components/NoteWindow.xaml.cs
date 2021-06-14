using Meddoc.App.Entity;
using Meddoc.App.Helper;
using MongoDB.Bson;
using System;
using System.Windows;
using Meddoc.App.Dto;
using System.Globalization;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для Note.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        public Note note;
        public PatientNote patientNote;
        public Main main;
        public ObjectId patientId;
        NoteType noteType;

        public NoteWindow(Main main, ObjectId objectId)
        {
            this.main = main;

            if (objectId != null)
            {
                var document = new BsonDocument("_id", objectId);
                patientNote = Collection<PatientNote>.Load(document).GetAwaiter().GetResult();
            }
            InitializeComponent();
            this.NoteDate.Text = patientNote.dateCreate.ToString("dd.MM.yyyy", CultureInfo.CurrentCulture);
            this.NoteText.Text = patientNote.Text;
            patientId = patientNote.PatientId;
        }

        public NoteWindow(Main main, PatientNote patientNote)
        {
            this.main = main;
            this.patientNote = patientNote;
            InitializeComponent();
            this.NoteDate.Text = patientNote.dateCreate.ToString("dd.MM.yyyy", CultureInfo.CurrentCulture);
            this.NoteText.Text = patientNote.Text;
            patientId = patientNote.PatientId;
        }

        public NoteWindow(Main main, NoteType type, object noteOrPatientNote, ObjectId patientId)
        {
            if (patientId != null)
                this.patientId = patientId;

            this.noteType = type;
            this.main = main;
            if (type == NoteType.NoteWindow)
            {
                if (noteOrPatientNote != null)
                {
                    var document = new BsonDocument("id", ((Note)noteOrPatientNote).Id);
                    note = Collection<Note>.Load(document).GetAwaiter().GetResult();
                    this.NoteDate.Text = note.dateCreate.ToString("HH:mm", CultureInfo.CurrentCulture);
                    this.NoteText.Text = note.Text;

                }
                else note = new Note();
            }

            if (type == NoteType.PatientNoteWindow)
            {
                if (noteOrPatientNote != null)
                {
                    var document = new BsonDocument("id", ((PatientNote)noteOrPatientNote).Id);
                    patientNote = Collection<PatientNote>.Load(document).GetAwaiter().GetResult();
                }
                else patientNote = new PatientNote();
            }
            InitializeComponent();
        }

        public void ClickCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void ClickAdd(object sender, RoutedEventArgs e)
        {
            if (noteType == NoteType.NoteWindow)
            {
                if (note.Id == ObjectId.Empty)
                    note.Id = ObjectId.GenerateNewId();


                note.Title = this.NoteTitle.Text;
                note.Text = this.NoteText.Text;
                note.dateCreate = DateTime.Now;

                Collection<Note>.Save(note);
            }
            else if (noteType == NoteType.PatientNoteWindow)
            {
                if (patientNote.Id == ObjectId.Empty)
                    patientNote.Id = ObjectId.GenerateNewId();

                patientNote.Text = this.NoteText.Text;
                patientNote.dateCreate = DateTime.Now;
                patientNote.PatientId = patientId;

                Collection<PatientNote>.Save(patientNote);
            }
            DialogResult = true;
            this.Close();
        }

    }
}
