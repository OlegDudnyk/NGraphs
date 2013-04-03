using System.Collections.Generic;
using NGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NGraphsTest {
    [TestClass]
    public class GraphTest {
        private Graph Graph;
        private List<Vertex> Vertices;

        [TestInitialize]
        public void Init() {
            //     1-2
            //      /|\
            //     3 4-5
            Vertices = new List<Vertex>();
            var v1 = new Vertex(1);
            Vertices.Add(v1);
            var v2 = new Vertex(2);
            Vertices.Add(v2);
            var v3 = new Vertex(3);
            Vertices.Add(v3);
            var v4 = new Vertex(4);
            Vertices.Add(v4);
            var v5 = new Vertex(5);
            Vertices.Add(v5);
            v1.AddNeighbour(v2);
            v2.AddNeighbour(v3);
            v2.AddNeighbour(v4);
            v2.AddNeighbour(v5);
            v4.AddNeighbour(v5);
            Graph = new Graph(Vertices);
        }

        [TestMethod]
        public void GraphBreathFirstSearchTest() {
            Dictionary<Vertex, BFSVisitingInfo> visits = Graph.BreathFirstSearch(Vertices[0]);
            Assert.AreEqual(0, visits[Vertices[0]].Distance);
            Assert.AreEqual(1, visits[Vertices[1]].Distance);
            Assert.AreEqual(2, visits[Vertices[2]].Distance);
            Assert.AreEqual(2, visits[Vertices[3]].Distance);
            Assert.AreEqual(2, visits[Vertices[4]].Distance);
        }

        [TestMethod]
        public void GraphFindPathTest() {
            List<Vertex> path = Graph.FindPath(Vertices[0], Vertices[4]);
            Assert.AreEqual(3, path.Count);
            Assert.AreEqual(1, path[0].Value);
            Assert.AreEqual(2, path[1].Value);
            Assert.AreEqual(5, path[2].Value);
        }

        [TestMethod]
        public void GraphDepthFirstSearchTest() {
            Dictionary<Vertex, DFSVisitingInfo> visits = Graph.DepthFirstSearch(Vertices[0]);
            Assert.AreEqual(5, visits.Count);
            Assert.AreEqual(Vertices[1], visits[Vertices[3]].From);
        }

        [TestMethod]
        public void GraphIsConnectedTest() {
            Assert.IsTrue(Graph.IsConnected());
            Vertices[1].RemoveNeighbour(Vertices[2]);
            Assert.IsFalse(Graph.IsConnected());
        }

        [TestMethod]
        public void GraphGetConnectedComponentsTest() {
            Assert.AreEqual(1, Graph.GetConnectedComponents().Count);
            Vertices[1].RemoveNeighbour(Vertices[2]);
            Assert.AreEqual(2, Graph.GetConnectedComponents().Count);
        }

        [TestMethod]
        public void GraphNumberOfEdgesTest() {
            Assert.AreEqual(5, Graph.NEdges);
        }

        [TestMethod]
        public void GraphNumberOfVerticesTest() {
            Assert.AreEqual(5, Graph.NVertices);
        }
    }
}
