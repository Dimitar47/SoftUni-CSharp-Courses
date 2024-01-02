namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        /*
          private readonly List<TextBook> textBooks = new List<TextBook>();

         public UniversityLibrary()
         {
             this.textBooks = new List<TextBook>();
         }

         public List<TextBook> Catalogue => this.textBooks;

         public string AddTextBookToLibrary(TextBook textBook)
         {
             textBook.InventoryNumber = textBooks.Count + 1;
             this.textBooks.Add(textBook);

             return textBook.ToString();
         }
         */
        [Test]
        public void Test_UniversityLibraryConstructor()
        {
            UniversityLibrary university = new();
            Assert.IsNotNull(university.Catalogue);
            TextBook textBook = new("Spider", "Brook", "Action");
            textBook.InventoryNumber = 122;
            textBook.Holder = "GHold";

            university.Catalogue.Add(textBook);
            Assert.AreEqual(university.Catalogue.Count, 1);
        }
        [Test]
        public void Test_AddTextBookToLibrary()
        {
            UniversityLibrary university = new();
            Assert.IsNotNull(university.Catalogue);
            TextBook textBook = new("Spider", "Brook", "Action");
            textBook.InventoryNumber = 122;
            textBook.Holder = "GHold";
           string res = university.AddTextBookToLibrary(textBook);

            Assert.AreEqual(textBook.InventoryNumber, 1);
            Assert.AreEqual(university.Catalogue.Count, 1);

            string actual = textBook.ToString();
            Assert.AreEqual(res, actual);
        }
        /*
          public string LoanTextBook(int bookInventoryNumber, string studentName)
        {
            TextBook textBook = this.textBooks.FirstOrDefault(t => t.InventoryNumber
        == bookInventoryNumber);

            if (textBook.Holder == studentName)
            {
                return $"{studentName} still hasn't returned {textBook.Title}!";
            }
            else
            {
                textBook.Holder = studentName;

                return $"{textBook.Title} loaned to {studentName}.";
            }

        }


        */
        [Test]
        public void Test_LoanTextBook()
        {
            UniversityLibrary university = new();
            TextBook firstBook = new("Spider", "Brook", "Action");
            firstBook.InventoryNumber = 122;
            firstBook.Holder = "GHold";

            TextBook secondBook = new("Turtle", "Jake", "Action");
            secondBook.InventoryNumber = 12;
            secondBook.Holder = "FHold";

            university.AddTextBookToLibrary(firstBook); // inventoryNumber = 1
            university.AddTextBookToLibrary(secondBook); // inventoryNumber = 2

            string res = university.LoanTextBook(2, "Sth");
            Assert.AreEqual("Sth", secondBook.Holder);
            Assert.AreEqual(res, $"{secondBook.Title} loaned to Sth.");


            res = university.LoanTextBook(2, secondBook.Holder);
            Assert.AreEqual(secondBook.Holder, "Sth");
            Assert.AreEqual(res, $"Sth still hasn't returned {secondBook.Title}!");

            
        }
        /*
          public string ReturnTextBook(int bookInventoryNumber)
        {
            TextBook textBook = this.textBooks.FirstOrDefault
        (t => t.InventoryNumber == bookInventoryNumber);

            textBook.Holder = string.Empty;

            return $"{textBook.Title} is returned to the library.";
        }


        */
        [Test]
        public void Test_ReturnTextBook()
        {
            UniversityLibrary university = new();
            TextBook firstBook = new("Spider", "Brook", "Action");
            firstBook.InventoryNumber = 122;
            firstBook.Holder = "GHold";

            TextBook secondBook = new("Turtle", "Jake", "Action");
            secondBook.InventoryNumber = 12;
            secondBook.Holder = "FHold";

            university.AddTextBookToLibrary(firstBook); // inventoryNumber = 1
            university.AddTextBookToLibrary(secondBook); // inventoryNumber = 2

            string res = university.ReturnTextBook(2); //secondBook
            Assert.AreEqual(secondBook.Holder, string.Empty);
            Assert.AreEqual(res,$"{secondBook.Title} is returned to the library.");
        }
    }
}