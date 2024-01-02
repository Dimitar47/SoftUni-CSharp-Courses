using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            string[] personalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = personalInfo[0];
            int age = int.Parse(personalInfo[1]);
            Person person = new Person(name,age);
            people.Add(person);

        }
        foreach(var  person in people.Where(x=>x.Age>30).OrderBy(x=>x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}