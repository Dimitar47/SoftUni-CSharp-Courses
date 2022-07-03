using System;

namespace _01.Encrypt_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            string[] name = new string[numberOfStrings];
            int[] newArr = new int[numberOfStrings];
            string something = "";

            for (int i = 0; i < numberOfStrings; i++)
            {
                int sum = 0;
                name[i] = Console.ReadLine();
                something = name[i];
            
                for (int j = 0; j < name[i].Length; j++)
                {
                    if(something[j] == 'a' || something[j] == 'e' || something[j] == 'i' || something[j] == 'o' || something[j] == 'u' || something[j] == 'A' || something[j] == 'E' || something[j] == 'I' || something[j] == 'O' || something[j] == 'U')
                    {
                        sum += something[j] * name[i].Length;
                        
                    }

                    else
                    {
                        
                        sum += something[j] / name[i].Length;
                      
                    }  
                    
                }

                newArr[i] = sum;
            }

            Array.Sort(newArr);
            foreach (var item in newArr)
            {
                Console.WriteLine(item);

            }
            
        }
    }
}
