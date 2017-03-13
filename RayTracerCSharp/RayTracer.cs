

namespace RayTracerCSharp
{
    public class RayTracer
    {
        const int ImageSizeX = 600; // Size of image in pixels
        const int ImageSizeY = 500; // Size of image in pixels
        const double ImageDistance = 200; // Distance between COP and image 
        // = Z coordinate of image


        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectlist">list of objects to trace</param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public Image RunRaytrace( ObjectList objectlist, ILogger logger )
        {
            logger.Log("Starting tracing");

            Image image = new Image(ImageSizeX, ImageSizeY);

            int traceLevel = 1;

            for (int y = 0; y < ImageSizeY; y++)
            {
                logger.Log("  LINE " + y);
            
                for (int x = 0; x < ImageSizeX; x++)
                {
                    Ray ray = DetermineRayFromCOPThroughPixel(x, y, objectlist);
                    var light = Rayer.RayObjects(objectlist, ray, traceLevel, false, null);
                    image.Set(x, y, light);
                }
            }

            logger.Log("Finished tracing and printing to file \n");

            return image;
        }

        /// <summary>
        /// Determine ray from COP through pixel
        /// COP is defined as (0,0,0)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="objectlist"></param>
        /// <returns></returns>
        public Ray DetermineRayFromCOPThroughPixel(int x, int y, ObjectList objectlist)
        {
            Vector rayVector = new Vector(x - ImageSizeX/2, y - ImageSizeY/2, ImageDistance);
            rayVector.Normalise();
            Ray ray = new Ray(objectlist.COP, rayVector);
            return ray;
        }



    }
}
