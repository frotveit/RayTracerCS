

using System.Collections.Generic;

namespace RayTracerCSharp
{
    public interface IDisplay
    {
        void DisplayImage(Image image);
        void DisplayLog(IEnumerable<string> log);
    }
}
