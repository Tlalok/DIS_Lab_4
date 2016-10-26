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
        private IPEndPoint endpoint;
        public event Action<Response> OnRequestStudents;
        public event Action<Response> OnCreateStudent;
        public event Action<Response> OnUpdateStudent;
        public event Action<Response> OnDeleteStudent;

        public Client(IPEndPoint endpoint)
        {
            this.endpoint = endpoint;
            OnRequestStudents += r => { };
            OnCreateStudent += r => { };
            OnUpdateStudent += r => { };
            OnDeleteStudent += r => { };
        }

        public Response RequestStudents()
        {
            var request = new Request {CommandName = Commands.View};
            var response = SendRequest(request);
            OnRequestStudents(response);
            return response;
            //String status = "=>Command sent:view data";
            //Отображеем служебную информацию в клиентском ListBox
            //listBox1.Items.Add(status);
        }

        public Response CreateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            var request = new Request
            {
                CommandName = Commands.Create,
                Student = student
            };
            var response = SendRequest(request);
            OnCreateStudent(response);
            return response;
        }

        private Response SendRequest(Request request)
        {
            var tcpClient = new TcpClient();
            tcpClient.Connect(endpoint);
            var toSent = Encoding.UTF8.GetBytes(request.Serialize());
            var networkStream = tcpClient.GetStream();
            networkStream.Write(toSent, 0, toSent.Length);
            var response = networkStream.ReadUtf8String().Deserialize<Response>();
            tcpClient.Close();
            return response;
        }
    }
}
