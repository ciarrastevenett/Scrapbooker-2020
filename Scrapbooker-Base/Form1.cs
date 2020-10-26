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
using System.Windows.Data;



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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Create a DeviceManager instance
                var deviceManager = new DeviceManager();

                for (int i = 0; i <= deviceManager.DeviceInfos.Count; i++) // Loop Through the get List Of Devices.
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType) // Skip device If it is not a scanner
                    {
                        continue;
                    }

                    lstListOfScanner.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"]); //gets the list of scanners and adds their name to the listbox
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

                var ScanerItem = device.Items[1]; // select the scanner.

                ImageFile imgFile = (ImageFile)ScanerItem.Transfer(FormatID.wiaFormatJPEG); //Retrive an image in Jpg format and store it into a variable.

                // 1) Get the string representing the application root directory
                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // 2) Create a new object DirectoryInfo using our path
                DirectoryInfo directory = new DirectoryInfo(path);
                string

                                // 3) Define the image's folder name within the path
                                imageFolderPath = path + @"\ImagesFolder-Scrapbooker";

                // 4) Check if the directory exists if not, it will create the images folder
                if (!Directory.Exists(imageFolderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(imageFolderPath);
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}