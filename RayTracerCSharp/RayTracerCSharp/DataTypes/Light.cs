
namespace RayTracerCSharp
{
    /// <summary>
    /// A light source
    /// </summary>
    public class Light
    {

        public Point Position;
        public double Intensity;
        
        public Light(Point setPos, double setIntensity)
        {
            Position = setPos;
            Intensity = setIntensity;
        }
        public void DeleteLight()
        {
            Position = null;
        }

        public double GetIntensity()
        {
            return Intensity;
        }

        public Point GetPosition()
        {
            return Position;
        }
        
    }

}
