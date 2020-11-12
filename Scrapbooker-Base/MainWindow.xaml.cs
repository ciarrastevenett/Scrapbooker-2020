﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Reflection;
using Scrapbooker_Base;
using WIA;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

// TODO: Separate necessary classes/methods/namespace

namespace Stage_Scrapbooker
{
    public partial class MainWindow : Window
    {
        private string imageFolderPath;

        public MainWindow()
        {
            InitializeComponent();

            Main.Content = new Upload();

            /*
             * Process to create the main folder to store the app's images in 4 steps
             * Reference: https://stackoverflow.com/questions/39832642/how-to-find-root-path-of-wpf-app-and-create-folder-on-root-directory-for-saving
             */
            // TODO: Error handling if the folder can't be created by any reason
            // 1) Get the string representing the application root directory
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // 2) Create a new object DirectoryInfo using our path
            DirectoryInfo directory = new DirectoryInfo(path);

            // 3) Define the image's folder name within the path
            imageFolderPath = path + @"\ImagesFolder-Scrapbooker";

            // 4) Check if the directory exists if not, it will create the images folder
            if (!Directory.Exists(imageFolderPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(imageFolderPath);
            }

        }

        private void BtnClickUpload(object sender, RoutedEventArgs e)
        {
            //Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            //op.Title = "Select a picture";
            //op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            //  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            //  "Portable Network Graphic (*.png)|*.png";
            //if (op.ShowDialog() == true)
            //{
            //    imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            //}
            Main.Content = new Upload();
        }

        private void BtnClickBrowse(object sender, RoutedEventArgs e)
        {
            Main.Content = new Browse();
        }

        private void BtnClickDetail(object sender, RoutedEventArgs e)
        {
            Main.Content = new DetailPage();
        }

        private void BtnClickSettings(object sender, RoutedEventArgs e)
        {
            Main.Content = new SettingsPage();
        }
        
        private void BtnClickScan(object sender, RoutedEventArgs e)
        {
            Form1 scanForm = new Form1();
            //this.Visibility = Visibility.Hidden;
            scanForm.Show();
        }

    }
}
    

