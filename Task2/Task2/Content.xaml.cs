using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для Content.xaml
    /// </summary>
    public partial class Content : Window
    {
        public Content()
        {
            InitializeComponent();
        }
        public Content(string Name,Color color)
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(color);
            this.Title = Name;
        }
    }
}
