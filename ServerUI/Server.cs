using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerUI
{
    public class Server
    {
        private string fileName = "data.xml";
        private IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 11000);

        private ServerForm form;
        private Thread serverThread;

        private bool end = false;

        public Server(ServerForm form)
        {
            this.form = form;
        }

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
                    var requestHandler = new RequestHandler(ns, fileName, form);
                    Thread thread = requestHandler.Start();
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
