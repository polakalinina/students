using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Forms.Groups
{
    public partial class GroupsTableForm : Form
    {
        public GroupsTableForm()
        {
            InitializeComponent();
            LoadTable();
        }
        
        private void LoadTable()
        {
            var table = new DataTable();

            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Number", typeof(string)));
            
            var groups = GroupsRepository.GetGroups();
            foreach (var group in groups)
            {
                table.LoadDataRow(group.ToDataRow(), LoadOption.Upsert);
            }

            dataGridView1.DataSource = table;
        }
    }
}