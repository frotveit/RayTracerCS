
using System.Drawing;

namespace RayTracerCSharp
{
    public class BitmapImage
    {
        public Bitmap Get( Image image)
        {
            Bitmap bitmapImage = new Bitmap(image.sizeX, image.sizeY);

            // Loop through the images pixels to set color.
            for (int x = 0; x < bitmapImage.Width; x++)
            {
                for (int y = 0; y < bitmapImage.Height; y++)
                {
                    double light = image.Get(x, image.sizeY- y-1);
                    int l = (int)light;
                    Color newColor = Color.FromArgb(l,l,l);
                    bitmapImage.SetPixel(x, y, newColor);
                }
            }

            return bitmapImage;
        }

        public Bitmap CreateTestImage()
        {
            Bitmap image = new Bitmap(256, 256);

            // Loop through the images pixels to set color.
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color newColor = Color.FromArgb(x, x, x);
                    image.SetPixel(x, y, newColor);
                }
            }

            return image;
        }

        public void SaveImageToTestFile(Bitmap image)
        {
            image.Save("D:/TEST/test.bmp");
        }
    }
}
