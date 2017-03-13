
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

        [TestMethod]
        public void TestMinusVector()
        {
            Vector v1 = new Vector(1,1,1);
            Vector v2 = new Vector(1, 2, 3);
            Vector v = v1.MinusVector(v2);

            Assert.AreEqual(0, v.X);
            Assert.AreEqual(-1, v.Y);
            Assert.AreEqual(-2, v.Z);
        }


    }
}
