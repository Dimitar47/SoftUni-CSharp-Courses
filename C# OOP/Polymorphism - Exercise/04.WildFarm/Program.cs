using _04.WildFarm.Animals;
using _04.WildFarm.Foods;

namespace _04.WildFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string command;

            List<Animal> animals = new List<Animal>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = AnimalFactory.CreateAnimal(animalInfo);
                Food food = FoodFactory.CreateFood(foodInfo);

                animals.Add(animal);
                animal.MakeSound();
                animal.Eat(food);
              
                
                
            }

            foreach(var animal in animals)
            {
                Console.WriteLine(animal);
            }
            




        }
      
    }
}
