    using _04.WildFarm.Foods;

namespace _04.WildFarm
{
    public class FoodFactory
    {
        public static Food CreateFood(string[] foodInfo)
        {
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            Food food = foodType switch
            {
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                "Vegetable" => new Vegetable(quantity),
                
            };

            return food;
        }
    }
}
