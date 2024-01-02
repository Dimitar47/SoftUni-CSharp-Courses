using System;
using System.Collections.Generic;

namespace _03.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSongs = int.Parse(Console.ReadLine());
            List<Song2> songs = new List<Song2>();
            for (int i = 0; i < numSongs; i++)
            {
                string[] data = Console.ReadLine().Split("_");
                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song2 song = new Song2();
                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }
            string typeList = Console.ReadLine();
            if (typeList == "all")
            {
                foreach (Song2 song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song2 song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
            //int numberOfSongs = int.Parse(Console.ReadLine());
            //Song song = new Song();
            //List<string> list = new List<string>();
            //for (int i = 0; i <= numberOfSongs; i++)
            //{
            //    string command = Console.ReadLine();
            //    string[] commandArray = command.Split("_");
            //    //if (command == commandArray[0] || command == "all")
            //    //{
            //    //    break;
            //    //}
            //    if (i < numberOfSongs)
            //    {
            //        list.Add(command);
                  
            //    }

            //    if (commandArray[0] == command)
            //    {
            //        for (int j = 0; j < numberOfSongs; j++)
            //        {
            //            if (list[j].Contains(commandArray[0]))
            //            {
            //                string[] newSplit = list[j].Split("_");
            //                song.TypeList = newSplit[1];

            //                Console.WriteLine(song.TypeList);
            //            }
            //        }
            //    }

            //    if (command == "all")
            //    {
            //        for (int j = 0; j < numberOfSongs; j++)
            //        {
            //            string[] newSplit = list[j].Split("_");
            //            song.TypeList = newSplit[1];

            //            Console.WriteLine(song.TypeList);
            //        }
            //    }
            //}
        }
    } 
    class Song2
    {
        public string TypeList
        {
            get; set;

        }

        public string Name
        {
            get; set;
        }

        public string Time
        {
            get; set;
        }
    }
}
