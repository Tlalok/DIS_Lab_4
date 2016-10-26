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
        private int fileCount = 0;
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
            serverThread.Start();
        }

        private void ServerLoop()
        {
            var listener = new TcpListener(endpoint);
            listener.Start();

            while (!end)
            {
                //if (listener.Pending())
                //{
                    //var socket = listener.AcceptSocket();
                    var client = listener.AcceptTcpClient();

                    //if (socket.Connected)
                    //{
                    //var ns = new NetworkStream(socket);
                    var ns = client.GetStream();
                    var requestHandler = new RequestHandler(ns, fileName, fileCount, form);
                    Thread thread = requestHandler.Start();
                    //}
                //}
            }

            listener.Stop();
        }

        public void Stop()
        {
            end = true;
        }


    }
}
