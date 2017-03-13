
namespace RayTracerCSharp
{
    public class Point
    {
        public double X, Y, Z;

        public Point() { }
        public Point(Point p)
        {
            X = p.GetX();
            Y = p.GetY();
            Z = p.GetZ();
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
        
        public void Set(double setx, double sety, double setz)
        {
            X = setx;
            Y = sety;
            Z = setz;
        }

        public override string ToString()
        {
            return "Pos:" + X + "," + Y + "," + Z;
        }
    }

}
