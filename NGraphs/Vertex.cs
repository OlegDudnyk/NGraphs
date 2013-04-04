using System;
using System.Collections.Generic;
using System.Linq;

namespace NGraphs {
    public class Vertex : IEquatable<Vertex> {
        public int Value { get; private set; }
        public IList<Edge> Edges { get; private set; }

        public Vertex(int value) {
            Value = value;
            Edges = new List<Edge>();
        }

        public void AddDoublyLinkedNeighbour(Vertex v) {
            if (v == null) { return; }
            var edge = new Edge(this, v);
            Edges.Add(edge);
            v.Edges.Add(edge);
        }

        public void AddSingleLinkedNeighbour(Vertex to) {
            if (to == null) { return; }
            var edge = new Edge(this, to);
            Edges.Add(edge);
        }

        public override bool Equals(object obj) {
            var other = obj as Vertex;
            if (other == null) { return false; }
            return Equals(other);
        }

        public override int GetHashCode() {
            return Value;
        }

        public bool Equals(Vertex other) {
            return Value == other.Value;
        }

        public override string ToString() {
            var neighbours = string.Join(", ", Edges.Select(edge => edge.Opposite(this).Value.ToString()));
            return Value + " : " + neighbours;
        }

        public void Print() {
            Console.WriteLine(Value);
        }
    }
}
