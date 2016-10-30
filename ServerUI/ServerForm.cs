using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Entities;

namespace ServerUI
{
    public partial class ServerForm : Form
    {
        private readonly Server server;

        public ServerForm()
        {
            InitializeComponent();
            server = new Server();
            server.OnRequestRecieving += RequestLog;
            server.Run();
        }

        private void RequestLog(Request request)
        {
            var message = $"{Environment.NewLine}{DateTime.Now.ToString("HH:mm:ss")}: {request.CommandName} request was recieved.";
            requestsTextBox.AppendText(message);
        }

        ~ServerForm()
        {
            server.Stop();
        }
    }
}
