namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private readonly List<Warrior> warriors = new List<Warrior>();
     
        [Test] 
        public void TestArenaConstructor() 
        {
           Assert.IsNotNull(warriors);

        }
        [Test]
        public void TestWarriorIReadOnlyCollection() 
        {
            Arena arena = new Arena();
            CollectionAssert.AreEqual(warriors,arena.Warriors);
        }
        [Test]
        public void TestWarriorEnroll()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("voin", 40, 100);
            arena.Enroll(warrior);
            foreach(var warr in arena.Warriors)
            {
                Assert.AreEqual(warrior,warr);
            }
            Assert.AreEqual(1,arena.Warriors.Count);
          
        }
        [Test]
        public void TestWarriorEnrollThrowsExceptionIfNameIsPresent()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("voin", 40, 100);
            Warrior secondWarrior = new Warrior("voin", 50, 100);
            arena.Enroll(warrior);
            Assert.That(()=>arena.Enroll(secondWarrior), Throws.InvalidOperationException);
            Assert.AreEqual(1, arena.Warriors.Count);
            
        }
        /*
           public void Fight(string attackerName, string defenderName)
        {
            Warrior attacker = this.warriors
                .FirstOrDefault(w => w.Name == attackerName);
            Warrior defender = this.warriors
                .FirstOrDefault(w => w.Name == defenderName);

            if (attacker == null || defender == null)
            {
                string missingName = attackerName;

                if (defender == null)
                {
                    missingName = defenderName;
                }

                throw new InvalidOperationException($"There is no fighter with name {missingName} enrolled for the fights!");
            }

            attacker.Attack(defender);
        }

        */
        [Test]
        public void TestFight()
        {
            var arena = new Arena();
            Warrior warrior = new Warrior("voin", 40, 100);
            Warrior secondWarrior = new Warrior("voin2", 50, 100);
            arena.Enroll(warrior);
            arena.Enroll(secondWarrior);
            Assert.IsNotNull(warrior);
            Assert.IsNotNull(secondWarrior);

        }

    }
}
