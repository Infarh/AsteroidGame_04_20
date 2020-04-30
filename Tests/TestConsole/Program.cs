using System;
using System.Globalization;
using TestConsole.Loggers;
using System.Diagnostics;
using System.Runtime.Serialization;
using TestConsole.Service;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var decanat = new Decanat();

            var rnd = new Random();

            for (var i = 1; i <= 100; i++)
                decanat.Add(new Student
                {
                    Name = $"Name {i}",
                    Surname = $"Surname {i}",
                    Patronimyc = $"Patronymic {i}",
                    Ratings = rnd.GetValues(rnd.Next(20, 30), 3, 6)
                });

            foreach (var student in decanat)
            {
                Console.WriteLine(student.Name);
            }

            var student_to_remove = decanat[0];

            decanat.Remove(student_to_remove);


            var random_student = new Student { Name = rnd.GetValue<string>("Иванов", "Петров", "Сидоров") };

            var random_rating = rnd.GetValue<int>(2, 3, 4, 5);

            decanat.SaveToFile("decanat.csv");

            var decanat2 = new Decanat();
            decanat2.LoadFromFile("decanat.csv");

            Console.ReadLine();
        }
    }
}
