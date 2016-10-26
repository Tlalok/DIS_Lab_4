using Core.Constants;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUI
{
    public partial class ClientForm : Form
    {
        private Client client;

        public ClientForm()
        {
            InitializeComponent();

            client = new Client();
            client.OnRequestStudents += r => MessageBox.Show(string.Join(", ", r.Students.Select(s => s.Name)));
            client.OnCreateStudent += r => MessageBox.Show(r.Status.ToString() + " " + r.ErrorMessage);
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            client.RequestStudents();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                Name = "Name 3",
                SubjectMarks = new List<SubjectMark>
                {
                    new SubjectMark("Math", 9)
                }
            };
            client.CreateStudent(student);
        }
    }
}
