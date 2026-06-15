using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary.Test
{
    public class TextBookTests
    {
        /*
          public TextBook(string title, string author, string category)
        {
            Title = title;
            Author = author;
            Category = category;
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public int InventoryNumber { get; set; }

        public string Category { get; set; }

        public string Holder { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {Title} - {InventoryNumber}");
            sb.AppendLine($"Category: {Category}");
            sb.AppendLine($"Author: {Author}");

            return sb.ToString().TrimEnd();
        }
        */
        [Test]
        public void Test_TextBookConstructor()
        {
            TextBook textBook = new("Spider", "Brook", "Action");
            Assert.IsNotNull(textBook);
            Assert.AreEqual("Spider", textBook.Title);
            Assert.AreEqual("Brook", textBook.Author);
            Assert.AreEqual("Action", textBook.Category);

            textBook.InventoryNumber = 122;
            textBook.Holder = "GHold";

            Assert.AreEqual(122, textBook.InventoryNumber);
            Assert.AreEqual("GHold", textBook.Holder);

            string res = textBook.ToString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber}");
            sb.AppendLine($"Category: {textBook.Category}");
            sb.AppendLine($"Author: {textBook.Author}");
            string actual =  sb.ToString().TrimEnd();

            Assert.AreEqual(res, actual);

        }

    }
}
