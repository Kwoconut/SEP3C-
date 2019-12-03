
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

        private void SendPlanes(NetworkStream stream, List<Plane> planes)
        {
            var json = JsonSerializer.Serialize(planes);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }

        private void SendNodesWithEdges(NetworkStream stream, List<GroundNodeDTO> nodesToSend)
        {
            var json = JsonSerializer.Serialize(nodesToSend);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }
        private void Run()
        {
                NetworkStream stream = client.GetStream();
                if (serverModel.Planes.Count == 0)
                {
                    serverModel.LoadPlanesWithPositionAndPlan();
                }
                SendPlanes(stream, serverModel.Planes);
                if (serverModel.GroundNodesDTO.Count == 0)
                {
                    serverModel.LoadNodesWithEdgeAndPosition();
                    serverModel.CreateNodesToSend();
                }
                SendNodesWithEdges(stream, serverModel.GroundNodesDTO);
            
        }
    }
}