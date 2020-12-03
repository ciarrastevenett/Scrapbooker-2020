using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Stage_Scrapbooker
{
    /// <summary>
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        int imgID;
        public DetailPage()
        {
            InitializeComponent();

            // Get File Name  
            //string justFileName = fi.Name;
            //FileName.Text = $"File Name: {justFileName}";
            // Get File extension   
            //string extn = fi.Extension;
            //FileFormat.Text = $"Type: {extn}";
            // Get File Size 
            //long size = fi.Length;
            //FileName.Text = $"Size: {size}";
        }

        public DetailPage(int imageID)
        {
            this.imgID = imageID;
            Console.WriteLine(imgID);

            /*            Image simpleImage = new Image();
                        simpleImage.Width = 200;
                        simpleImage.Margin = new Thickness(5);

                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.UriSource = new Uri(@"C:\Users\lucasmelorl\Pictures\12.jpg", UriKind.RelativeOrAbsolute);
                        bi.EndInit();

                        simpleImage.Source = bi;

                        listDetailPage.Items.Add(simpleImage);*/

            // Get all images from folder
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string imageFolderPath = path + @"\ImagesFolder-Scrapbooker";

            string[] fileEntries = Directory.GetFiles(imageFolderPath);
            // Get all images from DB


            // Loop and create images to add to screen
            foreach (string file in fileEntries)
            {
                Image simpleImage = new Image();
                simpleImage.Width = 200;
                simpleImage.Margin = new Thickness(5);

                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.UriSource = new Uri(file, UriKind.RelativeOrAbsolute);
                bi.EndInit();

                simpleImage.Source = bi;

                listDetailPage.Items.Add(simpleImage);
            }

        }
    }
}
