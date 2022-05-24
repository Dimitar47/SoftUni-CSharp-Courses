using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
           
            int trashedHeadset = lostGames / 2;
            int trashedMouse = lostGames / 3;
            int counterKeyboardTrashed = lostGames / (3 * 2);
            double counterDisplayTrashed = counterKeyboardTrashed / 2;
            double expenses = (trashedHeadset * headsetPrice) + (trashedMouse * mousePrice) + (counterKeyboardTrashed*keyboardPrice) + (counterDisplayTrashed * displayPrice);
            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
