using Meddoc.App.Entity;
using Meddoc.App.Forms;
using Meddoc.App.Helper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
            this.Time.Text = entity.Time.ToString("HH:mm");
            var document = new BsonDocument
            {
                {"_id",this.entity.PatientEntity }
            };


            TaskAwaiter<PatientEntity> awaiter = Collection<PatientEntity>.Load(document).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                PatientEntity item = awaiter.GetResult();
                this.Name.Text = item?.Name + " " + item?.LastName;
                this.Description.Text = this.entity.Info;
            });
        }

        private void Name_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.MainFrame.Content = new AddNewReception(main, entity);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteObj deleteObj = new DeleteObj();
            bool? result = deleteObj.ShowDialog();
            if (result.Value)
            {
                Collection<ReceptionEntity>.Del(entity);
                main.MainFrame.Content = new CalendarAndPatients(main);
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new AddNewReception(main, entity);
        }
    }
}
