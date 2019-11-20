using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SEP3_TIER3.Model
{
   public class NodeEdge
    {
        public int EdgeId { get; set; }

        public Edge Edge { get; set; }

        public int NodeId { get; set; }

        public GroundNode GroundNode { get; set; }

        public override string ToString()
        {
            return $"IdNode: {NodeId} ---- IdEdge: {EdgeId}";
        }
    }
}
