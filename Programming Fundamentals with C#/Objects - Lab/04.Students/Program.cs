using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Student> students = new List<Student>();
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split();
                string firstName = commandArray[0];
                string lastName = commandArray[1];
                int age = int.Parse(commandArray[2]);
                string town = commandArray[3];
                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.HomeTown = town;

                students.Add(student);
            }

            string cityName = Console.ReadLine();
          //  List<Student> filteredStudent = students.Where(s => s.HomeTown == cityName).ToList();

            foreach(Student student in students)
            {
                if (student.HomeTown == cityName)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName
        {
            get;set;
        }

        public string LastName
        {
            get;set;
        }

        public int Age
        {
            get;set;
        }

        public string HomeTown 
        {
            get;set;
        }
    }
}
