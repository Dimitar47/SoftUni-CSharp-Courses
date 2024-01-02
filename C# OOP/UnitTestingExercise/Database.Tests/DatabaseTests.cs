namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database _database;
      
        [Test]
        public void TestConstructor()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
             _database = new Database(data);
     
           
            Assert.AreEqual(16, _database.Count);
        }
        /*
         
         
        public void Add(int element)
        {
            if (this.count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            this.data[this.count] = element;
            this.count++;
        }
         
         */

        [Test]
        public void TestAddMethodShouldThrowExceptionWhenAddingElementWhenArrayCapMoreThan16()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16};
            _database = new Database(data);
            var res = Assert.Throws<InvalidOperationException>(() => _database.Add(2));
            Assert.That(res.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void TestAddMethodShouldAddElementWhenArrayCapLessThan16()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            _database = new Database(data);
            _database.Add(2);
         
            Assert.AreEqual(16, _database.Count);
            
        }
        [Test]
        public void TestRemoveMethodShouldThrowExceptionWhenTheCollectionIsEmpty()
        {
            int[] data = new int[] { };
            _database = new Database(data);
            var res = Assert.Throws<InvalidOperationException>(() => _database.Remove());
            Assert.That(res.Message, Is.EqualTo("The collection is empty!"));

        }
        [Test]
        public void TestRemoveMethodShouldRemoveElement()
        {
            int[] data = new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            _database = new Database(data);
            _database.Remove();
            Assert.AreEqual(15,_database.Count);
        

        }
        [Test]
        public void FetchOperationReturnsElementsAsArray()
        {
            _database = new Database(1, 2, 3, 4, 5, 6, 7, 8);
            int[] expectedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] testArray = _database.Fetch();
            Assert.AreEqual(expectedArray, testArray, "Fetch doesn't return correct elements.");
        }
    }
}
