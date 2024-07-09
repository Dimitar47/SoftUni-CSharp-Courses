using MigrationsDemo.Data;
using MigrationsDemo.Models;

namespace MigrationsDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                //// Add a new student
                //context.Students.Add(new Student { Name = "John Doe", Age = 20 });
                //context.Students.Add(new Student { Name = "Jane Simmons", Age = 21 });
                //context.Students.Add(new Student { Name = "Alice Smith", Age = 22 });
                //context.SaveChanges();

                //// Query all students
                //var students = context.Students.ToList();
                //Console.WriteLine("All students in the database:");
                //foreach (var student in students)
                //{
                //    Console.WriteLine($"- {student.Name}, Age: {student.Age}");
                //}
            }
        }
    }
}
