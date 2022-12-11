using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WindowsFormsApp1.Entities
{
    public class Student
    {
        public Student(IDataRecord reader)
        {
            Id = (int)reader["id"];
            FirstName = reader["first_name"] as string;
            LastName = reader["last_name"] as string;
            GroupId = (int)reader["group_id"];
        }

        public Student(int id, string firstName, string lastName, int groupId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            GroupId = groupId;
        }
        
        public Student(string firstName, string lastName, int groupId)
        {
            FirstName = firstName;
            LastName = lastName;
            GroupId = groupId;
        }
        
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int GroupId { get; set; }

        public object[] ToDataRow(List<Group> groups)
        {
            var array = new object[4];

            array[0] = Id;
            array[1] = FirstName;
            array[2] = LastName;
            array[3] = groups.First(group => group.Id == GroupId).Number;

            return array;
        }
    }
}