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
        private IPEndPoint myEndpoint = new IPEndPoint(IPAddress.Loopback, 11000);

        private ServerForm form;
        private Thread serverThread;

        public Server(ServerForm form)
        {
            this.form = form;
        }

        public void Run()
        {
            serverThread = new Thread(new ThreadStart(ServerLoop));
            serverThread.Start();
        }

        private void ServerLoop()
        {
            //var listener = new TcpListener(IPAddress.Any, 5555);
            var listener = new TcpListener(myEndpoint);
            listener.Start();

            while (true)
            {
                //if (listener.Pending())
                //{
                    //var socket = listener.AcceptSocket();
                    var tcpClient = listener.AcceptTcpClient();

                    //if (socket.Connected)
                    //{
                    //var ns = new NetworkStream(socket);
                    var ns = tcpClient.GetStream();
                    var requestHandler = new RequestHandler(ns, fileName, fileCount, form);
                    Thread thread = requestHandler.Start();
                    //}
                //}
            }
        }


    }
}
