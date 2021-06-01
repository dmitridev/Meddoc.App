using Meddoc.App.Entity;
using Meddoc.App.Helper;
using MongoDB.Bson;
using System;
using System.Windows;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для Note.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        public Note note;
        public NoteWindow(long id)
        {
            InitializeComponent();
            if (id != 0)
            {
                note = Collection<Note>.Load(id);
            }
            else
            {
                note = new Note();
            }
        }

        public void ClickCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ClickAdd(object sender, RoutedEventArgs e)
        {
            if(note.Id == ObjectId.Empty)
                note.Id = ObjectId.GenerateNewId();
            
            note.Title = this.NoteTitle.Text;
            note.Text = this.NoteText.Text;
            note.dateCreate = DateTime.Now;

            Collection<Note>.Save(note);
            this.Close();
        }

    }
}
