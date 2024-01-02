using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Person> persons = new List<Person>();
            while((command = Console.ReadLine()) != "End")
            {
                string[] commandArray = command.Split();
                string name = commandArray[0];
                string id = commandArray[1];
                int age = int.Parse(commandArray[2]);
                Person person = new Person(name, id, age);
                persons.Add(person);
            }
            List<Person> sortedPersons = persons.OrderBy(x=>x.Age).ToList();
            Console.WriteLine(string.Join(Environment.NewLine,sortedPersons));
        }
    }
    class Person
    {
        public Person(string name,string id,int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string ID
        {
            get;set;
        }
        public string Name
        {
            get;set;
        }
        public int Age
        {
            get;set;
        }
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
