using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTracerCSharp;

namespace RayTracerTest
{
    [TestClass]
    public class PointUnitTest
    {
        [TestMethod]
        public void TestEqual()
        {
            Point p1 = new Point(2, 3, 4);
            Point p2 = new Point(2, 3, 4);
            Point p3 = new Point(2, 3, 1);
            
            Assert.IsTrue(p1.Equals(p2));
            Assert.IsFalse(p1.Equals(p3));

            Assert.AreEqual(p1, p2);
            Assert.AreNotEqual(p1, p3);
        }
    }
}
