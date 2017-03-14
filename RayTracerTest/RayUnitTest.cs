
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerCSharp;

namespace RayTracerTest
{
    
    [TestClass]
    public class RayUnitTest
    {
        
        [TestMethod]
        public void TestDetermineRay()
        {
            Point startPoint = new Point(0, 0, 0);
            Ray ray = new Ray();
            ray.DetermineRay(startPoint, new Point(2, 2, 2));

            Assert.AreEqual(ray.StartPoint, startPoint);

            Vector expectedResult = new Vector(1, 1, 1);
            expectedResult.Normalise();
            Assert.AreEqual(ray.Vector, expectedResult);
        }
    }
}
