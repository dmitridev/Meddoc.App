using System;
using System.Windows;
using System.Windows.Controls;

namespace Meddoc.App.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomTextField.xaml
    /// </summary>
    public partial class CustomTextField : UserControl
    {
        public CustomTextField()
        {
            InitializeComponent();
            DataContext = this;
        }



        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(CustomTextField), new PropertyMetadata(""));
    }
}
