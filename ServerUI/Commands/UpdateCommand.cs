using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Constants;
using ServerUI.Entities;
using System.IO;
using Core.Extensions;

namespace ServerUI.Commands
{
    public class UpdateCommand : AbstractCommand
    {
        public UpdateCommand(NetworkStream networkStream, string fileName) 
            : base(networkStream, fileName, Core.Constants.Commands.Update) { }

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
                var student = students.Single(st => st.Id == request.Student.Id);
                student.SubjectMarks = request.Student.SubjectMarks;
                student.Name = request.Student.Name;
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
