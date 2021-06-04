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

namespace Meddoc.App.Components
{
    /// <summary>
    /// Логика взаимодействия для Memo.xaml
    /// </summary>
    public partial class Memo : UserControl
    {
        public Memo()
        {
            InitializeComponent();
        }

        public Memo(Note note)
        {
            InitializeComponent();
            this.NoteText.Text = note.Text;
            this.Title.Text = note.Title;
            this.Margin = new Thickness(0, 20, 0, 20);
        }
    }
}
