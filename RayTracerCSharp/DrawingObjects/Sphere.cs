using System;

namespace RayTracerCSharp
{
    public class Sphere : DrawingObject {
    
    public double Radius;
    
    public Sphere( Point  position ,
                         double ambientLight, 
                         double ambientReflectionCoeff,
                         double diffuseReflectionCoeff,
                         double specularReflectionCoeff,
                         int    specularReflectionExponent,
                         double specularColor,
                         double transmissionCoeff,
                         double transparencyIndicesOfRefractionAir,
                         double transparencyIndicesOfRefractionObj,
                         double radius ) {
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
        Radius = radius;
        Id = new DrawingObjectId( 0, "Sphere", DrawingObjectType.Sphere);
    }
    
    public override Vector ComputeNormal(Point intersPoint) {
        Vector normal = new Vector(0,0,0);
        // normal (not normalized) = vector from center to intersection point
        Point center = new Point (Position);
        normal.ComputeVector( center, intersPoint );
        normal.Normalise();
        return normal;
    }
        
    public override Hit Hit(Ray ray, ObjectList objList, bool inside) {
        // forumla 15.17
        // A*t*t + B*t + C = 0
        Hit hitData = new Hit( false );
        ray.Vector.Normalise();   
        var a = ray.Vector.X*ray.Vector.X 
                   + ray.Vector.Y*ray.Vector.Y 
                   + ray.Vector.Z*ray.Vector.Z;
        var b = 2 * ( ray.Vector.X*(ray.StartPoint.X - Position.X)
                         + ray.Vector.Y * (ray.StartPoint.Y - Position.Y)
                         + ray.Vector.Z * (ray.StartPoint.Z - Position.Z));
        var c = (ray.StartPoint.X - Position.X) * (ray.StartPoint.X - Position.X)
                   + (ray.StartPoint.Y - Position.Y) * (ray.StartPoint.Y - Position.Y)
                   + (ray.StartPoint.Z - Position.Z) * (ray.StartPoint.Z - Position.Z)
                   - Radius * Radius;

        var root = b*b-4*a*c;
        if (root < 0) return hitData;  // false
        var t = (-b-Math.Sqrt(root))/(2*a);
        if (t<=0) t = (-b+Math.Sqrt(root))/(2*a);
        if (t<=0) return hitData; // false

        hitData.IsHit = true;
        hitData.IntersectionPoint = new Point(ray.StartPoint.X + t * ray.Vector.X,
                                                  ray.StartPoint.Y + t * ray.Vector.Y,
                                                  ray.StartPoint.Z + t * ray.Vector.Z);
        hitData.Distance = t * ray.Vector.LengthOf();
//        hitData.setLight ( this.getLight( objList, hitData ) );

        return hitData;
    }
    
    public override void IdMe() {
        //System.out.print( "  Sphere  " );        
        //System.out.print( id.number );
    }
    
    public override void Texture(Point intersectionPoint) {
        // no action
    }
    
}
}
