using System;
using System.Collections.Generic;
using System.Linq;

namespace NGraphs {
    public class Graph {
        private IList<Vertex> Vertices;

        public int NVertices { get { return Vertices.Count; } }

        public int NEdges { get { return Vertices.Sum(v => v.Neighbours.Count) / 2; } }

        public Graph(IList<Vertex> vertices) {
            if (vertices == null) {
                throw new ArgumentNullException("vertices");
            }
            Vertices = vertices;
        }

        public Dictionary<Vertex, BFSVisitingInfo> BreathFirstSearch(Vertex start) {
            if (start == null) {
                throw new ArgumentNullException("start");
            }
            int distance = 0;
            var queue = new Queue<Vertex>();
            var visits = new Dictionary<Vertex, BFSVisitingInfo>(NEdges);
            visits[start] = new BFSVisitingInfo(0, null);
            queue.Enqueue(start);
            while (queue.Count > 0) {
                Vertex v = queue.Dequeue();
                v.Print();
                distance++;
                foreach (Vertex w in v.Neighbours) {
                    if (visits.ContainsKey(w)) { continue; }
                    visits[w] = new BFSVisitingInfo(distance, v);
                    queue.Enqueue(w);
                }
            }
            return visits;
        }

        public List<Vertex> FindPath(Vertex start, Vertex end) {
            Dictionary<Vertex, BFSVisitingInfo> visits = BreathFirstSearch(start);
            var stack = new Stack<Vertex>();
            stack.Push(end);
            Vertex from = end;
            while (from != null && from.Value != start.Value) {
                from = visits[from].From;
                stack.Push(from);
            }
            if (from == null) {
                return null;
            }
            var path = new List<Vertex>();
            while (stack.Count > 0) {
                path.Add(stack.Pop());
            }
            return path;
        }

        public bool IsConnected() {
            return GetConnectedComponents().Count == 1;
        }

        public List<List<Vertex>> GetConnectedComponents() {
            var components = new List<List<Vertex>>();
            var explored = new HashSet<Vertex>();
            foreach (Vertex vertex in Vertices) {
                if (!explored.Contains(vertex)) {
                    Dictionary<Vertex, DFSVisitingInfo> visits = DepthFirstSearch(vertex);
                    explored.UnionWith(visits.Keys);
                    components.Add(new List<Vertex>(visits.Keys));
                    if (explored.Count == Vertices.Count) {
                        break;
                    }
                }
            }
            return components;
        }

        public Dictionary<Vertex, DFSVisitingInfo> DepthFirstSearch(Vertex v) {
            var visits = new Dictionary<Vertex, DFSVisitingInfo>();
            visits[v] = new DFSVisitingInfo(null);
            DepthFirstSearch(v, visits);
            return visits;
        }

        private void DepthFirstSearch(Vertex v, Dictionary<Vertex, DFSVisitingInfo> visits) {
            foreach (Vertex vertex in v.Neighbours) {
                if (!visits.ContainsKey(vertex)) {
                    visits[vertex] = new DFSVisitingInfo(v);
                    DepthFirstSearch(vertex, visits);
                    visits[vertex].Color = VisitingColor.Black;
                }
            }
        }
    }
}
