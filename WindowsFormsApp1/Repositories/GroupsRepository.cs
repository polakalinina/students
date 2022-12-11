using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.Repositories
{
    public class GroupsRepository
    {
        public static List<Group> GetGroups()
        {
            var connection = Database.Connect();

            const string sqlExpression = "SELECT * FROM groups";
            var sqlCommand = new SqlCommand(sqlExpression, connection);

            var reader = sqlCommand.ExecuteReader();
            var groups = new List<Group>();
            while (reader.Read())
            {
                var group = new Group(reader);
                groups.Add(group);
            }
            
            connection.Close();
            return groups;
        }

        public static void AddGroup(Group group)
        {
            var connection = Database.Connect();

            var sqlExpression = "SELECT MAX(id) FROM groups";
            var sqlCommand = new SqlCommand(sqlExpression, connection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            group.Id = reader.GetInt32(0) + 1;
            reader.Close();
            
            sqlExpression = $"INSERT INTO groups VALUES ({group.Id}, '{group.Number}')";
            sqlCommand = new SqlCommand(sqlExpression, connection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}