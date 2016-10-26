using Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Response
    {
        public OperationStatus Status { get; set; }
        public List<Student> Students { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
