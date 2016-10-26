using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using System.Net;
using Core.Constants;

namespace ClientUI
{
    public class Client
    {
        private TcpClient tcp_client;
        private IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 11000);
        public event Action<Response> OnRequestStudents;
        public event Action<Response> OnCreateStudent;

        public Client()
        {
            OnRequestStudents += r => { };
            OnCreateStudent += r => { };
            //tcp_client.Connect(endpoint);
        }

        public void RequestStudents()
        {
            //var tcp_client = new TcpClient(endpoint);
            tcp_client = new TcpClient();
            tcp_client.Connect(endpoint);
            var request = new Request();
            request.CommandName = Commands.View;
            byte[] sent = Encoding.UTF8.GetBytes(request.Serialize());
            var ns = tcp_client.GetStream();
            ns.Write(sent, 0, sent.Length);

            var response = ns.ReadUtf8String().Deserialize<Response>();
            OnRequestStudents(response);

            tcp_client.Close();

            //String status = "=>Command sent:view data";
            //Отображеем служебную информацию в клиентском ListBox
            //listBox1.Items.Add(status);

        }

        public void CreateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            //var tcp_client = new TcpClient(endpoint);
            tcp_client = new TcpClient();
            tcp_client.Connect(endpoint);
            var request = new Request();
            request.CommandName = Commands.Create;
            request.Student = student;
            byte[] sent = Encoding.UTF8.GetBytes(request.Serialize());
            var ns = tcp_client.GetStream();
            ns.Write(sent, 0, sent.Length);

            var response = ns.ReadUtf8String().Deserialize<Response>();
            OnCreateStudent(response);
            tcp_client.Close();
        }
    }
}
