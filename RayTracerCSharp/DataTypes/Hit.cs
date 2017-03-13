
namespace RayTracerCSharp
{
    /// <summary>
    /// Used to return data about a hit when a ray is tested against an object
    /// </summary>
    public class Hit
    {
        public bool IsHit;
        public Point IntersectionPoint;
        /// <summary>
        /// Distance from ray start to intersection point
        /// </summary>
        public double Distance;

        public Hit()
        {
            IsHit = false;
            IntersectionPoint = null;
            Distance = 0;
        }

        public Hit(bool setHit)
        {
            IsHit = setHit;
            IntersectionPoint = null;
            Distance = 0;
        }

        /// <summary>
        /// Is it a hit?
        /// </summary>
        public bool GetHit() { return IsHit; }
        public double GetDistance() { return Distance; }
        public Point GetIntersectionPoint() { return IntersectionPoint; }
        public void SetHit(bool setHit) { IsHit = setHit; }
        public void SetDistance(double setDistance) { Distance = setDistance; }
        public void SetIntersectionPoint(Point setPoint) { IntersectionPoint = setPoint; }       
    }

}
