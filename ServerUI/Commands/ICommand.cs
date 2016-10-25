using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace ServerUI.Commands
{
    public interface ICommand
    {
        void Execute(Request request);
        bool Applicable(string commandName);
    }
}
