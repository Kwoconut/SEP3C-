
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
namespace Dbs.Server
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
            foreach(Plane plane in planes)
            {
                Console.WriteLine(plane);
            }
            var json = JsonSerializer.Serialize(planes);
            int length = Encoding.ASCII.GetByteCount(json);
            byte[] toSendBytes = Encoding.ASCII.GetBytes(json);
            byte[] toSendLengthBytes = BitConverter.GetBytes(length);
            stream.Write(toSendLengthBytes);
            stream.Write(toSendBytes);
        }

        private void SendNodesWithEdges(NetworkStream stream, List<GroundNodeToSend> nodesToSend)
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
            try
            {
                while (true)
                {
                    NetworkStream stream = client.GetStream();
                    Request request = ReceiveRequest(stream);
                    if (request.Type == Request.TYPE.REQUESTPLANES)
                    {
                        SendPlanes(stream, serverModel.Planes);
                    }
                    if(request.Type == Request.TYPE.REQUESTNODESWITHEDGES)
                    {
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
            public enum TYPE { REQUESTPLANES, REQUESTNODESWITHEDGES}
            public TYPE Type { get; }
        }
    }
}
