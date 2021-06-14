using Meddoc.App.Entity;
using Meddoc.App.Forms;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Meddoc.App.Helper;
using Meddoc.App.Components;
using System.IO;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using DB = Meddoc.App.Helper;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {

        List<Note> notes;

        public Main()
        {
            InitializeComponent();


            if (Configuration.currentUser.FirstName == null && Configuration.currentUser.LastName == null)
                this.Login.Text = Configuration.currentUser?.Login;
            else
            {
                this.Login.Text = Configuration.currentUser.FirstName + " " + Configuration.currentUser.MiddleName + " " + Configuration.currentUser.LastName + " ";
            }
            if (Configuration.currentUser != null && Configuration.currentUser.ImageBase64 != null)
                this.Logo.Source = Images.Load(Configuration.currentUser?.ImageBase64);

            this.MainFrame.Content = new CalendarAndPatients(this);
            this.Search.Textbox.PreviewMouseDown += SearchInput;
            this.Search.Textbox.TextChanged += SearchInputTextChanged;


        }

        private void SearchInputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(this.MainFrame.Content is MyPatients))
            {
                this.MainFrame.Content = new MyPatients(this);
            }

            MyPatients patients = (MyPatients)this.MainFrame.Content;
            ListCollectionView collectionView = new ListCollectionView(patients.collection);
            string value = this.Search.Textbox.Text;

            collectionView.Filter = (obj) => ((PatientEntity)obj).LastName.Contains(value);

            patients.Table.ItemsSource = collectionView;
        }

        private void SearchInput(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Content = new MyPatients(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new CalendarAndPatients(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new MyPatients(this);
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new AddNewReception();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Content = new Patient(this, new PatientEntity());
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Content = new UserInfo(this);
        }

        async void Button_Important_Click(object sender, RoutedEventArgs e)
        {
            Visibility visibility;

            if (this.NotesScroll.Visibility == Visibility.Visible)
            {
                visibility = Visibility.Hidden;

                this.Notes.Visibility = visibility;
                this.NotesScroll.Visibility = visibility;
                this.importantArrow.Source = new BitmapImage(new Uri("/Assets/ArrowDown.png", UriKind.Relative));
            }
            else
            {
                visibility = Visibility.Visible;

                this.Notes.Visibility = visibility;
                this.NotesScroll.Visibility = visibility;
                if (this.Notes.Children.Count == 0)
                {
                    await GetNotes();
                }
                this.importantArrow.Source = new BitmapImage(new Uri("/Assets/ArrowUp.png", UriKind.Relative));
            }
        }

        public async Task GetNotes()
        {
            this.importantArrow.Visibility = Visibility.Hidden;
            this.Loader.Visibility = Visibility.Visible;

            var list = await DB.Collection<Note>.ListAsync(new BsonDocument());
            this.Notes.Children.Clear();
            list.ToList().ForEach(note => this.Notes.Children.Add(new Memo(note)));
            this.Loader.Visibility = Visibility.Hidden;
            this.importantArrow.Visibility = Visibility.Visible;
        }
    }
}
