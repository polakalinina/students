using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Forms.Students
{
    public partial class StudentsTableForm : Form
    {
        public StudentsTableForm()
        {
            InitializeComponent();

            LoadTable(null);
        }

        private void LoadTable(string searchString)
        {
            var table = new DataTable();

            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("First Name", typeof(string)));
            table.Columns.Add(new DataColumn("Last Name", typeof(string)));
            table.Columns.Add(new DataColumn("Group Number", typeof(string)));

            var students = StudentsRepository.GetStudents();
            var groups = GroupsRepository.GetGroups();
            foreach (var student in students)
            {
                if (string.IsNullOrEmpty(searchString) ||
                    student.FirstName.Contains(searchString) ||
                    student.LastName.Contains(searchString) ||
                    groups.First(group => group.Id == student.GroupId).Number.Contains(searchString))
                {
                    table.LoadDataRow(student.ToDataRow(groups), LoadOption.Upsert);
                }
            }

            dataGridView1.DataSource = table;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm();
            addForm.Location = Location;
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Show();
            addForm.Closed += delegate { LoadTable(null); };
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var updateForm = new UpdateForm();
            updateForm.Location = Location;
            updateForm.StartPosition = FormStartPosition.Manual;
            updateForm.Show();
            updateForm.Closed += delegate { LoadTable(null); };
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var deleteForm = new DeleteForm();
            deleteForm.Location = Location;
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Show();
            deleteForm.Closed += delegate { LoadTable(null); };
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var searchString = search.Text;
            LoadTable(searchString);
        }
    }
}