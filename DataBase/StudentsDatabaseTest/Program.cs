using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsDatabaseTest.Data;
using StudentsDatabaseTest.Data.Entityes;

namespace StudentsDatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentsDB())
            {
                //db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var students_count = db.Students.Count();

                Console.WriteLine("Students in DB: {0}", students_count);

            }

            using (var db = new StudentsDB())
                if (!db.Groups.Any())
                {
                    var student_n = 1;
                    for (var group_n = 1; group_n <= 10; group_n++)
                    {
                        var group = new StudentsGroup
                        {
                            Name = $"Group {group_n}"
                        };

                        for (var i = 0; i < 10; i++)
                        {
                            var student = new Student
                            {
                                Name = $"Student {student_n}",
                                Surname = $"Surname {student_n}",
                                Patronymic = $"Patronymic {student_n}",
                            };
                            group.Students.Add(student);
                            student_n++;

                            //db.Students.Add(student); // в этом нет необходимости!
                        }

                        db.Groups.Add(group);
                    }

                    db.Database.Log = str => Console.WriteLine("EF>> {0}", str);
                    db.SaveChanges();
                }


            using (var db = new StudentsDB())
            {
                db.Database.Log = str => Console.WriteLine("EF>> {0}", str);

                var students_group_id_7 = db.Students
                   //.Include(student => student.Group)
                   .Where(student => student.Group.Id == 7).ToArray();

                Console.ReadLine();

                Console.WriteLine(students_group_id_7[0].Group.Name);
            }

            Console.ReadLine();
        }
    }
}
