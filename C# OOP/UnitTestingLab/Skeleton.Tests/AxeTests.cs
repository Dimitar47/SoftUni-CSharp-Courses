using NUnit.Framework;
using System;

namespace Skeleton.Tests
{


    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void TestInitialize()
        {
            this.axe = new Axe(10, 10); //attack, durability
            this.dummy = new Dummy(10, 10); // health, experience
            
            /*
    public void Attack(Dummy target)
    {
        if (this.durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.durabilityPoints -= 1;
    }

            */
   
        }
        [Test]
        public void WeaponShouldLoseDurabilityAfterAttack()
        {
            axe.Attack(this.dummy);
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
        [Test]
        public void AttackingWithBrokenWeaponThrowsErrorMessage()
        {
            axe = new Axe(20, 0);
            dummy = new Dummy(20, 20);
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}