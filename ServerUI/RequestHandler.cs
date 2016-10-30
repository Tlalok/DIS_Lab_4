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
        private NetworkStream networkStream;
        private string fileName;

        private readonly List<ICommand> commands;
        private readonly Action<Request> onRequest;

        public RequestHandler(NetworkStream networkStream, string fileName, Action<Request> onRequest)
        {
            this.networkStream = networkStream;
            this.fileName = fileName;
            this.onRequest = onRequest;

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
            var thread = new Thread(OperationHandler);
            thread.IsBackground = true;
            thread.Start();
            return thread;
        }

        private void OperationHandler()
        {
            var receivedString = networkStream.ReadUtf8String();
            var request = receivedString.Deserialize<Request>();

            onRequest?.Invoke(request);

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
