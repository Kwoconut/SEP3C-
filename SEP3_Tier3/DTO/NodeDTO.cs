using SEP3_TIER3.Model;

namespace SEP3_TIER3.DTO
{
    public class NodeDTO
    {
        public int NodeId { get; set; }
        public string Name { get; set; }
        public bool IsVisited { get; set; }
        public Position Position { get; set; }
        public int DistanceFromSource { get; set; }
        public bool IsGroundNode { get; set; }

        public override string ToString()
        {
            return $"NodeId: {NodeId} \nName: {Name} \nIsVisited {IsVisited} \nPosition {Position} \nDistanceFromSource {DistanceFromSource}\nIsGroundNode: {IsGroundNode}";
        }
    }
}
