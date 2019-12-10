using SEP3_TIER3.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEP3_TIER3.Database.DatabaseHandler
{
    class DbsHandler : DbsPersistence
    {        
        public List<Plane> LoadPlanes()
        {
            using (var context = new AppDbContext())
            {
                if(!(context.Positions.Any() &&  context.FlightDates.Any() && context.FlightPlans.Any()  && context.Planes.Any()))
                {
                    throw new Exception("No data in Positions / FlightDates / FlightPlans / Planes");
                }
                List<Position> positions = context.Positions.ToList();
                List<FlightDate> flightDates = context.FlightDates.ToList();
                List<FlightPlan> flightPlans = context.FlightPlans.ToList();
                List<Plane> planes = context.Planes.ToList();
                return planes;
            }
        }

        public List<Node> LoadNodes()
        {
            using (var context = new AppDbContext())
            {
                if (!(context.Positions.Any() && context.Nodes.Any()))
                {   
                    throw new Exception("No data in GroundNodes / Position");
                }
                List<Position> positions = context.Positions.ToList();
                List<Node> groundNodes = context.Nodes.ToList();
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

        /*public List<NodeEdge> LoadNodeWithEdge()
        {
            using (var context = new AppDbContext())
            {
                if (!(context.Positions.Any() && context.Nodes.Any() && context.Edges.Any() && context.NodeEdges.Any()))
                {
                    throw new Exception("No data in NodeEdges / Positions / GroundNodes / Edges");
                }
                List<Position> positions = context.Positions.ToList();
                List<Node> groundNodes = context.Nodes.ToList();
                List<Edge> edges = context.Edges.ToList();
                List<NodeEdge> nodes = context.NodeEdges.ToList();
                return nodes;
            }
        }*/
    }
}
