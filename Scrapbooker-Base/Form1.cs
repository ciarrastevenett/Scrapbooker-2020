using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Drawing.Imaging;
using Scrapbooker_Base;

namespace Stage_Scrapbooker
{
    public partial class Form1 : Form
    {

        DeviceManager deviceManager = new DeviceManager();
        public Form1()
        {
            InitializeComponent();
        }
        private void lblListOfScanner_Click(object sender, EventArgs e)
        {

        }

        public void Save(string filename)
        {
            filename = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {


                //Create a DeviceManager instance
                var deviceManager = new DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }

                    lstListOfScanner.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value()); //gets the list of scanners and adds their name to the listbox
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void btnScan_Click(object sender, EventArgs e)
        {
           try
            {

                var deviceManager = new DeviceManager();

                DeviceInfo AvailableScanner = null;

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }

                    AvailableScanner = deviceManager.DeviceInfos[i];

                    break;
                }

                var device = AvailableScanner.Connect(); //Connect to the available scanner.

                var ScannerItem = device.Items[1]; // select the scanner.
            

                var imgFile = (ImageFile)ScannerItem.Transfer(FormatID.wiaFormatJPEG); //Retrive an image in Jpg format and store it into a variable.

                //string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
               // string filePath = Path + @"\ImagesFolder-Scrapbooker";
                //save the image in some path with filename.
                string Path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string fileName = DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpeg";
                string filePath = Path + @"\ImagesFolder-Scrapbooker\" + fileName;

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                imgFile.SaveFile(filePath);
                pictureBox1.ImageLocation = filePath;

                //Call function to save the img to our database
                FileInfo fi = new FileInfo(filePath);
                string fileFormat = fi.Extension;
                long fileSize = fi.Length / 1000;
                addImageToFileTable(fileName, filePath, fileFormat, fileSize);


            }
            catch (COMException ex)
                {
                MessageBox.Show(ex.Message);
                }

            }

        // responsible to save the img info in our db
        private void addImageToFileTable(string fileName, string filePath, string fileFormat, long fileSize)
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
