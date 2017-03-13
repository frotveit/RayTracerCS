

namespace RayTracerCSharp
{
    public class Ray
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

        public void DetermineRay(Point fromStartPoint,
                                 Point fromThroughPoint)
        {
            StartPoint = new Point(fromStartPoint);
            Vector = new Vector();
            Vector.ComputeVector(fromStartPoint, fromThroughPoint);
            Vector.Normalise();
        }

    }
}
