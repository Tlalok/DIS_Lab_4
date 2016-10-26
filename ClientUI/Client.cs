﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using System.Net;

namespace ClientUI
{
    public class Client
    {
        //private TcpClient tcp_client = new TcpClient("localhost", 5555);
        private TcpClient tcp_client = new TcpClient();
        private IPEndPoint myEndpoint = new IPEndPoint(IPAddress.Loopback, 11000);
        public event Action<Response> OnRequestStudents;

        public Client()
        {
            OnRequestStudents += r => { };
            //tcp_client.Connect("localhost", 5555);
            tcp_client.Connect(myEndpoint);
        }

        public void RequestStudents()
        {
            var request = new Request();
            request.CommandName = "view";
            byte[] sent = Encoding.ASCII.GetBytes(request.Serialize());
            var ns = tcp_client.GetStream();
            ns.Write(sent, 0, sent.Length);

            var response = ns.ReadAsciiString().Deserialize<Response>();
            OnRequestStudents(response);

            //String status = "=>Command sent:view data";
            //Отображеем служебную информацию в клиентском ListBox
            //listBox1.Items.Add(status);

        }
    }
}
