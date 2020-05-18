using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FileHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            //var student = new Student
            //{
            //    Name = "Student name",
            //    Surname = "Student surname",
            //    Birthday = DateTime.Now
            //};

            //var binary_formatter = new BinaryFormatter();
            //var xml_serializer = new XmlSerializer(typeof(Student));

            //using (var bin_file = File.Create("student.bin"))
            //using (var xml_file = File.Create("student.xml"))
            //{
            //    binary_formatter.Serialize(bin_file, student);
            //    xml_serializer.Serialize(xml_file, student);
            //}

            //Student s1, s2;
            //using (var bin_file = File.Open("student.bin", FileMode.Open))
            //using (var xml_file = File.Open("student.xml", FileMode.Open))
            //{
            //    s1 = (Student) binary_formatter.Deserialize(bin_file);
            //    s2 = (Student) xml_serializer.Deserialize(xml_file);
            //}

            //var student = new Student();

            //var student_type = student.GetType();
            //var student_type2 = typeof(Student);

            //var student_name = student_type.GetProperty("Name");

            //student_name.SetValue(student, "Helo World!");
        }
    }

    //[Serializable]
    //public class Student
    //{
    //    public string Name { get; set; }
    //    public string Surname { get; set; }

    //    public DateTime Birthday { get; set; }
    //}
}
