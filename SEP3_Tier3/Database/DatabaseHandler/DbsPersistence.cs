using SEP3_TIER3.Model;
using System.Collections.Generic;

namespace SEP3_TIER3.Database.DatabaseHandler
{
    interface DbsPersistence
    {
        public List<Plane> LoadPlanes();


        //nodes with position
        public List<Node> LoadNodes();

        public List<Edge> LoadEdges();

        public void DeleteFlightPlan(string callSign);
        //relationship between nodes(with position) and their edges
        //public List<NodeEdge> LoadNodeWithEdge();
    }
}
