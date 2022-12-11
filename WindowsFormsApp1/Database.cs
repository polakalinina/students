using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class Database
    {
        private const string ConnectionString = 
            @"Server=.\SQLEXPRESS;Database=task2_db;Trusted_Connection=True;";
        
        public static SqlConnection Connect()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }
    }
}