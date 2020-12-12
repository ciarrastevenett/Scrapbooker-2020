using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Scrapbooker_Base
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    /// 
    public partial class Details : Page
    {
        int imgID;
        int albumSelectedToAddRemove;
        private int albumSelected;
        public ObservableCollection<ComboBoxItem> cbItems { get; set; }
        public ComboBoxItem SelectedcbItem { get; set; }
        public Details()
        {
            InitializeComponent();
        }

        public Details(int imageID)
        {
            InitializeComponent();

            //Initial setting for the Combobox (Dropdown) with the albums (NO NEED TO CHANGE)
            DataContext = this;
            cbItems = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "<--Select-->" };
            SelectedcbItem = cbItem;
            cbItems.Add(cbItem);

            //Store the IF of the image
            this.imgID = imageID;
            this.loadAbums();

            //Query the DB based on the ID received
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            var images = from d in db.Files
                         where d.id.Equals(imgID)
                         select d;

            foreach (var el in images)
            {
                //Name of the file
                FileName.Text = $"{el.fileName}";
                // Size in KB
                FileSize.Text = $"{el.fileSize} KB";

                //Display the image on the screen
                var uriSource = new Uri(el.filePath, UriKind.RelativeOrAbsolute);
                singleImage.Source = new BitmapImage(uriSource);

                //Query the Albums table to get a list of albuns availables
                var albums = from d in db.Albums
                             select d;

                foreach (var alb in albums)
                {
                    //For every "album", display on our combobox
                    cbItems.Add(new ComboBoxItem { Content = alb.albumName, Tag = alb.id });
                }
            }

        }

        private void album_list_Main_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)listAlbums.SelectedItem;
            string contentName = typeItem.Content.ToString();

            Console.WriteLine("album name: " + contentName);
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            var selectedItem = from el in db.Albums
                               where el.albumName == contentName
                               select el;

            if(selectedItem.FirstOrDefault<Album>() != null)
            {
                albumSelectedToAddRemove = selectedItem.FirstOrDefault<Album>().id;
            }
        }

        private void album_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Album album = (Album)album_list.SelectedItem;
            if (album is object)
            {
                //ID of Albu selected
                albumSelected = album.id;
                Console.WriteLine(albumSelected);
            }
        }

        private void addAlbum_Click(object sender, RoutedEventArgs e)
        {
            //TO DO: Grab selected album and add image to DB ImagesAlbums
            // Re-load the list

            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            ImagesInAlbum albumObject = new ImagesInAlbum()
            {
                fileID = this.imgID,
                albumID = albumSelectedToAddRemove
            };

            db.ImagesInAlbums.Add(albumObject);
            db.SaveChanges();
            this.loadAbums();

        }

        private void deleteAlbum_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            var selectedItem = from el in db.ImagesInAlbums
                               where el.fileID == this.imgID &&
                                el.albumID == this.albumSelected
                               select el;

            ImagesInAlbum albumToDelete = selectedItem.SingleOrDefault();

            if (albumToDelete != null)
            {
                db.ImagesInAlbums.Remove(albumToDelete);
                db.SaveChanges();
            }
            this.loadAbums();
        }

        private void loadAbums()
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            var selectedItem = from el in db.ImagesInAlbums
                               join b in db.Albums
                               on el.albumID equals b.id
                               where el.fileID == this.imgID
                               select b;

            this.album_list.ItemsSource = selectedItem.ToList();
        }
    }
}
