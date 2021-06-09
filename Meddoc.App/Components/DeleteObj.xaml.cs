﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Meddoc.App.Components
{
    /// <summary>
    /// Логика взаимодействия для DeleteObj.xaml
    /// </summary>
    public partial class DeleteObj : Window
    {
        public DeleteObj()
        {
            InitializeComponent();
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
