using SEP3_TIER3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEP3_TIER3.Database.DatabaseHandler
{
    interface DbsPersistence
    {
        public List<Plane> LoadPlanesWithPositionAndPlan();
        public List<NodeEdge> LoadNodesWithEdgeAndPosition();
        public List<GroundNode> LoadGroundNodes();
        public List<Edge> LoadEdges();
        public List<FlightPlan> LoadFlightPlans();
    }
}
