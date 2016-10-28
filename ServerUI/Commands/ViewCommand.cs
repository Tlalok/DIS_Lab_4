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
using Core.Constants;

namespace ServerUI.Commands
{
    public class ViewCommand : AbstractCommand
    {
        public ViewCommand(NetworkStream networkStream, string fileName)
            : base(networkStream, fileName, Core.Constants.Commands.View) { }

        public override void Execute(Request request)
        {
            var response = new Response
            {
                Status = OperationStatus.Success
            };
            try
            {
                var fileData = File.ReadAllText(fileName);
                var students = fileData.Deserialize<StudentFile>().Students;
                response.Students = students;
            }
            catch (Exception e)
            {
                response.Status = OperationStatus.Error;
                response.ErrorMessage = e.Message;
            }
            networkStream.SendUtf8String(response.Serialize());
        }

        //private readonly string name = Core.Constants.Commands.View;
        //private readonly NetworkStream networkStream;
        //private readonly string fileName;

        //public ViewCommand(NetworkStream networkStream, string fileName)
        //{
        //    this.networkStream = networkStream;
        //    this.fileName = fileName;
        //}

        //public bool Applicable(string commandName)
        //{
        //    return string.Equals(commandName, name, StringComparison.InvariantCultureIgnoreCase);
        //}

        //public void Execute(Request request)
        //{
        //    var response = new Response
        //    {
        //        Status = OperationStatus.Success
        //    };
        //    try
        //    {
        //        var fileData = File.ReadAllText(fileName);
        //        var students = fileData.Deserialize<StudentFile>().Students;
        //        response.Students = students;
        //    }
        //    catch (Exception e)
        //    {
        //        response.Status = OperationStatus.Error;
        //        response.ErrorMessage = e.Message;
        //    }
        //    var toSent = Encoding.UTF8.GetBytes(response.Serialize());
        //    networkStream.Write(toSent, 0, toSent.Length);
        //}

    }
}
