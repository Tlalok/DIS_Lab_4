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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var client = new Client();
            client.OnRequestStudents += r => MessageBox.Show(string.Join(", ", r.Students.Select(s => s.Name)));
            client.RequestStudents();
        }
    }
}
