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


        public CornerRadius PlaceHolderCornerRadius
        {
            get { return (CornerRadius)GetValue(PlaceHolderCornerRadiusProperty); }
            set { SetValue(PlaceHolderCornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceHolderCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderCornerRadiusProperty =
            DependencyProperty.Register("PlaceHolderCornerRadius", typeof(CornerRadius), typeof(CustomTextField), new PropertyMetadata(new CornerRadius(11)));


        public  Thickness PlaceHolderPadding
        {
            get { return (Thickness)GetValue(PlaceHolderPaddingProperty); }
            set { SetValue(PlaceHolderPaddingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderPaddingProperty =
            DependencyProperty.Register("PlaceHolderPaddingProperty", typeof(Thickness), typeof(CustomTextField), new PropertyMetadata(new Thickness(0)));
        
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
