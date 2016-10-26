using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Entities;
using Core.Extensions;
using ServerUI.Entities;

namespace ServerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());

            //GenerateTestData();
        }

        private static void GenerateTestData()
        {
            var students = new List<Student>();
            students.Add(new Student
            {
                Name = "Name 1",
                SubjectMarks = new List<SubjectMark>
                {
                    new SubjectMark("Math", 10)
                }
            });
            students.Add(new Student
            {
                Name = "Name 2",
                SubjectMarks = new List<SubjectMark>
                {
                    new SubjectMark("Physics", 8)
                }
            });
            var xml = new StudentFile
            {
                Students = students
            }.Serialize();
            File.WriteAllText("data.xml", xml);
        }
    }
}
