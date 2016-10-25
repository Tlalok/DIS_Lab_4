using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerUI.Commands
{
    public interface ICommand
    {
        void Execute();
        bool Applicable(string commandName);
    }
}
