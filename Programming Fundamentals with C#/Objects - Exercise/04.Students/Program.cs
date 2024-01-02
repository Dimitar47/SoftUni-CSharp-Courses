using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < countOfStudents; i++)
            {
                string[] commandArray = Console.ReadLine().Split();
                string firstName = commandArray[0];
                string lastName = commandArray[1];
                double grade = double.Parse(commandArray[2]);
                Student student = new Student(firstName,lastName,grade);
                students.Add(student);
            }

            List<Student> sortedStudentList = students.OrderByDescending(num => num.Grade).ToList();
            foreach (Student student in sortedStudentList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }

    class Student
    {

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
       public string FirstName {get;set;}
       public string LastName { get;set; }
       public double Grade { get;set; }
    }
}
