using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;

namespace ServerUI
{
    public class Server
    {
        private string fileName = "data.xml";
        private readonly IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 11000);
        private Thread serverThread;
        private bool end = false;

        public event Action<Request> OnRequestRecieving;

        public void Run()
        {
            end = false;
            serverThread = new Thread(ServerLoop);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void ServerLoop()
        {
            var listener = new TcpListener(endpoint);
            listener.Start();

            while (!end)
            {
                var client = listener.AcceptTcpClient();
                if (client.Connected)
                {
                    var ns = client.GetStream();
                    var requestHandler = new RequestHandler(ns, fileName, OnRequestRecieving);
                    var thread = requestHandler.Start();
                }
            }

            listener.Stop();
        }

        public void Stop()
        {
            end = true;
        }


    }
}
