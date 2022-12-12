using System;
using System.Data;
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
                if (searchString != null)
                {
                    var studentGroup = groups.FirstOrDefault(group => group.Number == searchString);
                    
                    if (student.FirstName == searchString || student.LastName == searchString || studentGroup != null) 
                    {
                        table.LoadDataRow(student.ToDataRow(groups), LoadOption.Upsert);
                    }
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
            addForm.Closed += delegate { LoadTable(); };
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            var updateForm = new UpdateForm();
            updateForm.Location = Location;
            updateForm.StartPosition = FormStartPosition.Manual;
            updateForm.Show();
            updateForm.Closed += delegate { LoadTable(); };
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var deleteForm = new DeleteForm();
            deleteForm.Location = Location;
            deleteForm.StartPosition = FormStartPosition.Manual;
            deleteForm.Show();
            deleteForm.Closed += delegate { LoadTable(); };
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var searchString = search.Text;
            LoadTable(searchString);
        }
    }
}