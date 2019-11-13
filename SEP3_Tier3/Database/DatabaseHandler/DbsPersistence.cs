using Dbs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dbs.Database.DatabaseHandler
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
