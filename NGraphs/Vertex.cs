using System;
using System.Collections.Generic;
using System.Linq;

namespace NGraphs {
    public class Vertex : IEquatable<Vertex> {
        public int Value { get; private set; }
        public IList<Vertex> Neighbours { get; private set; }

        public Vertex(int value) {
            Value = value;
            Neighbours = new List<Vertex>();
        }

        public void AddNeighbour(Vertex v) {
            if (v == null) { return; }
            Neighbours.Add(v);
            v.Neighbours.Add(this);
        }

        public void RemoveNeighbour(Vertex v) {
            if (v == null) { return; }
            Neighbours.Remove(v);
            v.Neighbours.Remove(this);
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
            var neighbours = string.Join(", ", Neighbours.Select(v => v.Value.ToString()));
            return Value + " : " + neighbours;
        }

        public void Print() {
            Console.WriteLine(Value);
        }
    }
}
