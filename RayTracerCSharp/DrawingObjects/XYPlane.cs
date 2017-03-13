
namespace RayTracerCSharp
{
    public class XYPlane : DrawingObject
    {
        // plane is positioned in XY plane
        public double Planesize;

        public XYPlane()
        {
        }

        public XYPlane(Point position,
            double ambientLight,
            double ambientReflectionCoeff,
            double diffuseReflectionCoeff,
            double specularReflectionCoeff,
            int    specularReflectionExponent,
            double specularColor,
            double transmissionCoeff,
            double transparencyIndicesOfRefractionAir,
            double transparencyIndicesOfRefractionObj,
            double size)
        {
            Position = new Point(position);
            AmbientLight = ambientLight;
            AmbientReflectionCoeff = ambientReflectionCoeff;
            DiffuseReflectionCoeff = diffuseReflectionCoeff;
            SpecularReflectionCoeff = specularReflectionCoeff;
            SpecularReflectionExponent = specularReflectionExponent;
            SpecularColor = specularColor;
            TransmissionCoeff = transmissionCoeff;
            TransparencyIndicesOfRefractionAir = transparencyIndicesOfRefractionAir;
            TransparencyIndicesOfRefractionObj = transparencyIndicesOfRefractionObj;
            Planesize = size;

            Id = new DrawingObjectId(0, "PlaneXY", DrawingObjectType.Xyplane);
        }

        public override Hit Hit(Ray ray, ObjectList objList, bool inside)
        {
            Hit hitData = new Hit(false);
            // check if intersects given Z plane
            if (((ray.StartPoint.Z > Position.Z) // starts on positive side of Z
                 && (ray.Vector.Z < 0)) // and has negative Z direction
                || ((ray.StartPoint.Z < Position.Z) // OR starts on negative side of Z
                    && (ray.Vector.Z > 0)))
            {
                // and has positive Z direction

                // find point on Z plane
                double t = (Position.Z - ray.StartPoint.Z)/ray.Vector.Z;
                double x = ray.StartPoint.X + t*ray.Vector.X;
                double y = ray.StartPoint.Y + t*ray.Vector.Y;

                // AND check if point is within plane
                if ((x < (Position.X + Planesize/2) && x > (Position.X - Planesize/2))
                    && (y < (Position.Y + Planesize/2) && y > (Position.Y - Planesize/2)))
                {
                    hitData.IsHit = true;
                    hitData.IntersectionPoint = new Point(x, y, Position.Z);
                    hitData.Distance = t*ray.Vector.LengthOf();
                    return hitData;
                }
            }
            return hitData; // false
        }

        public override Vector ComputeNormal(Point point)
        {
            // assumes that:
            // - COP is at 0,0,0
            // - image is in XY plane with positive Z
            // - plane is in XY plane with positive Z > image
            Vector v = new Vector(0, 0, -1);
            v.Normalise();
            return v;
        }

        public override void IdMe()
        {
            //System.out.print( "  PlaneXY  " );
        }

        public override void Texture(Point intersectionPoint)
        {
            // no action
        }

    }

}
