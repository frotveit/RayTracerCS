
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerCSharp;

namespace RayTracerTest
{
    [TestClass]
    public class VectorUnitTest
    {
        [TestMethod]
        public void TestComputeVector()
        {
            Vector v = new Vector();
            v.ComputeVector(new Point(1, 1, 1), new Point(2, 3, 4));

            Assert.AreEqual(1, v.X);
            Assert.AreEqual(2, v.Y);
            Assert.AreEqual(3, v.Z);
        }
    }
}
