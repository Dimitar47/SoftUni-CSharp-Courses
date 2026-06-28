using _04.WildFarm.Animals;

namespace _04.WildFarm
{
    public class AnimalFactory
    {

        public static Animal CreateAnimal(string[] tokens)
        {
            string type = tokens[0];
            string name = tokens[1];
            double weight = double.Parse(tokens[2]);

            Animal animal;
            if (type == "Owl")
            {
                double wingSize = double.Parse(tokens[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(tokens[3]);
                animal = new Hen(name, weight, wingSize);

            }
            else if (type == "Mouse")
            {
                string livingRegion = tokens[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = tokens[3];
                animal = new Dog(name, weight, livingRegion);
            }

            else if (type == "Cat")
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }


            return animal;
        }
    }
}
