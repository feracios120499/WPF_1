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
using System.Data.SQLite;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLiteConnection sqlConnection = new SQLiteConnection("Data Source=client.db");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            Canvas.SetLeft(line, Canvas.GetLeft(label1) + 1);
            line.Width = label1.Width;
            stackPanelCheckIn.Visibility = Visibility.Visible;
            stackPanelCheckIn.BringIntoView();
            stackPanelCheckIn.Background = new SolidColorBrush(Color.FromRgb(Convert.ToByte(slider.Value), Convert.ToByte(slider1.Value), Convert.ToByte(slider2.Value)));
        }

        private void label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.SetLeft(line, Canvas.GetLeft(label) + 1);
            line.Width = label.Width;
            stackPanelCheckIn.Visibility = Visibility.Hidden;
        }

        private void slider_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
            
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            stackPanelCheckIn.Background = new SolidColorBrush(Color.FromRgb(Convert.ToByte(slider.Value), Convert.ToByte(slider1.Value), Convert.ToByte(slider2.Value)));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            try
            {
                
                SQLiteCommand command = new SQLiteCommand("INSERT INTO client VALUES(@Name,@R,@G,@B)", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox.Text);
                command.Parameters.AddWithValue("R", slider.Value);
                command.Parameters.AddWithValue("G", slider1.Value);
                command.Parameters.AddWithValue("B", slider2.Value);
                command.ExecuteNonQuery();
                
                Task2.Content cont = new Task2.Content(textBox.Text, Color.FromRgb(Convert.ToByte(slider.Value), Convert.ToByte(slider1.Value), Convert.ToByte(slider2.Value)));
                cont.Show();
            }
            catch
            {
                MessageBox.Show("Такое имя уже зарегестрированно", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            sqlConnection.Close();
        }
        class Client
        {
            public string Name { get; set; }
            public Color color { get; set; }
            public Client(string Name,Color color)
            {
                this.Name = Name;
                this.color = color;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM client", sqlConnection);
            SQLiteDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                comboBox.Items.Add(new Client(dr["Name"].ToString(), Color.FromRgb(Convert.ToByte(dr["R"]), Convert.ToByte(dr["G"]), Convert.ToByte(dr["B"]))));
            }
            sqlConnection.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Client client = comboBox.SelectedItem as Client;
            if (client == null) return;
            Task2.Content cont = new Task2.Content(client.Name, client.color);
            cont.Show();
        }
    }
}
