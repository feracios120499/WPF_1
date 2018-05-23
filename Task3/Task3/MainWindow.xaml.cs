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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static Random r = new Random();
        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas.SetLeft(button, r.Next(0, Convert.ToInt32(this.Width - 100)));
            Canvas.SetTop(button, r.Next(0, Convert.ToInt32(this.Height - 100)));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("cool");
        }
    }
}
