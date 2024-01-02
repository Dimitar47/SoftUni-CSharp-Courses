using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participantsPoints = new Dictionary<string, int>();
            Dictionary<string, int> languagesSubmissions = new Dictionary<string, int>();
            string command = "";
            while((command= Console.ReadLine())!="exam finished")
            {
                string[] info = command.Split("-", StringSplitOptions.RemoveEmptyEntries);
                
                string username = info[0];
                if (info[1] == "banned")
                {
                    participantsPoints.Remove(username);
                    continue;
                }
                string language = info[1];
                int points = int.Parse(info[2]);

                if(!participantsPoints.ContainsKey(username))
                {
                    participantsPoints.Add(username, 0);
                }
                if (participantsPoints[username] < points)
                {
                    participantsPoints[username] = points;
                }
                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }
                languagesSubmissions[language]++;
            }
            Console.WriteLine("Results:");
            foreach(var participant in participantsPoints.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach(var language in languagesSubmissions.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
