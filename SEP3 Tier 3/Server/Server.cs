using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Dbs.Server
{
    class Server
    {
        private string IP { get; set; } 
        private int Port { get; set; }

        public void SetupServer()
        {
            Console.WriteLine("Start Server ....");
            using (var context = new AppDbContext())
            {
               DatabaseInitializer.Initialize(context);
            }
            IPAddress IPAdress = IPAddress.Parse(IP);
            TcpListener listener = new TcpListener(IPAdress, Port);
            listener.Start();
            ServerModel model = new ServerModel();
            Console.WriteLine("Server started");
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                ClientHandler handler = new ClientHandler(client, model);
            }
        }
        public static void Main (String [] args)
        {
            Server server = new Server { IP = "10.152.218.81", Port = 200};
            server.SetupServer();
        }

    }
}

