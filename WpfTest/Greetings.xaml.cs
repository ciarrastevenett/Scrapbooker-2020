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

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
             class Program
        {
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Hello_Button.IsChecked != true)
            {
                if (GoodbyeButton.IsChecked == true)
                {
                    MessageBox.Show("Goodbye.");
                }
            }
            else
            {
                MessageBox.Show("Hello.");
            }
        }
    }
    }

