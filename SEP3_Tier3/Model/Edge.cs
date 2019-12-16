using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER3.Model
{
    public class Edge
    {
        public int EdgeId { get; set; }
        public int Length { get; set; }
        public int FromNodeIndex { get; set; }
        public int ToNodeIndex { get; set; }
        public bool IsGroundEdge { get; set; }
        
        [Required]
        public ICollection<NodeEdge> NodeEdges { get; set; }

        public override string ToString()
        {
            return $"IdEdge {EdgeId} \nLength {Length} \nFromNodeIndex {FromNodeIndex} \nToNodeIndex {ToNodeIndex} \n {IsGroundEdge}" ;
        }
    }
}
