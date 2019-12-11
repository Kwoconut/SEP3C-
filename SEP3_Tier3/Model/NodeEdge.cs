namespace SEP3_TIER3.Model
{
    public class NodeEdge
    {
        public int EdgeId { get; set; }

        public Edge Edge { get; set; }

        public int NodeId { get; set; }

        public Node Node { get; set; }

        public override string ToString()
        {
            return $"IdNode: {NodeId} ---- IdEdge: {EdgeId}";
        }
    }
}
