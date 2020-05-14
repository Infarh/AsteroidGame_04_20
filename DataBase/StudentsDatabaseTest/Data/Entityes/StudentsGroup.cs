using System.Collections.Generic;

namespace StudentsDatabaseTest.Data.Entityes
{
    public class StudentsGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => $"[{Id}]{Name}";
    }
}