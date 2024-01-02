using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string command = "";
            List<Username> usernames = new List<Username>();
            List<string> names = new List<string>();
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArray = command.Split("=");
                string action = commandArray[0];
               
                if (action == "Add")
                {
                    string usernameTest = commandArray[1];
                    int sent = int.Parse(commandArray[2]);
                    int received = int.Parse(commandArray[3]);
                    int sum = sent + received;
                    Username username = new Username(usernameTest, received, sent,sum);
                    if (!usernames.Contains(username) && !names.Contains(usernameTest))
                    {
                        usernames.Add(username);
                        names.Add(usernameTest);
                    }

                }
                else if (action == "Message")
                {
                    string sender = commandArray[1];
                    string receiver = commandArray[2];

                    if (names.Contains(sender) && names.Contains(receiver))
                    {
                        Username userSender = usernames.Where(x => x.User == sender).First();
                        Username userReceiver = usernames.Where(x => x.User == receiver).First();
                        if (usernames.Contains(userReceiver) && usernames.Contains(userSender))
                        {
                            userReceiver.Sum++;
                            userSender.Sum++;
                            if (userSender.Sum >= capacity)
                            {
                                usernames.Remove(userSender);
                                names.Remove(sender);
                                Console.WriteLine($"{sender} reached the capacity!");
                            }
                            if (userReceiver.Sum >= capacity)
                            {
                                usernames.Remove(userReceiver);
                                names.Remove(receiver);
                                Console.WriteLine($"{receiver} reached the capacity!");
                            }
                        }
                    }
                }
                else if (action == "Empty")
                {
                    string username = commandArray[1];
                    if (username == "All")
                    {
                        usernames.Clear();
                        names.Clear();
                        continue;
                    }
                    if (names.Contains(username))
                    {
                        Username user = usernames.Where(x => x.User == username).First();
                            usernames.Remove(user);
                            names.Remove(username);

                    }

                }
            }
            if (usernames != null)
            {
                Console.WriteLine($"Users count: {usernames.Count}");

                foreach (var user in usernames)
                {
                    Console.WriteLine($"{user.User} - {user.Sum}");
                }

            }
            

        }
        public class Username
        {
            public Username(string username, int received, int sent,int sum)
            {
                this.User = username;
                this.Sent = sent;
                this.Received = received;
                this.Sum = sum;
            }

            public string User { get; set; }
            public int Received { get; set; }
            public int Sent { get; set; }
            public int Sum { get; set; }
        }
    }
}
