namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        /*

          private Person[] persons;

         private int count;

         public Database(params Person[] persons)
         {
             this.persons = new Person[16];
             AddRange(persons);
         }

         public int Count
         {
             get { return count; }
         }

         */
        [SetUp]
        public void Setup()
        {
            Person[] people = new Person[14];
            for (int i = 0; i < people.Length; i++)
                people[i] = new Person(i, ((char)('A' + i)).ToString());
            database = new Database(people);
        }

        
      
        [Test]
        public void TestConstructorShouldThrowExceptionWhenDataCollectionHasMoreThan16Elements()
        {
            Person[] persons = new Person[17];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new(i,((char) ('A' + i)).ToString());
            }
            Assert.Throws<ArgumentException>(() =>database = new Database(persons));
        }
        [Test]
        public void Add_MethodIncreaseTheCount()
        {
           
            database.Add(new Person(14,"Joe"));
            Assert.AreEqual(database.Count, 15);
        }
      
        [Test]
        public void Add_CannotAddPersonWithExistingName()
        {
            Assert.That(() => database.Add(new Person(100, "A")), Throws.InvalidOperationException);
        }
        [Test]
        public void Add_CannotAddPersonWithExistingId()
        {
            Assert.That(() => database.Add(new Person(1, "Josh")), Throws.InvalidOperationException);
        }
        [Test]
        public void Add_CannotExceedMaximumArrayCount()
        {
            database.Add(new Person(14, "Fourteen"));
            database.Add(new Person(15, "Sixteen"));
            Assert.That(() => database.Add(new Person(16, "Error")), Throws.InvalidOperationException);
        }
        [Test]
        public void Add_AddsPersonToTheCollection()
        {
            Person personToAdd = new Person(18, "Johnkata");
            database.Add(personToAdd);
            
            Assert.AreEqual(personToAdd.Id, 18);
            Assert.AreEqual(personToAdd.UserName, "Johnkata");
            Person expected = database.FindById(18);
            Assert.AreEqual(expected.UserName, personToAdd.UserName);
            Assert.AreEqual(expected.Id, personToAdd.Id);
        }

     
        [Test]
        public void Remove_ShouldThrowExceptionWhenCountIsZero()
        {
            Database db = new Database();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void Remove_ElementFromTheCollection()
        {
            Person[] persons = new Person[13];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new(i, ((char)('A' + i)).ToString());
            }
            database = new Database(persons);
            database.Remove();
            Assert.AreEqual(database.Count, 12);
            
        }
        [Test]
        public void Remove_LastElementFromTheCollection()
        {
            Person person = new Person(23, "Petli");
            database.Add(person);
            database.Remove();
            Assert.That(() => database.FindByUsername("Petli"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_ThrowsExceptionIfUsernameNotPresent()
        {
            Assert.That(() => database.FindByUsername("Misho"), Throws.InvalidOperationException);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_UserCantBeNull(string username)
        {
            Assert.That(() => database.FindByUsername(username), Throws.ArgumentNullException);
        }


        [Test]
        public void FindByUsername_ReturnsTheCorrectPerson()
        {
            Person personToFind = database.FindByUsername("A");
            Assert.AreEqual(personToFind.UserName, "A");
        }

        [Test]
        public void FindById_ReturnsTheCorrectPerson()
        {
            Person personToFind = database.FindById(4);
            Assert.AreEqual(personToFind.Id, 4);
        }

        [Test]
        public void FindById_IdMustBePositiveNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void FindById_ThrowsExceptionIfNonExistingIdIsPassed()
        {
            Assert.That(() => database.FindById(1337), Throws.InvalidOperationException);
        }












    }
}