using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; private set; }

        public string FavoriteFood { get; private set; }

        public Animal(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;

        }

        public virtual string ExplainSelf()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"I am {Name} and my fovourite food is {FavoriteFood}");

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
