using Meddoc.App.Components;
using Meddoc.App.Entity;
using Meddoc.App.Helper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
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
using System.Linq;

namespace Meddoc.App
{
    /// <summary>
    /// Логика взаимодействия для CalendarAndPatients.xaml
    /// </summary>
    public partial class CalendarAndPatients : Page
    {
        Main main;

        public CalendarAndPatients(Main main)
        {
            InitializeComponent();
            this.main = main;
            this.CalendarItem.SelectedDate = DateTime.Now;
            GetCurrentDatePatients(this.CalendarItem);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            NoteWindow note = new NoteWindow(main, Dto.NoteType.NoteWindow, null, new ObjectId());
            if (note.ShowDialog().Value == true)
            {
                await main.GetNotes();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new AddNewReception(main);
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            GetCurrentDatePatients(calendar);
        }

        private void PART_HeaderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        void GetCurrentDatePatients(Calendar calendar)
        {
            this.CurrentDate.Text = String.Format("{0:dd MMMM yyyy}", calendar.SelectedDate);
            DateTime selectedDate = calendar.SelectedDate.Value.Date;
            DateTime selectedDateNewDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day + 1);
            this.Receptions.Children.Clear();

            var filterByNow = Builders<ReceptionEntity>.Filter.Gte(r => r.Time, selectedDate);
            var filterByDayPlusOne = Builders<ReceptionEntity>.Filter.Lte(r => r.Time, selectedDateNewDate);
            var filter = Builders<ReceptionEntity>.Filter.And(filterByNow, filterByDayPlusOne);
            var collection = Collection<ReceptionEntity>.List(filter);
            foreach (var item in collection)
            {
                var reception = new Reception(main, item);
                this.Receptions.Children.Add(reception);
            }
            this.PatientsCount.Text = "В этот день" + collection.Count + " пациент(а)(ов)";
        }

        void SetBlackOutDates(Calendar calendar)
        {
            // найти все записи за месяц.
            // и проставить все Selected даты


            var dateTimeCurrentMonth = new DateTime(calendar.SelectedDate.Value.Year, calendar.SelectedDate.Value.Month, 1);
            var dateTimeNextMonth = new DateTime(calendar.SelectedDate.Value.Year, calendar.SelectedDate.Value.Month + 1, 1);

            var filterByMonth = Builders<ReceptionEntity>.Filter.Gte(re => re.Time, dateTimeCurrentMonth);
            var filterByNextMonth = Builders<ReceptionEntity>.Filter.Lte(re => re.Time, dateTimeNextMonth);
            var filter = Builders<ReceptionEntity>.Filter.And(filterByMonth, filterByNextMonth);
            var collection = Collection<ReceptionEntity>.List(filter);
            var listDays = collection.Select(item => item.Date.Day).Distinct().ToList();
            
            listDays.ForEach(day =>
            {
                var year = calendar.SelectedDate.Value.Year;
                var month = calendar.SelectedDate.Value.Month;
                var date = new DateTime(year, month, day);
                calendar.BlackoutDates.Add(new CalendarDateRange(date));
            });
        }

    }
}
