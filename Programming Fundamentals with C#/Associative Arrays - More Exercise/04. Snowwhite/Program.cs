using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> dictDwarfNames = new Dictionary<string,int>();
            
        
            
            string command;
            while((command = Console.ReadLine())!= "Once upon a time")
            {
                string[] commandArray = command.Split(" <:> ");
                string dwarfName = commandArray[0];
                string dwarfHatColor = commandArray[1];
                int dwarfHatPhysics = int.Parse(commandArray[2]);
                string ID = dwarfName + ":" + dwarfHatColor;
                if (!dictDwarfNames.ContainsKey(ID))
                {
                    dictDwarfNames.Add(ID, dwarfHatPhysics);

                }
                else
                {
                    dictDwarfNames[ID] = Math.Max(dictDwarfNames[ID], dwarfHatPhysics);
                }
                
            }
            foreach (var dwarf in dictDwarfNames
              .OrderByDescending(x => x.Value)
              .ThenByDescending(
                x => dictDwarfNames.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1])
                                          .Count()))
            {
                Console.WriteLine("({0}) {1} <-> {2}",
                    dwarf.Key.Split(':')[1],
                    dwarf.Key.Split(':')[0],
                    dwarf.Value);
            }


        }
    }
}
