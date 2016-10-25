using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerUI
{
    public class Server
    {
        //Путь к файлу, в котором будет храниться информация
        private String fileName = "d:\\file1.txt";
        private int fileCount = 0;
        //Создание объекта класса TcpListener
        private TcpListener listener = null;
        //Создание объекта класса Socket
        private Socket socket = null;
        //Создание объекта класса NetworkStream
        private NetworkStream ns = null;
        //Создание объекта класса кодировки ASCIIEncoding
        private ASCIIEncoding ae = null;

        private ServerForm form;

        public Server(ServerForm form)
        {
            this.form = form;
        }

        public void Run()
        {
            // Создаем новый TCP_Listener который принимает запросы от любых IP адресов и слушает по порту 5555
            listener = new TcpListener(IPAddress.Any, 5555);
            // Активация listen’ера                     
            listener.Start();

            while (true)
            {
                socket = listener.AcceptSocket();

                if (socket.Connected)
                {
                    ns = new NetworkStream(socket);
                    ae = new ASCIIEncoding();
                    RequestHandler threadClass = new RequestHandler(ns, fileName, fileCount, form);
                    Thread thread = threadClass.Start();
                }
            }
        }
    }
}
