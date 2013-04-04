using System;

namespace NGraphs {
    public class Edge : IEquatable<Edge> {
        public Vertex First { get; private set; }
        public Vertex Second { get; private set; }
        public int Weight { get; private set; }

        public Edge(Vertex first, Vertex second, int weight) {
            if (first == null) {
                throw new ArgumentNullException("first");
            }
            if (first == null) {
                throw new ArgumentNullException("second");
            }
            First = first;
            Second = second;
            Weight = weight;
        }

        public Edge(Vertex first, Vertex second) : this(first, second, 1) { }

        public Vertex Opposite(Vertex v) {
            if (v == null) {
                throw new ArgumentNullException("v");
            }
            if (v.Equals(First)) {
                return Second;
            }
            if (v.Equals(Second)) {
                return First;
            }
            throw new ArgumentException("");
        }

        public bool Equals(Edge other) {
            if (other == null) {
                return false;
            }
            return First.Equals(other.First) && Second.Equals(other.Second);
        }

        public override bool Equals(object obj) {
            return Equals(obj as Edge);
        }

        public override int GetHashCode() {
            return First.GetHashCode() ^ Second.GetHashCode();
        }

        public override string ToString() {
            return First.Value + "-" + Second.Value;
        }
    }
}
