using Dbs.Database;
using Dbs.Database.DatabaseHandler;
using Dbs.Model;
using Dbs.Server;
using System;
using System.Collections.Generic;

namespace Dbs
{
    class ServerModel
    {
        public List<Position> Positions { get; set; }
        public List<FlightPlan> FlightPlans { get; set; }
        public List<Plane> Planes { get; set; }
        public List<Edge> Edges { get; set; }
        public List<GroundNode> GroundNodes { get; set; }
        public List<NodeEdge> NodeEdges { get; set; }
        public List<GroundNodeToSend> GroundNodesToSend { get; set; }
        private DbsPersistence DatabaseAccess;

        public ServerModel()
        {
            DatabaseAccess = new DbsHandler();
            Positions = new List<Position>();
            FlightPlans = new List<FlightPlan>();
            Planes = new List<Plane>();
            Edges = new List<Edge>();
            GroundNodes = new List<GroundNode>();
            NodeEdges = new List<NodeEdge>();
            GroundNodesToSend = new List<GroundNodeToSend>();

            LoadPlanes();
            LoadNodesWithEdgeAndPosition();
            LoadNodes();
            LoadEdges();
            LoadFlightPlans();
            CreateNodesToSend();
            Console.WriteLine(DateTime.Now.Kind);

           /* foreach (Plane plane in Planes)
            {
                Console.WriteLine(plane);
            }
            Console.WriteLine("-----------------------");
            foreach (NodeEdge node in NodeEdges)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("-----------------------");
            foreach (GroundNode node in GroundNodes)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("-----------------------");
            foreach (Edge edge in Edges)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine("-----------------------");
            foreach (FlightPlan plan in FlightPlans)
            {
                Console.WriteLine(plan);
            }
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXX");
            foreach (GroundNodeToSend node in GroundNodesToSend)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("-----------------------");*/
        }

        private void CreateNodesToSend()
        {
            foreach(NodeEdge nodeEdge in NodeEdges)
            {
                bool flag = false;
                foreach(GroundNodeToSend nodeToSend in GroundNodesToSend)
                {
                    if(nodeEdge.NodeId == nodeToSend.NodeId)
                    {
                        flag = !flag;
                        nodeToSend.Edges.Add(nodeEdge.Edge);
                    }
                }
                if(!flag)
                {
                    GroundNodesToSend.Add(new GroundNodeToSend {NodeId = nodeEdge.NodeId, Name = nodeEdge.GroundNode.Name, IsVisited = nodeEdge.GroundNode.IsVisited, Position = nodeEdge.GroundNode.Position, Edges = new List<Edge> {nodeEdge.Edge } });
                }
            }

            foreach (GroundNodeToSend node in GroundNodesToSend)
            {
                node.NodeId = node.NodeId - 1;
                foreach (Edge edge in node.Edges)
                {
                    edge.EdgeId = edge.EdgeId - 1;
                }
            }
        }

        private void LoadFlightPlans()
        {
            try
            {
                FlightPlans = DatabaseAccess.LoadFlightPlans();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadEdges()
        {
            try
            {
                Edges = DatabaseAccess.LoadEdges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadNodes()
        {
            try
            {
                GroundNodes = DatabaseAccess.LoadGroundNodes();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadNodesWithEdgeAndPosition()
        {
            try
            {
                NodeEdges = DatabaseAccess.LoadNodesWithEdgeAndPosition();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void LoadPlanes()
        {
            try
            {
              Planes = DatabaseAccess.LoadPlanes();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
