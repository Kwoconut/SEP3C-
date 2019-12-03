using System;
using System.Collections.Generic;
using System.Text;

namespace SEP3_TIER3.Model
{
    class GroundNodeDTO
    {
        public int NodeId { get; set; }
        public string Name { get; set; }
        public bool IsVisited { get; set; }
        public Position Position { get; set; }
        public int DistanceFromSource { get; } = Int32.MaxValue;
        public ICollection<EdgeDTO> Edges { get; set; }

        public override string ToString()
        {
            string s = $"NodeId: {NodeId} \nName: {Name} \nIsVisited {IsVisited} \nPosition {Position} \nDistanceFromSource {DistanceFromSource} \nEdges: \n";
            foreach(EdgeDTO edge in Edges)
            {
                s += edge;
                s += "\n";
            }
            return s;
        }
    }
}
