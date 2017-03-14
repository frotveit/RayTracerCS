
using System;

namespace RayTracerCSharp
{
    public class Point : IEquatable<Point>
    {
        public double X, Y, Z;

        public Point() { }
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
        }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }        

        public double GetX() { return X; }
        public double GetY() { return Y; }
        public double GetZ() { return Z; }
        
        public void Set(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Equals

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(Object other)
        {
            if (other.GetType() != typeof(Point))
                return false;
            return X == ((Point)other).X && Y == ((Point)other).Y && Z == ((Point)other).Z;
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return (int)X;
        }

        #endregion Equals

        public override string ToString()
        {
            return "Point:" + X + "," + Y + "," + Z;
        }
    }

}
