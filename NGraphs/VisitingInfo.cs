namespace NGraphs {
    public class VisitingInfo {
        public Vertex From { get; set; }

        public VisitingInfo(Vertex from) {
            From = from;
        }
    }

    public class BFSVisitingInfo : VisitingInfo {
        public int Distance { get; set; }

        public BFSVisitingInfo(int distance, Vertex from) : base(from) {
            Distance = distance;
        }
    }

    public class DFSVisitingInfo : VisitingInfo {
        public VisitingColor Color { get; set; }

        public DFSVisitingInfo(Vertex from)
            : base(from) {
            Color = VisitingColor.Gray;
        }
    }

    public enum VisitingColor {
        White,
        Gray,
        Black
    }
}
