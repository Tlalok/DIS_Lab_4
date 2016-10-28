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
    public class DeleteCommand : AbstractCommand
    {
        public DeleteCommand(NetworkStream networkStream, string fileName) 
            : base(networkStream, fileName, Core.Constants.Commands.Delete) { }

        public override void Execute(Request request)
        {
            var response = new Response
            {
                Status = OperationStatus.Success
            };
            try
            {
                var fileData = File.ReadAllText(fileName);
                var studentFile = fileData.Deserialize<StudentFile>();
                var students = studentFile.Students;
                if (!students.Any(st => st.Id == request.Student.Id))
                {
                    throw new ArgumentException($"Student with id {request.Student.Id} does not exist.");
                }
                students.RemoveAll(st => st.Id == request.Student.Id);
                File.WriteAllText(fileName, studentFile.Serialize());
                response.Students = students;
            }
            catch (Exception e)
            {
                response.Status = OperationStatus.Error;
                response.ErrorMessage = e.Message;
            }
            networkStream.SendUtf8String(response.Serialize());
        }
    }
}
