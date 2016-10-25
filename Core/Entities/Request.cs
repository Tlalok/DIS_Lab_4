using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Request
    {
        public string CommandName { get; set; }
        public Student Student { get; set; }
    }
}
