using NGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NGraphsTest {
    [TestClass]
    public class VertexTest {
        [TestMethod]
        public void VertexWithoutNeighboursToStringTest() {
            var v = new Vertex(1);
            Assert.AreEqual("1 : ", v.ToString());
        }

        [TestMethod]
        public void VertexWithTwoNeighboursToStringTest() {
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            v1.AddNeighbour(v2);
            v1.AddNeighbour(v3);
            Assert.AreEqual("1 : 2, 3", v1.ToString());
            Assert.AreEqual("2 : 1", v2.ToString());
            Assert.AreEqual("3 : 1", v3.ToString());
        }
    }
}
