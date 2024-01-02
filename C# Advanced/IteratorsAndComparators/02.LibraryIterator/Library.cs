
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }


        public IEnumerator<Book> GetEnumerator()
        {
            return books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;
            /*  public LibraryIterator(IEnumerable<Book> books)
              {
                  this.Reset();
                  this.books = new List<Book>(books);
              }
            */

            public Book Current => books[currentIndex];
            object IEnumerator.Current => Current;
            public void Dispose() { }
            public bool MoveNext() { currentIndex++; return currentIndex < books.Count; }
            public void Reset() { currentIndex = -1; }
        }
    }
}
