using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] peopleProps = Console.ReadLine().Split();
                string name = peopleProps[0];
                int age = int.Parse(peopleProps[1]);
                Person person = new Person(name, age);
                
                family.AddMember(person);
            }
            Console.WriteLine(family.GetOldestMember().Name + " " +  family.GetOldestMember().Age);
        }
    }
    class Family
    {
       public List<Person> people { get; set; } = new List<Person>();
        public void AddMember(Person member)
        {
            people.Add(member);
        }
       public Person GetOldestMember()
        {
            var oldestPerson = people.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldestPerson;
          
          
        }
    }
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
