using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.Net.Sockets;
using Core.Constants;
using System.IO;
using ServerUI.Entities;
using Core.Extensions;

namespace ServerUI.Commands
{
    public class CreateCommand : ICommand
    {
        private readonly string name = Core.Constants.Commands.Create;
        private readonly NetworkStream networkStream;
        private readonly string fileName;

        public CreateCommand(NetworkStream networkStream, string fileName)
        {
            this.networkStream = networkStream;
            this.fileName = fileName;
        }

        public bool Applicable(string commandName)
        {
            return string.Equals(commandName, name, StringComparison.InvariantCultureIgnoreCase);
        }

        public void Execute(Request request)
        {
            var response = new Response
            {
                Status = OperationStatus.Success
            };
            try
            {
                var fileData = File.ReadAllText(fileName);
                var students = fileData.Deserialize<StudentFile>().Students;
                if (students.Any(st => string.Equals(st.Name, request.Student.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    throw new ArgumentException($"Student with name {request.Student.Name} is already exists.");
                }
                students.Add(request.Student);
                var studentFile = new StudentFile
                {
                    Students = students
                };
                File.WriteAllText(fileName, studentFile.Serialize());
            }
            catch (Exception e)
            {
                response.Status = OperationStatus.Error;
                response.ErrorMessage = e.Message;
            }
            var toSent = Encoding.UTF8.GetBytes(response.Serialize());
            networkStream.Write(toSent, 0, toSent.Length);
        }
    }
}
