using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Factory
    {


        public static Animal GetAnimal(string userInput)
        {
            string[] info = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = info[0];
            string name = info[1];
            double weight = double.Parse(info[2]);
            switch(type)
            {
                case "Hen": return new Hen(name, weight, double.Parse(info[3]));
                case "Owl": return new Owl(name, weight, double.Parse(info[3]));
                case "Cat": return new Cat(name, weight, info[3], info[4]);
                case "Tiger": return new Tiger(name, weight, info[3], info[4]);
                case "Dog": return new Dog(name, weight, info[3]);
                case "Mouse": return new Mouse(name, weight, info[3]);
                default: return null;
            }

        }
        public static Food GetFood(string foodInput)
        {
            string[] info = foodInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string foodType = info[0];
            int quantity = int.Parse(info[1]);
            switch (foodType)
            {
                case "Fruit": return new Fruit(quantity);
                case "Meat": return new Meat(quantity);
                case "Seeds": return new Seeds(quantity);
                case "Vegetable": return new Vegetable(quantity);
                default: return null;
            }
        }
    }
}
