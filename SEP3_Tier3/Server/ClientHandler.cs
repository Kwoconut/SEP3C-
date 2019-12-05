
using SEP3_TIER3.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
namespace SEP3_TIER3.Server
{
    class ClientHandler
    {
        private TcpClient client;
        private ServerModel serverModel;
        public ClientHandler(TcpClient client, ServerModel serverModel)
        {
            this.client = client;
            this.serverModel = serverModel;
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }
        private Request ReceiveRequest(NetworkStream stream)
        {
            byte[] receiveLengthBytes = new byte[4];
            stream.Read(receiveLengthBytes);
            int receiveLength = BitConverter.ToInt32(receiveLengthBytes, 0);
            byte[] receiveBytes = new byte[receiveLength];
            stream.Read(receiveBytes);
            String rcv = Encoding.ASCII.GetString(receiveBytes);
            return JsonSerializer.Deserialize<Request>(rcv);
        }

        private void SendPlanes(NetworkStream stream, List<Plane> planes)
        {
            Request request = new Request { type = Request.Type.RESPONSEPLANES, planesToSend = planes };
            var json = JsonSerializer.Serialize(request);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }

        /*private void SendNodesWithEdges(NetworkStream stream, List<GroundNodeDTO> nodesToSend)
        {
            var json = JsonSerializer.Serialize(nodesToSend);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }*/
        private void SendNodesWithPosition(NetworkStream stream, List<GroundNode> nodesToSend)
        {
            Request request = new Request { type = Request.Type.RESPONSENODES, nodesToSend = nodesToSend };
            var json = JsonSerializer.Serialize(request);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }
        private void SendEdges(NetworkStream stream, List<Edge> edgesToSend)
        {
            Request request = new Request { type = Request.Type.RESPONSEEDGES, edgesToSend = edgesToSend };
            var json = JsonSerializer.Serialize(request);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }
        private void Run()
        {
            while(true)
            {
                NetworkStream stream = client.GetStream();
                Request request = ReceiveRequest(stream);
                switch(request.type)
                {
                    case Request.Type.REQUESTPLANES:
                        {
                            if (serverModel.Planes.Count == 0)
                            {
                                serverModel.LoadPlanesWithPositionAndPlan();
                                SendPlanes(stream, serverModel.Planes);
                            }
                            break;
                        }
                    case Request.Type.REQUESTNODES:
                        {
                            if (serverModel.GroundNodes.Count == 0)
                            {
                                serverModel.LoadNodes();
                            }
                            SendNodesWithPosition(stream, serverModel.GroundNodes);
                            break;
                        }
                    case Request.Type.REQUESTEDGES:
                        {
                            if (serverModel.Edges.Count == 0)
                            {
                                serverModel.LoadEdges();
                            }
                            SendEdges(stream, serverModel.Edges);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }

    public class Request
    { 
        public enum Type { REQUESTPLANES, REQUESTNODES, REQUESTEDGES, RESPONSEPLANES, RESPONSENODES, RESPONSEEDGES}
        public Type type;
        public List<Plane> planesToSend { get; set; }
        public List<Edge> edgesToSend { get; set; }
        public List<GroundNode> nodesToSend { get; set; }
    }


}