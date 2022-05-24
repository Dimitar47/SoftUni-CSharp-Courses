using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            string dataType = "";
            while((command = Console.ReadLine()) != "END")
            {
                if (bool.TryParse(command,out bool boolResult))
                {
                    dataType = "boolean";
                }
                else if (int.TryParse(command, out int intResult))
                {
                    dataType = "integer";
                }
                else if (float.TryParse(command,out float doubleResult))
                {
                    dataType = "floating point";
                }
              
                
                else if (char.TryParse(command,out char charResult))
                {
                    dataType = "character";
                }
                else
                {
                    dataType = "string";
                }
                if(command == "")
                {
                    continue;
                }
                Console.WriteLine($"{command} is {dataType} type");
            }
        }
    }
}
