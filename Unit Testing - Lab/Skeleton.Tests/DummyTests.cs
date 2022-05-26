using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Dummy_Loose_Health_If_Attack()
        {
            Dummy dummy = new Dummy(10,10);

            dummy.TakeAttack(9);

            Assert.That(dummy.Health, Is.EqualTo(1));
        }

        [Test]
        public void Dead_Dummy_Throws_An_Exception_If_Attacked()
        {
            Dummy dummy = new Dummy(0, 10);

            

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(9);
            });
        }

        [Test]
        public void Dead_Dummy_Can_Give_XP()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.That(dummy.GiveExperience, Is.EqualTo(10));
            
        }

        [Test]
        public void Alive_Dummy_Cannnot_Give_XP()
        {
            Dummy dummy = new Dummy(100, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });

        }
    }
}