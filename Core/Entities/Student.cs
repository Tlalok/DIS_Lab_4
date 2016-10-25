using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Entities
{
    public class Student
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("subjectMark")]
        public List<SubjectMark> SubjectMarks { get; set; }
    }
}
