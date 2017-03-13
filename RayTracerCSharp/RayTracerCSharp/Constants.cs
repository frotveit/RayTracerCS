
namespace RayTracerCSharp
{
    public static class Constants
    {
        public const int RecursiveLevel = 2;

        /// <summary>
        /// output filename
        /// </summary>
        public const string PgmFileName = "raytrace";  
        public const int ImageX = 500;
        public const int ImageY = 500;

        public const int ViewWindowPosZ = 200;
        public const int CenterOfProjectionX = 0;
        public const int CenterOfProjectionY = 0;
        public const int CenterOfProjectionZ = 0;

        /// <summary>
        /// "MAX" value used when finding closest object
        /// </summary>
        public const int InitDistance = 999999;

        public const int BackgroundValue = 0;
    }

}
