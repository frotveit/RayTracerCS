using System;

namespace RayTracerCSharp
{
    public abstract class DrawingObject
    {
        public DrawingObjectId Id;

        public Point Position; // position of object
        public DrawingObject NextObject;
        /// <summary>
        /// Background lighting
        /// </summary>
        public double AmbientLight;
        /// <summary>
        /// Background lighting reflected
        /// Range 0 - 1
        /// </summary>
        public double AmbientReflectionCoeff;
        /// <summary>
        /// Reflection of light from light source
        /// Range 0 - 1
        /// </summary>
        public double DiffuseReflectionCoeff; 
        /// <summary>
        /// Mirror effect
        /// </summary>
        public double SpecularReflectionCoeff;
        /// <summary>
        /// Range 1 - infinite
        /// </summary>
        public int SpecularReflectionExponent;
        public double SpecularColor;
        public double TransmissionCoeff;
        public double TransparencyIndicesOfRefractionAir = 1;
        public double TransparencyIndicesOfRefractionObj = 1;


        /// <summary>
        /// Check if ray hits any object.
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="objList"></param>
        /// <param name="inside"></param>
        /// <returns></returns>
        public abstract Hit Hit(Ray ray, ObjectList objList, bool inside);
        public abstract Vector ComputeNormal(Point point);
        public abstract void IdMe();
        public abstract void Texture(Point intersectionPoint);


        public double GetLight(Hit hitData, Ray ray, ObjectList objectList, int traceDepth, bool inside)
        {
            double lightIntensity = 0;
            Vector lightVector = new Vector(0, 0, 0);

            Vector normal = ComputeNormal(hitData.IntersectionPoint);
            // Find V vector (opposite ray)
            Vector v = new Vector(-ray.GetVector().GetX(),
                -ray.GetVector().GetY(),
                -ray.GetVector().GetZ());

            // Adding AmbientLight
            if (!inside)
            {
                // Do not add ambient light if inside object
                Texture(hitData.IntersectionPoint);
                lightIntensity += AmbientLight*AmbientReflectionCoeff;
            }

            // For each light source
            if (!inside)
            {
                // Do not add light sources if inside object
                foreach (Light light in objectList.Lights)
                {
                    lightVector.ComputeVector(hitData.IntersectionPoint, light.GetPosition());
                    double lightDistance = lightVector.LengthOf();
                    lightVector.Normalise();

                    // test if light is blocked by other objects
                    Ray lightRay = new Ray(hitData.IntersectionPoint, lightVector);
                    if (Rayer.HitLight(objectList, lightRay, this))
                    {
                        // light not blocked
                        // Calculating lightSourceAttenuationFactor
                        const double c1 = 0;
                        const double c2 = 0.5;
                        const double c3 = 0;
                        double lightSourceAttenuationFactor // light weakened by distance
                            = 1/(c1 + c2*lightDistance + c3*lightDistance*lightDistance);
                        if (lightSourceAttenuationFactor < 1) lightSourceAttenuationFactor = 1;
                        // Adding DiffuseReflection
                        double dotProduct = normal.ComputeDotProduct(lightVector);
                        if (dotProduct < 0) dotProduct = 0; // ?? light from wrong direction ??
                        lightIntensity += lightSourceAttenuationFactor
                                          *light.GetIntensity()
                                          *DiffuseReflectionCoeff
                                          *dotProduct;

                        // Find SpecularReflection (formula 16.15, 16.17)
                        // Find R dot V
                        Vector rBasis = normal.Multiply(2*normal.ComputeDotProduct(lightVector));
                        Vector r = rBasis.MinusVector(lightVector);
                        double rDotV = r.ComputeDotProduct(v);
                        for (int n = 1; n < SpecularReflectionExponent; n++)
                            rDotV = rDotV*rDotV;
                        // Add SpecularReflection
                        lightIntensity += SpecularReflectionCoeff*SpecularColor*rDotV;
                    }
                }
            }

            if (traceDepth < Constants.RecursiveLevel)
            {
                if (SpecularReflectionCoeff > 0 // if object is reflective
                    && !inside)
                {
                    // Do not add reflection if inside object
                    // Find Reflected impact (16.16, 16.55)
                    double nDotV = normal.ComputeDotProduct(v);
                    Vector reflectionVectorBasis = normal.Multiply(2*nDotV);
                    Vector reflectionVector = reflectionVectorBasis.MinusVector(v);
                    reflectionVector.Normalise();
                    Ray reflectionRay =
                        new Ray(hitData.IntersectionPoint, reflectionVector);
                    double intensityReflectedRay
                        = Rayer.RayObjects(objectList, reflectionRay, traceDepth + 1, false, null);
                    lightIntensity += SpecularReflectionCoeff*intensityReflectedRay;
                }
                if (TransmissionCoeff > 0)
                {
                    // if object is transparent
                    // Find Refracted/Transmitted impact (16.55)
                    if (!inside)
                    {
                        // not inside of object
                        double nDotV = normal.ComputeDotProduct(v);
                        double transparencyIndicesOfRefraction =
                            TransparencyIndicesOfRefractionAir/TransparencyIndicesOfRefractionObj;
                        double cosT = Math.Sqrt(1 - transparencyIndicesOfRefraction
                                                *transparencyIndicesOfRefraction
                                                *(1 - nDotV));
                        Vector nBasis = normal.Multiply(transparencyIndicesOfRefraction*nDotV - cosT);
                        Vector vBasis = v.Multiply(transparencyIndicesOfRefraction);
                        Vector transmittedVector = nBasis.MinusVector(vBasis);
                        Ray transmittedRay = new Ray(hitData.IntersectionPoint, transmittedVector);
                        double intensityRefractedTransmittedRay
                            = Rayer.RayObjects(objectList, transmittedRay, traceDepth, true, this);
                        lightIntensity += TransmissionCoeff*intensityRefractedTransmittedRay;
                    }
                    else
                    {
                        // inside of object
                        Vector negNormal = normal.Multiply(-1);
                        double nNdotV = negNormal.ComputeDotProduct(v);
                        double transparencyIndicesOfRefraction =
                            TransparencyIndicesOfRefractionObj/TransparencyIndicesOfRefractionAir;
                        double cosT = Math.Sqrt(1 - transparencyIndicesOfRefraction
                                                *transparencyIndicesOfRefraction
                                                *(1 - nNdotV));
                        Vector nBasis = negNormal.Multiply(transparencyIndicesOfRefraction*nNdotV - cosT);
                        Vector vBasis = v.Multiply(transparencyIndicesOfRefraction);
                        Vector transmittedVector = nBasis.MinusVector(vBasis);
                        Ray transmittedRay = new Ray(hitData.IntersectionPoint, transmittedVector);
                        double intensityRefractedTransmittedRay
                            = Rayer.RayObjects(objectList, transmittedRay, traceDepth + 1, false, null);
                        lightIntensity += TransmissionCoeff*intensityRefractedTransmittedRay;
                    }
                }
            }

            if (lightIntensity < 0)
            {
                IdMe();
                //System.out.print("  ERROR light out of range: to small  " );
                //System.out.print( lightIntensity );
                lightIntensity = 0;
            }
            if (lightIntensity > 255)
            {
                IdMe();
                //System.out.print("  ERROR light out of range: to big  " );
                //System.out.print( lightIntensity );
                lightIntensity = 255;
            }

            return lightIntensity;
        }

        public DrawingObject GetNext()
        {
            return NextObject;
        }

        public void SetNext(DrawingObject next)
        {
            NextObject = next;
        }

        public override string ToString()
        {
            return base.ToString() + " " + Position;
        }

        public bool IsMe(DrawingObject obj)
        {
            return Id.IsMe(obj.Id);
        }
    }
}