using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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

        public void Execute(string commandData)
        {
            var asciiEncoding = new ASCIIEncoding();
            var toSent = new byte[256];
            //Создаем объект класса FileStream для последующего чтения информации из файла
            var fileData = File.ReadAllText(fileName);
            //Запись в переменную sent содержания прочитанного файла
            toSent = asciiEncoding.GetBytes(fileData);
            //Отправка информации клиенту
            ns.Write(toSent, 0, toSent.Length);
        }
    }
}
