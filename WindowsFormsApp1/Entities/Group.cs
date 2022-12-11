using System.Data;

namespace WindowsFormsApp1.Entities
{
    public class Group
    {
        public Group(IDataRecord reader)
        {
            Id = (int)reader["id"];
            Number = reader["number"] as string;
        }
        
        public Group(string number)
        {
            Number = number;
        }
        
        public int Id { get; set; }
        
        public string Number { get; set; }

        public object[] ToDataRow()
        {
            var array = new object[2];

            array[0] = Id;
            array[1] = Number;

            return array;
        }
    }
}