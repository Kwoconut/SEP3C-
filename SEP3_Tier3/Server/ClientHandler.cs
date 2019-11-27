
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
            var requestBack = new Request(Request.TYPE.REQUESTPLANES, planes);
            var json = JsonSerializer.Serialize(requestBack);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }

        private void SendNodesWithEdges(NetworkStream stream, List<GroundNodeToSend> nodesToSend)
        {
            var requestBack = new Request(Request.TYPE.REQUESTGROUNDNODES, nodesToSend);
            var json = JsonSerializer.Serialize(nodesToSend);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }
        private void Run()
        {
            try
            {
                while (true)
                {
                    NetworkStream stream = client.GetStream();
                    Request request = ReceiveRequest(stream);
                    if (request.Type == Request.TYPE.REQUESTPLANES)
                    {
                        if(serverModel.Planes.Count == 0)
                        {
                            serverModel.LoadPlanesWithPositionAndPlan();
                        }
                        SendPlanes(stream, serverModel.Planes);
                    }
                    if(request.Type == Request.TYPE.REQUESTGROUNDNODES)
                    {
                        if (serverModel.GroundNodesToSend.Count == 0)
                        {
                            serverModel.LoadNodesWithEdgeAndPosition();
                            serverModel.CreateNodesToSend();
                        }
                        SendNodesWithEdges(stream, serverModel.GroundNodesToSend);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public class Request
        {
            public enum TYPE { REQUESTPLANES, REQUESTGROUNDNODES}
            public TYPE Type { get; }
            private List<Plane> planes;
            private List<GroundNodeToSend> nodes;

            public Request(TYPE type, List<Plane> planes)
            {
                this.Type = type;
                this.planes = planes;
            }
            public Request(TYPE type, List<GroundNodeToSend> nodes)
            {
                this.Type = type;
                this.nodes = nodes;
            }
        }
    }
}
