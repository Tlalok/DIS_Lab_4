using ServerUI.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerUI
{
    public class ThreadClass
    {
        private Form1 form = null;
        private ASCIIEncoding asciiEncoding;
        private NetworkStream networkStream;
        private string fileName;
        private int fileCount;

        private List<ICommand> commands;

        public ThreadClass(NetworkStream networkStream, String fileName, int fileCount, Form1 form)
        {
            this.networkStream = networkStream;
            this.asciiEncoding = new ASCIIEncoding();
            this.fileName = fileName;
            this.fileCount = fileCount;
            this.form = form;

            commands = new List<ICommand>
            {
                new ViewCommand(networkStream, fileName)
            };
        }

        public Thread Start()
        {
            //Thread thread = new Thread(new ThreadStart(ThreadOperations));
            var thread = new Thread(OperationHandler);
            thread.Start();
            return thread;
        }

        private void OperationHandler()
        {
            //Создаем новую переменную типа byte[]
            var receivedData = new byte[256];
            //С помощью сетевого потока считываем в переменную received данные от клиента
            networkStream.Read(receivedData, 0, receivedData.Length);
            var receivedString = asciiEncoding.GetString(receivedData);
            var i = receivedString.IndexOf("|", 0);
            var commandName = receivedString.Substring(0, i);
            var conmmandData = receivedString.Substring(i + 1).TrimStart('|');

            foreach (var command in commands)
            {
                if (command.Applicable(commandName))
                {
                    command.Execute(conmmandData);
                    break;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
