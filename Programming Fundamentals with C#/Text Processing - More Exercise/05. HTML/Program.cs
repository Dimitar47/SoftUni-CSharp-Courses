using System;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string titleOfArticle = Console.ReadLine();
            string content = Console.ReadLine();
            string command = "";
            Console.WriteLine($"<h1>\n\t{titleOfArticle}\n</h1>");
            Console.WriteLine($"<article>\n\t{content}\n</article>");
            while((command = Console.ReadLine())!= "end of comments")
            {
                Console.WriteLine($"<div>\n\t{command}\n</div>");
            }
        }
    }
}
