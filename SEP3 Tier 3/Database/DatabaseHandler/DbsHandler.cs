using Dbs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dbs.Database.DatabaseHandler
{
    class DbsHandler : DbsPersistence
    {        
        public List<Plane> LoadPlanes()
        {
            using (var context = new AppDbContext())
            {
                if(!(context.Planes.Any() && context.Positions.Any() && context.FlightPlans.Any()))
                {
                    throw new Exception("No data in Planes / Positions / FlightPlans");
                }
                List<Position> positions = context.Positions.ToList();
                List<FlightPlan> flightPlans = context.FlightPlans.ToList();
                List<Plane> planes = context.Planes.ToList();
                return planes;
            }
        }

        public List<NodeEdge> LoadNodesWithEdgeAndPosition()
        {
            using (var context = new AppDbContext())
            {
                if (!(context.NodeEdges.Any()&& context.Positions.Any() && context.GroundNodes.Any() && context.Edges.Any()))
                {
                    throw new Exception("No data in NodeEdges / Positions / GroundNodes / Edges");
                }
                List<Position> positions = context.Positions.ToList();
                List<GroundNode> groundNodes = context.GroundNodes.ToList();
                List<Edge> edges = context.Edges.ToList();
                List<NodeEdge> nodes = context.NodeEdges.ToList();
                return nodes;
            }
        }

        public List<GroundNode> LoadGroundNodes()
        {
            using (var context = new AppDbContext())
            {
                if (!(context.GroundNodes.Any()))
                {   
                    throw new Exception("No data in GroundNodes");
                }
                List<GroundNode> groundNodes = context.GroundNodes.ToList();
                return groundNodes;
            }
        }

        public List<Edge> LoadEdges()
        {
            using (var context = new AppDbContext())
            {
                if (!(context.Edges.Any()))
                {
                    throw new Exception("No data in Edges");
                }
                List<Edge> edges = context.Edges.ToList();
                return edges;
            }
        }

        public List<FlightPlan> LoadFlightPlans()
        {
            using (var context = new AppDbContext())
            {
                if (!(context.FlightPlans.Any()))
                {
                    throw new Exception("No data in FlightPlan");
                }
                List<FlightPlan> flightPlans = context.FlightPlans.ToList();
                return flightPlans;
            }
        }
    }
}
