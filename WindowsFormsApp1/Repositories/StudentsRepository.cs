using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.Repositories
{
    public class StudentsRepository
    {
        public static List<Student> GetStudents()
        {
            var connection = Database.Connect();

            const string sqlExpression = "SELECT * FROM students";
            var sqlCommand = new SqlCommand(sqlExpression, connection);

            var reader = sqlCommand.ExecuteReader();
            var students = new List<Student>();
            while (reader.Read())
            {
                var student = new Student(reader);
                students.Add(student);
            }
            
            connection.Close();
            return students;
        }

        public static void AddStudent(Student student)
        {
            var connection = Database.Connect();

            var sqlExpression = "SELECT MAX(id) FROM students";
            var sqlCommand = new SqlCommand(sqlExpression, connection);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            student.Id = reader.GetInt32(0) + 1;
            reader.Close();
            
            sqlExpression = "INSERT INTO students VALUES " +
                            $"({student.Id}, '{student.FirstName}', '{student.LastName}', {student.GroupId})";
            sqlCommand = new SqlCommand(sqlExpression, connection);
            sqlCommand.ExecuteNonQuery();
        }

        public static void UpdateStudent(Student student)
        {
            var connection = Database.Connect();

            var sqlExpression = "UPDATE students SET " +
                                $"first_name = '{student.FirstName}', last_name = '{student.LastName}', group_id = {student.GroupId}" +
                                $"WHERE id = {student.Id}";
            var sqlCommand = new SqlCommand(sqlExpression, connection);
            sqlCommand.ExecuteNonQuery();
        }

        public static void DeleteStudent(int id)
        {
            var connection = Database.Connect();

            var sqlExpression = $"DELETE FROM students WHERE id = {id}";
            var sqlCommand = new SqlCommand(sqlExpression, connection);
            sqlCommand.ExecuteNonQuery();
        }
    }
}