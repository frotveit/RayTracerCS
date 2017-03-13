using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RayTracerCSharp
{
    public partial class Form_RT : Form
    {
        public Form_RT()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem_ClickClose(object sender, EventArgs e)
        {
            this.Close();

        }
        private void toolStripMenuItem_ClickTest (object sender, EventArgs e)
        {
            textBoxLog.AppendText("Starting image test \n");
            textBoxLog.AppendText("X = " + RT_Definitions.CONST_IMAGEX.ToString() );
            textBoxLog.AppendText(" Y = " + RT_Definitions.CONST_IMAGEX.ToString() );
            textBoxLog.AppendText(" \n");
            T_Image testImage1 = new T_Image(
                RT_Definitions.CONST_IMAGEX, 
                RT_Definitions.CONST_IMAGEY);
            T_Image testImage2 = new T_Image(
                RT_Definitions.CONST_IMAGEX,
                RT_Definitions.CONST_IMAGEY);

            textBoxLog.AppendText("Setting test data \n");
            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    double light = i/2;
 //                   textBoxLog.AppendText("Testdata " + light.ToString() + " /n");
                    testImage1.setPixel(i, j, light);
                }
            }
            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    testImage2.setPixel(i, j, j / 2);
                }
            }
            textBoxLog.AppendText("Writing test image \n"); 
            // testImage1.writeImage("test1.bmp");
            // testImage2.writeImage("test2.bmp");
            testImage1.writeRasterAsPGM8("test1.pgm");
            testImage2.writeRasterAsPGM8("test2.pgm");
            textBoxLog.AppendText("Finished Test \n");



        }

    }
}