using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Forms.Students
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var groups = GroupsRepository.GetGroups();
            var group = groups.FirstOrDefault(g => g.Number == groupNumber.Text);
            if (group is null)
            {
                group = new Group(groupNumber.Text);
                GroupsRepository.AddGroup(group);
            }
            
            var student = new Student(int.Parse(id.Text), firstName.Text, lastName.Text, group.Id);
            StudentsRepository.UpdateStudent(student);
            
            Close();
        }
    }
}