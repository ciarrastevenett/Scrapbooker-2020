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
                    cbItems.Add(new ComboBoxItem { Content = alb.albumName });
                }
            }

        }
    }
}
