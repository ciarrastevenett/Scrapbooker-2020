using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Reflection;
using Scrapbooker_Base;
using WIA;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ModernWpf.Controls;
using System.Linq;

// TODO: Separate necessary classes/methods/namespace

namespace Stage_Scrapbooker
{
    public partial class MainWindow : Window
    {
        private string imageFolderPath;

        public MainWindow()
        {
            InitializeComponent();
            //Makes the app start on the center of the screen
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            ContentFrame.Content = new Upload();

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

/*        private void BtnClickUpload(object sender, RoutedEventArgs e)
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
            ContentFrame.Content = new Upload();
        }*/

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {

/*            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }*/
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Content = new SettingsPage();
            }
            else
            {
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            if (item.Tag.Equals("scan"))
            {
                Form1 scanForm = new Form1();
                scanForm.Show();
            }
            else
            {
                switch (item.Tag)
                {
                    case "browse":
                        ContentFrame.Content = new Browse();
                        break;

                    case "upload":
                        ContentFrame.Content = new Upload();
                        break;
                }
            }
        }
    }
}
    

