using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

/*------------------------------------------
  CURRENT SETUP
  COP is def as 0,0,0
  View window is defined by Z value, X and Y is centered on origo
**------------------------------------------*/


namespace RayTracerCSharp
{
    public static class RT_Definitions
    {
        /*------------------------------------------
        **  CONSTANTS
        **------------------------------------------*/
        public const int CONST_RECURSIVE_LEVEL = 2;

        public const string CONST_PGM_FILENAME = "raytrace"; // output filename
        public const int CONST_IMAGEX = 500;
        public const int CONST_IMAGEY = 500;

        public const int CONST_VIEW_WINDOW_POS_Z = 200;
        public const int CONST_CENTER_PROJECTION_X = 0;
        public const int CONST_CENTER_PROJECTION_Y = 0;
        public const int CONST_CENTER_PROJECTION_Z = 0;

        public const int CONST_INIT_DISTANCE = 999999;  //"MAX" value used when finding closest object

        public const int CONST_BACKGROUND_VALUE = 0;
    }

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
            Application.Run(new Form_RT());

        }
    }


    /*------------------------------------------
    **  T_CLASSES
    **------------------------------------------*/

    //------------------------------------------
    // CLASS T_Point
    // A point

    class T_Point
    {
        double x ,y ,z;

        public T_Point (){}
        public T_Point(T_Point copyPoint)
        {
            x = copyPoint.getX();
            y = copyPoint.getY();
            z = copyPoint.getZ();
        }
        public T_Point(double setx, double sety, double setz)
      {
        x = setx;
        y = sety;
        z = setz;
      }
        public double getX() { return x; }
        public double getY() { return y; }
        public double getZ() { return z; }
        public void set(double setx, double sety, double setz)
      {
        x = setx;
        y = sety;
        z = setz;
      }
}

    /*----------------------------------------------
    ** CLASS T_Vector
    **----------------------------------------------*/
    class T_Vector {
        double x ,y ,z;
        
        public T_Vector () {}
        public T_Vector(double setx, double sety, double setz)
        {
                x = setx;
                y = sety;
                z = setz;
        }
        public double getX() { return x; }
        public double getY() { return y; }
        public double getZ() { return z; }
        public void set(double setx, double sety, double setz)
        {
                x = setx;
                y = sety;
                z = setz;
        }
        public void computeVector( T_Point From,
				                   T_Point To )
        {
                x = To.getX() - From.getX();
                y = To.getY() - From.getY();
                z = To.getZ() - From.getZ();
        }

        public double computeDotProduct(T_Vector Vector2)
        {
                return(   x * Vector2.getX()
	                + y * Vector2.getY()
	                + z * Vector2.getZ() );
        }

        public void normalise()
        {
                double length;
                double root;

                root = x*x + y*y + z*z;
                length = Math.Sqrt( root );
                x = x / length;
                y = y / length;
                z = z / length;
        }
        public double lengthOf()
        {
            double root = x*x + y*y + z*z;
            double length = Math.Abs(Math.Sqrt( root ));
            return length;
        }
        public T_Vector multiply(double mult)
        {
            T_Vector newVec = new T_Vector( x*mult, y*mult, z*mult);
            return newVec;
        }
        /*---------------------------------------------------
        **  METHOD minusVector
        **  RETURN this vector minus argument vector
        **---------------------------------------------------*/
        public T_Vector minusVector(T_Vector vec)
        {
            T_Vector newVec = new T_Vector( x- vec.getX(),
                                            y- vec.getY(),
                                            z- vec.getZ() );
            return newVec;
        }

    }

    /*----------------------------------------------
    ** CLASS T_Ray
    **----------------------------------------------*/

    class T_Ray
    {
        private T_Point  startPoint;
        private T_Vector vector;

        public T_Ray () { startPoint = null; vector = null; }
        public T_Ray(T_Point setStartPoint, T_Vector setVector)
        {
            startPoint = setStartPoint;
            vector = setVector;
        }
    public T_Point getStartPoint() { return startPoint; }
    public T_Vector getVector() { return vector; }
    /*    public void set(T_Point setStartPoint, T_Vector setVector)
        {
            startPoint = setStartPoint;
            vector = setVector;
        }
        void setStartPoint(T_Point setStartPoint)
        {
            startPoint = setStartPoint;
        }
        void setStartPoint(double x,double y, double z)
        {
            startPoint = new T_Point(x,y,z);
        }
        void setVector(T_Vector setVector)
        {
            vector = setVector;
        }
        void setVector(double x,double y, double z)
        {
            vector = new T_Vector(x,y,z);
        }*/
    public void determineRay(T_Point fromStartPoint,
		                     T_Point fromThroughPoint )
    {

        startPoint = new T_Point ( fromStartPoint );
        vector = new T_Vector();
        vector.computeVector( fromStartPoint , fromThroughPoint );
        vector.normalise();
    }

}

    /*----------------------------------------------
    ** CLASS T_Hit
     * Used to return data about a hit when a ray is tested against an object
    **----------------------------------------------*/
    class T_Hit
    {

        private bool hit;                   // Was it a hit? true or false
        private T_Point intersectionPoint;  // intersectionpoint of hit
        private double distance;            // distance from ray start to intersection point

        // CONSTRUCTOR
        public T_Hit()
        {
            hit = false;
            intersectionPoint = null;
            distance = 0;
        }
        public bool getHit() { return hit; }
        public double getDistance() { return distance; }
        public T_Point getIntersectionPoint() { return intersectionPoint; }
        public void setHit(bool setHit) { hit = setHit; }
        public void setDistance(double setDistance) { distance = setDistance; }
        public void setIntersectionPoint(T_Point setPoint) { intersectionPoint = setPoint; }
        // public void     deleteData() { if (intersectionPoint != null ) intersectionPoint = null; }
    }

    /*----------------------------------------------
     * CLASS T_Light
     * A light source
    **----------------------------------------------*/
    class T_Light
    {

        public T_Point pos;         // position of light
        public double  intensity;   // intenisty of light
        public T_Light next;        // linked list of lights

        // CONSTRUCTOR
        public T_Light(T_Point setPos, double setIntensity)
        {
            pos = setPos;
            intensity = setIntensity;
            next = null;
        }
        public void deleteLight()
        {
            pos = null;
        }

        public double getIntensity() 
        { 
            return intensity; 
        }
        public T_Point getPosition()  
        { 
            return pos;       
        }
        public T_Light getNext()     
        { 
            return next;      
        }
    }

    /*-------------------------------------------------------------------
     * CLASS  T_Image
     * The image that is built up and presented
    **-------------------------------------------------------------------*/
    class T_Image
    {
        //public Bitmap image;
        private int sizeX, sizeY;
        private double [ , ] data; // array with pixel data

        // CONSTRUCTOR
        //public T_Image () {}
        public T_Image (int setX, int setY) 
        { 
            data  = new double[setX,setY];
            //image = new Bitmap(setX, setY, PixelFormat.Format16bppGrayScale);
            sizeX = setX;
            sizeY = setY;
        }
        
        //---------------------------------------
        // METHOD setPixel
        // INPUT  x, y : position in normal x, y grid
        //        pixelLight: intensity of light
        //                    range 0 - 255
        public void setPixel ( int x, int y, double pixelLight )
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
        public void writeImage(string fileName)
        {
            //image.Save(fileName, ImageFormat.Bmp);
        }

        //------------------------------------------
        // METHOD writeRasterAsPGM8
        // This routine writes a grayscale image as a 8 bit .pgm file. 
        public void writeRasterAsPGM8(string fileName)
        {
            BinaryWriter binWriter;
            using ( binWriter =
                new BinaryWriter(File.Open(fileName, FileMode.Create)) )
            {
                binWriter.Write("P5 \n " );
                binWriter.Write(sizeX.ToString());
                binWriter.Write(" ");
                binWriter.Write(sizeY.ToString());
                binWriter.Write(" \n 255 ");
                for (int j = sizeY-1; j >=0 ; j--)
                {
                    for (int i = 0; i < sizeY; i++)
                    {
                        int lightAsInt = (int)data[i, j];
                        byte lightAsByte = (byte)lightAsInt;    // converting int to char
                        binWriter.Write(lightAsByte);
                    }
                }
       

                
            }
        }

        
    }

}