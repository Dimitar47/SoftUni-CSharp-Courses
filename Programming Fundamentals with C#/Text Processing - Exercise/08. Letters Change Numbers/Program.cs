using System;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                double number = 0;
             
                for (int j = 0; j < input[i].Length; j++)
                {
                    
                
                    char firstLetter = input[i][j];
                    int index = (int) firstLetter %32;
                    string getNumbers = input[i].Substring(1, input[i].Length - 2);
                    if (j == 0)
                    {
                        number = double.Parse(getNumbers);
                    }
                    if (j == 0)
                    {
                        if (char.IsUpper(firstLetter))
                        {

                            number = number / index;
                        }
                        else if (char.IsLower(firstLetter))
                        {
                            number = number * index;
                        }
                    }
                    if (j == input[i].Length - 1)
                    {

                        if (char.IsUpper(firstLetter))
                        {

                            number = number - index;
                        }
                        else if (char.IsLower(firstLetter))
                        {
                            number = number + index;
                        }
                    }
                 
                    
                   
                    j += input[i].Length-2;

                }
               
                totalSum += number;
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}




//// A12b s17G

//string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

//double sum = 0;

//foreach (var item in input)
//{
//    // A12b

//    char firstLetter = item[0]; // 'A'
//    char lastLetter = item[item.Length - 1]; // 'b'

//    double number = double.Parse(item.Substring(1, item.Length - 2)); // 12

//    double result = 0;



//    // check if upper:
//    if (firstLetter >= 65 && firstLetter <= 90)
//    {
//        int firstLetterPositionInTheAlphabet = firstLetter - 64;
//        result = number / firstLetterPositionInTheAlphabet;
//    }
//    else
//    {
//        int firstLetterPositionInTheAlphabet = firstLetter - 96;
//        result = number * firstLetterPositionInTheAlphabet;
//    }

//    if (lastLetter >= 65 && lastLetter <= 90)
//    {
//        int lastLetterPositionInTheAlphabet = lastLetter - 64;
//        sum += result - lastLetterPositionInTheAlphabet;
//    }
//    else
//    {
//        int lastLetterPositionInTheAlphabet = lastLetter - 96;
//        sum += result + lastLetterPositionInTheAlphabet;
//    }

//}
//Console.WriteLine($"{sum:F2}");
        