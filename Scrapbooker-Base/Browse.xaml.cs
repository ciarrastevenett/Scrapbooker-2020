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
using System.Data;
using System.Collections.ObjectModel;

namespace Stage_Scrapbooker
{
    /// <summary>
    /// Interaction logic for Browse.xaml
    /// </summary>
    public partial class Browse : Page
    {
        private int imgID;
        private int albumSelected;

        public ObservableCollection<ComboBoxItem> cbItems { get; set; }
        public ComboBoxItem SelectedcbItem { get; set; }
        public object Main { get; private set; }


        public Browse()
        {
            InitializeComponent();
          

        }


        //Reference for displaying one picture: http://www.java2s.com/Tutorial/CSharp/0470__Windows-Presentation-Foundation/Loadimageinyourcodeandaddtogrid.htm
        //Reference to find files inside a folder: https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=netcore-3.1
        public void PageLoaded(object sender, RoutedEventArgs args)
        {
            // Get all images from folder
            //string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string imageFolderPath = path + @"\ImagesFolder-Scrapbooker";

            //string[] fileEntries = Directory.GetFiles(imageFolderPath);
            // Get all images from DB
            //*****************************************************************************************
            // Start the connection with the DB
            ApplicationDBEntities1 db = new ApplicationDBEntities1();

            DataContext = this;
            cbItems = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "<--Select-->" };
            SelectedcbItem = cbItem;
            cbItems.Add(cbItem);


            var albums = from d in db.Albums
                         select d;
            foreach (var alb in albums)
            {
                //For every "album", display on our combobox
                cbItems.Add(new ComboBoxItem { Content = alb.albumName, Tag = alb.id });
            }

            var images = from d in db.Files
                         select d;
            // Iterate over the array let us use the information in each row (singleImage)
            foreach (var singleImage in images)
            {

                Image simpleImage = new Image();
                simpleImage.Width = 200;
                simpleImage.Margin = new Thickness(5);
                //String id = singleImage.id.ToString(); //Holding the ID of the image
                simpleImage.Tag = singleImage.id;

                BitmapImage bi = new BitmapImage();

                bi.BeginInit();
                bi.UriSource = new Uri(singleImage.filePath, UriKind.RelativeOrAbsolute);
                bi.EndInit();

                simpleImage.Source = bi;

                listBox.Items.Add(simpleImage);
            }

        }
      

        // Loop and create images to add to screen
        /*            foreach (string file in fileEntries)
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
                    }*/

    
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic elementSelected = listBox.SelectedItem as dynamic;
            int currentID = elementSelected.Tag;
            Details p2 = new Details(currentID);
            NavigationService.Navigate(p2);
        }

        private void PopulateListBox()
        {
            listBox.Items.Clear();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)listAlbums.SelectedItem;
            string contentName = typeItem.Content.ToString();

            Console.WriteLine("album name: " + contentName);
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            var selectedItem = from el in db.Albums
                               where el.albumName == contentName
                               select el;
            if (selectedItem.FirstOrDefault<Album>() != null)
            {
                listBox.Items.Clear();
                //Query the DB
                var selectedAlbum = from el in db.ImagesInAlbums
                                    join b in db.Files
                                    on el.albumID equals b.id
                                    where el.fileID == this.imgID
                                    select b;

                foreach (var singleImage in selectedAlbum)
                {
                    Image simpleImage = new Image();
                    simpleImage.Width = 200;
                    simpleImage.Margin = new Thickness(5);
                    //String id = singleImage.id.ToString(); //Holding the ID of the image
                    simpleImage.Tag = singleImage.id;

                    BitmapImage bi = new BitmapImage();

                    bi.BeginInit();
                    bi.UriSource = new Uri(singleImage.filePath, UriKind.RelativeOrAbsolute);
                    bi.EndInit();

                    simpleImage.Source = bi;

                    listBox.Items.Add(simpleImage);

                }
            }
               

        }

            
    }
}
