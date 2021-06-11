using Meddoc.App.Components;
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
using Meddoc.App.Helper;
using System.Globalization;

namespace Meddoc.App.Forms
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        Main main;
        public UserInfo()
        {
            InitializeComponent();

        }

        public UserInfo(Main main)
        {
            InitializeComponent();
            this.main = main;
            User user = Configuration.currentUser;
            this.Work.Text = user.Work;
            this.DateBirth.Text = user.DateBirth.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            this.Name.Text = user.LastName + " " + user.FirstName + " " + user.MiddleName;
            if (user.ImageBase64 != null)
                this.Logo.Source = Images.Load(user.ImageBase64);

            this.Count.Text = Collection<PatientEntity>.Count().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Content = new EditUser();
        }
    }
}
