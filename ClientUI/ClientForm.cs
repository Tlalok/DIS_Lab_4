using Core.Constants;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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

            client = new Client(new IPEndPoint(IPAddress.Loopback, 11000));
            client.OnRequestStudents += ViewResponseHandler;
            client.OnCreateStudent += CreateResponseHandler;
            client.OnUpdateStudent += UpdateResponseHandler;
            client.OnDeleteStudent += DeleteResponseHandler;
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            client.RequestStudents();
        }

        private void ViewResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            //MessageBox.Show(string.Join(", ", response.Students.Select(s => s.Name)));
            var message = string.Format("{0}{1}: Data request was performed successfuly.", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"));
            serverResponseTextBox.AppendText(message);
            UpdateListBox(response.Students);

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (!ValidateStudent())
            {
                return;
            }
            var newStudent = new Student
            {
                Name = nameTextBox.Text,
                SubjectMarks = GenerateMarkList()
            };
            client.CreateStudent(newStudent);
        }

        private void CreateResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            //MessageBox.Show(response.Status.ToString());
            var message = string.Format("{0}{1}: Create request was performed successfuly.", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"));
            serverResponseTextBox.AppendText(message);
            UpdateListBox(response.Students);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateStudent())
            {
                return;
            }
            var selectedStudent = GetSelectedStudent();
            if (selectedStudent == null)
            {
                return;
            }
            var newStudentData = new Student
            {
                Id = selectedStudent.Id,
                Name = nameTextBox.Text,
                SubjectMarks = GenerateMarkList()
            };
            client.UpdateStudent(newStudentData);
        }

        private void UpdateResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            //MessageBox.Show(response.Status.ToString());
            var message = string.Format("{0}{1}: Update request was performed successfuly.", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"));
            serverResponseTextBox.AppendText(message);
            UpdateListBox(response.Students);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedStudent = GetSelectedStudent();
            if (selectedStudent == null)
            {
                return;
            }
            client.DeleteStudent(selectedStudent);
        }

        private void DeleteResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            //MessageBox.Show(response.Status.ToString());
            var message = string.Format("{0}{1}: Delete request was performed successfuly.", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"));
            serverResponseTextBox.AppendText(message);
            UpdateListBox(response.Students);
        }

        private bool HandleErrorRequest(Response response)
        {
            if (response.Status == OperationStatus.Error)
            {
                var message = string.Format("{0}{1}: Request failed.{2}", Environment.NewLine, DateTime.Now.ToString("HH:mm:ss"), response.ErrorMessage);
                serverResponseTextBox.AppendText(message);
                return true;
            }
            return false;
        }

        

        private Student GetSelectedStudent()
        {
            var selectedIndex = studentListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                ShowErrorMessage("Вы не выбрали студента");
                return null;
            }
            return (Student)studentListBox.Items[selectedIndex];
        }

        private void UpdateListBox(List<Student> students)
        {
            var selecteIndex = studentListBox.SelectedIndex;
            studentListBox.BeginUpdate();
            studentListBox.Items.Clear();
            students.ForEach(st => studentListBox.Items.Add(st));
            studentListBox.EndUpdate();
            if (selecteIndex != -1 && students.Any())
            {
                studentListBox.SelectedIndex = Math.Min(selecteIndex, students.Count - 1);
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidateStudent()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                ShowErrorMessage("Вы не ввели имя студента");
                return false;
            }
            return true;
        }

        private List<SubjectMark> GenerateMarkList()
        {
            var math = Convert.ToInt32(mathNumericUpDown.Value);
            var dis = Convert.ToInt32(DisNumericUpDown.Value);
            var oop = Convert.ToInt32(OopNumericUpDown.Value);
            return MarkListGenerator(math, dis, oop);
        }

        private List<SubjectMark> MarkListGenerator(int math, int dis, int oop)
        {
            return new List<SubjectMark>
            {
                new SubjectMark(Subjects.Math, math),
                new SubjectMark(Subjects.Dis, dis),
                new SubjectMark(Subjects.Oop, oop)
            };
        }

        private void studentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (studentListBox.SelectedIndex == -1)
            {
                return;
            }

            var selectedStudent = GetSelectedStudent();
            nameTextBox.Text = selectedStudent.Name;
            mathNumericUpDown.Value = selectedStudent.SubjectMarks.Single(sm => string.Equals(sm.Subject, Subjects.Math, StringComparison.InvariantCultureIgnoreCase)).Mark;
            DisNumericUpDown.Value = selectedStudent.SubjectMarks.Single(sm => string.Equals(sm.Subject, Subjects.Dis, StringComparison.InvariantCultureIgnoreCase)).Mark;
            OopNumericUpDown.Value = selectedStudent.SubjectMarks.Single(sm => string.Equals(sm.Subject, Subjects.Oop, StringComparison.InvariantCultureIgnoreCase)).Mark;
        }
    }
}
