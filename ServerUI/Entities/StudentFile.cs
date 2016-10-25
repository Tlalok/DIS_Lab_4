using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Core.Entities;
using System.Xml.Serialization;

namespace ServerUI.Entities
{
    [XmlRoot("students")]
    public class StudentFile
    {
        [XmlElement("student")]
        public List<Student> Students { get; set; } 
    }
}
