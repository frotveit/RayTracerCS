

namespace RayTracerCSharp
{
    
    /// <summary>
    /// The image that is built up and presented
    /// </summary>
    public class Image
    {
        
        public int sizeX, sizeY;
        public double[,] data; // array with pixel data

        
        public Image(int setX, int setY)
        {
            data = new double[setX, setY];
            //image = new Bitmap(setX, setY, PixelFormat.Format16bppGrayScale);
            sizeX = setX;
            sizeY = setY;
        }

                        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">position in normal x, y grid</param>
        /// <param name="y">position in normal x, y grid</param>
        /// <param name="pixelLight">intensity of light - range 0 - 255</param>
        public void Set(int x, int y, double pixelLight)
        {
            // check range
            if (pixelLight > 255)
            {
                //cout << "ERROR light > 255 " << pixelLight << endl;
                pixelLight = 255;
            }
            if (pixelLight < 0)
            {
                //cout << "ERROR light < 0   " << pixelLight << endl;
                pixelLight = 0;
            }
            data[x, y] = pixelLight; // turning Y range


            /*
                        Color color = new Color();
                        color = Color.FromArgb(lightAsInt+1, lightAsInt+1, lightAsInt+1);
                        KnownColor co = color.ToKnownColor();
                        image.SetPixel(x, y, Color.Black);
             */
        }

        public double Get(int x, int y)
        {
            return data[x, y];
        }

        public void writeImage(string fileName)
        {
            //image.Save(fileName, ImageFormat.Bmp);
        }



    }

}
