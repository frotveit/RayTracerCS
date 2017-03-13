

namespace RayTracerCSharp
{
    public class MainController
    {
        
        public ObjectList ObjectList;
        public Logger Logger;
        public MainForm Form;
        public IDisplay Display { get { return Form; } }

        public MainController()
        {
            Form = new MainForm(this);
            Logger = new Logger();            
        }

        public void RunRayTracer()
        {
            ObjectList = new ObjectList();
            Logger.ClearLog();
            new InitObjects().AddObjects(ObjectList);
            Image image = new RayTracer().RunRaytrace(ObjectList, Logger);
            new PGMWrapper().WriteRasterAsPgm8(image, "C:/TEST/cs.pgm");
            Display.DisplayImage(image);
            Display.DisplayLog(Logger.GetLog());
        }

        
        /*
        BufferedImage image2 = new BufferedImage(RT_SIZE, RT_SIZE, BufferedImage.TYPE_BYTE_GRAY);
        Point image2Origin = new Point (0,0);
        int[] image2BitMask;
        SampleModel image2SampleModel = 
           new SinglePixelPackedSampleModel( DataBuffer.TYPE_BYTE, 
                                             RT_SIZE, RT_SIZE, 
                                             image2BitMask);
        WritableRaster image2Raster = new WritableRaster( image2SampleModel, image2Origin );
        */

    }
}
