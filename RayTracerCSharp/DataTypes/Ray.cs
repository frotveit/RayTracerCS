

using System;

namespace RayTracerCSharp
{
    public class Ray : IEquatable<Ray>
    {
        public Point StartPoint;
        public Vector Vector;

        public Ray()
        {
            StartPoint = null;
            Vector = null;
        }

        public Ray(Point setStartPoint, Vector setVector)
        {
            StartPoint = setStartPoint;
            Vector = setVector;
        }

        public Point GetStartPoint() { return StartPoint; }

        public Vector GetVector() { return Vector; }

        public void DetermineRay(Point startPoint,
                                 Point throughPoint)
        {
            StartPoint = new Point(startPoint);
            Vector = new Vector();
            Vector.ComputeVector(startPoint, throughPoint);
            Vector.Normalise();
        }

        #region Equals

        public bool Equals(Ray other)
        {
            return StartPoint.Equals(other.StartPoint) && Vector.Equals(other.Vector);
        }

        public override bool Equals(Object other)
        {
            if (other.GetType() != typeof(Ray))
                return false;
            return StartPoint.Equals(((Ray)other).StartPoint) && Vector.Equals(((Ray)other).Vector);            
        }

        public static bool operator ==(Ray a, Ray b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Ray a, Ray b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return (int)StartPoint.X;
        }

        #endregion Equals


    }
}
