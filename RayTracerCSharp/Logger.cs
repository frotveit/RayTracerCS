

using System.Collections.Generic;

namespace RayTracerCSharp
{
    public interface ILogger
    {
        void Log(string logText);
    }

    public class Logger : ILogger
    {
        private List<string> _log = new List<string>();
        public Logger()
        {

        }

        public void Log(string logText)
        {
            _log.Add(logText);
        }

        public IEnumerable<string> GetLog()
        {
            return _log;
        }

        public void ClearLog()
        {
            _log.Clear();
        }
    }
}
