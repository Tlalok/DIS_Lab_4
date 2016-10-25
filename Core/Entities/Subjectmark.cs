using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Entities
{
    public class SubjectMark
    {
        [XmlAttribute("mark")]
        public int Mark { get; set; }
        [XmlAttribute("subject")]
        public string Subject { get; set; }

        public SubjectMark() { }

        public SubjectMark(string subject, int mark)
        {
            Subject = subject;
            Mark = mark;
        }
    }
}
