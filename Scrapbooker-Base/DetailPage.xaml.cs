using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Stage_Scrapbooker
{
    /// <summary>
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();

/*            //Reference for displaying one picture: http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/Loadimageinyourcodeandaddtogrid.htm
            Image simpleImage = new Image();
            simpleImage.Width = 200;
            simpleImage.Margin = new Thickness(5);

            BitmapImage bi = new BitmapImage();

            bi.BeginInit();
            bi.UriSource = new Uri(@"\ImagesFolder-Scrapbooker", UriKind.RelativeOrAbsolute);
            bi.EndInit();

            simpleImage.Source = bi;

            // Add the image to the screen
            simpleGrid.Children.Add(simpleImage);

            //Reference to get the file information: https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-get-a-file-size-in-C-Sharp/
            // Full file name   
            string imageFile = @"\ImagesFolder-Scrapbooker";
            FileInfo fi = new FileInfo(imageFile);

            // Get File Name  
            string justFileName = fi.Name;
            FileName.Text = $"File Name: {justFileName}";
            // Get File extension   
            string extn = fi.Extension;
            FileFormat.Text = $"Type: {extn}";
            // Get File Size 
            //long size = fi.Length;
            //FileName.Text = $"Size: {size}";*/
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
