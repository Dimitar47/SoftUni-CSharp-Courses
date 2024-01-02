using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
           var  contestsDictionary = new Dictionary<string, string>();
            var dictNameStudent = new Dictionary<string, Student>();
            while ((command = Console.ReadLine())!= "end of contests")
            {
                string[] commandArray = command.Split(":");
                string contest = commandArray[0];
                string passwordContest = commandArray[1];
                if (!contestsDictionary.ContainsKey(contest))
                {
                    contestsDictionary.Add(contest, passwordContest);
                }
            }
          
            

            while((command=Console.ReadLine())!= "end of submissions")
            {
                string[] commandArray = command.Split("=>");
                string newContest = commandArray[0];
                string newPassword = commandArray[1];
                string username = commandArray[2];
                int points = int.Parse(commandArray[3]);

               
                
                if(!contestsDictionary.ContainsKey(newContest) || contestsDictionary[newContest] != newPassword)
                {
                    continue;
                }
                if (!dictNameStudent.ContainsKey(username))
                {
                    dictNameStudent.Add(username, new Student(username));
                }
                Student student = dictNameStudent[username];
                if (!student.ContestsWithPoints.ContainsKey(newContest))
                {
                    student.ContestsWithPoints.Add(newContest, points);
                }

                if (student.ContestsWithPoints[newContest] < points)
                {
                    student.ContestsWithPoints[newContest] = points;
                }
            }
            
            PrintTheRanking(dictNameStudent.Values.ToList());

        }

        private static void PrintTheRanking(List<Student> students)
        {
            var bestCandidate = students.OrderByDescending(x => x.ContestsWithPoints.Values.Sum()).First();
            Console.WriteLine($"Best candidate is { bestCandidate.Username } with total { bestCandidate.ContestsWithPoints.Values.Sum()} points.");
            Console.WriteLine("Ranking: ");
            foreach(var student in students.OrderBy(x=>x.Username))
            {
                Console.WriteLine($"{student.Username}");
                foreach(var (contest,points) in student.ContestsWithPoints.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }

        class Student
        {
            public Student(string username)
            {
                this.Username = username;
                ContestsWithPoints = new Dictionary<string, int>();
            }
            public Dictionary<string, int> ContestsWithPoints { get; }
            public string Username { get; }
        }
    }
}
