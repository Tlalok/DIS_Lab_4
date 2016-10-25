using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
