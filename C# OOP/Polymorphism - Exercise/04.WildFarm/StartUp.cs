namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Animal> animals = new List<Animal>();
            while((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal = Factory.GetAnimal(command);
                Console.WriteLine(animal.Sound());
                Food food = Factory.GetFood(Console.ReadLine());
                animal.Eat(food);
                animals.Add(animal);
                
             
            }
            foreach(Animal animal  in animals)
            { 
                Console.WriteLine(animal);
            }
        }
    }
}