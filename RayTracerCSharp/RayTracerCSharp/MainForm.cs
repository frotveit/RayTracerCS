using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RayTracerCSharp
{
    public partial class MainForm : Form, IDisplay
    {
        private MainController MainController;

        public MainForm(MainController mainController)
        {
            InitializeComponent();
            MainController = mainController;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ClickQuit(object sender, EventArgs e)
        {
            Close();
        }

        private void ClickTest(object sender, EventArgs e)
        {            
            PictureBox.Image = new BitmapImage().CreateTestImage();
        }

        private void ClickRunRayTracer(object sender, EventArgs e)
        {
            MainController.RunRayTracer();
        }

        public void DisplayImage(Image image)
        {
            PictureBox.Image = new BitmapImage().Get(image);
        }

        public void DisplayLog(IEnumerable<string> log)
        {
            foreach (string logText in log)
            {
                textBoxLog.AppendText(logText + "\n");
            }
        }
    }
}