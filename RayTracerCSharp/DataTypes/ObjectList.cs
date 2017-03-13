
using System.Collections.Generic;

namespace RayTracerCSharp
{
    public class ObjectList
    {
        public List<DrawingObject> DrawingObjects = new List<DrawingObject>();
        public List<Light> Lights = new List<Light>();
        private int _nextObjectNumber;  // Used to number the objects

        /// <summary>
        /// Center of projection
        /// </summary>
        public Point COP;

        public ObjectList()
        {
            _nextObjectNumber = 1;
        }

        public void AddObject(DrawingObject obj)
        {
            obj.Id.Number = _nextObjectNumber++;
            DrawingObjects.Add(obj);
        }

        public void RemoveObject(DrawingObject obj)
        {
            // TODO
        }       

        public void AddLight(Light light)
        {
            Lights.Add(light);
        }
        
    }

}
