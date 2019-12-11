using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER3.Model
{
    public class Node
    {
        [Key]
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public int NodeId { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        public bool IsVisited { get; set; } = false;

        [Required]
        public Position Position { get; set; }
        public int DistanceFromSource { get; set; } = Int32.MaxValue;
        public bool IsGroundNode { get; set; }

        [Required]
        public ICollection<NodeEdge> NodeEdges { get; set; }

        public override string ToString()
        {
            return $"NodeId: {NodeId} \nName: {Name} \nIsVisited {IsVisited} \nPosition {Position} \nDistanceFromSource {DistanceFromSource}\nIs GroundNode {IsGroundNode}";
        }
    }
}
