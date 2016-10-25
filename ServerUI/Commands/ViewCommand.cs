using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using ServerUI.Entities;

namespace ServerUI.Commands
{
    public class ViewCommand : ICommand
    {
        private readonly string name = "view";
        private readonly NetworkStream ns;
        private readonly string fileName;

        public ViewCommand(NetworkStream ns, string fileName)
        {
            this.ns = ns;
            this.fileName = fileName;
        }

        public bool Applicable(string commandName)
        {
            return string.Equals(commandName, name, StringComparison.InvariantCultureIgnoreCase);
        }

        public void Execute(Request request)
        {
            var fileData = File.ReadAllText(fileName);
            var students = fileData.Deserialize<StudentFile>().Students;
            var response = new Response
            {
                Students = students
            };
            var toSent = Encoding.ASCII.GetBytes(response.Serialize());
            ns.Write(toSent, 0, toSent.Length);
        }
    }
}
