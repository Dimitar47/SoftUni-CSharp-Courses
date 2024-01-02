using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = "";
           
            while ((command=Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try { 
            
              
            
                
                    if (command == "Cat")
                    {
                        Cat cat = new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(command);
                        Console.WriteLine(cat);
                   
                    }
                    else if (command == "Dog")
                    {
                        Dog dog = new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(command);
                        Console.WriteLine(dog);
                      
                    }
                    else if (command == "Frog")
                    {

                        Frog frog = new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
                        Console.WriteLine(command);
                        Console.WriteLine(frog);
                       
                    }
                    else if(command == "Kitten")
                    {
                        Kitten kitten = new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
                        Console.WriteLine(command);
                        Console.WriteLine(kitten);
                      
                    }
                    else if(command == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
                        Console.WriteLine(command);
                        Console.WriteLine(tomcat);
                    
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
