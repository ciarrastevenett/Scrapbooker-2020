using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Stage_Scrapbooker
{
    /// <summary>
    /// Interaction logic for Browse.xaml
    /// </summary>
    public partial class Browse : Page
    {
        public Browse()
        {
            InitializeComponent();

        }
        //Reference for displaying one picture: http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/Loadimageinyourcodeandaddtogrid.htm
        //Reference to find files inside a folder: https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=netcore-3.1
        public void PageLoaded(object sender, RoutedEventArgs args)
        {
            // Get all images from folder
            string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string imageFolderPath = path + @"\ImagesFolder-Scrapbooker";

            string[] fileEntries = Directory.GetFiles(imageFolderPath);

            // Loop and create images to add to screen
            foreach (string file in fileEntries)
            {
                int j = 1;
                int i = 1;
                i++;
                if (i % 3 == 0) {
                    j++;
                    i = 1;
                }
                Image simpleImage = new Image();
                simpleImage.Width = 200;
                simpleImage.Margin = new Thickness(5);

                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.UriSource = new Uri(file, UriKind.RelativeOrAbsolute);
                bi.EndInit();

                simpleImage.Source = bi;

                listBox.Items.Add(simpleImage);
                Grid.SetColumn(simpleImage, i);
                Grid.SetRow(simpleImage, j);
                //simpleGrid.Children.Add(simpleImage);


            }

        }
    }
}
