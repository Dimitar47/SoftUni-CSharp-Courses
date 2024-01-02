using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(", ").ToList();
            int n = int.Parse(Console.ReadLine());
            Article article = new Article(list[0], list[1], list[2]);
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();


                string[] commandArray = command.Split(": ");
                string commandType = commandArray[0];
                string commandValue = commandArray[1];
                if (commandType == "Edit")
                {

                    article.Edit(commandValue);

                }
                else if (commandType == "ChangeAuthor")
                {
                    article.ChangeAuthor(commandValue);

                }
                else if (commandType == "Rename")
                {
                    article.RenameTitle(commandValue);

                }

            }

            Console.WriteLine(article);

        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAuthor(string author)
        {
            Author = author;
        }

        public void RenameTitle(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}