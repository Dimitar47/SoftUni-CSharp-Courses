namespace _06.FoodShortage
{
    public interface IBuyer
    {
        string Name { get; }
        void BuyFood();
        int Food { get;}
    }
}
