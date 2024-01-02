using System;
using System.Collections.Generic;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main()
        {
            int countArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

           

            for (int i = 0; i < countArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                var article = new Article(input[0], input[1], input[2]);

                articles.Add(article);

            }

            string text = Console.ReadLine();


            Console.WriteLine(string.Join(Environment.NewLine, articles));
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}