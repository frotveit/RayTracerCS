using System;
using System.Windows.Forms;

/*------------------------------------------
  CURRENT SETUP
  COP is def as 0,0,0
  View window is defined by Z value, X and Y is centered on origo
**------------------------------------------*/


namespace RayTracerCSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainController controller = new MainController();
            
            Application.Run(controller.Form);
        }
    }







}