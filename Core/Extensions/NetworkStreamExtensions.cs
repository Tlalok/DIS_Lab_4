using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class NetworkStreamExtensions
    {
        public static string ReadAsciiString(this NetworkStream networkStream)
        {
            if (!networkStream.CanRead)
            {
                return string.Empty;
            }

            var myReadBuffer = new byte[1024];
            var myCompleteMessage = new StringBuilder();
            do
            {
                var numberOfBytesRead = networkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                myCompleteMessage.AppendFormat("{0}", Encoding.UTF8.GetString(myReadBuffer, 0, numberOfBytesRead));
            } while (networkStream.DataAvailable);
            return myCompleteMessage.ToString();
        }
    }
}
