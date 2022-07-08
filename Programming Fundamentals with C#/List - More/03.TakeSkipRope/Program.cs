using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            
            List<int> numbers = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            List<string> nonNumbersList = new List<string>();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < encryptedMessage.Length; i++)
            {

                if (char.IsDigit(encryptedMessage[i]))
                {

                    numbers.Add(int.Parse(encryptedMessage[i].ToString()));
                }
                else
                {
                    nonNumbersList.Add(encryptedMessage[i].ToString());
                }
            }
           
           
            //Console.WriteLine(string.Join(" ",numbers));
            //Console.WriteLine(string.Join(" ",chars));
           
            for (int i = 0; i < numbers.Count; i++)
            {
                if(i%2==0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            //Console.WriteLine(string.Join(" ",takeList));
            //Console.WriteLine(string.Join(" ",skipList));


            int indexForSkip = 0;
            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(nonNumbersList);
                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();
                result.Append(string.Join("",temp));
                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());



        }
    }
}
