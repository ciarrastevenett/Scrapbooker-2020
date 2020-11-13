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

namespace Stage_Scrapbooker
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Page
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void FileDropStackPanel_Drop(object sender, DragEventArgs e)
        {
            // 1)Check if there is any file or if it can be converted
            // TODO: Only allow images to be uploaded
            // TODO: Error handling 
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string imageFolderPath = path + @"\ImagesFolder-Scrapbooker";

                //2) Create an array to store the origin path of the dropped files
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // 3) Edit the title to inform how many images were uploaded
                FileNameLabel.Content = $"{files.Length} images were uploaded!";

                // Iterate over our array with the images' path and make a compy to our application directory
                // The "true" at the end allows our application to ovewrite existing files with the same name and format
                // TODO: If we don't allow upload the same image, add error handling
                foreach (string file in files)
                {
                    System.IO.File.Copy(file, $"{imageFolderPath}\\{System.IO.Path.GetFileName(file)}", true);

                    FileInfo fi = new FileInfo(file);
                    string fileName = fi.Name;
                    string filePath = imageFolderPath + "\\" + fileName;
                    string fileFormat = fi.Extension;
                    long fileSize = fi.Length / 1000;
                    addImageToFileTable(fileName, filePath, fileFormat, fileSize);
                }
            }
        }

        public void addImageToFileTable(string fileName, string filePath, string fileFormat, long fileSize)
        {
            ApplicationDBEntities1 db = new ApplicationDBEntities1();
            Scrapbooker_Base.File imageObject = new Scrapbooker_Base.File()
            {
                fileName = fileName,
                filePath = filePath,
                fileFormat = fileFormat,
                fileSize = fileSize

            };
            db.Files.Add(imageObject);
            db.SaveChanges();

        }
    }
}
