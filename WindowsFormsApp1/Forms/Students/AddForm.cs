using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Forms.Students
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var groups = GroupsRepository.GetGroups();
            var group = groups.FirstOrDefault(g => g.Number == groupNumber.Text);
            if (group is null)
            {
                group = new Group(groupNumber.Text);
                GroupsRepository.AddGroup(group);
            }
            
            var student = new Student(firstName.Text, lastName.Text, group.Id);
            StudentsRepository.AddStudent(student);
            
            Close();
        }
    }
}