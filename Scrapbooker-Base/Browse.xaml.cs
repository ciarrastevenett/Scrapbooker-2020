using Scrapbooker_Base;
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
using System.Data.SqlClient;
using Scrapbooker_Base;

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

            // Start the connection with the DB
            ApplicationDBEntities1 db = new ApplicationDBEntities1();

            // Save all rows from the "Files" table inside an array
            var images = from d in db.Files
                         select d;
            // Iterate over the array let us use the information in each row (singleImage)
            foreach (var singleImage in images)
            {
                Console.WriteLine(singleImage.filePath); //The path for the image
                Console.WriteLine(singleImage.id); //the ID - TO BE SEND with the click event when the user clicks in an image
            }


        }

        public object Main { get; private set; }

        //Reference for displaying one picture: http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/Loadimageinyourcodeandaddtogrid.htm
        //Reference to find files inside a folder: https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=netcore-3.1
        public void PageLoaded(object sender, RoutedEventArgs args)
        {
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

                listBox.Items.Add(simpleImage);
            }

        }


        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (object item in listBox.Items)
            {

                NavigationService.Navigate(new Uri("/DetailPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}
