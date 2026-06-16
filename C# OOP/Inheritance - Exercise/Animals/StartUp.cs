using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command;
            List<Animal> animals = new List<Animal>();
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string type = command;

                try
                {
                    string[] data = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string gender = data[2];

                    Animal animal = null;

                    switch (type)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;

                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;

                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;

                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;

                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;
                    }

                    animals.Add(animal);
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                }
           

        }
            foreach(var animal in animals)
            {
                Console.WriteLine(animal);
            }






        }
    }
}
