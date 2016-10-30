using Core.Constants;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
            TrySendRequest(() => client.RequestStudents());
        }

        private void ViewResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            LogMessage("Data request was performed successfuly.");
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
            TrySendRequest(() => client.CreateStudent(newStudent));
        }

        private void CreateResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            LogMessage("Create request was performed successfuly.");
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
            TrySendRequest(() => client.UpdateStudent(newStudentData));
        }

        private void UpdateResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            LogMessage("Update request was performed successfuly.");
            UpdateListBox(response.Students);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedStudent = GetSelectedStudent();
            if (selectedStudent == null)
            {
                return;
            }
            TrySendRequest(() => client.DeleteStudent(selectedStudent));
        }

        private void DeleteResponseHandler(Response response)
        {
            if (HandleErrorRequest(response))
            {
                return;
            }
            LogMessage("Delete request was performed successfuly.");
            UpdateListBox(response.Students);
        }

        private bool HandleErrorRequest(Response response)
        {
            if (response.Status == OperationStatus.Error)
            {
                var message =
                    $"{Environment.NewLine}{DateTime.Now.ToString("HH:mm:ss")}: Request failed. {response.ErrorMessage}";
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

        private bool TrySendRequest(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (SocketException ex)
            {
                LogMessage("Failure connecting to server.");
            }
            return false;
        }

        private void LogMessage(string message)
        {
            var textToAdd =
                $"{Environment.NewLine}{DateTime.Now.ToString("HH:mm:ss")}: {message}";
            serverResponseTextBox.AppendText(textToAdd);
        }
    }
}
