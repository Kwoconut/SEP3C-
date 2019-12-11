using SEP3_TIER3.Database.DatabaseHandler;
using SEP3_TIER3.Model;
using System;
using System.Collections.Generic;

namespace SEP3_TIER3.Server
{
    class ServerModel
    {
        public List<Plane> Planes { get; set; }
        public List<Edge> Edges { get; set; }
        public List<Node> Nodes { get; set; }
        //public List<NodeEdge> NodeEdges { get; set; }
        public List<NodeDTO> NodesDTO { get; set; }
        public List<EdgeDTO> EdgesDTO { get; set; }
        private DbsPersistence DatabaseAccess;

        public ServerModel()
        {
            DatabaseAccess = new DbsHandler();
            Planes = new List<Plane>();
            Edges = new List<Edge>();
            Nodes = new List<Node>();

            //NodeEdges = new List<NodeEdge>();
            NodesDTO = new List<NodeDTO>();
            EdgesDTO = new List<EdgeDTO>();
            //DO NOT FORGET TO COMMENT, loading happens after a request is made from clients
            LoadPlanes();
            LoadNodes();
            LoadEdges();

            //LoadNodesWithEdgeAndPosition();
            //CreateNodesToSend();

            foreach(Plane plane in Planes)
            {
                Console.WriteLine(plane);
                Console.WriteLine("-----------------------");
            }
            foreach (EdgeDTO edge in EdgesDTO)
            {
                Console.WriteLine(edge);
                Console.WriteLine("-----------------------");
            }
            foreach (NodeDTO node in NodesDTO)
            {
                Console.WriteLine(node);
                Console.WriteLine("-----------------------");
            }
        }
        public void LoadEdges()
        {
            try
            {
                Edges = DatabaseAccess.LoadEdges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            foreach(Edge edge in Edges)
            {
                EdgesDTO.Add(new EdgeDTO { EdgeId = edge.EdgeId, Length = edge.Length, FromNodeIndex = edge.FromNodeIndex, ToNodeIndex = edge.ToNodeIndex }) ;
            }
        }
        public void LoadNodes()
        {
            try
            {
                Nodes = DatabaseAccess.LoadNodes();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            foreach (Node node in Nodes)
            {
                NodesDTO.Add(new NodeDTO { Name = node.Name, NodeId = node.NodeId, IsVisited = node.IsVisited, Position = node.Position, DistanceFromSource = node.DistanceFromSource, isGroundNode = node.isGroundNode});
            }
        }
        public void LoadPlanes()
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
        //algorithm for sending a list of nodes with wach node having a list of edges
       /* public void CreateNodesToSend()
        {
            foreach (NodeEdge nodeEdge in NodeEdges)
            {
                bool flag = false;
                foreach (NodeDTO nodeToSend in NodesDTO)
                {
                    if (nodeEdge.NodeId == nodeToSend.NodeId)
                    {
                        flag = !flag;
                        nodeToSend.Edges.Add(new EdgeDTO { EdgeId = nodeEdge.Edge.EdgeId, FromNodeIndex = nodeEdge.Edge.FromNodeIndex, ToNodeIndex = nodeEdge.Edge.ToNodeIndex, Length = nodeEdge.Edge.Length });
                    }
                }
                if (!flag)
                {                  
                    NodesDTO.Add(new NodeDTO { NodeId = nodeEdge.NodeId, Name = nodeEdge.Node.Name, IsVisited = nodeEdge.Node.IsVisited, Position = nodeEdge.Node.Position, Edges = new List<EdgeDTO> { new EdgeDTO { EdgeId = nodeEdge.Edge.EdgeId, FromNodeIndex = nodeEdge.Edge.FromNodeIndex, ToNodeIndex = nodeEdge.Edge.ToNodeIndex, Length = nodeEdge.Edge.Length } } });
                }
            }

            foreach (NodeDTO node in NodesDTO)
            {
                node.NodeId = node.NodeId - 1;
                foreach (EdgeDTO edge in node.Edges)
                {
                    edge.EdgeId = edge.EdgeId - 1;
                }
            }
        }*/
        //needed for algorithm
        /*public void LoadNodesWithEdgeAndPosition()
        {
            try
            {
                NodeEdges = DatabaseAccess.LoadNodeWithEdge();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }*/

    }
}
