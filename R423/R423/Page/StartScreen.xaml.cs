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
using System.Windows.Shapes;

namespace R423.Page
{
    /// <summary>
    /// Логика взаимодействия для StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        private Window _parent;
        public StartScreen(Window parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _parent.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _parent.Close();
        }
    }
}
