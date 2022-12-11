using System;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Forms.Students
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var studentId = int.Parse(id.Text);
            StudentsRepository.DeleteStudent(studentId);
            
            Close();
        }
    }
}