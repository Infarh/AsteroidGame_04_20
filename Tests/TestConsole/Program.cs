using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace TestConsole
{
    class Program
    {
        private const string __NamesFile = "Names.txt";

        static void Main(string[] args)
        {
            //foreach(var student in GetStudents(__NamesFile))
            //    Console.WriteLine(student.Surname + " " + student.Name + " " + student.Patronimyc);

            List<Student> students_list = new List<Student>(100);
            //students_list.Count
            //students_list.Capacity = students_list.Count;

            var id = 1;
            foreach (var student in GetStudents(__NamesFile))
            {
                student.Id = id++;
                students_list.Add(student);
            }

            //var student_2 = students_list[2];
            //students_list.Remove(student_2);
            //students_list.RemoveAt(4);

            //var index = students_list.IndexOf(student_2);

            //students_list.BinarySearch();

            //students_list.Clear();

            // Упорядочивание студентов по возрастанию фамилии
            //students_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s1.Surname, s2.Surname));

            //students_list.Sort((s1, s2) => StringComparer.Ordinal.Compare(s2.Name, s1.Name));

            students_list.Clear();

            students_list.AddRange(GetStudents(__NamesFile));

            Student[] students_array = students_list.ToArray();

            var new_students_list = new List<Student>(students_array);
            var new_students_list2 = new List<Student>(GetStudents(__NamesFile));


            //var list = new ArrayList(new_students_list2);

            //list.Add(42);
            //list.Add("Hello World!");

            ////list.OfType<Student>();
            //list.Cast<Student>();

            //foreach (var student in list.OfType<Student>())
            //{
            //    Console.WriteLine(student);
            //}

            var new_students_list3 = GetStudents(__NamesFile).ToList();
            var new_students_array3 = GetStudents(__NamesFile).ToArray();

            foreach (var student in new_students_list2.ToArray())
            {
                if (student.Surname.StartsWith("А"))
                    new_students_list2.Remove(student);
            }

            if (new_students_list2.Exists(student => student.Surname.StartsWith("А")))
            {
                Console.WriteLine("В списке есть хотя бы один студент, фамилия которого начинается на А");
            }
            else
            {
                Console.WriteLine("Всех на А отчислили...");
            }

            //Stack<Student> students_stack = new Stack<Student>(100);
            //foreach (var student in GetStudents(__NamesFile))
            //{
            //    students_stack.Push(student);
            //}

            //var last_student = students_stack.Pop();

            //while (students_stack.Count > 0)
            //{
            //    Console.WriteLine(students_stack.Pop());
            //}

            //Queue<Student> students_queue = new Queue<Student>(100);
            //while (students_stack.Count > 0)
            //    students_queue.Enqueue(students_stack.Pop());

            //while (students_queue.Count > 0)
            //    Console.WriteLine(students_queue.Dequeue());

            Dictionary<string, List<Student>> surename_students = new Dictionary<string, List<Student>>();

            surename_students.Add("qwe", new List<Student>());

            var dict_data = surename_students.ToArray();

            foreach (var student in GetStudents(__NamesFile))
            {
                var surname = student.Surname;

                if(surename_students.ContainsKey(surname))
                    surename_students[surname].Add(student);
                else
                {
                    var new_list = new List<Student>();
                    new_list.Add(student);
                    surename_students.Add(surname, new_list);
                }
            }

            Console.WriteLine(new string('-', Console.BufferWidth));

            if (surename_students.TryGetValue("Хвостовский", out var students))
                foreach (var student in students)
                    Console.WriteLine(student);

            Console.ReadLine();
        }

        private static IEnumerable<Student> GetStudents(string FileName)
        {
            //yield break;
            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var components = line.Split(' ');
                    if (components.Length != 3) continue;

                    var student = new Student();
                    student.Surname = components[0];
                    student.Name = components[1];
                    student.Patronimyc = components[2];

                    yield return student;
                }
            }
        }
    }
}
