using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.Net.Sockets;

namespace ServerUI.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        protected readonly string name;
        protected readonly NetworkStream networkStream;
        protected readonly string fileName;

        public AbstractCommand(NetworkStream networkStream, string fileName, string commandName)
        {
            this.networkStream = networkStream;
            this.fileName = fileName;
            this.name = commandName;
        }

        public bool Applicable(string commandName)
        {
            return string.Equals(commandName, name, StringComparison.InvariantCultureIgnoreCase);
        }

        public abstract void Execute(Request request);
    }
}
