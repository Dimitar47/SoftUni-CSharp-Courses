namespace _01._Single_Inheritance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Bark();
        }
    }
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("eating...");
        }
    }
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("barking...");
        }
    }
}
