using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter command)
        {
            commandInterpreter = command;
        }



        public void Run()
        {
       
            while (true)
            {
                string input = Console.ReadLine();
                try
                {

                    string result = commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            
        }
    }
}