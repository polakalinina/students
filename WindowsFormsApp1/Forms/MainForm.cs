using System;
using System.Windows.Forms;
using WindowsFormsApp1.Forms.Groups;
using WindowsFormsApp1.Forms.Students;

namespace WindowsFormsApp1.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tableForm = new StudentsTableForm();
            tableForm.Location = Location;
            tableForm.StartPosition = FormStartPosition.Manual;
            tableForm.Show();
            tableForm.Closed += delegate { Show(); };
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tableForm = new GroupsTableForm();
            tableForm.Location = Location;
            tableForm.StartPosition = FormStartPosition.Manual;
            tableForm.Show();
            tableForm.Closed += delegate { Show(); };
            Hide();
        }
    }
}