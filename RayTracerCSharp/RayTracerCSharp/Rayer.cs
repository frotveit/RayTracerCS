

using System;

namespace RayTracerCSharp
{
    public class Rayer
    {

        /// <summary>
        /// Returns light intensity
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="traceLevel"></param>
        /// <param name="inside"></param>
        /// <param name="insideObject"></param>
        /// <returns></returns>
        public static double RayObjects(ObjectList objectList, Ray ray, int traceLevel, bool inside, DrawingObject insideObject)
        {
            if (inside)
            {
                return RayObjectsInside(objectList, ray, traceLevel, insideObject);
            }

            double light = Constants.BackgroundValue; // set background intensity
            double distance = Double.MaxValue;
            DrawingObject hitObject = null;
            Hit hitData = null;
            foreach (DrawingObject obj in objectList.DrawingObjects)
            {
                Hit hit = obj.Hit(ray, objectList, false);
                if (hit.IsHit)
                {
                    if (hit.Distance < distance) // if object is closest
                    {
                        distance = hit.Distance;
                        hitObject = obj;
                        hitData = hit;
                    }
                }
            }
            if (hitObject != null)
                light = hitObject.GetLight(hitData, ray, objectList, traceLevel, false);

            return light;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="traceLevel"></param>
        /// <param name="insideObject"></param>
        /// <returns></returns>
        private static double RayObjectsInside(ObjectList objectList, Ray ray, int traceLevel, DrawingObject insideObject)
        {
            // inside object - assume not nested objects
            // only needs to find intersection point to this object (exit point)

            double light = Constants.BackgroundValue; // set background intensity

            Hit hitData = insideObject.Hit(ray, objectList, true);
            if (hitData.IsHit)
            {
                light = insideObject.GetLight(hitData, ray, objectList, traceLevel, true);
            }

            return light;
        }


        /// <summary>
        /// Returns true if ray to light do not hits any objects. 
        /// Used to check if any objects blocks a light source.
        /// Assumes no objects behind light source
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="thisObject"></param>
        /// <returns></returns>
        public static bool HitLight(ObjectList objectList, Ray ray, DrawingObject thisObject)
        {
            // NB!!!  IS VIOLATED BY CHESSBOARD
            // does not test against intersected object (thisObj)

            foreach (var obj in objectList.DrawingObjects)
            {
                if (obj.IsMe(thisObject))  // do not test intersected object
                    continue;

                var hitObject = obj.Hit(ray, objectList, false);
                if (hitObject.GetHit())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
