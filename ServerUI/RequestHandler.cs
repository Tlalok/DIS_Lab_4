using ServerUI.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;

namespace ServerUI
{
    public class RequestHandler
    {
        private ServerForm form = null;
        private NetworkStream networkStream;
        private string fileName;

        private readonly List<ICommand> commands;

        public RequestHandler(NetworkStream networkStream, string fileName, ServerForm form)
        {
            this.networkStream = networkStream;
            this.fileName = fileName;
            this.form = form;

            commands = new List<ICommand>
            {
                new ViewCommand(networkStream, fileName),
                new CreateCommand(networkStream, fileName),
                new UpdateCommand(networkStream, fileName),
                new DeleteCommand(networkStream, fileName)
            };
        }

        public Thread Start()
        {
            //Thread thread = new Thread(new ThreadStart(ThreadOperations));
            var thread = new Thread(OperationHandler);
            thread.IsBackground = true;
            thread.Start();
            return thread;
        }

        private void OperationHandler()
        {
            var receivedString = networkStream.ReadUtf8String();
            var request = receivedString.Deserialize<Request>();

            foreach (var command in commands)
            {
                if (command.Applicable(request.CommandName))
                {
                    command.Execute(request);
                    return;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
