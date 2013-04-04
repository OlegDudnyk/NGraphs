using System.Collections.Generic;

namespace NGraphs {
    public class DiGraph : Graph {
        public DiGraph(IList<Vertex> vertices)
            : base(vertices) {
        }

        public List<Vertex> TopologicalSort() {
            return new List<Vertex>();
        }

        public bool IsThereCycle() {
            return false;
        }
    }
}
