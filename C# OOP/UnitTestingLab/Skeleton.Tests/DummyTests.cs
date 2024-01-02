using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
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
            /*
             

             public void TakeAttack(int attackPoints)
            {
                if (this.IsDead())
                {
                    throw new InvalidOperationException("Dummy is dead.");
                }

                this.health -= attackPoints;
            }
            */
        }
        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {

            axe.Attack(dummy); //the axe attacks the dummy and
                               //the health of the dummy is reduced by the
                               //attack points of the axe

            Assert.AreEqual(0,dummy.Health);
        }
        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(0, 10);
            var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }
        /*
           public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

        */

        [Test]
        public void TestDeadDummyCanGiveExp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(0, 10);
            int exp = dummy.GiveExperience();
            Assert.AreEqual(10, exp);
        }
        [Test]
        public void TestAliveDummyCannotGiveExp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
            var ex = Assert.Throws<InvalidOperationException>
                (() => dummy.GiveExperience());
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}