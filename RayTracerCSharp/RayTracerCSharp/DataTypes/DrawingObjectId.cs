

namespace RayTracerCSharp
{
    public class DrawingObjectId
    {

        public int Number;
        public string Name;
        public DrawingObjectType Type;

        public DrawingObjectId(int number, string name, DrawingObjectType type)
        {
            Number = number;
            Name = name;
            Type = type;
        }

        public bool IsMe(DrawingObjectId id)
        {
            return id.Type == Type && id.Number == Number;
        }


    }
}
