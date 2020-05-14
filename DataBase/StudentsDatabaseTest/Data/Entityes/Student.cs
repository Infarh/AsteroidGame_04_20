using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabaseTest.Data.Entityes
{
    public class Student
    {
        //[Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public StudentsGroup Group { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
