﻿using System;
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

namespace Task1
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Cut();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Copy();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }


        int count = 0;//смотреть сколько построили кругов
        int countKrug = 6;//сколько нужно построить кругов
        private void Krug(int radius)
        {
            //делаем круг
            if (count < countKrug)
            {
                count++;
                Krug(radius + 10);//вызываем новый круг
            }
        }
    }
}
