using System;
using System.Windows.Controls;

namespace Meddoc.App.Components
{
    /// <summary>
    /// Логика взаимодействия для CustomTextField.xaml
    /// </summary>
    public partial class CustomTextField : UserControl
    {
        private string PlaceHolder { get; set; }
        public CustomTextField()
        {
            InitializeComponent();
        }
    }
}
