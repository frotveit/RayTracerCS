
using System.IO;

namespace RayTracerCSharp
{
    public class PGMWrapper
    {
        /// <summary>
        /// This routine writes a gray scale image as a 8 bit .pgm file.
        /// </summary>
        public void WriteRasterAsPgm8(Image image, string fileName)
        {
            BinaryWriter binWriter;
            using (binWriter =
                new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                binWriter.Write("P5 \n ");
                binWriter.Write(image.sizeX.ToString());
                binWriter.Write(" ");
                binWriter.Write(image.sizeY.ToString());
                binWriter.Write(" \n 255 ");
                for (int j = image.sizeY - 1; j >= 0; j--)
                {
                    for (int i = 0; i < image.sizeY; i++)
                    {
                        int lightAsInt = (int)image.data[i, j];
                        byte lightAsByte = (byte)lightAsInt;    // converting int to char
                        binWriter.Write(lightAsByte);
                    }
                }
            }
        }

    }
}
