using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        private string title;
        private int year;
        private List<string> authors;
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();

        }
        public string Title { get { return title; } set { title = value; } }
        public int Year { get { return year; } set { year = value; } }
        public List<string> Authors { get { return authors; } set { authors = value; } }

        public int CompareTo(Book? other)
        {
            int result = this.Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);

            }
            return result;
        }
        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
