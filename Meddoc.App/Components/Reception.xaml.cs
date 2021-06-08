using Meddoc.App.Entity;
using Meddoc.App.Forms;
using Meddoc.App.Helper;
using MongoDB.Bson;
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

namespace Meddoc.App.Components
{
    /// <summary>
    /// Логика взаимодействия для Reception.xaml
    /// </summary>
    public partial class Reception : UserControl
    {
        Main main;
        ReceptionEntity entity;
        public Reception(Main main, ReceptionEntity entity)
        {
            InitializeComponent();
            this.main = main;
            this.entity = entity;
            this.Time.Text = entity.Time.ToString();
            var document = new BsonDocument
            {
                {"_id",this.entity.PatientEntity }
            };
            this.Name.Text = Collection<PatientEntity>.Load(document)?.Name;
            this.Description.Text = this.entity.Info;
        }

        private void Name_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.MainFrame.Content = new AddNewReception(entity);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new AddNewReception(entity);
        }
    }
}
