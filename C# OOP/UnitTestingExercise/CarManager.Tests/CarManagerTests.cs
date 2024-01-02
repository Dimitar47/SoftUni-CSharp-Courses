namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
      
        [Test]
        public void Test_ConstructorWithFields()
        {
            Car car = new Car("Honda", "23", 24, 50);
            Assert.IsNotNull(car);
            Assert.AreEqual(car.Make, "Honda");
            Assert.AreEqual(car.Model, "23");
            Assert.AreEqual(24, car.FuelConsumption);
            Assert.AreEqual(50, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [TestCase("")]
        [TestCase(null)]
        public void Test_CarMakeThrowsExceptionWhenNullOrEmpty(string make)
        {

            Assert.That(() => new Car(make, "40", 30, 50), Throws.ArgumentException);
        }
        [Test]
        public void Test_CarMakeSetsValue()
        {
            Car car = new("Honda", "23", 24, 50);
            Assert.AreEqual("Honda", car.Make);
        }
       
        [TestCase("")]
        [TestCase(null)]
        public void Test_CarModelThrowsExceptionWhenNullOrEmpty(string model)
        {
            Assert.That(() => new Car("Honda", model, 30, 50), Throws.ArgumentException);
        }
        [Test]
        public void Test_CarModelSetsValue()
        {
            Car car = new("Honda", "23", 24, 50);
            Assert.AreEqual("23", car.Model);
        }
      
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-4)]
        public void Test_CarFuelConsumptionThrowsExceptionWhenValueLessOrEqualToZero(double fuelConsumption)
        {
            Assert.That(() => new Car("Honda", "23", fuelConsumption, 50), Throws.ArgumentException);
        }
        [Test]
        public void Test_CarFuelConsumptionSetsValue()
        {
            Car car = new("Honda", "23", 24, 50);
            Assert.AreEqual(24, car.FuelConsumption);
        }
        

        [Test]
        public void PropertyFuelAmount_CantBeNegative()
        {
            Car car = new("Ferrari", "812 GTS", 15.8, 92.0);
            TestDelegate action = () => car.Drive(20);
            Assert.Throws<InvalidOperationException>(action);
        }
        [Test]
        public void Test_CarFuelAmountSetsValue()
        {
            Car car = new("Honda", "23", 24, 50);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-4)]
        public void Test_CarFuelCapacityThrowsExceptionWhenValueLessOrEqualToZero(double fuelCapacity)
        {
            Assert.That(() => new Car("Honda", "23", 24, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void Test_CarFuelCapacitySetsValue()
        {
            Car car = new("Honda", "23", 24, 50);
            Assert.AreEqual(50, car.FuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-4)]
        public void RefuelThrowsExceptionWhenFuelToRefuelIsLessOrEqualToZero(double fuelToRefuel)
        {
            Car car = new("Honda", "23", 24, 50);
            Assert.That(() => car.Refuel(fuelToRefuel), Throws.ArgumentException);
        }
        [Test]
        public void RefuelWhenFuelIsPositiveNumber()
        {
            Car car = new("Honda", "23", 24, 50);
            car.Refuel(23);
            Assert.AreEqual(car.FuelAmount, 23);
        }
        [Test]
        public void FuelAmountBecomesFuelCapacity()
        {
            Car car = new("Honda", "23", 24, 50);
            car.Refuel(63);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }
     
        [Test]
        public void Test_Drive()
        {
            Car car = new("Honda", "23", 24, 50);
            car.Refuel(20);
            car.Drive(20);
            
            Assert.AreEqual(car.FuelAmount, 15.2);
        }

    }
}