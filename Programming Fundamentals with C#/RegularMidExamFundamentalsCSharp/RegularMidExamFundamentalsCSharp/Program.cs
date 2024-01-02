using System;

namespace RegularMidExamFundamentalsCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBiscuitsAWorker = int.Parse(Console.ReadLine());
            int countOfWorkers = int.Parse(Console.ReadLine());
            ulong competingFactoryNumberOfBiscuitsForMonth = ulong.Parse(Console.ReadLine());
           
            double totalNumberOfBiscuitsForADay = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 != 0)
                {
                    totalNumberOfBiscuitsForADay += numberOfBiscuitsAWorker * countOfWorkers;
                }
                else
                {
                    totalNumberOfBiscuitsForADay += Math.Floor(0.75 * numberOfBiscuitsAWorker * countOfWorkers);
                }
            }

            Console.WriteLine($"You have produced {totalNumberOfBiscuitsForADay} biscuits for the past month.");
            
            if (totalNumberOfBiscuitsForADay > competingFactoryNumberOfBiscuitsForMonth)
            {
                double difference = totalNumberOfBiscuitsForADay - competingFactoryNumberOfBiscuitsForMonth;
                Console.WriteLine($"You produce {difference/competingFactoryNumberOfBiscuitsForMonth*100:F2} percent more biscuits.");
            }
            else
            {
                double difference = competingFactoryNumberOfBiscuitsForMonth - totalNumberOfBiscuitsForADay;
                Console.WriteLine($"You produce {difference/competingFactoryNumberOfBiscuitsForMonth*100:F2} percent less biscuits.");

            }
            
        }
    }
}
