using System;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string result = "";
            for (int i = 0; i < command.Length; i++)
            {
               
                    string testletter = command[i];
                    switch (testletter)
                    {
                        case ".-": result += "A"; break; 
                        case "-...": result += "B"; break;
                        case "-.-.": result += "C"; break;
                        case "-..": result += "D"; break;
                        case ".": result += "E"; break;
                        case "..-.": result += "F"; break;
                        case "--.": result += "G"; break;
                        case "....": result += "H"; break;
                        case "..": result += "I"; break;
                        case ".---": result += "J"; break;
                        case "-.-": result += "K"; break;
                        case ".-..": result += "L"; break;
                        case "--": result += "M"; break;
                        case "-.": result += "N"; break;
                        case "---": result += "O"; break;
                        case ".--.": result += "P"; break;
                        case "--.-": result += "Q"; break;
                        case ".-.": result += "R"; break;
                        case "...": result += "S"; break;
                        case "-": result += "T"; break;
                        case "..-": result += "U"; break;
                        case "...-": result += "V"; break;
                        case ".--": result += "W"; break;
                        case "-..-": result += "X"; break;
                        case "-.--": result += "Y"; break;
                        case "--..": result += "Z"; break;
                        default: result += " "; break;



                    
                }
               
             
                
            }
            Console.WriteLine(result.ToUpper());
        }
    }
}
